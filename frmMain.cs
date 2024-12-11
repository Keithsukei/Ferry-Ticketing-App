using Ferry_Ticketing_App.Classes;
using Ferry_Ticketing_App.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App
{

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
            // Set default states
            btnFindTripsNB.Visible = false;
            btnBookingsWB.Visible = false;
            Passenger.ClearBookedPassengers();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnFindTripsNB_Click(object sender, EventArgs e)
        {
            var currentControl = Controls.OfType<UserControl>()
                .FirstOrDefault(c => c.Visible &&
                    (c.Name.Contains("ucSearch") ||
                     c.Name.Contains("ucComplete") ||
                     c.Name.Contains("ucCheckout") ||
                     c.Name.Contains("ucPassenger") ||
                     c.Name.Contains("ucRoundTripPayment") ||
                     c.Name.Contains("ucFindTrips")));

            if (currentControl != null)
            {
                var result = MessageBox.Show(
                    "Switching tabs will clear your current progress. Do you want to continue?",
                    "Confirm Switch",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            btnBookingsNB.Visible = true;
            btnBookingsWB.Visible = false;
            btnFindTripsNB.Visible = false;
            btnFindTripsWB.Visible = true;
            ucFindTrips1.BringToFront();
            
        }

        private void btnFindTripsWB_Click(object sender, EventArgs e)
        {
            btnBookingsWB.Visible = false;
            btnBookingsNB.Visible = true;
            ucFindTrips1.BringToFront();
        }

        private void btnBookingsNB_Click(object sender, EventArgs e)
        {
            var currentControl = Controls.OfType<UserControl>()
                .FirstOrDefault(c => c.Visible && c is ucFindTrips);

            if (currentControl != null)
            {
                var result = MessageBox.Show(
                    "Switching tabs will clear your current search. Do you want to continue?",
                    "Confirm Switch",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }
            GetAllInfoForTicket.ResetAllControls(this); 
            btnFindTripsNB.Visible = true;
            btnFindTripsWB.Visible = false;
            btnBookingsNB.Visible = false;
            btnBookingsWB.Visible = true;
            ucHistory1.BringToFront();
        }

        private void btnBookingsWB_Click(object sender, EventArgs e)
        {
            btnFindTripsWB.Visible = false;
            btnFindTripsNB.Visible = true;
            ucHistory1.BringToFront();
        }
    }
}
