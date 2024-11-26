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
    public partial class ucComplete : UserControl
    {
        
        public ucComplete()
        {
            InitializeComponent();
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var findTrips = this.Parent.Controls.OfType<ucFindTrips>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandleBackToHome(this, complete, findTrips);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandleDownloadTicket(complete);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var complete = this.Parent.Controls.OfType<ucComplete>().FirstOrDefault();
            var paymentRetriever = new GetAllInfoForTicket();
            paymentRetriever.HandlePrintTicket(complete);
        }
    }
}
