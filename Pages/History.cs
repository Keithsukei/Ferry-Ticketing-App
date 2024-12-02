using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.Classes.Ticket;

namespace Ferry_Ticketing_App.Pages
{
    public partial class History : UserControl
    {
        private ITicketDataManager ticketDataManager;

        public History()
        {
            InitializeComponent();

        }

        private void History_Load(object sender, EventArgs e)
        {

        }
        public void UpdateDataGridView()
        {
            dgvHistory.DataSource = ticketDataManager.GetTicketData();
        }
    }
}
