using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.Pages.ucIndividualTrips;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucReturnSummary : UserControl
    {
        private bool isTripSelected = false;
        public ucReturnSummary()
        {
            InitializeComponent();
        }

        public void UpdateReturnDetails(ReturnTripDetails returnTripDetails)
        {
            if (returnTripDetails != null)
            {
                lblReturnFrom.Text = returnTripDetails.FromPortName;
                lblReturnTo.Text = returnTripDetails.ToPortName;
                lblRVesselName.Text = returnTripDetails.RVesselName;

                pnlRetDropdownNoSelected.Visible = false;
                pnlRetDropdownSelected.Visible = true;
                isTripSelected = true;
            }
        }
        public void ClearSummary()
        {
            pnlRetDropdownNoSelected.Visible = true;
        }

        private void btnReturnOpen_Click(object sender, EventArgs e)
        {
            // Only toggle dropdowns if a trip has been selected
            if (isTripSelected)
            {
                pnlRetDropdownSelected.Visible = false;
            }
            else
            {
                pnlRetDropdownNoSelected.Visible = false;
            }
            btnReturnClosed.BringToFront();
        }

        private void btnReturnClosed_Click(object sender, EventArgs e)
        {
            // Only toggle dropdowns if a trip has been selected
            if (isTripSelected)
            {
                pnlRetDropdownNoSelected.Visible = true;
            }
            else
            {
                pnlRetDropdownNoSelected.Visible = true;
            }
            btnReturnOpen.BringToFront();
        }
    }
}
