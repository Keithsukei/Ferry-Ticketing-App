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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucRoundTripPayment : UserControl
    {
        private decimal basePrice = 0;
        public string selectedPaymentMethod;
        private decimal serviceCharge = 0;

        public ucRoundTripPayment()
        {
            InitializeComponent();
            btnCard.Click += (s, e) => SelectPaymentMethod("Card", 50);
            btnMaya.Click += (s, e) => SelectPaymentMethod("Maya", 30);
            btnGcash.Click += (s, e) => SelectPaymentMethod("Gcash", 30);
        }
        public void SetBasePrice(decimal price)
        {
            basePrice = price;

            lblTerminalFee.Text = "₱25.00";

            UpdateTotalPrice(0);
        }

        private void UpdateTotalPrice(decimal serviceCharge)
        {
            try
            {
                decimal terminalFee = 25;
                decimal totalPrice = 0;

                var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
                if (searchRoundTrip != null)
                {
                    decimal departurePrice = decimal.Parse(searchRoundTrip.ucDepartureSummary1.lblDPrice.Text.Replace("₱", ""));
                    decimal returnPrice = decimal.Parse(searchRoundTrip.ucIndividualTrips2.lblTicketPrice.Text.Replace("₱", ""));
                    
                    var passengerContactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
                    if (passengerContactInfo != null)
                    {
                        var passengerDetails = passengerContactInfo.pnlPassengerControlInfo.Controls
                            .OfType<ucPassengerDetails>()
                            .OrderBy(c => int.Parse(c.Name.Replace("ucPassengerDetails", "")))
                            .ToList();

                        foreach (var passenger in passengerDetails)
                        {
                            string passengerType = passenger.cmbBType.SelectedItem?.ToString() ?? "Adult";
                            DateTime birthDate = passenger.dtpDateOfBirth.Value;
                            int age = DateTime.Today.Year - birthDate.Year;
                            if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;

                            Price depPrice = new Price(departurePrice, 0);
                            Price retPrice = new Price(returnPrice, 0);
                            
                            totalPrice += depPrice.ApplyDiscount(passengerType, age);
                            totalPrice += retPrice.ApplyDiscount(passengerType, age);
                        }
                    }

                    CalculateIndividualPrices(departurePrice, returnPrice);
                }

                totalPrice += (terminalFee + serviceCharge);
                lblTerminalFee.Text = "₱" + terminalFee.ToString("N2");
                lblTotalPrice.Text = "₱" + totalPrice.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating total price: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectPaymentMethod(string method, decimal charge)
        {
            lblServiceCharge.Text = "₱" + charge.ToString("N2");
            serviceCharge = charge;

            HighlightSelectedButton(method);

            SelectedPaymentMethod = method;
            SelectedServiceCharge = charge;

            UpdateTotalPrice(charge);
        }

        private void HighlightSelectedButton(string selectedMethod)
        {
            ResetButtonColors();

            switch (selectedMethod)
            {
                case "Card":
                    HighlightButton(btnCard);
                    break;

                case "Maya":
                    HighlightButton(btnMaya);
                    break;

                case "Gcash":
                    HighlightButton(btnGcash);
                    break;
            }
        }

        private void HighlightButton(Button button)
        {
            button.BackColor = Color.LightBlue;
            button.FlatAppearance.BorderColor = Color.Blue;
            button.FlatAppearance.BorderSize = 1;
        }

        private void ResetButtonColors()
        {
            Color defaultBackColor = SystemColors.Control;
            Color defaultBorderColor = Color.Gray;

            ResetButtonColor(btnCard, defaultBackColor, defaultBorderColor);
            ResetButtonColor(btnMaya, defaultBackColor, defaultBorderColor);
            ResetButtonColor(btnGcash, defaultBackColor, defaultBorderColor);
        }

        private void ResetButtonColor(Button button, Color backColor, Color borderColor)
        {
            button.BackColor = backColor;
            button.FlatAppearance.BorderColor = borderColor;
            button.FlatAppearance.BorderSize = 0;
        }

        public string SelectedPaymentMethod { get; private set; }
        public decimal SelectedServiceCharge { get; private set; }

        public void SetupPassengerInfo(int numberOfPassengers, List<Passenger> passengers)
        {
            var existingPassengerInfo = pnlPayment.Controls.OfType<ucPaymentPassengerInfo>()
                .Where(ctrl => ctrl.Name != "ucPaymentPassengerInfo1")
                .ToList();

            foreach (var info in existingPassengerInfo)
            {
                pnlPayment.Controls.Remove(info);
                info.Dispose();
            }

            var firstPassengerInfo = pnlPayment.Controls["ucPaymentPassengerInfo1"] as ucPaymentPassengerInfo;
            if (firstPassengerInfo == null) return;

            int padding = 20;
            int bottomPadding = 70; 
            int topPosition = firstPassengerInfo.Bottom + padding;

            if (passengers.Count > 0)
            {
                Passenger firstPassenger = passengers[0];
                SetPassengerInfo(firstPassengerInfo, firstPassenger, 1);
            }

            for (int i = 2; i <= numberOfPassengers; i++)
            {
                var newPassengerInfo = new ucPaymentPassengerInfo
                {
                    Name = $"ucPaymentPassengerInfo{i}",
                    Location = new Point(firstPassengerInfo.Left, topPosition),
                    Width = firstPassengerInfo.Width,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                if (i - 1 < passengers.Count)
                {
                    Passenger passenger = passengers[i - 1];
                    SetPassengerInfo(newPassengerInfo, passenger, i);
                }

                pnlPayment.Controls.Add(newPassengerInfo);
                topPosition = newPassengerInfo.Bottom + padding;
            }

            if (btnPaymentBack != null && btnPaymentContinue != null)
            {
                int buttonY = topPosition + padding;
                btnPaymentBack.Top = buttonY;
                btnPaymentContinue.Top = buttonY;

                btnPaymentBack.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btnPaymentContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            int totalContentHeight = btnPaymentBack.Bottom + bottomPadding;
            pnlPayment.Height = totalContentHeight;

            pnlPayment.AutoScroll = true;
            pnlPayment.PerformLayout();
            pnlPayment.Refresh();
        }

        private void SetPassengerInfo(ucPaymentPassengerInfo passengerInfo, Passenger passenger, int passengerNo)
        {
            passengerInfo.lblPIFName.Text = passenger.FirstName;
            passengerInfo.lblPIMiddleInitial.Text = passenger.MiddleInitial;
            passengerInfo.lblPILName.Text = passenger.LastName;
            passengerInfo.lblPIGender.Text = passenger.Gender;
            passengerInfo.lblPIBirthdate.Text = passenger.DateOfBirth.ToShortDateString();
            passengerInfo.lblPINationality.Text = passenger.Nationality;
            passengerInfo.lblPassengerNo.Text = passengerNo.ToString();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Card";
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Maya";
        }

        private void btnGcash_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Gcash";
        }
        public string GetSelectedPaymentMethod()
        {
            return selectedPaymentMethod;
        }

        private void btnPaymentContinue_Click(object sender, EventArgs e)
        {
            var paymentRetriever = new GetAllInfoForTicket();

            if (string.IsNullOrEmpty(selectedPaymentMethod))
            {
                MessageBox.Show("Please select a payment method before proceeding.", "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the checkout user control
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            if (checkOut == null)
            {
                MessageBox.Show("Unable to navigate to the checkout page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserControl paymentControl = null;
            switch (selectedPaymentMethod)
            {
                case "Card":
                    paymentControl = new ucPaymentCard();
                    break;
                case "Maya":
                    paymentControl = new ucPaymentMaya();
                    break;
                case "Gcash":
                    paymentControl = new ucPaymentGcash();
                    break;
                default:
                    MessageBox.Show("Invalid payment method selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            paymentControl.Location = new Point(22, 186);
            paymentControl.Size = checkOut.ucPaymentCard1.Size;
            paymentControl.Anchor = checkOut.ucPaymentCard1.Anchor;

            var pnlCheckout = checkOut.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "pnlCheckout");
            if (pnlCheckout == null)
            {
                MessageBox.Show("Unable to find the checkout panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pnlCheckout.Controls.Remove(checkOut.ucPaymentCard1);
            checkOut.ucPaymentCard1.Dispose();

            pnlCheckout.Controls.Add(paymentControl);
            paymentControl.Visible = true;
            paymentControl.BringToFront();

            checkOut.btnCompleteOrder.BringToFront();

            Random random = new Random();
            int paymentId = random.Next(100000, 999999);
            int ticketId = random.Next(100000, 999999);
            decimal totalPrice = decimal.Parse(lblTotalPrice.Text.Replace("₱", ""));
            DateTime paymentDate = DateTime.Now;

            Payment payment = new Payment(
                paymentId,
                ticketId,
                totalPrice,
                serviceCharge,
                paymentDate,
                selectedPaymentMethod
            );

            checkOut.lblPaymentID.Text = payment.PaymentId.ToString();
            checkOut.lblTotalPrice.Text = "₱" + payment.TotalPrice.ToString("N2");

            checkOut.btnCompleteOrder.Click -= checkOut.btnCompleteOrder_Click;
            checkOut.btnCompleteOrder.Click += checkOut.btnCompleteOrder_Click;

            checkOut.Visible = true;
            checkOut.BringToFront();
        }

        private void btnPaymentBack_Click(object sender, EventArgs e)
        {
            var parentControl = this.Parent;

            var passengerContactInfoControl = parentControl.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();

            if (passengerContactInfoControl != null)
            {
                passengerContactInfoControl.Visible = true;
                passengerContactInfoControl.BringToFront();
            }

            this.Visible = false;

            lblServiceCharge.Text = "₱0.00";
            lblTotalPrice.Text = "₱0.00";
            lblTerminalFee.Text = "₱25.00";
            selectedPaymentMethod = string.Empty;

            ResetButtonColors();
        }

        public void CalculateIndividualPrices(decimal departureBasePrice, decimal returnBasePrice)
        {
            try
            {
                var passengerContactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
                if (passengerContactInfo == null) return;

                int students = 0, pwd = 0, senior = 0, child3_11 = 0, child0_2 = 0;
                decimal totalDiscount = 0;
                decimal totalBasePrice = departureBasePrice + returnBasePrice;

                var passengerDetails = passengerContactInfo.pnlPassengerControlInfo.Controls
                    .OfType<ucPassengerDetails>()
                    .OrderBy(c => int.Parse(c.Name.Replace("ucPassengerDetails", "")))
                    .ToList();

                foreach (var passenger in passengerDetails)
                {
                    string passengerType = passenger.cmbBType.SelectedItem?.ToString() ?? "Adult";
                    DateTime birthDate = passenger.dtpDateOfBirth.Value;
                    int age = DateTime.Today.Year - birthDate.Year;
                    if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;

                    switch (passengerType)
                    {
                        case "Student": students++; break;
                        case "PWD": pwd++; break;
                        case "Senior Citizen": senior++; break;
                    }

                    if (age >= 3 && age <= 11) child3_11++;
                    else if (age >= 0 && age <= 2) child0_2++;

                    // Calculate discounts for both departure and return
                    Price departurePrice = new Price(departureBasePrice, 0);
                    decimal departureDiscounted = departurePrice.ApplyDiscount(passengerType, age);
                    totalDiscount += (departureBasePrice - departureDiscounted);

                    Price returnPrice = new Price(returnBasePrice, 0);
                    decimal returnDiscounted = returnPrice.ApplyDiscount(passengerType, age);
                    totalDiscount += (returnBasePrice - returnDiscounted);
                }

                lblNoOfStudents.Text = students.ToString();
                lblNoOfPWD.Text = pwd.ToString();
                lblNoOfSenior.Text = senior.ToString();
                lblNoOfChild3_11.Text = child3_11.ToString();
                lblNoOfChild0_2.Text = child0_2.ToString();
                
                decimal discountPercentage = (totalDiscount / (totalBasePrice * passengerDetails.Count)) * 100;
                lblDiscountPercentage.Text = $"{discountPercentage:N2}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating prices: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
