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
                dateButtons[i].Text = $"{date.Day}\n{date:ddd}\n{date:MMM}";
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
                HighlightDate(selectedDate);
                UpdateTripDetails(selectedDate);

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

        public void SetSearchRoundTripReference(ucSearchRoundTrip searchRoundTrip)
        {
            this.searchRoundTrip = searchRoundTrip;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string accommodationType = cmbBoxAccommodationType.SelectedItem.ToString();
            string seatType = Accommodation.AccommodationDictionary[accommodationType].SeatType;
            string vesselName = lblVesselName.Text;

            if (lblFrom == null || lblTo == null || lblVesselName == null || searchRoundTrip == null)
            {
                MessageBox.Show("Required controls are not properly initialized.");
                return;
            }
            if (searchRoundTrip.lblDepartureDate == null || searchRoundTrip.lblToCity == null || searchRoundTrip.lblFromCity == null)
            {
                MessageBox.Show("Search round trip labels are not properly initialized.");
                return;
            }

            var tripDetails = new TripDetails
            {
                FromPortName = lblFrom.Text,
                ToPortName = lblTo.Text,
                VesselName = vesselName,
                Accommodation = accommodationType,
                SeatType = seatType,
                DepartureDate = DateTime.Parse(searchRoundTrip.lblDepartureDate.Text),
                DepartTo = searchRoundTrip.lblToCity.Text,
                DepartFrom = searchRoundTrip.lblFromCity.Text,
                Price = lblTicketPrice.Text
            };

            var returnTripDetails = new ReturnTripDetails
            {
                FromPortName = searchRoundTrip.lblToCity.Text,
                ToPortName = searchRoundTrip.lblFromCity.Text,
                RVesselName = vesselName
            };

            TripSelected?.Invoke(tripDetails);
            ReturnTripSelected?.Invoke(returnTripDetails);
        }
    }
}
