using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ferry_Ticketing_App
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            // Ensure error labels are not visible at the start
            lblErrorUser.Visible = false;
            lblErrorPass.Visible = false;

            // Set styles for error labels if not already configured in the designer
            lblErrorUser.ForeColor = Color.Red;

            lblErrorPass.ForeColor = Color.Red;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Hide error labels initially
            lblErrorUser.Visible = false;
            lblErrorPass.Visible = false;

            bool hasError = false;

            // Check for empty username
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                lblErrorUser.Text = "Please enter a username.";
                lblErrorUser.Visible = true;
                hasError = true;
            }

            // Check for empty password
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblErrorPass.Text = "Please enter a password.";
                lblErrorPass.Visible = true;
                hasError = true;
            }

            // If there are no errors, proceed with login validation
            if (!hasError)
            {
                // Check username and password
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                {
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }
                else if (txtUsername.Text != "admin" && txtPassword.Text == "admin")
                {
                    lblErrorUser.Text = "Incorrect Username. Please try again.";
                    lblErrorUser.Visible = true;
                }
                else if (txtUsername.Text == "admin" && txtPassword.Text != "admin")
                {
                    lblErrorPass.Text = "Incorrect Password. Please try again.";
                    lblErrorPass.Visible = true;
                }
                else if (txtUsername.Text != "admin" && txtPassword.Text != "admin")
                {
                    lblErrorUser.Text = "Incorrect Username or Password.";
                    lblErrorUser.Visible = true;

                    lblErrorPass.Text = "Incorrect Username or Password.";
                    lblErrorPass.Visible = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            pbHide.SendToBack();
            pbView.BringToFront();
        }

        private void pbView_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            pbView.SendToBack();
            pbHide.BringToFront();
        }
    }
}
