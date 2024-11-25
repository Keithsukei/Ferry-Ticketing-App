using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferry_Ticketing_App.Pages.ucIndividualTrips;

namespace Ferry_Ticketing_App.Pages
{
    public partial class ucRoundTripTripSummary : UserControl
    {
        public ucRoundTripTripSummary()
        {
            InitializeComponent();

            // Assuming you want to iterate over all labels in the UserControl
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    switch (label.Name)
                    {
                        case "lblDepFromPort":
                            AdjustLabelAndArrow(lblDepFromPort, pbDepArrowRight);
                            break;
                        case "lblDepToPort":
                            AdjustLabelAndArrow(lblDepToPort, pbDepArrowRight, true);
                            break;
                        case "lblRetFromPort":
                            AdjustLabelAndArrow(lblRetFromPort, pbRetArrowRight);
                            break;
                        case "lblRetToPort":
                            AdjustLabelAndArrow(lblRetToPort, pbRetArrowRight, true);
                            break;
                    }
                }
            }
        }

        private void AdjustLabelAndArrow(Label label, PictureBox arrow, bool isDestination = false)
        {
            int padding = 15; // Gap between the label and the arrow
            if (isDestination)
            {
                label.Left = arrow.Right + padding; // Position destination label to the right of the arrow
            }
            else
            {
                label.Left = 50; // Reset 'From' label to its starting position
                arrow.Left = label.Right + padding; // Adjust arrow position
            }
        }
    }
}
