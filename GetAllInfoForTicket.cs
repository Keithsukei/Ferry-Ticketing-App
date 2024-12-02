using Ferry_Ticketing_App.Pages;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App
{
    public class GetAllInfoForTicket
    {
        public class DepartureTicketInfo
        {
            #region Properties
            public string DepartureFromPort { get; set; }
            public string DepartureToPort { get; set; }
            public string DepartureDate { get; set; }
            public string VesselName { get; set; }
            public string Accommodation { get; set; }

            public List<PassengerDetails> Passengers { get; set; }

            public ContactPersonDetails ContactPerson { get; set; }

            public class PassengerDetails
            {
                public string FirstName { get; set; }
                public string MiddleInitial { get; set; }
                public string LastName { get; set; }
                public string Gender { get; set; }
                public string Birthdate { get; set; }
            }

            public class ContactPersonDetails
            {
                public string Name { get; set; }
                public string EmailAddress { get; set; }
                public string MobileNumber { get; set; }
                public string Address { get; set; }
            }
        }

        private string GetLabelText(Control parentControl, string labelName)
        {
            try
            {
                var label = parentControl.Controls.Find(labelName, true).FirstOrDefault() as Label;
                return label?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving label {labelName}: {ex.Message}");
                return string.Empty;
            }
        }

        public List<DepartureTicketInfo.PassengerDetails> GetPassengersInfo(Control ucRoundTripPayment)
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

        private DepartureTicketInfo.ContactPersonDetails GetContactPersonInfo(Control ucRoundTripPayment)
        {
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

        private static readonly Random _random = new Random();

        public string GenerateORNo()
        {
            string letterComponent = GenerateRandomLetters(2, 3);

            string numberComponent = GenerateRandomNumbers(7);

            return $"{letterComponent}-{numberComponent}";
        }

        public string GenerateTransactionNo(int currentTransactionCount)
        {
            int sanitizedCount = Math.Max(1, Math.Min(currentTransactionCount, 99999));

            return sanitizedCount.ToString("D5");
        }

        private string GenerateRandomLetters(int minLength, int maxLength)
        {
            int length = _random.Next(minLength, maxLength + 1);

            StringBuilder letterBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                char randomLetter = (char)_random.Next('A', 'Z' + 1);
                letterBuilder.Append(randomLetter);
            }

            return letterBuilder.ToString();
        }

        private string GenerateRandomNumbers(int maxDigits)
        {
            int digits = _random.Next(1, maxDigits + 1);

            StringBuilder numberBuilder = new StringBuilder(digits);
            numberBuilder.Append(_random.Next(1, 10)); 

            for (int i = 1; i < digits; i++)
            {
                numberBuilder.Append(_random.Next(0, 10));
            }

            return numberBuilder.ToString();
        }
        public (decimal TotalPrice, string PaymentMethod) GetPaymentDetails(Control ucCheckout, ucRoundTripPayment ucRoundTripPayment)
        {
            try
            {
                var lblTotalPrice = ucCheckout.Controls.Find("lblTotalPrice", true).FirstOrDefault() as Label;

                if (lblTotalPrice == null || string.IsNullOrEmpty(lblTotalPrice.Text))
                {
                    throw new Exception("Unable to retrieve total price");
                }

                decimal totalPrice = decimal.Parse(
                    lblTotalPrice.Text.Replace("₱", "").Trim(),
                    System.Globalization.CultureInfo.InvariantCulture
                );

                string paymentMethod = ucRoundTripPayment.GetSelectedPaymentMethod();

                return (totalPrice, paymentMethod);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving payment details: {ex.Message}");
                return (0, string.Empty);
            }
        }
        #endregion



        #region Departure Ticket Information
        public void PopulateTicketInformation(
            Control ucComplete,
            Control ucRoundTripTripSummary1,
            Control ucSearchRoundTrip,
            Control ucTicket,
            int passengerIndex = 1)
        {
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
            SetLabelText(ucTicket, "lblFrom", departureFromPort);
            SetLabelText(ucTicket, "lblTo", departureToPort);
            SetLabelText(ucTicket, "lblVesselName", vesselName);
            SetLabelText(ucTicket, "lblDepartureDate", $"{departureDate} {departureTime}");
            SetLabelText(ucTicket, "lblETA", eta);

            // Vessel-specific information (assuming similar pattern)
            SetLabelText(ucTicket, "lblVVesselName", vesselName);
            SetLabelText(ucTicket, "lblBCVesselName", vesselName);

            // From-To Code (you might need to modify this based on your specific implementation)
            string fromToCode = GenerateFromToCode(departureFromPort, departureToPort);
            SetLabelText(ucTicket, "lblBCFromToCode", fromToCode);
            SetLabelText(ucTicket, "lblVFromToCode", fromToCode);

            // Departure Dates
            SetLabelText(ucTicket, "lblVDepartureDate", $"{departureDate} {departureTime}");
            SetLabelText(ucTicket, "lblBCDepartureDate", $"{departureDate} {departureTime}");
        }

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
      
        private string CalculateETA(string departureDate, string departureTime, string travelTime)
        {
            try
            {
                DateTime departure = DateTime.Parse($"{departureDate} {departureTime}");

                TimeSpan travelTimeSpan = ParseTravelTime(travelTime);

                DateTime eta = departure.Add(travelTimeSpan);

                return eta.ToString("yyyy-MM-dd HH:mm");
            }
            catch
            {
                return "N/A";
            }
        }

        private TimeSpan ParseTravelTime(string travelTime)
        {
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

        private string GenerateFromToCode(string fromPort, string toPort)
        {
            return $"{fromPort}->{toPort}";
        }

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

        public void PopulatePassengerAndPaymentInfo(
            Control ucTicket, 
            Control ucPaymentPassengerInfo1,
            Control ucRoundTripPayment,
            Control ucCheckout,
            Control ucPassengerDetails1,
            Control ucDepartureSummary,
            int passengerIndex = 0)
        {
            // Dynamically find the correct passenger info control
            var specificPassengerInfoControl = ucRoundTripPayment.Controls
                .OfType<Control>()
                .FirstOrDefault(c => c.Name == $"ucPaymentPassengerInfo{passengerIndex}");

            // If specific passenger control not found, fall back to default
            if (specificPassengerInfoControl == null)
                specificPassengerInfoControl = ucPaymentPassengerInfo1;

            // Retrieve Passengers Info using the specific passenger control
            var passengers = GetPassengersInfo(specificPassengerInfoControl);

            // Populate Passenger Details
            if (passengers.Count > 0)
            {
                var firstPassenger = passengers[0];

                // Full Name
                SetLabelText(ucTicket, "lblPDName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");

                // Age and Gender
                int age = CalculateAge(firstPassenger.Birthdate);
                SetLabelText(ucTicket, "lblPDAgeGender", $"{age} {firstPassenger.Gender}");

                // Get Accommodation and Discount Type from Passenger Info Controls
                string accommodation = GetLabelText(ucDepartureSummary, "lblDAccommodation");
                SetLabelText(ucTicket, "lblPDAccommodation", accommodation);

                string discountType = GetDiscountType(ucPassengerDetails1);
                SetLabelText(ucTicket, "lblPDDiscountType", discountType);
                SetLabelText(ucTicket, "lblBCType", discountType);
                SetLabelText(ucTicket, "lblVType", discountType);

                // Populate various name labels
                SetLabelText(ucTicket, "lblVName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");
                SetLabelText(ucTicket, "lblVAgeGender", $"{age} {firstPassenger.Gender}");
                SetLabelText(ucTicket, "lblBCName", $"{firstPassenger.FirstName} {firstPassenger.LastName}");
                SetLabelText(ucTicket, "lblBCAgeGender", $"{age} {firstPassenger.Gender}");
            }

            var contactPerson = GetContactPersonInfo(ucRoundTripPayment);
            if (contactPerson != null)
            {
                SetLabelText(ucTicket, "lblPDContactPerson", contactPerson.Name);
                SetLabelText(ucTicket, "lblPDContactNo", contactPerson.MobileNumber);
                SetLabelText(ucTicket, "lblPaymentSoldTo", contactPerson.Name);
            }

            var paymentControl = ucRoundTripPayment as ucRoundTripPayment; // Cast to specific type

            var paymentDetails = GetPaymentDetails(ucCheckout, paymentControl);

            decimal totalPrice = paymentDetails.TotalPrice;
            string paymentMethod = paymentDetails.PaymentMethod;

            DateTime paymentDateReserved = GetPaymentDateReserved();
            SetLabelText(ucTicket, "lblPaymentDateReserved", paymentDateReserved.ToString("yyyy-MM-dd"));

            string orNumber = GenerateORNo();
            string transactionNo = GenerateTransactionNo(1); 

            SetLabelText(ucTicket   , "lblPaymentTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(ucTicket   , "lblVTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(   ucTicket, "lblBCTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(ucTicket, "lblPaymentORNo", orNumber);
            SetLabelText(ucTicket, "lblVORNo", orNumber);
            SetLabelText(ucTicket, "lblBCORNo", orNumber);
            SetLabelText(ucTicket, "lblPPaymentMethod", paymentMethod);
            SetLabelText(ucTicket, "lblBTransactionNo", transactionNo);
        }
        public DateTime GetPaymentDateReserved()
        {
            return DateTime.Now;
        }
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

        private string GetDiscountType(Control ucPassengerDetails1)
        {
            try
            {
                var discountComboBox = ucPassengerDetails1.Controls.Find("cmbBType", true).FirstOrDefault() as ComboBox;

                return discountComboBox?.SelectedItem?.ToString() ?? string.Empty;
            }
            catch
            {
                return string.Empty; 
            }
        }
        #endregion


        #region Booking & Ticket Information

        public void PopulateBookingDetails(Control ucTicket)
        {
            string bookingDate = DateTime.Now.ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBBookingDate", bookingDate);

            string validUntilDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBValidUntil", validUntilDate);

            string tinBuyer = GenerateTINNumber();
            SetLabelText(ucTicket, "lblPaymentTINBuyer", tinBuyer);
        }

        private string GenerateTINNumber()
        {
            return GenerateRandomNumbers(12);
        }

        #endregion
        public class ReturnTicketInformation
        {
            // Return Details
            public string ReturnFromPort { get; set; }
            public string ReturnToPort { get; set; }
            public string ReturnDate { get; set; }
            public string VesselName { get; set; }
            public string Accommodation { get; set; }

            // Passengers Information (can reuse the same PassengerDetails from DepartureTicketInfo)
            public List<DepartureTicketInfo.PassengerDetails> Passengers { get; set; }

            // Contact Person Details (can reuse the same ContactPersonDetails from DepartureTicketInfo)
            public DepartureTicketInfo.ContactPersonDetails ContactPerson { get; set; }
        }
        public void PopulateReturnTicketInformation(
            Control ucTicket,
            Control ucRoundTripTripSummary1,
            Control ucSearchRoundTrip,
            Control ucRoundTripTripSummary,
            int passengerIndex = 1)
        {
            // Find the ticket placeholder panel inside the ucTicket user control
            var pnlTicketPH = ucTicket.Controls.Find("pnlReturnTicketPH", true).FirstOrDefault();

            if (pnlTicketPH == null)
            {
                MessageBox.Show("Unable to find return ticket placeholder panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reuse existing methods with modifications
            string returnFromPort = GetLabelText(ucRoundTripTripSummary, "lblReturnFromPort");
            string returnToPort = GetLabelText(ucRoundTripTripSummary, "lblReturnToPort");
            string vesselName = GetLabelText(ucRoundTripTripSummary, "lblReturnVesselName");
            string returnDate = GetLabelText(ucRoundTripTripSummary, "lblReturnDepartureDate");

            // Reuse existing methods
            string returnTime = GetDepartureTime(ucRoundTripTripSummary);
            string travelTime = GetLabelText(ucSearchRoundTrip, "lblReturnTravelTime");

            // Calculate ETA (reuse existing method)
            string eta = CalculateETA(returnDate, returnTime, travelTime);

            // Populate labels (similar to departure ticket method)
            SetLabelText(ucTicket, "lblReturnFrom", returnFromPort);
            SetLabelText(ucTicket, "lblReturnTo", returnToPort);
            SetLabelText(ucTicket, "lblReturnVesselName", vesselName);
            SetLabelText(ucTicket, "lblReturnDepartureDate", $"{returnDate} {returnTime}");
            SetLabelText(ucTicket, "lblReturnETA", eta);

            // Generate From-To Code (reuse existing method)
            string returnFromToCode = GenerateFromToCode(returnFromPort, returnToPort);
            SetLabelText(ucTicket, "lblReturnFromToCode", returnFromToCode);
        }


        #region Event Handlers
        public void HandleBackToHome(Control form, Control ucComplete, Control ucFindTrips)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Thank you for Choosing Aerian Star Ferries. Do you want to book another trip?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Ensure ucFindTrips and ucComplete are in the same parent container
                    if (ucComplete.Parent != null && ucFindTrips.Parent != null)
                    {
                        // Hide current control
                        ucComplete.Visible = false;

                        // Show find trips control
                        ucFindTrips.Visible = true;
                        ucFindTrips.BringToFront();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles Download button click (PDF generation)
        /// </summary>
        /// <param name="ucComplete">Complete user control</param>
        public void HandleDownloadTicket(Control ucComplete)
        {
            try
            {
                // Find ucTicket control (itself, not nested in a panel)
                var ucTicketPanels = ucComplete.Controls.Find("ucTicket1", true);
                if (ucTicketPanels.Length == 0)
                {
                    MessageBox.Show("No ucTicket control found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var ucTicket = ucTicketPanels[0];

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PNG Files|*.png";
                    saveDialog.Title = "Save Ticket as Image";
                    saveDialog.FileName = $"Ticket_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string imagePath = saveDialog.FileName;

                        Bitmap ticketBitmap = new Bitmap(ucTicket.Width, ucTicket.Height);
                        ucTicket.DrawToBitmap(ticketBitmap, new System.Drawing.Rectangle(0, 0, ucTicket.Width, ucTicket.Height));

                        ticketBitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                        MessageBox.Show($"Ticket saved to {imagePath}", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Find ucTicket control (itself, not nested in a panel)
                var ucTicketPanels = ucComplete.Controls.Find("ucTicket1", true);
                if (ucTicketPanels.Length == 0)
                {
                    MessageBox.Show("No ucTicket control found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the ucTicket control (it's directly the container now)
                var ucTicket = ucTicketPanels[0];

                // Open print dialog
                using (PrintDialog printDialog = new PrintDialog())
                {
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.PrinterSettings = printDialog.PrinterSettings;

                        // Print the ucTicket as an image
                        printDoc.PrintPage += (sender, e) =>
                        {
                            // Capture ucTicket as a bitmap image
                            Bitmap ticketBitmap = new Bitmap(ucTicket.Width, ucTicket.Height);
                            ucTicket.DrawToBitmap(ticketBitmap, new System.Drawing.Rectangle(0, 0, ucTicket.Width, ucTicket.Height));

                            // Draw the bitmap to the print page
                            e.Graphics.DrawImage(ticketBitmap, 0, 0);

                            // Optionally, scale or modify the image size to fit the page
                            // e.Graphics.DrawImage(ticketBitmap, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));
                        };

                        // Start printing
                        printDoc.Print();
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
