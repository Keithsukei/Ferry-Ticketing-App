using Ferry_Ticketing_App.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.Utilities;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucFindTrips : UserControl
    {
        private List<Ports> portsList;
        private ListBox suggestionBoxFrom;
        private ListBox suggestionBoxTo;


        public ucFindTrips()
        {
            InitializeComponent();
            portsList = Ports.Port;
            suggestionBoxFrom = new ListBox
            {
                Visible = false,
                Font = new Font("SF Pro Display", 20F, FontStyle.Regular),
                Location = new Point(115, 166)
            };
            suggestionBoxTo = new ListBox
            {
                Visible = false,
                Font = new Font("SF Pro Display", 20F, FontStyle.Regular),
                Location = new Point(571, 166)
            };

            this.Controls.Add(suggestionBoxFrom);
            this.Controls.Add(suggestionBoxTo);

            txtFrom.KeyUp += (s, e) => UpdateSuggestions(txtFrom, suggestionBoxFrom, portsList);
            txtTo.Enter += (s, e) => UpdateSuggestions(txtTo, suggestionBoxTo, portsList, isToField: true);
            txtTo.KeyUp += (s, e) => UpdateSuggestions(txtTo, suggestionBoxTo, portsList, isToField: true);
            txtTo.GotFocus += (s, e) => UpdateSuggestions(txtTo, suggestionBoxTo, portsList, isToField: true);

            // Add leave focus events to hide suggestion boxes
            txtFrom.LostFocus += (s, e) => {
                // Add delay to allow click event to fire first
                Timer timer = new Timer();
                timer.Interval = 100;
                timer.Tick += (sender, args) => {
                    HideSuggestionBox(suggestionBoxFrom);
                    timer.Stop();
                };
                timer.Start();
            };
            
            txtTo.LostFocus += (s, e) => {
                Timer timer = new Timer();
                timer.Interval = 100;
                timer.Tick += (sender, args) => {
                    HideSuggestionBox(suggestionBoxTo);
                    timer.Stop();
                };
                timer.Start();
            };

            // Add click event handler for the form to hide suggestion boxes
            this.Click += (s, e) => {
                HideSuggestionBox(suggestionBoxFrom);
                HideSuggestionBox(suggestionBoxTo);
            };

            // Add scroll event handler for both the control and its parent
            this.Scroll += (s, e) => {
                HideSuggestionBox(suggestionBoxFrom);
                HideSuggestionBox(suggestionBoxTo);
            };

            // Handle parent control scrolling
            this.ParentChanged += (s, e) => {
                if (this.Parent is ScrollableControl scrollable)
                {
                    scrollable.Scroll += (sender, args) => {
                        HideSuggestionBox(suggestionBoxFrom);
                        HideSuggestionBox(suggestionBoxTo);
                    };
                }
            };

            suggestionBoxFrom.Click += (s, e) => SelectSuggestion(txtFrom, suggestionBoxFrom);
            suggestionBoxTo.Click += (s, e) => SelectSuggestion(txtTo, suggestionBoxTo);

            // Set default dates
            dtpDepart.Value = DateTime.Today;
            dtpReturn.Value = DateTime.Today.AddDays(1);
            dtpDepart.MinDate = DateTime.Today;
            dtpReturn.MinDate = DateTime.Today.AddDays(1);
            dtpDepart.MaxDate = new DateTime(2030, 12, 31);
            dtpReturn.MaxDate = new DateTime(2030, 12, 31);

            // Add date change handler
            dtpDepart.ValueChanged += DtpDepart_ValueChanged;
        }

        private void HideSuggestionBox(ListBox suggestionBox)
        {
            if (suggestionBox != null && !suggestionBox.IsDisposed)
            {
                suggestionBox.Visible = false;
            }
        }

        private void rbRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRoundTrip.Checked)
            {
                pbtxtReturn.Visible = true;
                dtpReturn.Visible = true;
            }
        }
        private void rbOneWay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOneWay.Checked)
            {
                pbtxtReturn.Visible = false;
                dtpReturn.Visible = false;
            }
        }
        private void UpdateSuggestions(TextBox textBox, ListBox suggestionBox, List<Ports> portsList, bool isToField = false)
        {
            string input = textBox.Text.Trim();
            List<string> closestMatches;

            if (isToField)
            {
                var fromPortInput = txtFrom.Text.Trim();
                var fromPort = portsList.FirstOrDefault(port =>
                    port.PortName.Equals(fromPortInput, StringComparison.OrdinalIgnoreCase) ||
                    port.City.Equals(fromPortInput, StringComparison.OrdinalIgnoreCase) ||
                    port.Code.Equals(fromPortInput, StringComparison.OrdinalIgnoreCase));

                if (fromPort == null || string.IsNullOrEmpty(fromPortInput))
                {
                    // Clear and hide txtTo suggestions if txtFrom is invalid or empty
                    suggestionBox.Items.Clear();
                    suggestionBox.Visible = false;
                    return;
                }

                closestMatches = fromPort.Connections
                    .Select(conn => portsList.FirstOrDefault(p => p.PortName.Equals(conn.Item1))?.City)
                    .Where(city => !string.IsNullOrEmpty(city))
                    .Distinct()
                    .Where(city => city.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(city => city)
                    .ToList();
            }
            else
            {
                // Show all Ports
                closestMatches = portsList
                    .Where(port => port.PortName.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   port.Code.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   port.City.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(port => StringUtils.LevenshteinDistance(input, port.City))
                    .Select(port => port.City)
                    .Distinct()
                    .Take(5) // Limit to 5 suggestions
                    .ToList();
            }

            suggestionBox.Items.Clear();
            suggestionBox.Items.AddRange(closestMatches.ToArray());

            if (suggestionBox.Items.Count > 0 && textBox.Focused)
            {
                var textBoxPosition = textBox.PointToScreen(Point.Empty);
                var userControlPosition = this.PointToScreen(Point.Empty);

                int offsetX = textBoxPosition.X - userControlPosition.X;
                int offsetY = textBoxPosition.Y - userControlPosition.Y + textBox.Height + 2;

                suggestionBox.Location = new Point(offsetX, offsetY);
                suggestionBox.Width = textBox.Width;
                suggestionBox.Height = suggestionBox.PreferredHeight;

                suggestionBox.Visible = true;
                suggestionBox.BringToFront();
            }
            else
            {
                suggestionBox.Visible = false;
            }
        }


        private void SelectSuggestion(TextBox textBox, ListBox suggestionBox)
        {
            if (suggestionBox.SelectedItem != null)
            {
                textBox.Text = suggestionBox.SelectedItem.ToString();
                suggestionBox.Visible = false;
            }
        }

        private void btnSearchTrips_Click(object sender, EventArgs e)
        {
            string sourcePort = txtFrom.Text.Trim();
            string destinationPort = txtTo.Text.Trim();
            DateTime departDate = dtpDepart.Value;
            DateTime returnDate = dtpReturn.Value;

            // Get references to both search controls
            var searchRoundControl = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var searchOneWayControl = this.Parent.Controls.OfType<ucSearchOneWayTrip>().FirstOrDefault();

            // Common validation
            string fromCity = txtFrom.Text;
            string toCity = txtTo.Text;

            var fromPort = portsList.FirstOrDefault(p => p.City == fromCity)?.PortName;
            var toPort = portsList.FirstOrDefault(p => p.City == toCity)?.PortName;

            if (fromPort == null || toPort == null)
            {
                MessageBox.Show("Invalid port selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate passenger input
            if (!int.TryParse(txtPassengers.Text, out int passengers) || passengers <= 0 || passengers > 5)
            {
                MessageBox.Show("Please enter a valid number of passengers (1-5).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbOneWay.Checked)
            {
                if (searchOneWayControl != null)
                {
                    // Initialize one-way trip
                    searchOneWayControl.ucIndividualTrips1.InitializeWithRouteAndDate(
                        fromPort, toPort, departDate, Ferryline.AllTrips, portsList);

                    // Recalculate price and update trip details
                    searchOneWayControl.ucIndividualTrips1.RecalculateTripDetails(departDate);

                    // Update the itinerary labels
                    string fromCode = portsList.FirstOrDefault(p => p.City == fromCity)?.Code ?? "";
                    string toCode = portsList.FirstOrDefault(p => p.City == toCity)?.Code ?? "";

                    searchOneWayControl.UpdateItinerary(fromCode, fromCity, toCode, toCity,
                        passengers, departDate);

                    searchOneWayControl.Visible = true;
                    searchOneWayControl.BringToFront();
                    searchRoundControl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Could not find the ucSearchOneWay control.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbRoundTrip.Checked)
            {
                if (searchRoundControl != null)
                {
                    // Initialize round trip (departure)
                    searchRoundControl.ucIndividualTrips1.InitializeWithRouteAndDate(
                        fromPort, toPort, departDate, Ferryline.AllTrips, portsList);

                    searchRoundControl.ucIndividualTrips1.RecalculateTripDetails(departDate);

                    // Initialize round trip (return)
                    searchRoundControl.ucIndividualTrips2.InitializeWithRouteAndDate(
                        toPort, fromPort, returnDate, Ferryline.AllTrips, portsList);

                    searchRoundControl.ucIndividualTrips2.RecalculateTripDetails(returnDate);

                    // Update the itinerary labels
                    string fromCode = portsList.FirstOrDefault(p => p.City == fromCity)?.Code ?? "";
                    string toCode = portsList.FirstOrDefault(p => p.City == toCity)?.Code ?? "";

                    searchRoundControl.UpdateItinerary(fromCode, fromCity, toCode, toCity,
                        passengers, departDate, returnDate);

                    searchRoundControl.Visible = true;
                    searchRoundControl.BringToFront();
                    searchOneWayControl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Could not find the ucSearchRound control.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DtpDepart_ValueChanged(object sender, EventArgs e)
        {
            // Set return date to day after departure
            dtpReturn.MinDate = dtpDepart.Value.AddDays(1);
            dtpReturn.Value = dtpDepart.Value.AddDays(1);
        }
    }
}
