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
            var findtrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var searchOneWayTrip = this.Parent.Controls.OfType<ucSearchOneWayTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            var oneWayPayment = this.Parent.Controls.OfType<ucOneWTripPayment>().FirstOrDefault();
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var contactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
            var history = this.Parent.Controls.OfType<ucHistory>().FirstOrDefault();

            if (history == null)
            {
                history = new ucHistory();
                this.Parent.Controls.Add(history);
            }

            // Validate payment first
            UserControl currentPaymentControl = pnlCheckout.Controls.OfType<UserControl>()
                .FirstOrDefault(c => c.Visible &&
                    (c is ucPaymentCard || c is ucPaymentGcash || c is ucPaymentMaya));
            if (!ValidatePayment(currentPaymentControl))
            {
                return;
            }

            List<Passenger> passengers = GetPassengerDetails(contactInfo);
            if (passengers != null && passengers.Any())
            {
                // Add passengers to booked list only after payment validation
                foreach (var passenger in passengers)
                {
                    passenger.AddToBookedList();
                }
                
                string bookingReference = GenerateBookingReference();
                var paymentRetriever = new GetAllInfoForTicket();

                List<TicketGroup> ticketGroups = new List<TicketGroup>();

                if (complete.ucTicket1 != null)
                {
                    complete.ucTicket1.Controls.Clear();

                    bool isRoundTrip = findtrips.rbRoundTrip.Checked;
                    var tripPayment = isRoundTrip ? roundTripPayment : oneWayPayment as Control;
                    var tripSummary = isRoundTrip ? 
                        (Control)roundTripPayment?.ucRoundTripTripSummary1 : 
                        (Control)oneWayPayment?.ucOneWTripSummary1;
                    var searchTrip = isRoundTrip ? 
                        (Control)searchRoundTrip : 
                        (Control)searchOneWayTrip;

                    // Create tickets for each passenger
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        // Create departure ticket
                        var departureTicket = CreateTicket(
                            $"ucTicket{i + 1}.1", 
                            $"Passenger{i + 1}_Departure",
                            "DEPARTURE TICKET",
                            bookingReference);

                        var departureSummary = isRoundTrip ? 
                            searchRoundTrip.ucDepartureSummary1 : 
                            searchOneWayTrip.ucDepartureSummary1;

                        paymentRetriever.PopulateTicketInformation(
                            departureTicket,
                            tripSummary,
                            searchTrip,
                            i);

                        paymentRetriever.PopulatePassengerAndPaymentInfo(
                            departureTicket,
                            tripPayment?.Controls.Find($"ucPaymentPassengerInfo{i + 1}", true).FirstOrDefault() 
                                ?? tripPayment?.Controls.Find("ucPaymentPassengerInfo1", true).FirstOrDefault(),
                            tripPayment,
                            checkOut,
                            contactInfo.ucPassengerDetails1,
                            departureSummary,
                            i);

                        paymentRetriever.PopulateBookingDetails(departureTicket);
                        complete.ucTicket1.Controls.Add(departureTicket);

                        var ticketGroup = new TicketGroup { DepartureTicket = departureTicket };

                        // Create return ticket only if it's a round trip
                        if (isRoundTrip)
                        {
                            var returnTicket = CreateTicket(
                                $"ucTicket{i + 1}.2",
                                $"Passenger{i + 1}_Return",
                                "RETURN TICKET",
                                $"{bookingReference}-R");

                            paymentRetriever.PopulateReturnTicketInformation(
                                returnTicket,
                                searchRoundTrip,
                                roundTripPayment.ucRoundTripTripSummary1,
                                i);

                            paymentRetriever.PopulateReturnPassengerAndPaymentInfo(
                                returnTicket,
                                roundTripPayment.ucPaymentPassengerInfo1,
                                roundTripPayment,
                                checkOut,
                                contactInfo.ucPassengerDetails1,
                                searchRoundTrip.ucDepartureSummary1,
                                i);

                            paymentRetriever.PopulateReturnBookingDetails(returnTicket);
                            complete.ucTicket1.Controls.Add(returnTicket);

                            ticketGroup.ReturnTicket = returnTicket;
                        }

                        ticketGroups.Add(ticketGroup);
                    }
                    complete.ucTicket1.Refresh();
                }

                complete.SetupTickets(passengers.Count, passengers);
                complete.BringToFront();
                complete.Visible = true;

                // Store ticket groups in history
                if (history != null)
                {
                    history.Visible = true;
                    history.AddBookingToHistory(ticketGroups, passengers);
                }
            }
        }

        private bool ValidatePayment(UserControl currentPaymentControl)
        {
            string errorMessage = "Please complete all payment details";
            bool isValid = false;

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
                MessageBox.Show(errorMessage, "Incomplete Payment Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValid;
        }

        private List<Passenger> GetPassengerDetails(ucPassengerContactInfo contactInfo)
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (ucPassengerDetails passengerControl in contactInfo.pnlPassengerControlInfo.Controls.OfType<ucPassengerDetails>())
            {
                Passenger passenger = passengerControl.GetPassengerDetails();
                if (passenger != null)
                {
                    passengers.Add(passenger);
                }
            }
            return passengers;
        }

        private ucTicket CreateTicket(string name, string tag, string ticketType, string bookingReference)
        {
            var ticket = new ucTicket();
            ticket.Name = name;
            ticket.Tag = tag;
            SetLabelText(ticket, "lblTicketType", ticketType);
            SetLabelText(ticket, "lblBTransactionNo", bookingReference);
            return ticket;
        }

        private void SetLabelText(Control control, string labelName, string text)
        {
            var label = control.Controls.Find(labelName, true).FirstOrDefault() as Label;
            if (label != null)
            {
                label.Text = text;
            }
        }

        private string GenerateBookingReference()
        {
            // Get the count of existing history tickets
            var history = this.Parent.Controls.OfType<ucHistory>().FirstOrDefault();
            int bookingCount = history?.flpTicketContainer.Controls.Count ?? 0;
            return $"ASF-{(bookingCount + 1).ToString("0000")}";
        }
    }
}
