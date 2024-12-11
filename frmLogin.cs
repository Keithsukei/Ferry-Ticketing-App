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
            
        }

        private void TxtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            lblErrorUser.Text = "Username";
            lblErrorUser.ForeColor = Color.White;
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            lblErrorPass.Text = "Password";
            lblErrorPass.ForeColor = Color.White;
            pbHide.Visible = true;
            pbView.Visible = true;
        }
    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            // Reset colors first
            txtUsername.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            lblErrorUser.Visible = false;
            lblErrorPass.Visible = false;

            // Check for empty username
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = "";
                txtUsername.BackColor = Color.FromArgb(255, 128, 128);
                lblErrorUser.Text = "Please enter username";
                lblErrorUser.ForeColor = Color.Red;
                lblErrorUser.Visible = true;
                hasError = true;
            }

            // Check for empty password
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = "";
                txtPassword.BackColor = Color.FromArgb(255, 128, 128);
                lblErrorPass.Text = "Please enter password";
                lblErrorPass.ForeColor = Color.Red;
                lblErrorPass.Visible = true;
                hasError = true;
                pbHide.Visible = false;
                pbView.Visible = false;
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
                    txtUsername.Text = "";
                    txtUsername.BackColor = Color.IndianRed;
                    lblErrorUser.Text = "Incorrect username";
                    lblErrorUser.ForeColor = Color.Red;
                    lblErrorUser.Visible = true;
                    pbHide.Visible = false;
                    pbView.Visible = false;
                }
                else if (txtUsername.Text == "admin" && txtPassword.Text != "admin")
                {
                    txtPassword.Text = "";
                    txtPassword.BackColor = Color.FromArgb(255, 128, 128);
                    lblErrorPass.Text = "Incorrect password";
                    lblErrorPass.ForeColor = Color.Red;
                    lblErrorPass.Visible = true;
                    pbHide.Visible = false;
                    pbView.Visible = false;
                }
                else if (txtUsername.Text != "admin" && txtPassword.Text != "admin")
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.BackColor = Color.FromArgb(255, 128, 128);
                    txtPassword.BackColor = Color.FromArgb(255, 128, 128);
                    lblErrorUser.Text = "Incorrect username";
                    lblErrorPass.Text = "Incorrect password";
                    lblErrorUser.ForeColor = Color.Red;
                    lblErrorPass.ForeColor = Color.Red;
                    lblErrorUser.Visible = true;
                    lblErrorPass.Visible = true;
                    pbHide.Visible = false;
                    pbView.Visible = false;
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
