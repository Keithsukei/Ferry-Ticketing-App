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
        public event Action<TripDetails> TripSelected;
        public event Action<ReturnTripDetails> ReturnTripSelected;
        private ucSearchRoundTrip searchRoundTrip;
        private ucSearchOneWayTrip searchOneWayTrip;
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
            
            // Add event handler for accommodation type changes
            cmbBoxAccommodationType.SelectedIndexChanged += CmbBoxAccommodationType_SelectedIndexChanged;
        }
        private void PopulateSeatTypes()
        {
            cmbBoxAccommodationType.Items.Clear();

            foreach (var seat in Accommodation.AccommodationDictionary.Keys)
            {
                cmbBoxAccommodationType.Items.Add(seat);
            }

            if (cmbBoxAccommodationType.Items.Count > 0)
            {
                cmbBoxAccommodationType.SelectedIndex = 0;
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
                var cachedDetails = tripDetailsCache[selectedDate];
                UpdateUIWithFerryDetails(cachedDetails.VesselName, cachedDetails.DepartureTime, cachedDetails.TravelTime);
                return;
            }
            // Ensure available ferries exist
            var availableFerries = Ferryline.AllTrips?.ToList();
            if (availableFerries == null || !availableFerries.Any())
            {
                MessageBox.Show("No available ferries found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTripDetails();
                return;
            }
            // Randomly pick a ferry
            var random = new Random();
            var randomFerry = availableFerries[random.Next(availableFerries.Count)];
            if (randomFerry == null)
            {
                MessageBox.Show("Failed to select a ferry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTripDetails();
                return;
            }
            var departurePort = ports.FirstOrDefault(p => p.PortName == sourcePort);
            var arrivalPort = ports.FirstOrDefault(p => p.PortName == destinationPort);
            if (departurePort != null && arrivalPort != null)
            {
                double distance = Utilities.GeoUtils.GetDistance(
                    departurePort.Latitude, departurePort.Longitude,
                    arrivalPort.Latitude, arrivalPort.Longitude
                );
                TimeSpan travelTime = Utilities.GeoUtils.CalculateTravelTime(distance, 30);
                int randomHour = random.Next(6, 22);
                DateTime roundedDepartureTime = selectedDate.Date.AddHours(randomHour);
                tripDetailsCache[selectedDate] = (randomFerry.VesselName, roundedDepartureTime, travelTime);
                // Update the UI
                UpdateUIWithFerryDetails(randomFerry.VesselName, roundedDepartureTime, travelTime);
                decimal basePricePerKm = 10m;
                decimal serviceCharge = 50m;
                decimal distanceInDecimal = (decimal)distance;

                // Get accommodation price
                string selectedAccommodationType = cmbBoxAccommodationType.SelectedItem?.ToString();
                decimal accommodationPrice = Accommodation.AccommodationDictionary[selectedAccommodationType].BasePrice; ;

                Price price = new Price(distanceInDecimal * basePricePerKm + accommodationPrice, serviceCharge);
                lblTicketPrice.Text = price.CalculateFinalPrice().ToString("₱0.00");
            }
            else
            {
                ClearTripDetails();
                MessageBox.Show("Unable to find route details or available ferries.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                dateButtons[i].Text = $"{date:dd}\n{date:ddd, MMM}";
                dateButtons[i].Tag = date;

                dateButtons[i].Click -= DateButton_Click;
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
                if (selectedDate.Date < DateTime.Today)
                {
                    MessageBox.Show("You cannot select a past date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HighlightDate(selectedDate);
                UpdateTripDetails(selectedDate);

                // Check if we're in a one-way trip context
                if (searchOneWayTrip != null)
                {
                    searchOneWayTrip.lblDepartureDate.Text = selectedDate.ToString("yyyy-MM-dd");
                }
                // Check if we're in a round trip context
                else if (searchRoundTrip != null)
                {
                    if (this.Name == "ucIndividualTrips1")
                    {
                        searchRoundTrip.lblDepartureDate.Text = selectedDate.ToString("yyyy-MM-dd");
                    }
                    else if (this.Name == "ucIndividualTrips2")
                    {
                        searchRoundTrip.lblReturnDate.Text = selectedDate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        public void RecalculateTripDetails(DateTime selectedDate)
        {
            if (string.IsNullOrEmpty(sourcePort) || string.IsNullOrEmpty(destinationPort))
                return;
            if (tripDetailsCache.ContainsKey(selectedDate))
            {
                var cachedDetails = tripDetailsCache[selectedDate];
                UpdateUIWithFerryDetails(cachedDetails.VesselName, cachedDetails.DepartureTime, cachedDetails.TravelTime);
                return;
            }
            var availableFerries = Ferryline.AllTrips?.ToList();
            if (availableFerries == null || !availableFerries.Any())
            {
                MessageBox.Show("No available ferries found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTripDetails();
                return;
            }
            var departurePort = ports.FirstOrDefault(p => p.PortName == sourcePort);
            var arrivalPort = ports.FirstOrDefault(p => p.PortName == destinationPort);
            if (departurePort != null && arrivalPort != null)
            {
                double distance = Utilities.GeoUtils.GetDistance(
                    departurePort.Latitude, departurePort.Longitude,
                    arrivalPort.Latitude, arrivalPort.Longitude
                );
                TimeSpan travelTime = Utilities.GeoUtils.CalculateTravelTime(distance, 30);
                var random = new Random();
                var randomFerry = availableFerries[random.Next(availableFerries.Count)];
                if (randomFerry == null)
                {
                    MessageBox.Show("Failed to select a ferry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearTripDetails();
                    return;
                }
                int randomHour = random.Next(6, 22);
                DateTime departureTime = selectedDate.Date.AddHours(randomHour);
                tripDetailsCache[selectedDate] = (randomFerry.VesselName, departureTime, travelTime);
                UpdateUIWithFerryDetails(randomFerry.VesselName, departureTime, travelTime);
                decimal basePricePerKm = 10m;
                decimal serviceCharge = 25m;
                decimal distanceInDecimal = (decimal)distance;

                // Get accommodation price
                string selectedAccommodationType = cmbBoxAccommodationType.SelectedItem?.ToString();
                decimal accommodationPrice = 0m;
                if (!string.IsNullOrEmpty(selectedAccommodationType) &&
                    Accommodation.AccommodationDictionary.ContainsKey(selectedAccommodationType))
                {
                    accommodationPrice = Accommodation.AccommodationDictionary[selectedAccommodationType].BasePrice;
                }

                Price price = new Price(distanceInDecimal * basePricePerKm, serviceCharge);
                lblTicketPrice.Text = price.CalculateFinalPrice().ToString("₱0.00") + accommodationPrice;
            }
            else
            {
                ClearTripDetails();
                MessageBox.Show("Unable to find route details or available ferries.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public class TripDetails
        {
            public string FromPortName { get; set; }
            public string ToPortName { get; set; }
            public string VesselName { get; set; }
            public string Accommodation { get; set; }
            public string SeatType { get; set; }
            public DateTime DepartureDate { get; set; }
            public string DepartTo { get; set; }
            public string DepartFrom { get; set; }
            public string Price { get; set; }
        }

        public class ReturnTripDetails
        {
            public string FromPortName { get; set; }
            public string ToPortName { get; set; }
            public string RVesselName { get; set; }
        }

        public void SetSearchOneWayTripReference(ucSearchOneWayTrip searchOneWayTrip)
        {
            this.searchOneWayTrip = searchOneWayTrip;
        }

        public void SetSearchRoundTripReference(ucSearchRoundTrip searchRoundTrip)
        {
            this.searchRoundTrip = searchRoundTrip;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbBoxAccommodationType.SelectedItem == null || lblVesselName == null || 
                lblFrom == null || lblTo == null || string.IsNullOrEmpty(lblTicketPrice?.Text))
            {
                MessageBox.Show("Required controls are not properly initialized.");
                return;
            }

            string accommodationType = cmbBoxAccommodationType.SelectedItem.ToString();
            string seatType = Accommodation.AccommodationDictionary[accommodationType].SeatType;
            string vesselName = lblVesselName.Text;


            var selectedDate = dateButtons.FirstOrDefault(b => b.BackColor == Color.LightBlue)?.Tag as DateTime?;
            if (!selectedDate.HasValue)
            {
                MessageBox.Show("Please select a departure date.");
                return;
            }

            if (searchOneWayTrip != null) // One-way trip
            {
                var tripDetails = new TripDetails
                {
                    FromPortName = searchOneWayTrip.lblFromCity.Text,
                    ToPortName = searchOneWayTrip.lblToCity.Text,
                    VesselName = vesselName,
                    Accommodation = accommodationType,
                    SeatType = seatType,
                    DepartureDate = selectedDate.Value,
                    DepartTo = destinationPort,
                    DepartFrom = sourcePort,
                    Price = lblTicketPrice.Text
                };
                TripSelected?.Invoke(tripDetails);
            }
            else if (searchRoundTrip != null) // Round trip
            {
                if (this.Name == "ucIndividualTrips1") // Departure trip
                {
                    var tripDetails = new TripDetails
                    {
                        FromPortName = searchRoundTrip.lblFromCity.Text,
                        ToPortName = searchRoundTrip.lblToCity.Text,
                        VesselName = vesselName,
                        Accommodation = accommodationType,
                        SeatType = seatType,
                        DepartureDate = selectedDate.Value,
                        DepartTo = destinationPort,
                        DepartFrom = sourcePort,
                        Price = lblTicketPrice.Text
                    };
                    TripSelected?.Invoke(tripDetails);
                }
                else if (this.Name == "ucIndividualTrips2") // Return trip
                {
                    var returnTripDetails = new ReturnTripDetails
                    {
                        FromPortName = searchRoundTrip.lblFromCity.Text,
                        ToPortName = searchRoundTrip.lblToCity.Text,
                        RVesselName = vesselName
                    };
                    ReturnTripSelected?.Invoke(returnTripDetails);
                }
            }
        }

        private void CmbBoxAccommodationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected date from any highlighted button
            DateTime? selectedDate = dateButtons.FirstOrDefault(b => b.BackColor == Color.LightBlue)?.Tag as DateTime?;
            
            if (selectedDate.HasValue)
            {
                var departurePort = ports.FirstOrDefault(p => p.PortName == sourcePort);
                var arrivalPort = ports.FirstOrDefault(p => p.PortName == destinationPort);

                if (departurePort != null && arrivalPort != null)
                {
                    double distance = Utilities.GeoUtils.GetDistance(
                        departurePort.Latitude, departurePort.Longitude,
                        arrivalPort.Latitude, arrivalPort.Longitude
                    );

                    decimal basePricePerKm = 10m;
                    decimal serviceCharge = 50m;
                    decimal distanceInDecimal = (decimal)distance;

                    // Get accommodation price
                    string selectedAccommodationType = cmbBoxAccommodationType.SelectedItem?.ToString();
                    decimal accommodationPrice = 0m;
                    if (!string.IsNullOrEmpty(selectedAccommodationType) &&
                        Accommodation.AccommodationDictionary.ContainsKey(selectedAccommodationType))
                    {
                        accommodationPrice = Accommodation.AccommodationDictionary[selectedAccommodationType].BasePrice;
                    }

                    // Calculate final price including distance-based fare, accommodation price, and service charge
                    Price price = new Price(distanceInDecimal * basePricePerKm + accommodationPrice, serviceCharge);
                    lblTicketPrice.Text = price.CalculateFinalPrice().ToString("₱0.00");
                }
            }
        }
    }
}
