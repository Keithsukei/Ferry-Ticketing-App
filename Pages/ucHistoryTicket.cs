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
    public partial class ucHistoryTicket : UserControl
    {
        private List<TicketGroup> ticketGroups;

        public ucHistoryTicket()
        {
            InitializeComponent();
        }

        public void SetTicketGroups(List<TicketGroup> groups)
        {
            ticketGroups = groups;
        }

        private void btnViewTicket_Click(object sender, EventArgs e)
        {
            try
            {
                // Debug: Check Tag content
                var ticketGroups = this.Tag as List<TicketGroup>;
                if (ticketGroups != null)
                {
                    MessageBox.Show($"Found {ticketGroups.Count} ticket groups\n" +
                        $"First ticket departure info: {ticketGroups[0].DepartureTicket?.Controls.Find("lblFrom", true).FirstOrDefault()?.Text ?? "not found"}\n" +
                        $"Has return ticket: {(ticketGroups[0].ReturnTicket != null ? "Yes" : "No")}",
                        "Debug Info");
                }
                else
                {
                    MessageBox.Show("Tag is null or not a List<TicketGroup>", "Debug Info");
                    return;
                }

                // Get the parent form
                var mainForm = this.FindForm();
                if (mainForm == null) return;

                // Find or create ucViewTickets
                var viewTickets = mainForm.Controls.Find("ucViewTickets1", true).FirstOrDefault() as ucViewTickets;
                if (viewTickets == null)
                {
                    MessageBox.Show("View tickets control not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ticketGroups.Any())
                {
                    MessageBox.Show("No tickets found for this booking.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create new instances of tickets for display
                var displayTicketGroups = new List<TicketGroup>();
                foreach (var group in ticketGroups)
                {
                    var newGroup = new TicketGroup
                    {
                        DepartureTicket = new ucTicket(),
                        ReturnTicket = group.ReturnTicket != null ? new ucTicket() : null
                    };

                    // Copy departure ticket content
                    foreach (Control control in group.DepartureTicket.Controls)
                    {
                        if (control is Label sourceLabel)
                        {
                            var destLabel = newGroup.DepartureTicket.Controls.Find(sourceLabel.Name, true).FirstOrDefault() as Label;
                            if (destLabel != null)
                            {
                                destLabel.Text = sourceLabel.Text;
                            }
                        }
                    }

                    // Copy return ticket content if exists
                    if (group.ReturnTicket != null)
                    {
                        foreach (Control control in group.ReturnTicket.Controls)
                        {
                            if (control is Label sourceLabel)
                            {
                                var destLabel = newGroup.ReturnTicket.Controls.Find(sourceLabel.Name, true).FirstOrDefault() as Label;
                                if (destLabel != null)
                                {
                                    destLabel.Text = sourceLabel.Text;
                                }
                            }
                        }
                    }

                    displayTicketGroups.Add(newGroup);
                }

                viewTickets.DisplayTickets(displayTicketGroups);
                viewTickets.BringToFront();
                viewTickets.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing tickets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var ticketGroups = Tag as List<TicketGroup>;
                if (ticketGroups == null || !ticketGroups.Any())
                {
                    MessageBox.Show("No tickets found to download.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDialog.FileName = $"Tickets_{lblBookingNum.Text}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<Control> ticketsToDownload = new List<Control>();
                        foreach (var group in ticketGroups)
                        {
                            ticketsToDownload.Add(group.DepartureTicket);
                            if (group.ReturnTicket != null)
                            {
                                ticketsToDownload.Add(group.ReturnTicket);
                            }
                        }

                        TicketPdfGenerator.GenerateTicketPdf(ticketsToDownload, saveDialog.FileName);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this booking history?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var ticketGroups = Tag as List<TicketGroup>;
                if (ticketGroups?.FirstOrDefault()?.DepartureTicket != null)
                {
                    var departureTicket = ticketGroups.First().DepartureTicket;
                    
                    string firstName = departureTicket.Controls.Find("lblPDFirstName", true).FirstOrDefault()?.Text ?? "";
                    string middleInitial = departureTicket.Controls.Find("lblPDMiddleInitial", true).FirstOrDefault()?.Text ?? "";
                    string lastName = departureTicket.Controls.Find("lblPDLastName", true).FirstOrDefault()?.Text ?? "";
                    string birthDateStr = departureTicket.Controls.Find("lblPDBirthdate", true).FirstOrDefault()?.Text ?? "";
                    DateTime dateOfBirth = DateTime.TryParse(birthDateStr, out DateTime dob) ? dob : DateTime.Now;

                    Passenger.RemoveBookedPassenger(firstName, middleInitial, lastName, dateOfBirth);

                    this.Parent.Controls.Remove(this);
                    this.Dispose();

                    MessageBox.Show(
                        "Booking history has been deleted successfully.",
                        "Delete Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
    }
}
