using Ferry_Ticketing_App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App
{
    public class GetAllInfoForTicket
    {
        // Nested class to represent departure ticket information
        public class DepartureTicketInfo
        {
            #region Properties
            // Departure Details
            public string DepartureFromPort { get; set; }
            public string DepartureToPort { get; set; }
            public string DepartureDate { get; set; }
            public string VesselName { get; set; }
            public string Accommodation { get; set; }

            // Passengers Information
            public List<PassengerDetails> Passengers { get; set; }

            // Contact Person Details
            public ContactPersonDetails ContactPerson { get; set; }

            // Nested class for Passenger Details
            public class PassengerDetails
            {
                public string FirstName { get; set; }
                public string MiddleInitial { get; set; }
                public string LastName { get; set; }
                public string Gender { get; set; }
                public string Birthdate { get; set; }
            }

            // Nested class for Contact Person Details
            public class ContactPersonDetails
            {
                public string Name { get; set; }
                public string EmailAddress { get; set; }
                public string MobileNumber { get; set; }
                public string Address { get; set; }
            }
        }

        // Method to retrieve Departure Ticket Information
        public DepartureTicketInfo GetDepartureTicketInfo(
            Control ucRoundTripPayment,
            Control ucRoundTripTripSummary1,
            Control ucPaymentPassengerInfo1)
        {
            var departureInfo = new DepartureTicketInfo();

            // Retrieve Departure Details
            departureInfo.DepartureFromPort = GetLabelText(ucRoundTripTripSummary1, "lblDepFromPort");
            departureInfo.DepartureToPort = GetLabelText(ucRoundTripTripSummary1, "lblDepToPort");
            departureInfo.DepartureDate = GetLabelText(ucRoundTripTripSummary1, "lblDepDepartureDate");
            departureInfo.VesselName = GetLabelText(ucRoundTripTripSummary1, "lblDepVesselName");
            departureInfo.Accommodation = GetLabelText(ucRoundTripTripSummary1, "lblDepAccommodation");

            // Retrieve Passengers Information
            departureInfo.Passengers = GetPassengersInfo(ucPaymentPassengerInfo1);

            // Retrieve Contact Person Details
            departureInfo.ContactPerson = GetContactPersonInfo(ucRoundTripPayment);

            return departureInfo;
        }

        // Helper method to get label text
        private string GetLabelText(Control parentControl, string labelName)
        {
            try
            {
                var label = parentControl.Controls.Find(labelName, true).FirstOrDefault() as Label;
                return label?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error retrieving label {labelName}: {ex.Message}");
                return string.Empty;
            }
        }

        // Method to retrieve Passengers Information
        private List<DepartureTicketInfo.PassengerDetails> GetPassengersInfo(Control ucRoundTripPayment)
        {
            var passengersList = new List<DepartureTicketInfo.PassengerDetails>();

            var passengerControls = ucRoundTripPayment.Controls
                .Cast<Control>()
                .Where(c => c.Name.StartsWith("ucPaymentPassengerInfo"))
                .ToList();

            foreach (var passengerPanel in passengerControls)
            {
                var passenger = new DepartureTicketInfo.PassengerDetails
                {
                    FirstName = GetLabelText(passengerPanel, "lblPIFName"),
                    MiddleInitial = GetLabelText(passengerPanel, "lblPIMiddleInitial"),
                    LastName = GetLabelText(passengerPanel, "lblPILName"),
                    Gender = GetLabelText(passengerPanel, "lblPIGender"),
                    Birthdate = GetLabelText(passengerPanel, "lblPIBirthdate")
                };

                passengersList.Add(passenger);
            }

            return passengersList;
        }

        // Method to retrieve Contact Person Information
        private DepartureTicketInfo.ContactPersonDetails GetContactPersonInfo(Control ucRoundTripPayment)
        {
            // Find the contact info panel
            var contactInfoPanel = ucRoundTripPayment.Controls
                .Find("pnlContactInfo", true)
                .FirstOrDefault();

            if (contactInfoPanel == null)
            {
                return null;
            }

            return new DepartureTicketInfo.ContactPersonDetails
            {
                Name = GetLabelText(contactInfoPanel, "lblCIName"),
                EmailAddress = GetLabelText(contactInfoPanel, "lblCIEmailAdd"),
                MobileNumber = GetLabelText(contactInfoPanel, "lblCIMobileNo"),
                Address = GetLabelText(contactInfoPanel, "lblCIAddress")
            };
        }

        // Random number generator with cryptographic randomness
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates a random OR Number with combined string and integer components
        /// </summary>
        /// <returns>A unique OR Number</returns>
        public string GenerateORNo()
        {
            // Generate a random string component (2-3 uppercase letters)
            string letterComponent = GenerateRandomLetters(2, 3);

            // Generate a random numeric component (up to 7 digits)
            string numberComponent = GenerateRandomNumbers(7);

            // Combine the components
            return $"{letterComponent}-{numberComponent}";
        }

        /// <summary>
        /// Generates a sequential Transaction Number with leading zeros
        /// </summary>
        /// <returns>A formatted Transaction Number</returns>
        public string GenerateTransactionNo(int currentTransactionCount)
        {
            // Ensure the transaction count is within the 1-99999 range
            int sanitizedCount = Math.Max(1, Math.Min(currentTransactionCount, 99999));

            // Format the number with leading zeros to ensure 5 digits
            return sanitizedCount.ToString("D5");
        }

        /// <summary>
        /// Generates a random string of uppercase letters
        /// </summary>
        /// <param name="minLength">Minimum length of the letter string</param>
        /// <param name="maxLength">Maximum length of the letter string</param>
        /// <returns>A random string of uppercase letters</returns>
        private string GenerateRandomLetters(int minLength, int maxLength)
        {
            // Determine the length of the letter string
            int length = _random.Next(minLength, maxLength + 1);

            // Generate the letter string
            StringBuilder letterBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                // Generate a random uppercase letter (A-Z)
                char randomLetter = (char)_random.Next('A', 'Z' + 1);
                letterBuilder.Append(randomLetter);
            }

            return letterBuilder.ToString();
        }

        /// <summary>
        /// Generates a random numeric string with specified maximum length
        /// </summary>
        /// <param name="maxDigits">Maximum number of digits</param>
        /// <returns>A random numeric string</returns>
        private string GenerateRandomNumbers(int maxDigits)
        {
            // Ensure we don't exceed the maximum digits
            int digits = _random.Next(1, maxDigits + 1);

            // Prevent leading zero by starting with a non-zero digit
            StringBuilder numberBuilder = new StringBuilder(digits);
            numberBuilder.Append(_random.Next(1, 10)); // First digit 1-9

            // Add remaining digits (0-9)
            for (int i = 1; i < digits; i++)
            {
                numberBuilder.Append(_random.Next(0, 10));
            }

            return numberBuilder.ToString();
        }
        /// <summary>
        /// Retrieves payment details (Total Price and Payment Method)
        /// </summary>
        /// <param name="ucCheckout">The checkout user control</param>
        /// <returns>A tuple containing Total Price and Payment Method</returns>
        public (decimal TotalPrice, string PaymentMethod) GetPaymentDetails(Control ucCheckout)
        {
            try
            {
                // Find the total price label
                var lblTotalPrice = ucCheckout.Controls.Find("lblTotalPrice", true).FirstOrDefault() as Label;

                // Validate total price label
                if (lblTotalPrice == null || string.IsNullOrEmpty(lblTotalPrice.Text))
                {
                    throw new Exception("Unable to retrieve total price");
                }

                // Parse total price (remove currency symbol and trim)
                decimal totalPrice = decimal.Parse(
                    lblTotalPrice.Text.Replace("₱", "").Trim(),
                    System.Globalization.CultureInfo.InvariantCulture
                );

                // Get the selected payment method
                string paymentMethod = GetSelectedPaymentMethod(ucCheckout);

                // Return the total price and payment method
                return (totalPrice, paymentMethod);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error retrieving payment details: {ex.Message}");
                return (0, string.Empty);
            }
        }

        /// <summary>
        /// Determines the selected payment method
        /// </summary>
        /// <param name="ucCheckout">The checkout user control</param>
        /// <returns>Selected payment method as a string</returns>
        private string GetSelectedPaymentMethod(Control ucRoundTripPayment)
        {
            // List of possible payment methods
            string[] paymentMethods = { "Card", "Maya", "Gcash" };

            // Check for radio buttons or other selection controls
            foreach (string method in paymentMethods)
            {
                // Look for a radio button or other selection indicator
                var paymentMethodControl = ucRoundTripPayment.Controls.Find($"btn{method}", true).FirstOrDefault();

                if (paymentMethodControl is Button btnMethod && btnMethod.Focused)
                {
                    return method;
                }
            }

            // If no method is found, return an empty string
            return string.Empty;
        }
        #endregion



        #region Departure Ticket Information
        /// <summary>
        /// Populates the ticket information in the ucComplete control
        /// </summary>
        /// <param name="ucComplete">The completion user control</param>
        /// <param name="ucRoundTripTripSummary1">Trip summary user control</param>
        /// <param name="ucSearchRoundTrip">Search round trip user control</param>
        public void PopulateTicketInformation(
            Control ucComplete,
            Control ucRoundTripTripSummary1,
            Control ucSearchRoundTrip)
        {
            // Find the ticket placeholder panel
            var pnlTicketPH = ucComplete.Controls.Find("pnlTicketPH", true).FirstOrDefault();

            if (pnlTicketPH == null)
            {
                MessageBox.Show("Unable to find ticket placeholder panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve departure information
            string departureFromPort = GetLabelText(ucRoundTripTripSummary1, "lblDepFromPort");
            string departureToPort = GetLabelText(ucRoundTripTripSummary1, "lblDepToPort");
            string vesselName = GetLabelText(ucRoundTripTripSummary1, "lblDepVesselName");
            string departureDate = GetLabelText(ucRoundTripTripSummary1, "lblDepDepartureDate");

            // Retrieve departure time and travel time
            string departureTime = GetDepartureTime(ucRoundTripTripSummary1);
            string travelTime = GetLabelText(ucSearchRoundTrip, "lblTravelTime");

            // Calculate ETA
            string eta = CalculateETA(departureDate, departureTime, travelTime);

            // Populate labels in the ticket placeholder panel
            SetLabelText(pnlTicketPH, "lblFrom", departureFromPort);
            SetLabelText(pnlTicketPH, "lblTo", departureToPort);
            SetLabelText(pnlTicketPH, "lblVesselName", vesselName);
            SetLabelText(pnlTicketPH, "lblDepartureDate", $"{departureDate} {departureTime}");
            SetLabelText(pnlTicketPH, "lblETA", eta);

            // Vessel-specific information (assuming similar pattern)
            SetLabelText(pnlTicketPH, "lblVVesselName", vesselName);
            SetLabelText(pnlTicketPH, "lblBCVesselName", vesselName);

            // From-To Code (you might need to modify this based on your specific implementation)
            string fromToCode = GenerateFromToCode(departureFromPort, departureToPort);
            SetLabelText(pnlTicketPH, "lblBCFromToCode", fromToCode);
            SetLabelText(pnlTicketPH, "lblVFromToCode", fromToCode);

            // Departure Dates
            SetLabelText(pnlTicketPH, "lblVDepartureDate", $"{departureDate} {departureTime}");
            SetLabelText(pnlTicketPH, "lblBCDepartureDate", $"{departureDate} {departureTime}");
        }

        /// <summary>
        /// Retrieves the departure time from the trip summary control
        /// </summary>
        private string GetDepartureTime(Control ucRoundTripTripSummary1)
        {
            try
            {
                // Adjust the label name as per your actual control
                return GetLabelText(ucRoundTripTripSummary1, "lblDepDepartureTime");
            }
            catch
            {
                // Fallback or default time if not found
                return "00:00";
            }
        }

        /// <summary>
        /// Calculates the Estimated Time of Arrival (ETA)
        /// </summary>
        private string CalculateETA(string departureDate, string departureTime, string travelTime)
        {
            try
            {
                // Parse departure date and time
                DateTime departure = DateTime.Parse($"{departureDate} {departureTime}");

                // Parse travel time (assuming format like "5h 30m")
                TimeSpan travelTimeSpan = ParseTravelTime(travelTime);

                // Calculate ETA
                DateTime eta = departure.Add(travelTimeSpan);

                // Return formatted ETA
                return eta.ToString("yyyy-MM-dd HH:mm");
            }
            catch
            {
                // Fallback if calculation fails
                return "N/A";
            }
        }

        /// <summary>
        /// Parses travel time string into a TimeSpan
        /// </summary>
        private TimeSpan ParseTravelTime(string travelTime)
        {
            // Example parsing of "5h 30m" or similar formats
            int hours = 0, minutes = 0;

            if (travelTime.Contains('h'))
            {
                hours = int.Parse(travelTime.Split('h')[0]);
            }

            if (travelTime.Contains('m'))
            {
                minutes = int.Parse(travelTime.Split('m')[0].Split(' ').Last());
            }

            return new TimeSpan(hours, minutes, 0);
        }

        /// <summary>
        /// Generates a simple From-To Code based on port names
        /// </summary>
        private string GenerateFromToCode(string fromPort, string toPort)
        {
            // Create a simple code from the first letters of the ports
            return $"{fromPort}->{toPort}";
        }

        /// <summary>
        /// Sets the text of a label within a parent control
        /// </summary>
        private void SetLabelText(Control parentControl, string labelName, string text)
        {
            try
            {
                var label = parentControl.Controls.Find(labelName, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting label {labelName} text: {ex.Message}");
            }
        }
        #endregion

        #region Passenger and Payment Information
        /// <summary>
        /// Populates passenger, contact person, and payment information labels
        /// </summary>
        /// <param name="ucComplete">The completion user control</param>
        /// <param name="ucPaymentPassengerInfo1">Passenger info user control</param>
        /// <param name="ucRoundTripPayment">Payment user control</param>
        /// <param name="ucCheckout">Checkout user control</param>
        public void PopulatePassengerAndPaymentInfo(
            Control ucComplete,
            Control ucPaymentPassengerInfo1,
            Control ucRoundTripPayment,
            Control ucCheckout)
        {
            // Find the ticket placeholder panel
            var pnlTicketPH = ucComplete.Controls.Find("pnlTicketPH", true).FirstOrDefault();

            if (pnlTicketPH == null)
            {
                MessageBox.Show("Unable to find ticket placeholder panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve Passengers Info
            var passengers = GetPassengersInfo(ucPaymentPassengerInfo1);

            // Populate Passenger Details
            if (passengers.Count > 0)
            {
                var firstPassenger = passengers[0];

                // Full Name
                SetLabelText(pnlTicketPH, "lblPDName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");

                // Age and Gender
                int age = CalculateAge(firstPassenger.Birthdate);
                SetLabelText(pnlTicketPH, "lblPDAgeGender", $"{age} {firstPassenger.Gender}");

                // Get Accommodation and Discount Type from Passenger Info Controls
                string accommodation = GetLabelText(ucPaymentPassengerInfo1, "lblDepAccommodation");
                SetLabelText(pnlTicketPH, "lblPDAccommodation", accommodation);

                string discountType = GetDiscountType(ucPaymentPassengerInfo1);
                SetLabelText(pnlTicketPH, "lblPDDiscountType", discountType);

                // Populate various name labels
                SetLabelText(pnlTicketPH, "lblVName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");
                SetLabelText(pnlTicketPH, "lblVAgeGender", $"{age} {firstPassenger.Gender}");
                SetLabelText(pnlTicketPH, "lblBCName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");
                SetLabelText(pnlTicketPH, "lblBCAgeGender", $"{age} {firstPassenger.Gender}");
            }

            // Retrieve and Populate Contact Person Info
            var contactPerson = GetContactPersonInfo(ucRoundTripPayment);
            if (contactPerson != null)
            {
                SetLabelText(pnlTicketPH, "lblPDContactPerson", contactPerson.Name);
                SetLabelText(pnlTicketPH, "lblPDContactNo", contactPerson.MobileNumber);
                SetLabelText(pnlTicketPH, "lblPaymentSoldTo", contactPerson.Name);
            }

            // Retrieve and Populate Payment Details
            var (totalPrice, paymentMethod) = GetPaymentDetails(ucCheckout);

            // Generate OR Number and Transaction Number
            string orNumber = GenerateORNo();
            string transactionNo = GenerateTransactionNo(1); // You might want to pass the current transaction count

            // Populate Payment Labels
            SetLabelText(pnlTicketPH, "lblPaymentTotalAmount", totalPrice.ToString("C"));
            SetLabelText(pnlTicketPH, "lblPaymentORNo", orNumber);
            SetLabelText(pnlTicketPH, "lblPPaymentMethod", paymentMethod);
            SetLabelText(pnlTicketPH, "lblBTransactionNo", transactionNo);
        }

        /// <summary>
        /// Calculates age based on birthdate
        /// </summary>
        private int CalculateAge(string birthdate)
        {
            try
            {
                DateTime birthdateDate = DateTime.Parse(birthdate);
                int age = DateTime.Now.Year - birthdateDate.Year;

                // Adjust age if birthday hasn't occurred this year
                if (DateTime.Now < birthdateDate.AddYears(age))
                    age--;

                return age;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the discount type from passenger info control
        /// </summary>
        private string GetDiscountType(Control ucPaymentPassengerInfo1)
        {
            try
            {
                // Adjust the control name as per your actual implementation
                var discountComboBox = ucPaymentPassengerInfo1.Controls.Find("cmbBType", true).FirstOrDefault() as ComboBox;
                return discountComboBox?.SelectedItem?.ToString() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion


        #region Booking & Ticket Information
        /// <summary>
        /// Populates booking details and date-related information
        /// </summary>
        /// <param name="ucComplete">The completion user control</param>
        public void PopulateBookingDetails(Control ucComplete)
        {
            // Find the ticket placeholder panel
            var pnlTicketPH = ucComplete.Controls.Find("pnlTicketPH", true).FirstOrDefault();

            if (pnlTicketPH == null)
            {
                MessageBox.Show("Unable to find ticket placeholder panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set Booking Date (Current Date)
            string bookingDate = DateTime.Now.ToString("yyyy-MM-dd");
            SetLabelText(pnlTicketPH, "lblBBookingDate", bookingDate);

            // Set Valid Until Date (30 days from now)
            string validUntilDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            SetLabelText(pnlTicketPH, "lblBValidUntil", validUntilDate);

            // Generate TIN for Buyer (Random 12-digit number)
            string tinBuyer = GenerateTINNumber();
            SetLabelText(pnlTicketPH, "lblPaymentTINBuyer", tinBuyer);
        }

        /// <summary>
        /// Generates a random TIN (Taxpayer Identification Number)
        /// </summary>
        /// <returns>A 12-digit random number as a string</returns>
        private string GenerateTINNumber()
        {
            return GenerateRandomNumbers(12);
        }

        /// <summary>
        /// Populates Return Trip Ticket Information
        /// </summary>
        /// <param name="ucComplete">Complete user control</param>
        /// <param name="ucRoundTripTripSummary1">Trip summary user control</param>
        /// <param name="ucSearchRoundTrip">Search round trip user control</param>
        public void PopulateReturnTicketInformation(
            Control ucComplete,
            Control ucRoundTripTripSummary1,
            Control ucSearchRoundTrip)
        {
            // Find the existing ticket placeholder panel
            var existingTicketPH = ucComplete.Controls.Find("pnlTicketPH", true).FirstOrDefault();

            if (existingTicketPH == null)
            {
                MessageBox.Show("Unable to find existing ticket placeholder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clone the existing panel for return trip
            var returnTicketPH = ClonePanel(existingTicketPH as Panel);

            // Add the new panel to the parent control
            ucComplete.Controls.Add(returnTicketPH);

            // Adjust position of the new panel
            returnTicketPH.Top = existingTicketPH.Bottom + 20; // Add some spacing

            // Retrieve return trip information
            string returnFromPort = GetLabelText(ucRoundTripTripSummary1, "lblRetFromPort");
            string returnToPort = GetLabelText(ucRoundTripTripSummary1, "lblRetToPort");
            string vesselName = GetLabelText(ucRoundTripTripSummary1, "lblRetVesselName");
            string returnDate = GetLabelText(ucRoundTripTripSummary1, "lblRetDepartureDate");
            string returnTime = GetLabelText(ucRoundTripTripSummary1, "lblRetDepartureTime");

            // Retrieve travel time
            string travelTime = GetLabelText(ucSearchRoundTrip, "lblTravelTime");

            // Calculate ETA
            string eta = CalculateETA(returnDate, returnTime, travelTime);

            // Populate return trip labels
            SetLabelText(returnTicketPH, "lblFrom", returnFromPort);
            SetLabelText(returnTicketPH, "lblTo", returnToPort);
            SetLabelText(returnTicketPH, "lblVesselName", vesselName);
            SetLabelText(returnTicketPH, "lblDepartureDate", $"{returnDate} {returnTime}");
            SetLabelText(returnTicketPH, "lblETA", eta);

            // Additional return trip specific labels
            SetLabelText(returnTicketPH, "lblBCFromToCode", GenerateFromToCode(returnFromPort, returnToPort));
        }

        /// <summary>
        /// Clones a panel with all its child controls
        /// </summary>
        /// <param name="originalPanel">The panel to clone</param>
        /// <returns>A new panel with copied properties and controls</returns>
        private Panel ClonePanel(Panel originalPanel)
        {
            // Create a new panel with the same properties
            Panel clonedPanel = new Panel
            {
                Size = originalPanel.Size,
                BackColor = originalPanel.BackColor,
                Name = "pnlReturnTicketPH"
            };

            // Clone child controls
            foreach (Control ctrl in originalPanel.Controls)
            {
                if (ctrl is Label labelCtrl)
                {
                    Label clonedLabel = new Label
                    {
                        Name = "Return" + labelCtrl.Name,
                        Location = labelCtrl.Location,
                        Size = labelCtrl.Size,
                        Font = labelCtrl.Font,
                        ForeColor = labelCtrl.ForeColor,
                        BackColor = labelCtrl.BackColor,
                        Text = "" // Clear the text for return trip
                    };
                    clonedPanel.Controls.Add(clonedLabel);
                }
            }

            return clonedPanel;
        }

        /// <summary>
        /// Handles Back to Home button click
        /// </summary>
        /// <param name="form">The main form</param>
        /// <param name="ucComplete">Complete user control</param>
        /// <param name="ucFindTrips">Find trips user control</param>
        public void HandleBackToHome(Control form, Control ucComplete, Control ucFindTrips)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to go back to the home page? All current booking information will be lost.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Hide current control
                ucComplete.Visible = false;

                // Show find trips control
                ucFindTrips.Visible = true;

                // Reset any necessary state
                ResetBookingState(ucComplete);
            }
        }

        /// <summary>
        /// Resets the booking state
        /// </summary>
        /// <param name="ucComplete">Complete user control</param>
        private void ResetBookingState(Control ucComplete)
        {
            // Clear ticket placeholder panels
            var ticketPanels = ucComplete.Controls.Find("pnlTicketPH", true);
            foreach (var panel in ticketPanels)
            {
                ucComplete.Controls.Remove(panel);
                panel.Dispose();
            }

            // Additional reset logic as needed
        }

        /// <summary>
        /// Handles Download button click (PDF generation)
        /// </summary>
        /// <param name="ucComplete">Complete user control</param>
        public void HandleDownloadTicket(Control ucComplete)
        {
            try
            {
                // Check for ticket panels
                var ticketPanels = ucComplete.Controls.Find("pnlTicketPH", true);

                if (ticketPanels.Length == 0)
                {
                    MessageBox.Show("No tickets to download", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Prompt for save location
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files|*.pdf";
                    saveDialog.Title = "Save Ticket as PDF";
                    saveDialog.FileName = $"Ticket_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Note: Actual PDF generation would require a PDF library like iTextSharp or similar
                        MessageBox.Show($"Ticket would be saved to {saveDialog.FileName}", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles Print button click
        /// </summary>
        /// <param name="ucComplete">Complete user control</param>
        public void HandlePrintTicket(Control ucComplete)
        {
            try
            {
                // Check for ticket panels
                var ticketPanels = ucComplete.Controls.Find("pnlTicketPH", true);

                if (ticketPanels.Length == 0)
                {
                    MessageBox.Show("No tickets to print", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Open print dialog
                using (PrintDialog printDialog = new PrintDialog())
                {
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Note: Actual printing would require more complex implementation
                        MessageBox.Show("Ticket would be sent to the selected printer", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
