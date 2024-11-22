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

            suggestionBoxFrom.Click += (s, e) => SelectSuggestion(txtFrom, suggestionBoxFrom);
            suggestionBoxTo.Click += (s, e) => SelectSuggestion(txtTo, suggestionBoxTo);
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

            if (suggestionBox.Items.Count > 0)
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
            DateTime selectedDate = dtpDepart.Value;
            var searchRoundControl = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            if (searchRoundControl != null)
            {
                string fromPort = txtFrom.Text.Trim();
                string toPort = txtTo.Text.Trim();
                DateTime departDate = dtpDepart.Value;
                DateTime returnDate = dtpReturn.Value;
                int passengers;
                var individualTrips = searchRoundControl.Controls.OfType<ucIndividualTrips>().FirstOrDefault();

                if (searchRoundControl.ucIndividualTrips1 != null)
                {
                    // Pass the departure date to ucIndividualTrips1
                    searchRoundControl.ucIndividualTrips1.InitializeWithDate(departDate);

                    // Debug: Confirm the date is passed correctly
                    Console.WriteLine($"Departure Date Passed to IndividualTrips1: {departDate.ToShortDateString()}");
                }
                else
                {
                    MessageBox.Show("ucIndividualTrips1 control is not initialized in ucSearchRoundTrip.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!int.TryParse(txtPassengers.Text, out passengers) || passengers <= 0)
                {
                    MessageBox.Show("Please enter a valid number of passengers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fromPortData = portsList.FirstOrDefault(p =>
                    p.PortName.Equals(fromPort, StringComparison.OrdinalIgnoreCase) ||
                    p.City.Equals(fromPort, StringComparison.OrdinalIgnoreCase));
                var toPortData = portsList.FirstOrDefault(p =>
                    p.PortName.Equals(toPort, StringComparison.OrdinalIgnoreCase) ||
                    p.City.Equals(toPort, StringComparison.OrdinalIgnoreCase));

                if (fromPortData == null || toPortData == null)
                {
                    MessageBox.Show("Invalid ports selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                searchRoundControl.UpdateItinerary(
                    fromPortData.Code,
                    fromPortData.City,
                    toPortData.Code,
                    toPortData.City,
                    passengers,
                    departDate,
                    returnDate
                );

                searchRoundControl.Visible = true;
                searchRoundControl.BringToFront();

                // Pass the selected departure date to the slider
                searchRoundControl.LoadInitialDates(departDate);
            }
            else
            {
                MessageBox.Show("Could not find the ucSearchRound control.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
