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
using static Ferry_Ticketing_App.Classes.Ticket;
using static Ferry_Ticketing_App.GetAllInfoForTicket;
using static Ferry_Ticketing_App.GetAllInfoForTicket.DepartureTicketInfo;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucComplete : UserControl
    {
        private ITicketDataManager ticketDataManager;

        public ucComplete()
        {
            InitializeComponent();
        }

        public void SetupTickets(int numberOfPassengers, List<Passenger> passengers)
        {
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            var contactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            var existingTickets = pnlComplete.Controls.OfType<ucTicket>()
                .Where(ticket => ticket.Name != "ucTicket1")
                .ToList();
            foreach (var ticket in existingTickets)
            {
                pnlComplete.Controls.Remove(ticket);
                ticket.Dispose();
            }
            var firstTicket = pnlComplete.Controls["ucTicket1"] as ucTicket;
            if (firstTicket == null) return;
            int padding = 20; // Space between tickets
            int bottomPadding = 70; // Extra space at the bottom
            int topPosition = firstTicket.Bottom + padding;
            // Populate the first ticket with the first passenger's information
            if (passengers.Count > 0)
            {
                paymentRetriever.PopulateTicketInformation(
                    complete,
                    roundTripPayment.ucRoundTripTripSummary1,
                    searchRoundTrip,
                    firstTicket,
                    1);
                paymentRetriever.PopulatePassengerAndPaymentInfo(
                    firstTicket,
                    roundTripPayment.ucPaymentPassengerInfo1,
                    roundTripPayment,
                    checkOut,
                    contactInfo.ucPassengerDetails1,
                    searchRoundTrip.ucDepartureSummary1,
                    1);
                paymentRetriever.PopulateBookingDetails(firstTicket);
            }
            for (int i = 2; i <= numberOfPassengers; i++)
            {
                var newTicket = new ucTicket
                {
                    Name = $"ucTicket{i}",
                    Location = new Point(firstTicket.Left, topPosition),
                    Width = firstTicket.Width,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                if (i - 1 < passengers.Count)
                {
                    paymentRetriever.PopulateTicketInformation(
                        complete,
                        roundTripPayment.ucRoundTripTripSummary1,
                        searchRoundTrip,
                        newTicket,
                        i);
                    paymentRetriever.PopulatePassengerAndPaymentInfo(
                        newTicket,
                        roundTripPayment.ucPaymentPassengerInfo1,
                        roundTripPayment,
                        checkOut,
                        contactInfo.ucPassengerDetails1,
                        searchRoundTrip.ucDepartureSummary1,
                        i);
                    paymentRetriever.PopulateBookingDetails(newTicket);
                }
                pnlComplete.Controls.Add(newTicket);
                topPosition = newTicket.Bottom + padding;
            }
            if (btnBackToHome != null && btnDownload != null && btnPrint != null)
            {
                int buttonY = topPosition + padding;
                btnBackToHome.Top = buttonY;
                btnDownload.Top = buttonY;
                btnPrint.Top = buttonY;
                btnBackToHome.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            int totalContentHeight = btnBackToHome.Bottom + bottomPadding;
            pnlComplete.Height = totalContentHeight;
            pnlComplete.PerformLayout();
            pnlComplete.Refresh();
        }


        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            var ticket = this.Parent.Controls.OfType<ucTicket>().FirstOrDefault();

            if (ticket == null)
            {
                return;
            }

            if (complete != null && findTrips != null)
            {
                var paymentRetriever = new GetAllInfoForTicket();
                paymentRetriever.HandleBackToHome(this, complete, findTrips);

                try
                {
                    TicketData newTicket = new TicketData
                    {
                        TransactionNo = ticket.lblBTransactionNo.Text,
                        ORNo = ticket.lblPaymentORNo.Text,
                        ContactPerson = ticket.lblPDContactPerson.Text,
                        DepartureDate = ticket.lblDepartureDate.Text,
                        ETA = ticket.lblETA.Text,
                        DateBooked = ticket.lblBBookingDate.Text
                    };

                    newTicket.AddTicketData(
                        newTicket.TransactionNo,
                        newTicket.ORNo,
                        newTicket.ContactPerson,
                        newTicket.DepartureDate,
                        newTicket.ETA,
                        newTicket.DateBooked
                    );

                    ((History)Parent).UpdateDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Required controls not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandleDownloadTicket(complete);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandlePrintTicket(complete);
        }
    }
}
