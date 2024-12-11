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
    public partial class ucPaymentMaya : UserControl
    {
        private string generatedOTP;
        private Random random = new Random();
        private int captchaNumber1;
        private int captchaNumber2;

        public ucPaymentMaya()
        {
            InitializeComponent();

            // Add validation events for name fields
            txtPaymentMayaFName.KeyPress += ValidateLettersOnly;
            txtPaymentMayaLName.KeyPress += ValidateLettersOnly;
            txtPaymentMayaOTP.KeyPress += ValidateNumbersOnly;
            txtPaymentMayaAccountNo.KeyPress += ValidateNumbersOnly;

            // Set up CAPTCHA verification
            GenerateNewCaptcha();
            cbImNotARobot.CheckedChanged += CaptchaCheckChanged;
        }

        private void GenerateNewCaptcha()
        {
            captchaNumber1 = random.Next(1, 10);
            captchaNumber2 = random.Next(1, 10);
            lblCaptcha.Text = $"What is {captchaNumber1} + {captchaNumber2}?";
            lblCaptcha.Visible = false;
            txtCaptchaAnswer.Clear();
            txtCaptchaAnswer.Visible = false;
        }

        private void CaptchaCheckChanged(object sender, EventArgs e)
        {
            if (cbImNotARobot.Checked)
            {
                txtCaptchaAnswer.Visible = true;
                lblCaptcha.Visible = true;
                txtCaptchaAnswer.Focus();
            }
            else
            {
                txtCaptchaAnswer.Visible = false;
                txtCaptchaAnswer.Clear();
                lblCaptcha.Visible = false;
            }
        }

        public bool ValidateCaptcha()
        {
            if (!cbImNotARobot.Checked)
            {
                MessageBox.Show("Please verify that you are not a robot.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (int.TryParse(txtCaptchaAnswer.Text, out int answer))
            {
                if (answer == captchaNumber1 + captchaNumber2)
                {
                    return true;
                }
            }

            MessageBox.Show("Incorrect answer. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GenerateNewCaptcha();
            cbImNotARobot.Checked = false;
            return false;
        }

        private void ValidateLettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateNumbersOnly(object sender, KeyPressEventArgs e)
        {
            // Allow backspace and plus sign (for +63 format)
            if (e.KeyChar == '+' && txtPaymentMayaAccountNo.Text.Length == 0)
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void btnSendOTP_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            generatedOTP = random.Next(100000, 999999).ToString();

            MessageBox.Show($"Your OTP code is: {generatedOTP}", "OTP Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ValidateMayaFields()
        {
            // Validate CAPTCHA first
            if (!ValidateCaptcha())
            {
                return false;
            }

            // Validate name fields
            if (string.IsNullOrWhiteSpace(txtPaymentMayaFName.Text) ||
                string.IsNullOrWhiteSpace(txtPaymentMayaLName.Text))
            {
                MessageBox.Show("Name fields cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate phone number format
            string phoneNumber = txtPaymentMayaAccountNo.Text.Trim();
            bool isValidFormat = false;

            if (phoneNumber.StartsWith("+63") && phoneNumber.Length == 13 &&
                phoneNumber.Substring(3).All(char.IsDigit))
            {
                isValidFormat = true;
            }
            else if (phoneNumber.StartsWith("09") && phoneNumber.Length == 11 &&
                     phoneNumber.All(char.IsDigit))
            {
                isValidFormat = true;
            }
            else if (phoneNumber.StartsWith("9") && phoneNumber.Length == 10 &&
                     phoneNumber.All(char.IsDigit))
            {
                isValidFormat = true;
            }

            if (!isValidFormat)
            {
                MessageBox.Show("Please enter a valid Philippines mobile number.\nValid formats:\n" +
                              "+63XXXXXXXXXX (10 digits after +63)\n" +
                              "09XXXXXXXXX (9 digits after 09)\n" +
                              "9XXXXXXXXX (9 digits after 9)",
                              "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if OTP field is filled
            return !string.IsNullOrEmpty(txtPaymentMayaOTP.Text);
        }

        public bool IsOTPValid()
        {
            if (string.IsNullOrEmpty(txtPaymentMayaOTP.Text))
            {
                MessageBox.Show("Please enter the OTP.", "OTP Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPaymentMayaOTP.Text != generatedOTP)
            {
                MessageBox.Show("Incorrect OTP! Please try again.", "Invalid OTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
