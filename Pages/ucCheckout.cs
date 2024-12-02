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
using static Ferry_Ticketing_App.GetAllInfoForTicket;
using static Ferry_Ticketing_App.GetAllInfoForTicket.DepartureTicketInfo;

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
            var contactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            UserControl currentPaymentControl = pnlCheckout.Controls.OfType<UserControl>()
                .FirstOrDefault(c => c.Visible &&
                    (c is ucPaymentCard || c is ucPaymentGcash || c is ucPaymentMaya));
            bool isValid = false;
            string errorMessage = "Please complete all payment details";
            if (currentPaymentControl is ucPaymentCard cardPayment)
            {
                isValid = cardPayment.AreCardFieldsFilled();
                errorMessage = "Please complete all card payment details";
            }
            else if (currentPaymentControl is ucPaymentGcash gcashPayment)
            {
                isValid = gcashPayment.ValidateGcashFields() && gcashPayment.IsOTPValid();
                errorMessage = "Please complete all Gcash payment details and verify OTP";
            }
            else if (currentPaymentControl is ucPaymentMaya mayaPayment)
            {
                isValid = mayaPayment.ValidateMayaFields() && mayaPayment.IsOTPValid();
                errorMessage = "Please complete all Maya payment details and verify OTP";
            }
            if (!isValid)
            {
                MessageBox.Show(errorMessage,
                    "Incomplete Payment Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            List<Passenger> epassengers = new List<Passenger>();
            foreach (ucPassengerDetails passengerControl in contactInfo.pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
            {
                Passenger passenger = passengerControl.GetPassengerDetails();
                if (passenger != null)
                {
                    Console.WriteLine($"Passenger: {passenger.FirstName}, {passenger.MiddleInitial}, {passenger.LastName}");
                    epassengers.Add(passenger);
                }
                else
                {
                    Console.WriteLine("No passenger details found for this control.");
                }
            }
            if (complete.ucTicket1 != null)
            {
                complete.ucTicket1.Controls.Clear();
                for (int i = 0; i < epassengers.Count; i++)
                {
                    ucTicket ticketControl = new ucTicket();
                    ticketControl.Name = $"ucTicket{i + 1}";
                    Passenger passenger = epassengers[i];
                    paymentRetriever.PopulateTicketInformation(
                        complete,
                        roundTripPayment.ucRoundTripTripSummary1,
                        searchRoundTrip,
                        complete.ucTicket1);
                    paymentRetriever.PopulatePassengerAndPaymentInfo(
                        complete.ucTicket1,
                        roundTripPayment.ucPaymentPassengerInfo1,
                        roundTripPayment,
                        checkOut,
                        contactInfo.ucPassengerDetails1,
                        searchRoundTrip.ucDepartureSummary1);
                    paymentRetriever.PopulateBookingDetails(complete.ucTicket1);
                    complete.ucTicket1.Controls.Add(ticketControl);
                }
                complete.ucTicket1.Refresh();
            }
            complete.SetupTickets(epassengers.Count, epassengers);
            complete.BringToFront();
            complete.Visible = true;
        }

    }
}
