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
        private bool isRoundTrip = false;

        public ucPassengerContactInfo()
        {
            InitializeComponent();

            // Add validation events for name fields
            txtContactPerson.KeyPress += ValidateLettersOnly;
            txtMobileNo.KeyPress += ValidateNumbersOnly;
            txtEmailAdd.TextChanged += ValidateEmail;
            txtConfirmEmailAdd.TextChanged += ValidateEmail;
        }

        private void ValidateLettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateEmail(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
            {
                if (!IsValidEmail(textBox.Text))
                {
                    textBox.BackColor = Color.LightPink;
                }
                else
                {
                    textBox.BackColor = SystemColors.Window;
                }
            }
        }

        public void UpdateItinerary2(string fromCode, string fromCity, string toCode, string toCity, 
            int passengers, DateTime departDate, DateTime returnArrivalDate, bool isRoundTrip = false)
        {
            this.isRoundTrip = isRoundTrip;

            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFCityCode":
                            label.Text = fromCode;
                            break;
                        case "lblTCityCode":
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
                        case "lblReturn":
                            label.Visible = isRoundTrip;
                            break;
                        case "lblReturnDate":
                            label.Visible = isRoundTrip;
                            label.Text = isRoundTrip ? returnArrivalDate.ToString("yyyy-MM-dd") : "";
                            break;
                        case "lblArrival":
                            label.Visible = !isRoundTrip;
                            break;
                        case "lblArrivalDate":
                            label.Visible = !isRoundTrip;
                            label.Text = !isRoundTrip ? returnArrivalDate.ToString("yyyy-MM-dd") : "";
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

        private void btnModifyItinerary_Click(object sender, EventArgs e)
        {
            // Clear all passenger details and contact info
            btnBack_Click(sender, e);

            // Reset SearchRoundTrip and show FindTrips
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            if (findTrips != null)
            {
                var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
                if (searchRoundTrip != null)
                {
                    // Reset SearchRoundTrip controls
                    searchRoundTrip.ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
                    searchRoundTrip.ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
                    searchRoundTrip.ucReturnSummary1.pnlRetDropdownSelected.Visible = false;
                    searchRoundTrip.ucReturnSummary1.pnlRetDropdownNoSelected.Visible = true;
                }

                findTrips.BringToFront();
                findTrips.Visible = true;
                this.Visible = false;
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
                // Reset all controls in the first passenger details
                firstPassengerDetails.cmbBType.SelectedIndex = 0;
                firstPassengerDetails.cmbBoxGender.SelectedIndex = 0;
                firstPassengerDetails.cmbBoxNationality.SelectedIndex = 0;
                firstPassengerDetails.txtFName.Clear();
                firstPassengerDetails.txtLName.Clear();
                firstPassengerDetails.txtMI.Clear();
                firstPassengerDetails.dtpDateOfBirth.Value = DateTime.Today.AddYears(-20);
            }

            // Clear contact info
            txtContactPerson.Clear();
            txtEmailAdd.Clear();
            txtConfirmEmailAdd.Clear();
            txtMobileNo.Clear();
            txtAddress.Clear();

            // Clear the itinerary labels
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    label.Text = "";
                }
            }

            // Reset panel height
            pnlPassengerControlInfo.Height = 1499;

            // Hide this control and show SearchRoundTrip
            this.Visible = false;
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            if (searchRoundTrip != null)
            {
                searchRoundTrip.Visible = true;
                searchRoundTrip.BringToFront();
            }
        }

        public bool ValidateContactInfo()
        {
            string email = txtEmailAdd.Text.Trim();
            string confirmEmail = txtConfirmEmailAdd.Text.Trim();
            string mobileNo = txtMobileNo.Text.Trim();
            string contactPerson = txtContactPerson.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(contactPerson))
            {
                MessageBox.Show("Please enter contact person name.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            // Validate email address
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!email.Equals(confirmEmail, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email address and confirmation email must match.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(mobileNo) || !Regex.IsMatch(mobileNo, @"^\d{10,11}$"))
            {
                MessageBox.Show("Please enter a valid mobile number (10-11 digits).",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter an address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

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

        private bool ValidateAllPassengerDetails()
        {
            var passengerControls = pnlPassengerControlInfo.Controls
                .OfType<ucPassengerDetails>()
                .OrderBy(c => int.Parse(c.Name.Replace("ucPassengerDetails", "")))
                .ToList();

            bool isValid = true;
            StringBuilder errorMessage = new StringBuilder();
            bool hasAdultGuardian = false;

            foreach (var control in passengerControls)
            {
                int passengerNumber = int.Parse(control.Name.Replace("ucPassengerDetails", ""));
                
                if (!control.ValidatePassengerDetails())
                {
                    isValid = false;
                    errorMessage.AppendLine($"• Passenger {passengerNumber}: Please check all required fields");
                    control.BackColor = Color.MistyRose;
                }
                else
                {
                    // Calculate age
                    DateTime birthDate = control.dtpDateOfBirth.Value;
                    int age = DateTime.Today.Year - birthDate.Year;
                    if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;

                    // Check if passenger is an adult (18 or older)
                    if (age >= 18 && (passengerNumber == 1 || passengerNumber == 2))
                    {
                        hasAdultGuardian = true;
                    }

                    control.BackColor = SystemColors.Control;
                }
            }

            if (!hasAdultGuardian)
            {
                isValid = false;
                errorMessage.AppendLine("• At least one of the first two passengers must be 18 years or older");
            }

            if (!isValid)
            {
                MessageBox.Show(
                    $"Please correct the following errors:\n\n{errorMessage}",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                var firstInvalidControl = passengerControls.FirstOrDefault(c => c.BackColor == Color.MistyRose);
                firstInvalidControl?.Focus();
            }

            return isValid;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!ValidateAllPassengerDetails() || !ValidateContactInfo())
            {
                return;
            }

            Console.WriteLine($"isRoundTrip: {isRoundTrip}"); // Debug line

            if (isRoundTrip)
            {
                var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
                var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();

                if (searchRoundTrip == null || roundTripPayment == null)
                {
                    MessageBox.Show("Round trip payment setup failed.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string priceText = searchRoundTrip.ucDepartureSummary1.lblDPrice.Text;
                    Console.WriteLine($"Original price text: {priceText}"); // Debug line

                    priceText = priceText.Replace("₱", "").Replace(",", "").Trim();
                    Console.WriteLine($"Cleaned price text: {priceText}"); // Debug line

                    if (decimal.TryParse(priceText, out decimal price))
                    {
                        SetupRoundTripPayment(roundTripPayment, searchRoundTrip, price);
                    }
                    else
                    {
                        MessageBox.Show($"Unable to parse price: {priceText}", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing round trip price: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var searchOneWay = this.Parent.Controls.OfType<ucSearchOneWayTrip>().FirstOrDefault();
                var oneWayPayment = this.Parent.Controls.OfType<ucOneWTripPayment>().FirstOrDefault();

                if (searchOneWay == null || oneWayPayment == null)
                {
                    MessageBox.Show("One-way trip payment setup failed.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string oneWayPriceText = searchOneWay.ucDepartureSummary1.lblDPrice.Text;
                    Console.WriteLine($"Original one-way price text: {oneWayPriceText}"); // Debug line

                    oneWayPriceText = oneWayPriceText.Replace("₱", "").Replace(",", "").Trim();
                    Console.WriteLine($"Cleaned one-way price text: {oneWayPriceText}"); // Debug line

                    if (decimal.TryParse(oneWayPriceText, out decimal oneWayPrice))
                    {
                        SetupOneWayPayment(oneWayPayment, searchOneWay, oneWayPrice);
                    }
                    else
                    {
                        MessageBox.Show($"Unable to parse price: {oneWayPriceText}", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing one-way price: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<Passenger> CollectPassengerDetails()
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (ucPassengerDetails passengerControl in pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
            {
                Passenger passenger = passengerControl.GetPassengerDetails();
                if (passenger != null)
                {
                    passengers.Add(passenger);
                }
            }
            return passengers;
        }

        private void SetupPaymentInfo(object payment, List<Passenger> passengers, int numberOfPassengers)
        {
            if (payment is ucRoundTripPayment roundTripPayment)
            {
                SetupRoundTripPaymentInfo(roundTripPayment, passengers, numberOfPassengers);
            }
            else if (payment is ucOneWTripPayment oneWayPayment)
            {
                SetupOneWayPaymentInfo(oneWayPayment, passengers, numberOfPassengers);
            }
        }

        private void SetupRoundTripPaymentInfo(ucRoundTripPayment payment, List<Passenger> passengers, int numberOfPassengers)
        {
            if (payment.ucPaymentPassengerInfo1 != null)
            {
                payment.ucPaymentPassengerInfo1.Controls.Clear();
                for (int i = 0; i < passengers.Count; i++)
                {
                    var passengerInfoControl = new ucPaymentPassengerInfo();
                    passengerInfoControl.Name = $"ucPaymentPassengerInfo{i + 1}";
                    SetupPassengerInfoControl(passengerInfoControl, passengers[i], i + 1);
                    payment.ucPaymentPassengerInfo1.Controls.Add(passengerInfoControl);
                }
                payment.ucPaymentPassengerInfo1.Refresh();
            }

            payment.lblNoOfPassengers.Text = numberOfPassengers.ToString();
            payment.lblCIName.Text = txtContactPerson.Text;
            payment.lblCIEmailAdd.Text = txtEmailAdd.Text;
            payment.lblCIMobileNo.Text = txtMobileNo.Text;
            payment.lblCIAddress.Text = txtAddress.Text;
        }

        private void SetupOneWayPaymentInfo(ucOneWTripPayment payment, List<Passenger> passengers, int numberOfPassengers)
        {
            if (payment.ucPaymentPassengerInfo1 != null)
            {
                payment.ucPaymentPassengerInfo1.Controls.Clear();
                for (int i = 0; i < passengers.Count; i++)
                {
                    var passengerInfoControl = new ucPaymentPassengerInfo();
                    passengerInfoControl.Name = $"ucPaymentPassengerInfo{i + 1}";
                    SetupPassengerInfoControl(passengerInfoControl, passengers[i], i + 1);
                    payment.ucPaymentPassengerInfo1.Controls.Add(passengerInfoControl);
                }
                payment.ucPaymentPassengerInfo1.Refresh();
            }

            payment.lblNoOfPassengers.Text = numberOfPassengers.ToString();
            payment.lblCIName.Text = txtContactPerson.Text;
            payment.lblCIEmailAdd.Text = txtEmailAdd.Text;
            payment.lblCIMobileNo.Text = txtMobileNo.Text;
            payment.lblCIAddress.Text = txtAddress.Text;
        }

        private void UpdateTripSummary(ucRoundTripPayment roundTripPayment, ucOneWTripPayment oneWayPayment, ucSearchRoundTrip roundTrip, ucSearchOneWayTrip oneWay)
        {
            if (isRoundTrip)
            {
                if (roundTripPayment?.ucRoundTripTripSummary1 == null) return;
                UpdateRoundTripSummary(roundTripPayment, roundTrip);
            }
            else
            {
                if (oneWayPayment?.ucOneWTripSummary1 == null) return;
                UpdateOneWayTripSummary(oneWayPayment, oneWay);
            }
        }

        private void UpdateRoundTripSummary(ucRoundTripPayment payment, ucSearchRoundTrip roundTrip)
        {
            var summary = payment.ucRoundTripTripSummary1;
            // Departure Summary
            summary.lblDepVesselName.Text = roundTrip.ucDepartureSummary1.lblDVesselName.Text;
            summary.lblDepFromPort.Text = roundTrip.ucDepartureSummary1.lblDepartFrom.Text;
            summary.lblDepToPort.Text = roundTrip.ucDepartureSummary1.lblDepartTo.Text;
            summary.lblDepPort.Text = roundTrip.ucDepartureSummary1.lblFromPortName.Text;
            summary.lblDepDepartureDate.Text = roundTrip.ucDepartureSummary1.lblDepartureDate.Text;
            summary.lblDepAccommodation.Text = roundTrip.ucDepartureSummary1.lblDAccommodation.Text;
            summary.lblDepSeatType.Text = roundTrip.ucDepartureSummary1.lblDSeatType.Text;
            summary.lblDepAircon.Text = roundTrip.ucDepartureSummary1.lblDAircon.Text;
            summary.lblDepDepartureTime.Text = roundTrip.ucIndividualTrips1.lblDTime.Text;

            // Return Summary
            summary.lblRetVesselName.Text = roundTrip.ucReturnSummary1.lblRVesselName.Text;
            summary.lblRetFromPort.Text = roundTrip.ucReturnSummary1.lblReturnFrom.Text;
            summary.lblRetToPort.Text = roundTrip.ucReturnSummary1.lblReturnTo.Text;
            summary.lblRetPort.Text = roundTrip.ucIndividualTrips2.lblFrom.Text;
            summary.lblRetDepartureDate.Text = roundTrip.lblReturnDate.Text;
            summary.lblRetAccommodation.Text = roundTrip.ucIndividualTrips2.cmbBoxAccommodationType.SelectedItem.ToString();
            summary.lblRetSeatType.Text = Accommodation.AccommodationDictionary[roundTrip.ucIndividualTrips2.cmbBoxAccommodationType.SelectedItem.ToString()].SeatType;
            summary.lblRetAircon.Text = roundTrip.ucDepartureSummary1.lblDAircon.Text;
            summary.lblRetDepartureTime.Text = roundTrip.ucIndividualTrips2.lblDTime.Text;
        }

        private void UpdateOneWayTripSummary(ucOneWTripPayment payment, ucSearchOneWayTrip oneWay)
        {
            var summary = payment.ucOneWTripSummary1;
            summary.lblDepVesselName.Text = oneWay.ucDepartureSummary1.lblDVesselName.Text;
            summary.lblDepFromPort.Text = oneWay.ucDepartureSummary1.lblDepartFrom.Text;
            summary.lblDepToPort.Text = oneWay.ucDepartureSummary1.lblDepartTo.Text;
            summary.lblDepPort.Text = oneWay.ucDepartureSummary1.lblFromPortName.Text;
            summary.lblDepDepartureDate.Text = oneWay.ucDepartureSummary1.lblDepartureDate.Text;
            summary.lblDepAccommodation.Text = oneWay.ucDepartureSummary1.lblDAccommodation.Text;
            summary.lblDepSeatType.Text = oneWay.ucDepartureSummary1.lblDSeatType.Text;
            summary.lblDepAircon.Text = oneWay.ucDepartureSummary1.lblDAircon.Text;
            summary.lblDepDepartureTime.Text = oneWay.ucIndividualTrips1.lblDTime.Text;
        }

        private void SetupPassengerInfoControl(ucPaymentPassengerInfo control, Passenger passenger, int index)
        {
            control.Name = $"ucPaymentPassengerInfo{index}";
            control.lblPIFName.Text = passenger.FirstName;
            control.lblPIMiddleInitial.Text = passenger.MiddleInitial;
            control.lblPILName.Text = passenger.LastName;
            control.lblPIGender.Text = passenger.Gender;
            control.lblPIBirthdate.Text = passenger.DateOfBirth.ToShortDateString();
            control.lblPINationality.Text = passenger.Nationality;
            control.lblPassengerNo.Text = index.ToString();
        }

        private void SetupRoundTripPayment(ucRoundTripPayment payment, ucSearchRoundTrip roundTrip, decimal price)
        {
            if (payment == null) return;

            int numberOfPassengers = int.Parse(lblNoOfPassengers.Text);
            List<Passenger> passengers = CollectPassengerDetails();

            SetupPaymentInfo(payment, passengers, numberOfPassengers);
            
            // Get both departure and return prices
            decimal departurePrice = decimal.Parse(roundTrip.ucDepartureSummary1.lblDPrice.Text.Replace("₱", ""));
            decimal returnPrice = decimal.Parse(roundTrip.ucIndividualTrips2.lblTicketPrice.Text.Replace("₱", ""));
            payment.CalculateIndividualPrices(departurePrice, returnPrice);
            
            UpdateTripSummary(payment, null, roundTrip, null);
            payment.SetBasePrice(price);

            this.Visible = false;
            payment.Visible = true;
            payment.BringToFront();
            payment.SetupPassengerInfo(numberOfPassengers, passengers);
        }

        private void SetupOneWayPayment(ucOneWTripPayment payment, ucSearchOneWayTrip oneWay, decimal price)
        {
            if (payment == null) return;

            int numberOfPassengers = int.Parse(lblNoOfPassengers.Text);
            List<Passenger> passengers = CollectPassengerDetails();

            SetupPaymentInfo(payment, passengers, numberOfPassengers);
            payment.CalculateIndividualPrices(price);
            UpdateTripSummary(null, payment, null, oneWay);

            payment.SetBasePrice(price);

            this.Visible = false;
            payment.Visible = true;
            payment.BringToFront();
            payment.SetupPassengerInfo(numberOfPassengers, passengers);
        }
    }
}
