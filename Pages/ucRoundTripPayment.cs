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
        private string selectedPaymentMethod = null; // Tracks the selected payment method

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

            // Update the labels
            lblTerminalFee.Text = "₱25.00"; // Display fixed terminal fee

            // Initialize total price (no service charge yet)
            UpdateTotalPrice(0);
        }

        // Modify the UpdateTotalPrice method to use basePrice
        private void UpdateTotalPrice(decimal serviceCharge)
        {
            decimal terminalFee = 25; // Fixed terminal fee

            // Calculate total price
            decimal totalPrice = basePrice + terminalFee + serviceCharge;

            // Update the labels
            lblTerminalFee.Text = "₱" + terminalFee.ToString("N2");
            lblTotalPrice.Text = "₱" + totalPrice.ToString("N2");
        }

        private void SelectPaymentMethod(string method, decimal charge)
        {
            // Update the service charge label
            lblServiceCharge.Text = "₱" + charge.ToString("N2");

            // Highlight the selected button
            HighlightSelectedButton(method);

            // Store the selected payment method (if needed)
            SelectedPaymentMethod = method;
            SelectedServiceCharge = charge;

            // Update the total price (assuming other charges are calculated already)
            UpdateTotalPrice(charge);
        }

        // Method to highlight the selected payment button
        private void HighlightSelectedButton(string selectedMethod)
        {
            // Reset button colors
            ResetButtonColors();

            // Highlight the selected button
            switch (selectedMethod)
            {
                case "Card":
                    btnCard.BackColor = Color.LightBlue; // Highlight color
                    btnCard.FlatAppearance.BorderColor = Color.Blue;
                    btnCard.FlatAppearance.BorderSize = 2;
                    break;

                case "Maya":
                    btnMaya.BackColor = Color.LightBlue;
                    btnMaya.FlatAppearance.BorderColor = Color.Blue;
                    btnMaya.FlatAppearance.BorderSize = 2;
                    break;

                case "Gcash":
                    btnGcash.BackColor = Color.LightBlue;
                    btnGcash.FlatAppearance.BorderColor = Color.Blue;
                    btnGcash.FlatAppearance.BorderSize = 2;
                    break;
            }
        }

        // Method to reset button colors to default
        private void ResetButtonColors()
        {
            Color defaultBackColor = SystemColors.Control;
            Color defaultBorderColor = Color.Gray;

            btnCard.BackColor = defaultBackColor;
            btnCard.FlatAppearance.BorderColor = defaultBorderColor;
            btnCard.FlatAppearance.BorderSize = 1;

            btnMaya.BackColor = defaultBackColor;
            btnMaya.FlatAppearance.BorderColor = defaultBorderColor;
            btnMaya.FlatAppearance.BorderSize = 1;

            btnGcash.BackColor = defaultBackColor;
            btnGcash.FlatAppearance.BorderColor = defaultBorderColor;
            btnGcash.FlatAppearance.BorderSize = 1;
        }

        // Properties to store the selected method and service charge (if needed)
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

            // Get the first passenger details control
            var firstPassengerInfo = pnlPayment.Controls["ucPaymentPassengerInfo1"] as ucPaymentPassengerInfo;
            if (firstPassengerInfo == null) return;

            int padding = 10;
            int bottomPadding = 70; // Added extra padding for bottom
            int topPosition = firstPassengerInfo.Bottom + padding;

            // Populate the first control with the first passenger's data
            if (passengers.Count > 0)
            {
                Passenger firstPassenger = passengers[0];
                firstPassengerInfo.lblPIFName.Text = firstPassenger.FirstName;
                firstPassengerInfo.lblPIMiddleInitial.Text = firstPassenger.MiddleInitial;
                firstPassengerInfo.lblPILName.Text = firstPassenger.LastName;
                firstPassengerInfo.lblPIGender.Text = firstPassenger.Gender;
                firstPassengerInfo.lblPIBirthdate.Text = firstPassenger.DateOfBirth.ToShortDateString();
                firstPassengerInfo.lblPINationality.Text = firstPassenger.Nationality;
                firstPassengerInfo.lblPassengerNo.Text = "1"; // First passenger
            }

            // Create additional passenger info controls
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
                    newPassengerInfo.lblPIFName.Text = passenger.FirstName;
                    newPassengerInfo.lblPIMiddleInitial.Text = passenger.MiddleInitial;
                    newPassengerInfo.lblPILName.Text = passenger.LastName;
                    newPassengerInfo.lblPIGender.Text = passenger.Gender;
                    newPassengerInfo.lblPIBirthdate.Text = passenger.DateOfBirth.ToShortDateString();
                    newPassengerInfo.lblPINationality.Text = passenger.Nationality;
                    newPassengerInfo.lblPassengerNo.Text = i.ToString();
                }

                pnlPayment.Controls.Add(newPassengerInfo);
                topPosition = newPassengerInfo.Bottom + padding;
            }

            if (btnPaymentBack != null && btnPaymentContinue != null)
            {
                // Set both buttons to the same top position
                int buttonY = topPosition + padding;
                btnPaymentBack.Top = buttonY;
                btnPaymentContinue.Top = buttonY;

                // Make sure both buttons maintain their anchoring
                btnPaymentBack.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btnPaymentContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            int totalContentHeight = btnPaymentBack.Bottom + bottomPadding;  // Added extra bottom padding
            pnlPayment.Height = totalContentHeight;

            pnlPayment.AutoScroll = true;
            pnlPayment.PerformLayout();
            pnlPayment.Refresh();
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

        private void btnPaymentContinue_Click(object sender, EventArgs e)
        {
            // Validate if a payment method is selected
            if (string.IsNullOrEmpty(selectedPaymentMethod))
            {
                MessageBox.Show("Please select a payment method before proceeding.", "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed to checkout
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            if (checkOut == null) return;

            // Replace the ucPaymentCard1 in ucCheckout with the appropriate control
            Control paymentControl = null;
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
            }

            if (paymentControl != null)
            {
                paymentControl.Location = new Point(22, 186); // Set location
                paymentControl.Size = checkOut.ucPaymentCard1.Size; // Match the size of the original control
                paymentControl.Anchor = checkOut.ucPaymentCard1.Anchor;

                // Remove the existing control and add the selected payment method control
                checkOut.Controls.Remove(checkOut.ucPaymentCard1);
                checkOut.ucPaymentCard1.Dispose(); // Ensure the old control is disposed of
                checkOut.Controls.Add(paymentControl);
            }

            // Generate Payment details
            Random random = new Random();
            int paymentId = random.Next(100000, 999999); // Generate random Payment ID
            int ticketId = random.Next(100000, 999999);  // Generate random Ticket ID
            decimal totalPrice = decimal.Parse(lblTotalPrice.Text.Replace("₱", "")); // Extract total price
            DateTime paymentDate = DateTime.Now; // Set current date and time

            // Create Payment object
            Payment payment = new Payment(
                paymentId,
                ticketId,
                totalPrice,
                paymentDate,
                selectedPaymentMethod,
                totalPrice
            );
            checkOut.lblPaymentID.Text = payment.PaymentId.ToString();


            checkOut.Visible = true;
            checkOut.BringToFront();
        }
    }
}
