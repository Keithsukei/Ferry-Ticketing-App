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
    public partial class ucPaymentGcash : UserControl
    {
        private string generatedOTP;

        public ucPaymentGcash()
        {
            InitializeComponent();
        }

        public void btnSendOTP_Click(object sender, EventArgs e)
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            generatedOTP = random.Next(100000, 999999).ToString();

            // Show the generated OTP in a MessageBox (for debugging purposes)
            MessageBox.Show($"Your OTP code is: {generatedOTP}", "OTP Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool ValidateGcashFields()
        {
            // Validate numeric fields
            if (!int.TryParse(txtPaymentGcashAccountNo.Text, out _))
            {
                MessageBox.Show("Account number must contain only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if all fields are filled
            return !string.IsNullOrEmpty(txtPaymentGcashFName.Text) &&
                   !string.IsNullOrEmpty(txtPaymentGcashLName.Text) &&
                   !string.IsNullOrEmpty(txtPaymentGcashAccountNo.Text) &&
                   !string.IsNullOrEmpty(txtPaymentGcashOTP.Text);

        }

        public bool IsOTPValid()
        {
            if (string.IsNullOrEmpty(txtPaymentGcashOTP.Text))
            {
                MessageBox.Show("Please enter the OTP.", "OTP Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPaymentGcashOTP.Text != generatedOTP)
            {
                MessageBox.Show("Incorrect OTP! Please try again.", "Invalid OTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
