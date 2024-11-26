using Ferry_Ticketing_App.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();

            if (findTrips != null)
            {
                findTrips.BringToFront();
                findTrips.Visible = true;

                int passengers = int.TryParse(findTrips.txtPassengers.Text, out int result) ? result : 1;

                // Update trip details for all instances of ucIndividualTrips
                foreach (var tripControl in this.Parent.Controls.OfType<ucIndividualTrips>())
                {
                    lblNoOfPassengers.Text = passengers.ToString();
                    tripControl.RecalculateTripDetails(DateTime.Now);
                }
            }
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

        // Method to validate contact information
        public bool ValidateContactInfo()
        {
            // Extract values from controls inside pnlContactInfoPH
            string email = txtEmailAdd.Text.Trim();
            string confirmEmail = txtConfirmEmailAdd.Text.Trim();
            string mobileNo = txtMobileNo.Text.Trim();

            // Validate email address
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            // Check if email and confirm email match
            if (!email.Equals(confirmEmail, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email address and confirmation email must match.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            // Validate mobile number
            if (string.IsNullOrWhiteSpace(mobileNo) || !Regex.IsMatch(mobileNo, @"^\d{10,11}$"))
            {
                MessageBox.Show("Please enter a valid mobile number (10-11 digits).",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Helper method for email validation
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            string selectedAccommodationType = searchRoundTrip.ucIndividualTrips2.cmbBoxAccommodationType.SelectedItem?.ToString();
            decimal departurePrice = decimal.Parse(searchRoundTrip.ucDepartureSummary1.lblDPrice.Text.Replace("₱", ""));
            int numberOfPassengers = int.Parse(lblNoOfPassengers.Text);

            // Collect passenger details from all ucPassengerDetails controls
            List<Passenger> passengers = new List<Passenger>();

            foreach (ucPassengerDetails passengerControl in pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
            {
                Passenger passenger = passengerControl.GetPassengerDetails();
                if (passenger != null)
                {
                    Console.WriteLine($"Passenger: {passenger.FirstName}, {passenger.MiddleInitial}, {passenger.LastName}");
                    passengers.Add(passenger);
                }
                else
                {
                    Console.WriteLine("No passenger details found for this control.");
                }
            }

            // Setup passenger info in the payment page
            if (roundTripPayment.ucPaymentPassengerInfo1 != null)
            {
                // Clear existing controls if needed
                roundTripPayment.ucPaymentPassengerInfo1.Controls.Clear();

                // Create passenger info controls based on number of passengers
                for (int i = 0; i < passengers.Count; i++) // Loop through the list of passengers
                {
                    ucPaymentPassengerInfo passengerInfoControl = new ucPaymentPassengerInfo();
                    passengerInfoControl.Name = $"ucPaymentPassengerInfo{i + 1}"; // Set unique control name

                    // Get the passenger data from the list
                    Passenger passenger = passengers[i];

                    // Populate the ucPaymentPassengerInfo control with passenger details
                    passengerInfoControl.lblPIFName.Text = passenger.FirstName;
                    passengerInfoControl.lblPIMiddleInitial.Text = passenger.MiddleInitial;
                    passengerInfoControl.lblPILName.Text = passenger.LastName;
                    passengerInfoControl.lblPIGender.Text = passenger.Gender;
                    passengerInfoControl.lblPIBirthdate.Text = passenger.DateOfBirth.ToShortDateString();
                    passengerInfoControl.lblPINationality.Text = passenger.Nationality;


                    // Update passenger number label (1-based index)
                    passengerInfoControl.lblPassengerNo.Text = (i + 1).ToString();  // 1-based index

                    // Add the control to the parent container
                    roundTripPayment.ucPaymentPassengerInfo1.Controls.Add(passengerInfoControl);
                }

                // Refresh the parent container to update the UI
                roundTripPayment.ucPaymentPassengerInfo1.Refresh();  // Force UI to update and reflect changes
            }

            // Set the number of passengers and total price
            roundTripPayment.lblNoOfPassengers.Text = numberOfPassengers.ToString();
            decimal totalPrice = departurePrice * numberOfPassengers;
            roundTripPayment.SetBasePrice(totalPrice);

            if (roundTripPayment.ucRoundTripTripSummary1 != null)
            {
                // Departure Summary
                roundTripPayment.ucRoundTripTripSummary1.lblDepVesselName.Text = searchRoundTrip.ucDepartureSummary1.lblDVesselName.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepFromPort.Text = searchRoundTrip.ucDepartureSummary1.lblDepartFrom.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepToPort.Text = searchRoundTrip.ucDepartureSummary1.lblDepartTo.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepPort.Text = searchRoundTrip.ucDepartureSummary1.lblFromPortName.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepDepartureDate.Text = searchRoundTrip.ucDepartureSummary1.lblDepartureDate.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepAccommodation.Text = searchRoundTrip.ucDepartureSummary1.lblDAccommodation.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepSeatType.Text = searchRoundTrip.ucDepartureSummary1.lblDSeatType.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepAircon.Text = searchRoundTrip.ucDepartureSummary1.lblDAircon.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblDepDepartureTime.Text = searchRoundTrip.ucIndividualTrips1.lblDTime.Text;

                // Return Summary
                roundTripPayment.ucRoundTripTripSummary1.lblRetVesselName.Text = searchRoundTrip.ucReturnSummary1.lblRVesselName.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetFromPort.Text = searchRoundTrip.ucReturnSummary1.lblReturnFrom.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetToPort.Text = searchRoundTrip.ucReturnSummary1.lblReturnTo.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetPort.Text = searchRoundTrip.ucIndividualTrips2.lblFrom.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetDepartureDate.Text = searchRoundTrip.lblReturnDate.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetAccommodation.Text = searchRoundTrip.ucIndividualTrips2.cmbBoxAccommodationType.SelectedItem.ToString();
                roundTripPayment.ucRoundTripTripSummary1.lblRetSeatType.Text = Accommodation.AccommodationDictionary[selectedAccommodationType].SeatType;
                roundTripPayment.ucRoundTripTripSummary1.lblRetAircon.Text = searchRoundTrip.ucDepartureSummary1.lblDAircon.Text;
                roundTripPayment.ucRoundTripTripSummary1.lblRetDepartureTime.Text = searchRoundTrip.ucIndividualTrips2.lblDTime.Text;

                // Contact Info
                roundTripPayment.lblCIName.Text = txtContactPerson.Text;
                roundTripPayment.lblCIEmailAdd.Text = txtEmailAdd.Text;
                roundTripPayment.lblCIMobileNo.Text = txtMobileNo.Text;
                roundTripPayment.lblCIAddress.Text = txtAddress.Text;
            }

            if (!ValidateContactInfo())
            {
                return;
            }

            // Switch to passenger details page and hide current page
            var passengerDetails = this.Parent.Controls.OfType<ucPassengerDetails>().FirstOrDefault();
            if (passengerDetails != null)
            {
                this.Visible = false;
                passengerDetails.Visible = true;
                passengerDetails.BringToFront();
            }

            // Show round trip payment page
            roundTripPayment.Visible = true;
            roundTripPayment.BringToFront();
            roundTripPayment.SetupPassengerInfo(numberOfPassengers, passengers);
        }
    }
}
