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
        public void UpdateSearchRoundTrip(string fromCode, string toCode, int passengers, DateTime departDate, DateTime returnDate)
        {
            if (ucSearchRoundTrip1 != null)
            {
                ucSearchRoundTrip1.SetTripDetails(
                    fromCode,
                    Ports.FindPortByName(fromCode)?.City ?? "Unknown City", // Get city using FindPortByName
                    toCode,
                    Ports.FindPortByName(toCode)?.City ?? "Unknown City", // Get city using FindPortByName
                    passengers,
                    departDate,
                    returnDate
                );
                ucSearchRoundTrip1.Visible = true;
            }
        }

    }
}
