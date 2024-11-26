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
    public partial class ucPaymentCard : UserControl
    {
        public ucPaymentCard()
        {
            InitializeComponent();
        }
        public bool AreCardFieldsFilled()
        {
            var cardControl = this.Controls.OfType<ucPaymentCard>().FirstOrDefault();
            if (cardControl != null)
            {
                // Validate numeric fields
                if (!int.TryParse(cardControl.txtPaymentCardNo.Text, out _))
                {
                    MessageBox.Show("Card number must contain only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!int.TryParse(cardControl.txtPaymentCardCVV.Text, out _))
                {
                    MessageBox.Show("CVV must contain only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return !string.IsNullOrEmpty(cardControl.txtPaymentCardFName.Text) &&
                       !string.IsNullOrEmpty(cardControl.txtPaymentCardLName.Text) &&
                       !string.IsNullOrEmpty(cardControl.txtPaymentCardNo.Text) &&
                       !string.IsNullOrEmpty(cardControl.txtPaymentCardExpDate.Text) &&
                       !string.IsNullOrEmpty(cardControl.txtPaymentCardCVV.Text);
            }
            return true;
        }
    }
}
