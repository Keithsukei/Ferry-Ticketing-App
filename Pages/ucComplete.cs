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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucComplete : UserControl
    {

        public ucComplete()
        {
            InitializeComponent();
        }

        public void SetupTickets(int numberOfPassengers, List<Passenger> passengers)
        {
            var searchRoundTrip = this.Parent.Controls.OfType<ucSearchRoundTrip>().FirstOrDefault();
            var searchOneWay = this.Parent.Controls.OfType<ucSearchOneWayTrip>().FirstOrDefault();
            var roundTripPayment = this.Parent.Controls.OfType<ucRoundTripPayment>().FirstOrDefault();
            var oneWayPayment = this.Parent.Controls.OfType<ucOneWTripPayment>().FirstOrDefault();
            var checkOut = this.Parent.Controls.OfType<ucCheckout>().FirstOrDefault();
            var contactInfo = this.Parent.Controls.OfType<ucPassengerContactInfo>().FirstOrDefault();
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var findtrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            bool isRoundTrip = findtrips.rbRoundTrip.Checked;

            // Clear existing tickets except the first one
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

            int padding = 20;
            int bottomPadding = 70;
            int topPosition = firstTicket.Bottom + padding;

            // For each passenger, create tickets
            for (int i = 0; i < numberOfPassengers; i++)
            {
                // Handle first passenger's departure ticket (already exists)
                if (i == 0)
                {
                    if (isRoundTrip)
                    {
                        paymentRetriever.PopulateTicketInformation(
                            firstTicket,
                            roundTripPayment.ucRoundTripTripSummary1,
                            searchRoundTrip,
                            i);

                        paymentRetriever.PopulatePassengerAndPaymentInfo(
                            firstTicket,
                            roundTripPayment.ucPaymentPassengerInfo1,
                            roundTripPayment,
                            checkOut,
                            contactInfo.ucPassengerDetails1,
                            searchRoundTrip.ucDepartureSummary1,
                            i);
                    }
                    else
                    {
                        paymentRetriever.PopulateTicketInformation(
                            firstTicket,
                            oneWayPayment.ucOneWTripSummary1,
                            searchOneWay,
                            i);

                        paymentRetriever.PopulatePassengerAndPaymentInfo(
                            firstTicket,
                            oneWayPayment.ucPaymentPassengerInfo1,
                            oneWayPayment,
                            checkOut,
                            contactInfo.ucPassengerDetails1,
                            searchOneWay.ucDepartureSummary1,
                            i);
                    }
                    paymentRetriever.PopulateBookingDetails(firstTicket);

                    // Create return ticket for first passenger if round trip
                    if (isRoundTrip)
                    {
                        var returnTicket = new ucTicket
                        {
                            Name = $"ucTicket1.2",
                            Location = new Point(firstTicket.Left, topPosition),
                            Width = firstTicket.Width,
                            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                        };

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

                        pnlComplete.Controls.Add(returnTicket);
                        topPosition = returnTicket.Bottom + padding;
                    }
                }
                else
                {
                    // Create departure ticket for additional passengers
                    var departureTicket = new ucTicket
                    {
                        Name = $"ucTicket{i + 1}.1",
                        Location = new Point(firstTicket.Left, topPosition),
                        Width = firstTicket.Width,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                    };

                    if (isRoundTrip)
                    {
                        paymentRetriever.PopulateTicketInformation(
                            departureTicket,
                            roundTripPayment.ucRoundTripTripSummary1,
                            searchRoundTrip,
                            i);

                        paymentRetriever.PopulatePassengerAndPaymentInfo(
                            departureTicket,
                            roundTripPayment.ucPaymentPassengerInfo1,
                            roundTripPayment,
                            checkOut,
                            contactInfo.ucPassengerDetails1,
                            searchRoundTrip.ucDepartureSummary1,
                            i);
                    }
                    else
                    {
                        paymentRetriever.PopulateTicketInformation(
                            departureTicket,
                            oneWayPayment.ucOneWTripSummary1,
                            searchOneWay,
                            i);

                        paymentRetriever.PopulatePassengerAndPaymentInfo(
                            departureTicket,
                            oneWayPayment.ucPaymentPassengerInfo1,
                            oneWayPayment,
                            checkOut,
                            contactInfo.ucPassengerDetails1,
                            searchOneWay.ucDepartureSummary1,
                            i);
                    }
                    paymentRetriever.PopulateBookingDetails(departureTicket);

                    pnlComplete.Controls.Add(departureTicket);
                    topPosition = departureTicket.Bottom + padding;

                    // Create return ticket if round trip
                    if (isRoundTrip)
                    {
                        var returnTicket = new ucTicket
                        {
                            Name = $"ucTicket{i + 1}.2",
                            Location = new Point(firstTicket.Left, topPosition),
                            Width = firstTicket.Width,
                            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                        };

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

                        pnlComplete.Controls.Add(returnTicket);
                        topPosition = returnTicket.Bottom + padding;
                    }
                }
            }

            // Update buttons position
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

        public class FerryTicket : Ticket
        {
            public FerryTicket(int ticketNumber, int bookingID, string contactPerson,
                DateTime bookingDate, string tripType, string destination, int orNumber)
                : base(ticketNumber, bookingID, contactPerson, bookingDate, tripType, destination, orNumber)
            {
            }

            public override bool Validate()
            {
                return TicketNumber > 0 &&
                       BookingID > 0 &&
                       !string.IsNullOrEmpty(ContactPerson) &&
                       BookingDate != default;
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            
            GetAllInfoForTicket.ResetAllControls(this);

            findTrips.Visible = true;
            findTrips.BringToFront();
        }

        private List<T> GetAllControlsOfType<T>(Control parent) where T : Control
        {
            var controls = new List<T>();
            foreach (Control control in parent.Controls)
            {
                if (control is T typedControl)
                {
                    controls.Add(typedControl);
                }
                else
                {
                    controls.AddRange(GetAllControlsOfType<T>(control));
                }
            }
            return controls;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var tickets = pnlComplete.Controls.OfType<ucTicket>().ToList();
                if (!tickets.Any())
                {
                    MessageBox.Show("No tickets found to download.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    var firstTicket = tickets.First();
                    var bookingRef = firstTicket.Controls.Find("lblBBookingRef", true).FirstOrDefault()?.Text ?? "Unknown";
                    saveDialog.FileName = $"Tickets_{bookingRef}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        TicketPdfGenerator.GenerateTicketPdf(tickets.Cast<Control>().ToList(), saveDialog.FileName);

                        MessageBox.Show("Tickets have been successfully downloaded!", "Download Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading tickets: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandlePrintTicket(complete);
        }
    }
}
