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
using Ferry_Ticketing_App.Classes;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucHistory : UserControl
    {
        public ucHistory()
        {
            InitializeComponent();
            flpTicketContainer.AutoScroll = true;
            flpTicketContainer.WrapContents = false;
            flpTicketContainer.FlowDirection = FlowDirection.TopDown;
        }

        public void AddBookingToHistory(List<TicketGroup> ticketGroups, List<Passenger> passengers)
        {
            try
            {
                var historyTicket = new ucHistoryTicket();
                historyTicket.Visible = true;
                
                var findtrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
                
                // Get first departure ticket
                var firstTicket = ticketGroups.FirstOrDefault()?.DepartureTicket;
                if (firstTicket != null)
                {
                    // Get booking reference
                    var bookingLabel = firstTicket.Controls.Find("lblBTransactionNo", true).FirstOrDefault() as Label;
                    if (bookingLabel != null)
                    {
                        string bookingReference = bookingLabel.Text;
                        historyTicket.lblBookingNum.Text = bookingReference;
                        historyTicket.lblBookingID.Text = bookingReference;
                    }

                    // Get contact person
                    var contactPersonLabel = firstTicket.Controls.Find("lblPDContactPerson", true).FirstOrDefault() as Label;
                    if (contactPersonLabel != null)
                    {
                        historyTicket.lblContactPerson.Text = contactPersonLabel.Text;
                    }

                    // Get destination
                    var destinationLabel = firstTicket.Controls.Find("lblTo", true).FirstOrDefault() as Label;
                    if (destinationLabel != null)
                    {
                        historyTicket.lblDestination.Text = destinationLabel.Text;
                    }
                }

                // Set date booked
                historyTicket.lblDateBooked.Text = DateTime.Now.ToString("MM/dd/yyyy");

                // Set trip type
                historyTicket.lblTripType.Text = findtrips?.rbRoundTrip.Checked == true ? "Round Trip" : "One Way";

                // Set number of passengers
                historyTicket.lblNoOfPassengers.Text = passengers.Count.ToString();

                // Store ticket groups in the history ticket's Tag property
                historyTicket.Tag = ticketGroups;
                historyTicket.SetTicketGroups(ticketGroups);

                // Add to flow layout panel
                flpTicketContainer.Controls.Add(historyTicket);
                
                // Force layout update
                flpTicketContainer.PerformLayout();
                this.PerformLayout();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding booking to history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
