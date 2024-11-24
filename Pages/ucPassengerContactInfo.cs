﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucPassengerContactInfo : UserControl
    {
        public ucPassengerContactInfo()
        {
            InitializeComponent();
        }

        // Keep the existing UpdateItinerary2 method exactly as it was
        public void UpdateItinerary2(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate, DateTime returnDate)
        {
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFromCode":
                            label.Text = fromCode;
                            break;
                        case "lblToCode":
                            label.Text = toCode;
                            break;
                        case "lblFCity":
                            label.Text = fromCity;
                            break;
                        case "lblTCity":
                            label.Text = toCity;
                            break;
                        case "lblNoOfPassengers":
                            label.Text = passengers.ToString();
                            break;
                        case "lblDepartureDate":
                            label.Text = departDate.ToString("yyyy-MM-dd");
                            break;
                        case "lblReturnDate":
                            label.Text = returnDate.ToString("yyyy-MM-dd");
                            break;
                    }
                }
            }
        }

        public void SetupPassengerDetails(int numberOfPassengers)
        {
            // Clear existing passenger details except the first one
            var existingPassengerDetails = pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>()
                .Where(ctrl => ctrl.Name != "ucPassengerDetails1")
                .ToList();

            foreach (var detail in existingPassengerDetails)
            {
                pnlPassengerControlInfo.Controls.Remove(detail);
                detail.Dispose();
            }

            // Get reference to the first passenger details control
            var firstPassengerDetails = pnlPassengerControlInfo.Controls["ucPassengerDetails1"] as ucPassengerDetails;
            if (firstPassengerDetails == null) return;

            int padding = 10;
            int bottomPadding = 70; // Added extra padding for bottom
            int topPosition = firstPassengerDetails.Bottom + padding;

            // Add additional passenger details controls
            for (int i = 2; i <= numberOfPassengers; i++)
            {
                var passengerDetails = new ucPassengerDetails
                {
                    Name = $"ucPassengerDetails{i}",
                    Location = new Point(firstPassengerDetails.Left, topPosition),
                    Width = firstPassengerDetails.Width,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                pnlPassengerControlInfo.Controls.Add(passengerDetails);
                topPosition = passengerDetails.Bottom + padding;
            }

            // Update the buttons' positions - both at same Y coordinate
            if (btnBack != null && btnContinue != null)
            {
                // Set both buttons to the same top position
                int buttonY = topPosition + padding;
                btnBack.Top = buttonY;
                btnContinue.Top = buttonY;

                // Make sure both buttons maintain their anchoring
                btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btnContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            // Adjust panel height to accommodate all controls plus extra bottom padding
            int totalContentHeight = btnBack.Bottom + bottomPadding;  // Added extra bottom padding
            pnlPassengerControlInfo.Height = totalContentHeight;

            // Enable AutoScroll on the panel
            pnlPassengerControlInfo.AutoScroll = true;

            // Force layout update
            pnlPassengerControlInfo.PerformLayout();
            pnlPassengerControlInfo.Refresh();
        }

        private void btnModifyItenerary_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Clear all passenger details except the first one
            var existingPassengerDetails = pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>()
                .Where(ctrl => ctrl.Name != "ucPassengerDetails1")
                .ToList();

            foreach (var detail in existingPassengerDetails)
            {
                pnlPassengerControlInfo.Controls.Remove(detail);
                detail.Dispose();
            }

            // Clear the first passenger details form
            var firstPassengerDetails = pnlPassengerControlInfo.Controls["ucPassengerDetails1"] as ucPassengerDetails;
            if (firstPassengerDetails != null)
            {
                // Clear all textboxes in the first passenger details
                foreach (Control ctrl in firstPassengerDetails.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        textBox.Clear();
                    }
                    else if (ctrl is ComboBox comboBox)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }
            }

            // Clear the itinerary labels
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFromCode":
                        case "lblToCode":
                        case "lblFCity":
                        case "lblTCity":
                        case "lblNoOfPassengers":
                        case "lblDepartureDate":
                        case "lblReturnDate":
                            label.Text = "";
                            break;
                    }
                }
            }

            // Hide this control first
            this.Visible = false;

            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            if (searchRoundTrip != null)
            {
                searchRoundTrip.Visible = true;
                searchRoundTrip.BringToFront();

                this.SendToBack();
            }

            pnlPassengerControlInfo.Height = 1499;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            
            decimal departurePrice = decimal.Parse(searchRoundTrip.ucDepartureSummary1.lblDPrice.Text.Replace("₱", ""));

            int numberOfPassengers = int.Parse(lblNoOfPassengers.Text);

            decimal serviceCharge = 25;
            decimal terminalFee = 25;

                
            roundTripPayment.lblNoOfPassengers.Text = numberOfPassengers.ToString();
            roundTripPayment.lblServiceCharge.Text = "₱" + serviceCharge.ToString("N2");
            roundTripPayment.lblTerminalFee.Text = "₱" + terminalFee.ToString("N2");

            decimal totalPrice = (departurePrice * numberOfPassengers) + serviceCharge + terminalFee;

            roundTripPayment.lblTotalPrice.Text = "₱" + totalPrice.ToString("N2");

            roundTripPayment.Visible = true;
            roundTripPayment.BringToFront();
            
        }
    }
}
