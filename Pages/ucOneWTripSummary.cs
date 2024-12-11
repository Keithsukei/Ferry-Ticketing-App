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
    public partial class ucOneWTripSummary : UserControl
    {
        public ucOneWTripSummary()
        {
            InitializeComponent();

            foreach (Control ctrl in pnlDepCodeToCode.Controls)
            {
                if (ctrl is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblDepFromPort":
                            AdjustLabelAndArrow(lblDepFromPort, pbDepArrowRight);
                            break;
                        case "lblDepToPort":
                            AdjustLabelAndArrow(lblDepToPort, pbDepArrowRight, true);
                            break;
                    }
                }
            }
        }

        private void AdjustLabelAndArrow(Label label, PictureBox arrow, bool isDestination = false)
        {
            int padding = 10;
            if (isDestination)
            {
                label.Left = arrow.Right + padding;
            }
            else
            {
                label.Left = 10;
                arrow.Left = label.Right + padding;
            }
        }
    }
}
