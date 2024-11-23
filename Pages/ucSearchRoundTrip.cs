using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucSearchRoundTrip : UserControl
    {

        public ucSearchRoundTrip()
        {
            InitializeComponent();
        }

        public void UpdateItinerary(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate, DateTime returnDate)
        {
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblFromCode":
                            label.Text = fromCode;
                            break;
                        case "lblToCode":
                            label.Text = toCode;
                            break;
                        case "lblFromCity":
                            label.Text = fromCity;
                            break;
                        case "lblToCity":
                            label.Text = toCity;
                            break;
                        case "lblNoOfPassengers":
                            label.Text = passengers.ToString();
                            break;
                        case "lblDepartureDate":
                            label.Text = departDate.ToString("yyyy-MM-dd");
                            break;
                        case "lblReturnDate":
                            label.Text = returnDate.ToString("yyyy-MM-dd");
                            break;
                    }
                }
            }
        }

        private void btnModifyItinerary_Click(object sender, EventArgs e)
        {
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();

            if (findTrips != null)
            {
                findTrips.BringToFront();
                findTrips.Visible = true;

                // Update the number of passengers based on the input field (if available)
                int passengers = int.TryParse(findTrips.txtPassengers.Text, out int result) ? result : 1;

                foreach (var tripControl in this.Parent.Controls.OfType<ucIndividualTrips>())
                {
                    // Update trip details for all instances
                    lblNoOfPassengers.Text = passengers.ToString();
                    tripControl.RecalculateTripDetails(DateTime.Now); // Replace DateTime.Now with the appropriate date
                }
            }
        }
    }
}
