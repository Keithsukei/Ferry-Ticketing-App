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
    public partial class ucRoundTripTripSummary : UserControl
    {
        public ucRoundTripTripSummary()
        {
            InitializeComponent();
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
    }
}
