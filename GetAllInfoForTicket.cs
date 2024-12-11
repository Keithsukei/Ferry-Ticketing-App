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
using Ferry_Ticketing_App.Classes;

namespace Ferry_Ticketing_App
{
    public class GetAllInfoForTicket
    {
        private string _tinBuyer;

        public GetAllInfoForTicket()
        {
            _tinBuyer = GenerateRandomNumbers(12);
        }

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

        public List<DepartureTicketInfo.PassengerDetails> GetPassengersInfo(Control ucPaymentPassengerInfo)
        {
            var passengersList = new List<DepartureTicketInfo.PassengerDetails>();
            
            // Get the parent control that contains all passenger info controls
            var parentControl = ucPaymentPassengerInfo.Parent;
            if (parentControl == null) return passengersList;

            // Get specific passenger control
            var passengerControls = parentControl.Controls
                .OfType<Control>()
                .Where(c => c.Name.StartsWith("ucPaymentPassengerInfo"))
                .OrderBy(c => c.Name)
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

            string numberComponent = GenerateRandomNumbers(9);

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
            if (maxDigits < 9)
                throw new ArgumentException("maxDigits must be at least 9 for TIN format.");

            // Generate 9 random digits
            StringBuilder numberBuilder = new StringBuilder(9);
            for (int i = 0; i < 9; i++)
            {
                numberBuilder.Append(_random.Next(0, 10));
            }

            // Format as 123-456-789
            return $"{numberBuilder[0]}{numberBuilder[1]}{numberBuilder[2]}-" +
                   $"{numberBuilder[3]}{numberBuilder[4]}{numberBuilder[5]}-" +
                   $"{numberBuilder[6]}{numberBuilder[7]}{numberBuilder[8]}";
        }

        public (decimal TotalPrice, string PaymentMethod) GetPaymentDetails(Control ucCheckout, object payment)
        {
            try
            {
                var lblTotalPrice = ucCheckout.Controls.Find("lblTotalPrice", true).FirstOrDefault() as Label;
                if (lblTotalPrice == null || string.IsNullOrEmpty(lblTotalPrice.Text))
                {
                    throw new Exception("Unable to retrieve total price");
                }

                string paymentMethod = "";
                if (payment is ucRoundTripPayment roundTripPayment)
                {
                    paymentMethod = roundTripPayment.SelectedPaymentMethod;
                }
                else if (payment is ucOneWTripPayment oneWayPayment)
                {
                    paymentMethod = oneWayPayment.SelectedPaymentMethod;
                }

                decimal totalPrice = decimal.Parse(lblTotalPrice.Text.Replace("₱", ""));
                return (totalPrice, paymentMethod);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting payment details: {ex.Message}");
                return (0, string.Empty);
            }
        }

        #region Departure Ticket Information
        public void PopulateTicketInformation(
            Control ucTicket,
            Control tripSummary,
            Control searchTrip,
            int passengerIndex = 1)
        {
            try
            {
                string departureFromPort = GetLabelText(tripSummary, "lblDepFromPort");
                string departureToPort = GetLabelText(tripSummary, "lblDepToPort");
                string vesselName = GetLabelText(tripSummary, "lblDepVesselName");
                string departureDate = GetLabelText(tripSummary, "lblDepDepartureDate");
                string departureTime = GetDepartureTime(tripSummary);
                string travelTime = GetLabelText(searchTrip, "lblTravelTime");
                string eta = CalculateETA(departureDate, departureTime, travelTime);

                SetLabelText(ucTicket, "lblFrom", departureFromPort);
                SetLabelText(ucTicket, "lblTo", departureToPort);
                SetLabelText(ucTicket, "lblVesselName", vesselName);
                SetLabelText(ucTicket, "lblDepartureDate", $"{departureDate} {departureTime}");
                SetLabelText(ucTicket, "lblETA", eta);

                SetLabelText(ucTicket, "lblVVesselName", vesselName);
                SetLabelText(ucTicket, "lblBCVesselName", vesselName);

                string fromToCode = GenerateFromToCode(departureFromPort, departureToPort);
                SetLabelText(ucTicket, "lblBCFromToCode", fromToCode);
                SetLabelText(ucTicket, "lblVFromToCode", fromToCode);

                SetLabelText(ucTicket, "lblVDepartureDate", $"{departureDate} {departureTime}");
                SetLabelText(ucTicket, "lblBCDepartureDate", $"{departureDate} {departureTime}");

                SetLabelText(ucTicket, "lblTicketType", "DEPARTURE TICKET");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating ticket information: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDepartureTime(Control tripSummary)
        {
            try
            {
                // Adjust the label name as per your actual control
                return GetLabelText(tripSummary, "lblDepDepartureTime");
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
            Control ucPaymentPassengerInfo,
            Control payment,
            Control ucCheckout,
            Control ucPassengerDetails1,
            Control ucDepartureSummary,
            int passengerIndex)
        {
            try
            {
                var specificPassengerInfoControl = payment.Controls
                    .OfType<Control>()
                    .FirstOrDefault(c => c.Name == $"ucPaymentPassengerInfo{passengerIndex + 1}");

                if (specificPassengerInfoControl == null)
                    specificPassengerInfoControl = ucPaymentPassengerInfo;

                decimal basePrice = decimal.Parse(GetLabelText(ucDepartureSummary, "lblDPrice").Replace("₱", ""));
                string discountType = GetDiscountType(ucPassengerDetails1.Parent, passengerIndex);
                string birthdate = GetLabelText(specificPassengerInfoControl, "lblPIBirthdate");
                int age = CalculateAge(birthdate);

                Price price = new Price(basePrice, 0);
                decimal individualPrice = price.ApplyDiscount(discountType, age);

                decimal serviceCharge = 0;
                int passengerCount = GetPassengerCount(ucPaymentPassengerInfo);
                bool isRoundTrip = payment is ucRoundTripPayment;

                if (isRoundTrip)
                {
                    var roundTrip = payment as ucRoundTripPayment;
                    serviceCharge = decimal.Parse(roundTrip.lblServiceCharge.Text.Replace("₱", ""));
                }
                else if (payment is ucOneWTripPayment oneWayPayment)
                {
                    serviceCharge = decimal.Parse(oneWayPayment.lblServiceCharge.Text.Replace("₱", ""));
                }

                decimal terminalFee = 25m;

                // Calculate service charge per passenger
                decimal serviceChargePerPassenger;
                if (isRoundTrip)
                {
                    // For round trip, divide by (passenger count * 2) since charge is split between departure and return
                    serviceChargePerPassenger = passengerCount > 0 ? serviceCharge / (passengerCount * 2) : 0;
                }
                else
                {
                    // For one way, just divide by passenger count
                    serviceChargePerPassenger = passengerCount > 0 ? serviceCharge / passengerCount : 0;
                }

                decimal totalIndividualPrice = individualPrice + serviceChargePerPassenger + terminalFee;

                SetLabelText(ucTicket, "lblPaymentTotalAmmount", $"₱{totalIndividualPrice:N2}");
                SetLabelText(ucTicket, "lblVTotalAmmount", $"₱{totalIndividualPrice:N2}");
                SetLabelText(ucTicket, "lblBCTotalAmmount", $"₱{totalIndividualPrice:N2}");

                var passengers = GetPassengersInfo(specificPassengerInfoControl);
                if (passengers.Count > passengerIndex)
                {
                    var passenger = passengers[passengerIndex];
                    PopulatePassengerDetails(ucTicket, passenger, ucDepartureSummary, ucPassengerDetails1, passengerIndex);
                }

                var contactPerson = GetContactPersonInfo(payment);
                if (contactPerson != null)
                {
                    PopulateContactInfo(ucTicket, contactPerson);
                }

                var (_, paymentMethod) = GetPaymentDetails(ucCheckout, payment);
                SetLabelText(ucTicket, "lblPPaymentMethod", paymentMethod);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating individual price: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulatePassengerDetails(Control ucTicket, DepartureTicketInfo.PassengerDetails passenger,
            Control ucDepartureSummary, Control ucPassengerDetails1, int passengerIndex)
        {
            SetLabelText(ucTicket, "lblPDName", $"{passenger.FirstName} {passenger.LastName}");
            int age = CalculateAge(passenger.Birthdate);
            SetLabelText(ucTicket, "lblPDAgeGender", $"{age} {passenger.Gender}");
            
            string accommodation = GetLabelText(ucDepartureSummary, "lblDAccommodation");
            SetLabelText(ucTicket, "lblPDAccommodation", accommodation);

            string discountType = GetDiscountType(ucPassengerDetails1.Parent, passengerIndex);
            SetLabelText(ucTicket, "lblPDDiscountType", discountType);
            SetLabelText(ucTicket, "lblBCType", discountType);
            SetLabelText(ucTicket, "lblVType", discountType);

            SetLabelText(ucTicket, "lblVName", $"{passenger.FirstName} {passenger.LastName}");
            SetLabelText(ucTicket, "lblVAgeGender", $"{age} {passenger.Gender}");
            SetLabelText(ucTicket, "lblBCName", $"{passenger.FirstName} {passenger.LastName}");
            SetLabelText(ucTicket, "lblBCAgeGender", $"{age} {passenger.Gender}");
        }

        private void PopulateContactInfo(Control ucTicket, DepartureTicketInfo.ContactPersonDetails contactPerson)
        {
            SetLabelText(ucTicket, "lblPDContactPerson", contactPerson.Name);
            SetLabelText(ucTicket, "lblPDContactNo", contactPerson.MobileNumber);
            SetLabelText(ucTicket, "lblPaymentSoldTo", contactPerson.Name);
        }

        private void PopulatePaymentInfo(Control ucTicket, decimal totalPrice, string paymentMethod)
        {
            SetLabelText(ucTicket, "lblPaymentTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(ucTicket, "lblVTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(ucTicket, "lblBCTotalAmmount", totalPrice.ToString("C"));
            SetLabelText(ucTicket, "lblPPaymentMethod", paymentMethod);
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

        private string GetDiscountType(Control ucPassengerContactInfo, int passengerIndex)
        {
            try
            {
                // Find the specific passenger details control
                var passengerDetails = ucPassengerContactInfo.Controls
                    .OfType<ucPassengerDetails>()
                    .FirstOrDefault(c => c.Name == $"ucPassengerDetails{passengerIndex + 1}");

                if (passengerDetails != null)
                {
                    var discountTypeComboBox = passengerDetails.Controls
                        .Find("cmbBType", true)
                        .FirstOrDefault() as ComboBox;

                    return discountTypeComboBox?.SelectedItem?.ToString() ?? "Adult";
                }

                return "Adult"; // Default to Adult if control not found
            }
            catch
            {
                return "Adult"; // Default to Adult on error
            }
        }
        #endregion


        #region Booking & Ticket Information

        public void PopulateBookingDetails(Control ucTicket)
        {
            string bookingDate = DateTime.Now.ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBBookingDate", bookingDate);
            SetLabelText(ucTicket, "lblPaymentDateReserved", bookingDate);

            string validUntilDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBValidUntil", validUntilDate);

            SetLabelText(ucTicket, "lblPaymentTINBuyer", _tinBuyer);

            // Generate and set OR number
            string orNumber = GenerateORNo();
            SetLabelText(ucTicket, "lblPaymentORNo", orNumber);
            SetLabelText(ucTicket, "lblVORNo", orNumber);
            SetLabelText(ucTicket, "lblBCORNo", orNumber);
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
            Control ucSearchRoundTrip,
            Control ucRoundTripTripSummary,
            int passengerIndex = 1)
        {
            // Reuse existing methods with modifications
            string returnFromPort = GetLabelText(ucRoundTripTripSummary, "lblRetFromPort");
            string returnToPort = GetLabelText(ucRoundTripTripSummary, "lblRetToPort");
            string vesselName = GetLabelText(ucRoundTripTripSummary, "lblRetVesselName");
            string returnDate = GetLabelText(ucRoundTripTripSummary, "lblRetDepartureDate");

            // Reuse existing methods
            string returnTime = GetDepartureTime(ucRoundTripTripSummary);
            string travelTime = GetLabelText(ucSearchRoundTrip, "lblTravelTime");

            // Calculate ETA (reuse existing method)
            string eta = CalculateETA(returnDate, returnTime, travelTime);

            // Populate labels (similar to departure ticket method)
            SetLabelText(ucTicket, "lblFrom", returnFromPort);
            SetLabelText(ucTicket, "lblTo", returnToPort);
            SetLabelText(ucTicket, "lblVesselName", vesselName);
            SetLabelText(ucTicket, "lblDepartureDate", $"{returnDate} {returnTime}");
            SetLabelText(ucTicket, "lblETA", eta);

              // Vessel-specific information (assuming similar pattern)
            SetLabelText(ucTicket, "lblVVesselName", vesselName);
            SetLabelText(ucTicket, "lblBCVesselName", vesselName);

            // Generate From-To Code (reuse existing method)
            string returnFromToCode = GenerateFromToCode(returnFromPort, returnToPort);
            SetLabelText(ucTicket, "lblBCFromToCode", returnFromToCode);
            SetLabelText(ucTicket, "lblVFromToCode", returnFromToCode);

            // Return Dates
            SetLabelText(ucTicket, "lblVDepartureDate", $"{returnDate} {returnTime}");
            SetLabelText(ucTicket, "lblBCDepartureDate", $"{returnDate} {returnTime}");

            // Update the ticket type label to indicate it's a return ticket
            SetLabelText(ucTicket, "lblTicketType", "RETURN TICKET");
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

        public void PopulateReturnPassengerAndPaymentInfo(
            Control ucTicket, 
            Control ucPaymentPassengerInfo1,
            Control ucRoundTripPayment,
            Control ucCheckout,
            Control ucPassengerDetails1,
            Control ucDepartureSummary,
            int passengerIndex)
        {
            try
            {
                // Get the specific passenger control for this ticket
                var specificPassengerInfoControl = ucRoundTripPayment.Controls
                    .OfType<Control>()
                    .FirstOrDefault(c => c.Name == $"ucPaymentPassengerInfo{passengerIndex + 1}");

                if (specificPassengerInfoControl == null)
                    specificPassengerInfoControl = ucPaymentPassengerInfo1;

                // Get base price for return trip
                var searchRoundTrip = ucRoundTripPayment.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
                decimal basePrice = decimal.Parse(searchRoundTrip.ucIndividualTrips2.lblTicketPrice.Text.Replace("₱", ""));

                // Retrieve Passengers Info using the specific passenger control
                var passengers = GetPassengersInfo(specificPassengerInfoControl);

                // Populate Passenger Details
                if (passengers.Count > passengerIndex)
                {
                    var passenger = passengers[passengerIndex];

                    // Full Name and Demographics
                    SetLabelText(ucTicket, "lblPDName", $"{passenger.FirstName} {passenger.LastName}");
                    int age = CalculateAge(passenger.Birthdate);
                    SetLabelText(ucTicket, "lblPDAgeGender", $"{age} {passenger.Gender}");

                    // Get Accommodation
                    string accommodation = GetLabelText(ucDepartureSummary, "lblDAccommodation");
                    SetLabelText(ucTicket, "lblPDAccommodation", accommodation);

                    // Get and set discount type
                    string discountType = GetDiscountType(ucPassengerDetails1.Parent, passengerIndex);
                    SetLabelText(ucTicket, "lblPDDiscountType", discountType);
                    SetLabelText(ucTicket, "lblBCType", discountType);
                    SetLabelText(ucTicket, "lblVType", discountType);

                    // Set passenger names on various labels
                    SetLabelText(ucTicket, "lblVName", $"{passenger.FirstName} {passenger.LastName}");
                    SetLabelText(ucTicket, "lblVAgeGender", $"{age} {passenger.Gender}");
                    SetLabelText(ucTicket, "lblBCName", $"{passenger.FirstName} {passenger.LastName}");
                    SetLabelText(ucTicket, "lblBCAgeGender", $"{age} {passenger.Gender}");

                    // Calculate base price with discount
                    Price price = new Price(basePrice, 0);
                    decimal individualPrice = price.ApplyDiscount(discountType, age);

                    // Get service charge and passenger count
                    decimal serviceCharge = decimal.Parse(
                        (ucRoundTripPayment as ucRoundTripPayment)?.lblServiceCharge.Text.Replace("₱", "") ?? "0");
                    int passengerCount = GetPassengerCount(ucPaymentPassengerInfo1);

                    decimal terminalFee = 25m;

                    // Calculate service charge per passenger (divide by passenger count * 2 for round trip)
                    decimal serviceChargePerPassenger = passengerCount > 0 ? serviceCharge / (passengerCount * 2) : 0;
                    decimal totalIndividualPrice = individualPrice + serviceChargePerPassenger + terminalFee;

                    // Set the prices on the ticket
                    SetLabelText(ucTicket, "lblPaymentTotalAmmount", $"₱{totalIndividualPrice:N2}");
                    SetLabelText(ucTicket, "lblVTotalAmmount", $"₱{totalIndividualPrice:N2}");
                    SetLabelText(ucTicket, "lblBCTotalAmmount", $"₱{totalIndividualPrice:N2}");
                }

                // Set contact person information
                var contactPerson = GetContactPersonInfo(ucRoundTripPayment);
                if (contactPerson != null)
                {
                    SetLabelText(ucTicket, "lblPDContactPerson", contactPerson.Name);
                    SetLabelText(ucTicket, "lblPDContactNo", contactPerson.MobileNumber);
                    SetLabelText(ucTicket, "lblPaymentSoldTo", contactPerson.Name);
                }

                // Set payment method
                var paymentControl = ucRoundTripPayment as ucRoundTripPayment;
                SetLabelText(ucTicket, "lblPPaymentMethod", paymentControl?.SelectedPaymentMethod ?? string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating individual return price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateReturnBookingDetails(Control ucTicket)
        {
            string bookingDate = DateTime.Now.ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBBookingDate", bookingDate);
            SetLabelText(ucTicket, "lblPaymentDateReserved", bookingDate);

            string validUntilDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            SetLabelText(ucTicket, "lblBValidUntil", validUntilDate);

            SetLabelText(ucTicket, "lblPaymentTINBuyer", _tinBuyer);

            // Generate unique numbers for return ticket
            string orNumber = $"{GenerateORNo()}-R";
            string transactionNo = $"{GenerateTransactionNo(1)}-R";

            SetLabelText(ucTicket, "lblPaymentORNo", orNumber);
            SetLabelText(ucTicket, "lblVORNo", orNumber);
            SetLabelText(ucTicket, "lblBCORNo", orNumber);
            SetLabelText(ucTicket, "lblBTransactionNo", transactionNo);
        }
        #endregion

        public static void ResetAllControls(Control parentControl)
        {
            try
            {
                // Find all relevant user controls
                var findTrips = parentControl.Controls.OfType<ucFindTrips>().FirstOrDefault();
                var searchRoundTrip = parentControl.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
                var searchOneWayTrip = parentControl.Controls.OfType<ucSearchOneWayTrip>().FirstOrDefault();
                var passengerContactInfo = parentControl.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
                var roundTripPayment = parentControl.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
                var oneWayPayment = parentControl.Controls.OfType<ucOneWTripPayment>().FirstOrDefault();
                var checkout = parentControl.Controls.OfType<ucCheckout>().FirstOrDefault();
                var complete = parentControl.Controls.OfType<ucComplete>().FirstOrDefault();
                var history = parentControl.Controls.OfType<ucHistory>().FirstOrDefault();

                // Reset FindTrips
                if (findTrips != null)
                {
                    findTrips.txtPassengers.Text = "1";
                    findTrips.rbOneWay.Checked = true;
                    findTrips.dtpDepart.Value = DateTime.Now;
                    findTrips.dtpReturn.Value = DateTime.Now.AddDays(1);
                    findTrips.Visible = true;
                    findTrips.BringToFront();
                    findTrips.AutoScrollPosition = new Point(0, 0);
                }

                // Reset SearchRoundTrip
                if (searchRoundTrip != null)
                {
                    searchRoundTrip.ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
                    searchRoundTrip.ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
                    searchRoundTrip.ucReturnSummary1.pnlRetDropdownSelected.Visible = false;
                    searchRoundTrip.ucReturnSummary1.pnlRetDropdownNoSelected.Visible = true;
                    searchRoundTrip.Visible = false;
                    searchRoundTrip.AutoScrollPosition = new Point(0, 0);
                    searchRoundTrip.ucDepartureSummary1.AutoScrollPosition = new Point(0, 0);
                    searchRoundTrip.ucReturnSummary1.AutoScrollPosition = new Point(0, 0);
                }

                // Reset SearchOneWayTrip
                if (searchOneWayTrip != null)
                {
                    searchOneWayTrip.ucDepartureSummary1.pnlDepDropDownSelected.Visible = false;
                    searchOneWayTrip.ucDepartureSummary1.pnlDepDropDownNoSelected.Visible = true;
                    searchOneWayTrip.Visible = false;
                    searchOneWayTrip.AutoScrollPosition = new Point(0, 0);
                    searchOneWayTrip.ucDepartureSummary1.AutoScrollPosition = new Point(0, 0);
                }

                // Reset PassengerContactInfo
                if (passengerContactInfo != null)
                {
                    passengerContactInfo.txtContactPerson.Clear();
                    passengerContactInfo.txtEmailAdd.Clear();
                    passengerContactInfo.txtMobileNo.Clear();
                    passengerContactInfo.txtAddress.Clear();
                    passengerContactInfo.txtConfirmEmailAdd.Clear();
                    passengerContactInfo.Visible = false;
                    passengerContactInfo.AutoScrollPosition = new Point(0, 0);
                    passengerContactInfo.pnlPassengerControlInfo.AutoScrollPosition = new Point(0, 0);
                }

                // Reset RoundTripPayment
                if (roundTripPayment != null)
                {
                    roundTripPayment.selectedPaymentMethod = string.Empty;
                    roundTripPayment.lblServiceCharge.Text = "₱0.00";
                    roundTripPayment.lblTotalPrice.Text = "₱0.00";
                    roundTripPayment.lblTerminalFee.Text = "₱25.00";
                    roundTripPayment.Visible = false;
                    roundTripPayment.AutoScrollPosition = new Point(0, 0);
                }

                // Reset OneWayPayment
                if (oneWayPayment != null)
                {
                    oneWayPayment.selectedPaymentMethod = string.Empty;
                    oneWayPayment.lblServiceCharge.Text = "₱0.00";
                    oneWayPayment.lblTotalPrice.Text = "₱0.00";
                    oneWayPayment.lblTerminalFee.Text = "₱25.00";
                    oneWayPayment.Visible = false;
                    oneWayPayment.AutoScrollPosition = new Point(0, 0);
                }

                // Reset Complete
                if (complete != null)
                {
                    complete.ucTicket1?.Controls.Clear();
                    complete.Visible = false;
                    complete.AutoScrollPosition = new Point(0, 0);
                    complete.pnlComplete.AutoScrollPosition = new Point(0, 0);
                }

                // Reset History
                if (history != null)
                {
                    history.flpTicketContainer.AutoScrollPosition = new Point(0, 0);
                    history.AutoScrollPosition = new Point(0, 0);
                }

                // Reset Checkout
                if (checkout != null)
                {
                    checkout.Visible = false;
                    checkout.AutoScrollPosition = new Point(0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting controls: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetPassengerCount(Control paymentControl)
        {
            return paymentControl.Controls
                .OfType<Control>()
                .Count(c => c.Name.StartsWith("ucPaymentPassengerInfo"));
        }
    }
}
