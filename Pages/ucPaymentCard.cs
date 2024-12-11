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
        private Random random = new Random();
        private int captchaNumber1;
        private int captchaNumber2;

        public ucPaymentCard()
        {
            InitializeComponent();

            // Add validation events for each textbox
            txtPaymentCardFName.KeyPress += ValidateLettersOnly;
            txtPaymentCardLName.KeyPress += ValidateLettersOnly;
            txtPaymentCardNo.KeyPress += ValidateNumbersOnly;
            txtPaymentCardCVV.KeyPress += ValidateNumbersOnly;

            // Set up expiration date formatting
            txtPaymentCardExpDate.MaxLength = 5; // MM/YY format
            txtPaymentCardExpDate.KeyPress += ValidateExpDate;
            txtPaymentCardExpDate.TextChanged += FormatExpDate;

            // Set CVV max length
            txtPaymentCardCVV.MaxLength = 3;

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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateExpDate(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void FormatExpDate(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = new string(textBox.Text.Where(c => char.IsDigit(c) || c == '/').ToArray());

            if (text.Length > 0)
            {
                // Handle month validation
                if (text.Length >= 2)
                {
                    int month;
                    if (int.TryParse(text.Substring(0, 2), out month))
                    {
                        if (month < 1 || month > 12)
                        {
                            MessageBox.Show("Please enter a valid month (01-12)", "Invalid Month", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Text = "";
                            return;
                        }
                    }
                }

                if (text.Length <= 2)
                {
                    textBox.Text = text;
                }
                else
                {
                    // Ensure there's only one forward slash
                    if (!text.Contains("/"))
                    {
                        textBox.Text = text.Substring(0, 2) + "/" + text.Substring(2);
                    }
                    else
                    {
                        string[] parts = text.Split('/');
                        if (parts.Length == 2 && parts[1].Length > 2)
                        {
                            parts[1] = parts[1].Substring(0, 2);
                        }
                        textBox.Text = string.Join("/", parts);
                    }
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
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

                if (!ValidateCaptcha())
                {
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
