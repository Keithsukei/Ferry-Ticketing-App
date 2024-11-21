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
        public void SetTripDetails(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate, DateTime returnDate)
        {
            lblFromCode.Text = fromCode;
            lblFromCity.Text = fromCity;
            lblToCode.Text = toCode;
            lblToCity.Text = toCity;
            lblNoOfPassengers.Text = passengers.ToString();
            lblDepartureDate.Text = departDate.ToString("MM/dd/yyyy");
            lblArrivalDate.Text = returnDate.ToString("MM/dd/yyyy");
        }
        public void UpdateItinerary(string fromCode, string fromCity, string toCode, string toCity, int passengers, DateTime departDate, DateTime returnDate)
        {
            foreach (Control ctrl in pnlItineraryPH.Controls)
            {
                if (ctrl is Label)
                {
                    var label = (Label)ctrl;

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
                        case "lblArrivalDate":
                            label.Text = returnDate.ToString("yyyy-MM-dd");
                            break;
                    }
                }
            }
        }

        private void btnModifyItenerary_Click(object sender, EventArgs e)
        {
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();

            findTrips.BringToFront();
            findTrips.Visible = true;
            
        }
    }
}
