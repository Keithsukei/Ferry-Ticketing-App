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
            txtTo.KeyUp += (s, e) => UpdateSuggestions(txtTo, suggestionBoxTo, portsList);

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
        private void UpdateSuggestions(TextBox textBox, ListBox suggestionBox, List<Ports> portsList)
        {
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                suggestionBox.Visible = false;
                return;
            }

            // Get closest matches based on the port name, code, or city
            var closestMatches = portsList
                .Where(port => port.PortName.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               port.Code.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               port.City.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(port => StringUtils.LevenshteinDistance(input, port.PortName))
                .Take(5)
                .Select(port => $"{port.City}, {port.PortName}, {port.Code}")
                .ToList();

            suggestionBox.Items.Clear(); // Clear previous suggestions
            suggestionBox.Items.AddRange(closestMatches.ToArray()); // Add new suggestions

            if (suggestionBox.Items.Count > 0)
            {
                var textBoxPosition = textBox.PointToScreen(Point.Empty);
                var userControlPosition = this.PointToScreen(Point.Empty);

                int offsetX = textBoxPosition.X - userControlPosition.X;
                int offsetY = textBoxPosition.Y - userControlPosition.Y + textBox.Height + 2;

                suggestionBox.Location = new Point(offsetX, offsetY);
                suggestionBox.Width = textBox.Width;
                suggestionBox.Height = suggestionBox.PreferredHeight;

                suggestionBox.Visible = true; // Show suggestion box
                suggestionBox.BringToFront();
            }
            else
            {
                suggestionBox.Visible = false; // Hide suggestion box if no matches
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
            // Retrieve and trim inputs
            string fromPort = txtFrom.Text.Trim();
            string toPort = txtTo.Text.Trim();
            DateTime departDate = dtpDepart.Value;
            DateTime returnDate = dtpReturn.Value;
            int passengers;

            // Validate passengers input
            if (!int.TryParse(txtPassengers.Text, out passengers) || passengers <= 0)
            {
                MessageBox.Show("Please enter a valid number of passengers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate ports input
            if (string.IsNullOrWhiteSpace(fromPort) || string.IsNullOrWhiteSpace(toPort))
            {
                MessageBox.Show("Please enter both 'From' and 'To' locations.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find the "From" port by matching PortName, City, or Code
            var fromPortData = Ports.Port.FirstOrDefault(p =>
                p.PortName.Equals(fromPort, StringComparison.OrdinalIgnoreCase) ||
                p.City.Equals(fromPort, StringComparison.OrdinalIgnoreCase) ||
                p.Code.Equals(fromPort, StringComparison.OrdinalIgnoreCase)
            );

            if (fromPortData == null)
            {
                MessageBox.Show($"Port '{fromPort}' not found. Please check your input.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find the "To" port by matching PortName, City, or Code
            var toPortData = Ports.Port.FirstOrDefault(p =>
                p.PortName.Equals(toPort, StringComparison.OrdinalIgnoreCase) ||
                p.City.Equals(toPort, StringComparison.OrdinalIgnoreCase) ||
                p.Code.Equals(toPort, StringComparison.OrdinalIgnoreCase)
            );

            if (toPortData == null)
            {
                MessageBox.Show($"Port '{toPort}' not found. Please check your input.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if "To" port has a valid connection from the "From" port
            var toConnection = fromPortData.Connections.FirstOrDefault(c =>
                c.Destination.Equals(toPortData.PortName, StringComparison.OrdinalIgnoreCase)
            );

            if (toConnection == null)
            {
                MessageBox.Show($"No direct connection from '{fromPort}' to '{toPort}'. Please select a valid route.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if round trip is selected
            bool isRoundTrip = rbRoundTrip.Checked;

            if (isRoundTrip)
            {
                // Access main form and update round-trip details
                var mainForm = this.FindForm() as frmMain;
                if (mainForm != null)
                {
                    mainForm.UpdateSearchRoundTrip(
                        fromPortData.Code,
                        toConnection.Destination,
                        passengers,
                        departDate,
                        returnDate
                    );
                    this.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("One-Way trip functionality is not yet implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
