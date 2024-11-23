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
            var modifyItinerary = this.Parent.Controls.OfType<ucIndividualTrips>().FirstOrDefault();

            // Bring the 'FindTrips' control to the front
            findTrips.BringToFront();
            findTrips.Visible = true;

            // Trigger the recalculation when switching to the Modify Itinerary page
            modifyItinerary.ClearTripDetails(); // Pass the appropriate selected date
        }
    }
}
