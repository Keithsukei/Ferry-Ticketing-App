using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferry_Ticketing_App.Classes;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucViewTickets : UserControl
    {
        public ucViewTickets()
        {
            InitializeComponent();
        }

        public void DisplayTickets(List<TicketGroup> ticketGroups)
        {
            if (ticketGroups == null || !ticketGroups.Any()) return;
            
            flpTicketView.Controls.Clear();

            // Add Departure Header
            var departureHeader = new Label
            {
                Text = "DEPARTURE TICKETS",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = flpTicketView.Width,
                BackColor = Color.Transparent
            };
            flpTicketView.Controls.Add(departureHeader);

            // Display Departure Tickets
            foreach (var group in ticketGroups)
            {
                var departureTicketCopy = new ucTicket();
                CopyTicketContent(group.DepartureTicket, departureTicketCopy);
                departureTicketCopy.Margin = new Padding((flpTicketView.Width - departureTicketCopy.Width) / 2, 10, 0, 10);
                flpTicketView.Controls.Add(departureTicketCopy);
            }

            // If there are return tickets
            if (ticketGroups.Any(g => g.ReturnTicket != null))
            {
                // Add Return Header
                var returnHeader = new Label
                {
                    Text = "RETURN TICKETS",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = flpTicketView.Width,
                    Margin = new Padding(0, 20, 0, 10),
                    BackColor = Color.Transparent
                };
                flpTicketView.Controls.Add(returnHeader);

                // Display Return Tickets
                foreach (var group in ticketGroups.Where(g => g.ReturnTicket != null))
                {
                    var returnTicketCopy = new ucTicket();
                    CopyTicketContent(group.ReturnTicket, returnTicketCopy);
                    returnTicketCopy.Margin = new Padding((flpTicketView.Width - returnTicketCopy.Width) / 2, 10, 0, 10);
                    flpTicketView.Controls.Add(returnTicketCopy);
                }
            }

            // Add Back Button
            var backButton = new Button
            {
                Text = "Back",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Size = new Size(38, 35),
                Margin = new Padding(10, 10, 0, 20),
                Cursor = Cursors.Hand
            };
            backButton.Click += (s, e) => 
            {
                var history = this.Parent.Controls.OfType<ucHistory>().FirstOrDefault();
                if (history != null)
                {
                    history.BringToFront();
                    history.Visible = true;
                    this.Visible = false;
                }
            };
            flpTicketView.Controls.Add(backButton);

            flpTicketView.Refresh();
        }

        private void CopyTicketContent(ucTicket source, ucTicket destination)
        {
            if (source == null || destination == null) return;
            
            foreach (Control sourceControl in source.Controls)
            {
                if (sourceControl is Label sourceLabel)
                {
                    var destLabel = destination.Controls.Find(sourceLabel.Name, true).FirstOrDefault() as Label;
                    if (destLabel != null)
                    {
                        destLabel.Text = sourceLabel.Text;
                    }
                }
            }
        }
    }
}
