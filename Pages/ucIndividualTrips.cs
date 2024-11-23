using Ferry_Ticketing_App.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucIndividualTrips : UserControl
    {
        private DateTime currentDateStart;
        private List<Button> dateButtons;
        private List<Time> availableTrips;
        private string sourcePort;
        private string destinationPort;
        private List<Ferryline> ferrylines;
        private List<Ports> ports;

        public ucIndividualTrips()
        {
            InitializeComponent();
            dateButtons = new List<Button>
            {
                btnDate1, btnDate2, btnDate3, btnDate4, btnDate5,
                btnDate6, btnDate7, btnDate8, btnDate9, btnDate10
            };

            // Hook up navigation button events
            btnLeft.Click += (s, e) => UpdateDates(-10);
            btnRight.Click += (s, e) => UpdateDates(10);
            PopulateSeatTypes();
        }
        private void PopulateSeatTypes()
        {
            cmbBoxSeatType.Items.Clear();

            foreach (var seat in Seat.SeatDictionary.Keys)
            {
                cmbBoxSeatType.Items.Add(seat);
            }

            if (cmbBoxSeatType.Items.Count > 0)
            {
                cmbBoxSeatType.SelectedIndex = 0;
            }
        }

        private void HighlightDate(DateTime dateToHighlight)
        {
            foreach (var button in dateButtons)
            {
                if (button.Tag is DateTime buttonDate && buttonDate.Date == dateToHighlight.Date)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.BackColor = Color.LightBlue;
                    button.ForeColor = Color.Black;
                }
                else
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }

        internal void InitializeWithRouteAndDate(string from, string to, DateTime startDate, List<Ferryline> ferryLines, List<Ports> portsList)
        {
            sourcePort = from;
            destinationPort = to;
            ferrylines = ferryLines;
            ports = portsList;

            currentDateStart = startDate;
            UpdateDateButtons();
            HighlightDate(startDate);
            UpdateTripDetails(startDate);
        }

        private Dictionary<DateTime, (string VesselName, DateTime DepartureTime, TimeSpan TravelTime)> tripDetailsCache
        = new Dictionary<DateTime, (string VesselName, DateTime DepartureTime, TimeSpan TravelTime)>();

        public void UpdateTripDetails(DateTime selectedDate)
        {
            // Check if the ferry and departure time are already stored for this date
            if (tripDetailsCache.ContainsKey(selectedDate))
            {
                // Use the cached ferry and time
                var cachedDetails = tripDetailsCache[selectedDate];
                UpdateUIWithFerryDetails(cachedDetails.VesselName, cachedDetails.DepartureTime, cachedDetails.TravelTime);
            }
            else
            {
                // Randomly pick a ferry if not already cached
                var availableFerries = Ferryline.AllTrips.ToList();
                var random = new Random();
                var randomFerry = availableFerries[random.Next(availableFerries.Count)];

                // Get the departure and arrival ports
                var departurePort = ports.FirstOrDefault(p => p.PortName == sourcePort);
                var arrivalPort = ports.FirstOrDefault(p => p.PortName == destinationPort);

                if (departurePort != null && arrivalPort != null)
                {
                    // Calculate the distance using GeoUtils
                    double distance = Utilities.GeoUtils.GetDistance(departurePort.Latitude, departurePort.Longitude,
                                                                     arrivalPort.Latitude, arrivalPort.Longitude);

                    // Calculate travel time (assuming ferry speed is 30 km/h)
                    TimeSpan travelTime = Utilities.GeoUtils.CalculateTravelTime(distance, 30);

                    // Generate a random departure hour (between 6:00 AM and 10:00 PM)
                    int randomHour = random.Next(6, 22);
                    DateTime roundedDepartureTime = selectedDate.Date.AddHours(randomHour);

                    // Store the selected ferry and its details
                    tripDetailsCache[selectedDate] = (randomFerry.VesselName, roundedDepartureTime, travelTime);

                    // Update UI with ferry details
                    UpdateUIWithFerryDetails(randomFerry.VesselName, roundedDepartureTime, travelTime);

                    // Now calculate the price based on the distance
                    decimal basePricePerKm = 10m; // Example base price per kilometer in PHP
                    decimal serviceCharge = 50m;  // Example service charge

                    // Update the ticket price label
                    decimal distanceInDecimal = (decimal)distance;
                    Price price = new Price(distanceInDecimal * basePricePerKm, serviceCharge);
                    lblTicketPrice.Text = price.CalculateFinalPrice().ToString("₱0.00"); // Display price in PHP
                }
                else
                {
                    ClearTripDetails();
                }
            }
        }
        private void UpdateUIWithFerryDetails(string vesselName, DateTime departureTime, TimeSpan travelTime)
        {
            foreach (Control ctrl in pnlTimePH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblDTime":
                            label.Text = departureTime.ToString("h:00 tt").ToUpper();
                            break;
                        case "lblTravelTime":
                            label.Text = $"{travelTime.Hours} Hours";
                            break;
                    }
                }
            }

            foreach (Control ctrl in pnlLogoNamePH.Controls)
            {
                if (ctrl is Label label && label.Name == "lblVesselName")
                {
                    label.Text = vesselName;
                    break;
                }
            }
            foreach (Control ctrl in pnlCodeToCode.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFrom":
                            label.Text = sourcePort;
                            AdjustLabelAndArrow(lblFrom, pbArrowRight);
                            break;
                        case "lblTo":
                            label.Text = destinationPort;
                            AdjustLabelAndArrow(lblTo, pbArrowRight, true);
                            break;
                    }
                }
            }
        }

        private void AdjustLabelAndArrow(Label label, PictureBox arrow, bool isDestination = false)
        {
            int padding = 10; // Gap between the label and the arrow
            if (isDestination)
            {
                label.Left = arrow.Right + padding; // Position destination label to the right of the arrow
            }
            else
            {
                label.Left = 10; // Reset 'From' label to its starting position
                arrow.Left = label.Right + padding; // Adjust arrow position
            }
        }

        public void ClearTripDetails()
        {
            foreach (Control ctrl in pnlTimePH.Controls)
            {
                if (ctrl is Label label)
                {
                    if (label.Name == "lblDTime" || label.Name == "lblTravelTime")
                    {
                        label.Text = "--:--";
                    }
                }
            }

            foreach (Control ctrl in pnlLogoNamePH.Controls)
            {
                if (ctrl is Label label && label.Name == "lblVesselName")
                {
                    label.Text = "No vessel available";
                    break;
                }
            }
        }


        private void UpdateDateButtons()
        {
            for (int i = 0; i < dateButtons.Count; i++)
            {
                DateTime date = currentDateStart.AddDays(i);
                dateButtons[i].Text = $"{date.Day}\n{date:ddd}\n{date:MMM}";
                dateButtons[i].Tag = date;

                // Ensure all buttons hook up the click event
                dateButtons[i].Click -= DateButton_Click; // Avoid duplicate event handlers
                dateButtons[i].Click += DateButton_Click;
            }
            HighlightDate(currentDateStart);
        }

        private void UpdateDates(int offset)
        {
            DateTime newDate = currentDateStart.AddDays(offset);

            if (newDate < DateTime.MinValue || newDate > DateTime.MaxValue)
            {
                MessageBox.Show("The selected date range is invalid. Please adjust your navigation.", "Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentDateStart = newDate;
            UpdateDateButtons();
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            if (sender is Button selectedButton && selectedButton.Tag is DateTime selectedDate)
            {
                HighlightDate(selectedDate);
                UpdateTripDetails(selectedDate);
            }
        }
        public void RecalculateTripDetails(DateTime selectedDate)
        {
            // Ensure source and destination ports are set
            if (string.IsNullOrEmpty(sourcePort) || string.IsNullOrEmpty(destinationPort))
                return;

            var departurePort = ports.FirstOrDefault(p => p.PortName == sourcePort);
            var arrivalPort = ports.FirstOrDefault(p => p.PortName == destinationPort);

            if (departurePort != null && arrivalPort != null)
            {
                // Calculate distance using GeoUtils
                double distance = Utilities.GeoUtils.GetDistance(
                    departurePort.Latitude, departurePort.Longitude,
                    arrivalPort.Latitude, arrivalPort.Longitude
                );

                // Calculate travel time (assuming ferry speed is 30 km/h)
                TimeSpan travelTime = Utilities.GeoUtils.CalculateTravelTime(distance, 30);

                // Generate a random departure time
                DateTime departureTime = Utilities.GeoUtils.GetRandomDepartureTime();

                // Update UI with ferry details
                UpdateUIWithFerryDetails("Ferry Name", departureTime, travelTime); // Replace with actual ferry name

                // Calculate price based on distance
                decimal basePricePerKm = 10m; // Example: ₱10 per km
                decimal serviceCharge = 50m;  // Example: ₱50 service charge
                Price price = new Price((decimal)distance * basePricePerKm, serviceCharge);

                // Update price label
                lblTicketPrice.Text = price.CalculateFinalPrice().ToString("₱0.00");
            }
            else
            {
                ClearTripDetails();
            }
        }

    }
}
