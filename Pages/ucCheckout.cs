using System;
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
    public partial class ucCheckout : UserControl
    {
        public ucCheckout()
        {
            InitializeComponent();
        }

        public void btnCompleteOrder_Click(object sender, EventArgs e)
        {

            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            // Determine the current payment method control
            UserControl currentPaymentControl = pnlCheckout.Controls.OfType<UserControl>()
                .FirstOrDefault(c => c.Visible &&
                    (c is ucPaymentCard || c is ucPaymentGcash || c is ucPaymentMaya));

            // Validate based on the current payment method
            bool isValid = false;
            string errorMessage = "Please complete all payment details";

            if (currentPaymentControl is ucPaymentCard cardPayment)
            {
                // For card payment, use the existing method
                isValid = cardPayment.AreCardFieldsFilled();
                errorMessage = "Please complete all card payment details";
            }
            else if (currentPaymentControl is ucPaymentGcash gcashPayment)
            {
                // For Gcash, check both field validation and OTP
                isValid = gcashPayment.ValidateGcashFields() && gcashPayment.IsOTPValid();
                errorMessage = "Please complete all Gcash payment details and verify OTP";
            }
            else if (currentPaymentControl is ucPaymentMaya mayaPayment)
            {
                // For Maya, check both field validation and OTP
                isValid = mayaPayment.ValidateMayaFields() && mayaPayment.IsOTPValid();
                errorMessage = "Please complete all Maya payment details and verify OTP";
            }

            // If validation fails, show an error message
            if (!isValid)
            {
                MessageBox.Show(errorMessage,
                    "Incomplete Payment Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (isValid)
            {
                var paymentRetriever = new GetAllInfoForTicket();

                // Populate ticket information
                paymentRetriever.PopulateTicketInformation(
                    complete,
                    roundTripPayment.ucRoundTripTripSummary1,
                    searchRoundTrip);
                paymentRetriever.PopulatePassengerAndPaymentInfo(
                    complete,
                    roundTripPayment.ucPaymentPassengerInfo1,
                    roundTripPayment,
                    checkOut);

                // Populate booking details
                paymentRetriever.PopulateBookingDetails(complete);

                // Populate return ticket information
                paymentRetriever.PopulateReturnTicketInformation(
                    complete,
                    roundTripPayment.ucRoundTripTripSummary1,
                    searchRoundTrip);
            }

            complete.BringToFront();
            complete.Visible = true;
        }

    }
}
