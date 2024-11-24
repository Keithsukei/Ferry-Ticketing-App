using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.Pages.ucIndividualTrips;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucDepartureSummary : UserControl
    {
        private bool isTripSelected = false;

        public ucDepartureSummary()
        {
            InitializeComponent();
        }
        public void UpdateDepartureDetails(TripDetails tripDetails)
        {
            if (tripDetails != null)
            {

                foreach (Control ctrl in pnlDepDropDownSelected.Controls)
                {
                    if (ctrl is Label label)
                    {
                        switch (label.Name)
                        {
                            case "lblFromPortName":
                                label.Text = tripDetails.FromPortName;
                                AdjustLabelAndArrow(lblFromPortName, pbArrowRight);
                                break;
                            case "lblToPortName":
                                label.Text = tripDetails.ToPortName;
                                AdjustLabelAndArrow(lblToPortName, pbArrowRight, true);
                                break;
                        }
                    }
                }
                    
                lblDVesselName.Text = tripDetails.VesselName;
                lblDSeatType.Text = tripDetails.SeatType;
                lblDepartureDate.Text = tripDetails.DepartureDate.ToString("yyyy-MM-dd HH:mm");
                lblDepartTo.Text = tripDetails.DepartTo;
                lblDepartFrom.Text = tripDetails.DepartFrom;
                lblDAircon.Text = "Yes"; // Always "Yes"
                lblDPrice.Text = tripDetails.Price.ToString();

                // Show the selected dropdown panel and hide the no-selected panel
                pnlDepDropDownSelected.Visible = true;
                pnlDepDropDownNoSelected.Visible = false;

                isTripSelected = true;
            }
        }

        public void ClearSummary()
        {
            pnlDepDropDownNoSelected.Visible = true;
        }

        private void AdjustLabelAndArrow(Label label, PictureBox arrow, bool isDestination = false)
        {
            int padding = 10; // Gap between the label and the arrow
            if (isDestination)
            {
                label.Left = arrow.Right + padding; // Position destination label to the right of the arrow
            }
            else
            {
                label.Left = 20; // Reset 'From' label to its starting position
                arrow.Left = label.Right + padding; // Adjust arrow position
            }
        }

        private void btnDepartureOpen_Click(object sender, EventArgs e)
        {
            // Only toggle dropdowns if a trip has been selected
            if (isTripSelected)
            {
                pnlDepDropDownSelected.Visible = false;
            }
            else
            {
                pnlDepDropDownNoSelected.Visible = false;
            }
            btnDepartureClosed.BringToFront();
        }

        private void btnDepartureClosed_Click(object sender, EventArgs e)
        {
            // Only toggle dropdowns if a trip has been selected
            if (isTripSelected)
            {
                pnlDepDropDownSelected.Visible = true;
            }
            else
            {
                pnlDepDropDownNoSelected.Visible = true;
            }
            btnDepartureOpen.BringToFront();
        }
    }
}
