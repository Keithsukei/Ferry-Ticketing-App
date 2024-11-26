using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                main.Show();
                this.Hide();
            }
            else if (string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a username and password.");
            }
            else if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
            }
            else if (txtUsername.Text == "admin" && txtPassword.Text != "admin")
            {
                MessageBox.Show("Incorrect Password, Please try again.");
            }
            else if (txtUsername.Text != "admin" && txtPassword.Text == "admin")
            {
                MessageBox.Show("Incorrect Username, Please try again.");
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password, Please try again.");
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
    }
}
