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
    }
}
