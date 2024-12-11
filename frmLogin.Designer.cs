namespace Ferry_Ticketing_App
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLoginBG = new System.Windows.Forms.Panel();
            this.pnlLoginPlaceholder = new System.Windows.Forms.Panel();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.pbView = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblErrorUser = new System.Windows.Forms.Label();
            this.lblErrorPass = new System.Windows.Forms.Label();
            this.pnlLoginBG.SuspendLayout();
            this.pnlLoginPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoginBG
            // 
            this.pnlLoginBG.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoginBG.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.loginformbg2;
            this.pnlLoginBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlLoginBG.Controls.Add(this.pnlLoginPlaceholder);
            this.pnlLoginBG.Location = new System.Drawing.Point(23, 28);
            this.pnlLoginBG.Name = "pnlLoginBG";
            this.pnlLoginBG.Size = new System.Drawing.Size(752, 460);
            this.pnlLoginBG.TabIndex = 5;
            // 
            // pnlLoginPlaceholder
            // 
            this.pnlLoginPlaceholder.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.loginbg5;
            this.pnlLoginPlaceholder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlLoginPlaceholder.Controls.Add(this.lblErrorPass);
            this.pnlLoginPlaceholder.Controls.Add(this.lblErrorUser);
            this.pnlLoginPlaceholder.Controls.Add(this.pbHide);
            this.pnlLoginPlaceholder.Controls.Add(this.pbView);
            this.pnlLoginPlaceholder.Controls.Add(this.btnLogin);
            this.pnlLoginPlaceholder.Controls.Add(this.txtPassword);
            this.pnlLoginPlaceholder.Controls.Add(this.txtUsername);
            this.pnlLoginPlaceholder.Location = new System.Drawing.Point(3, 16);
            this.pnlLoginPlaceholder.Name = "pnlLoginPlaceholder";
            this.pnlLoginPlaceholder.Size = new System.Drawing.Size(374, 437);
            this.pnlLoginPlaceholder.TabIndex = 0;
            // 
            // pbHide
            // 
            this.pbHide.BackColor = System.Drawing.Color.White;
            this.pbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHide.Image = global::Ferry_Ticketing_App.Properties.Resources.hide1;
            this.pbHide.Location = new System.Drawing.Point(307, 248);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(28, 29);
            this.pbHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHide.TabIndex = 0;
            this.pbHide.TabStop = false;
            this.pbHide.Click += new System.EventHandler(this.pbHide_Click);
            // 
            // pbView
            // 
            this.pbView.BackColor = System.Drawing.Color.White;
            this.pbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbView.Image = global::Ferry_Ticketing_App.Properties.Resources.view;
            this.pbView.Location = new System.Drawing.Point(306, 247);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(28, 29);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbView.TabIndex = 0;
            this.pbView.TabStop = false;
            this.pbView.Click += new System.EventHandler(this.pbView_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnlogin2;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("SF Pro Display", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(74)))), ((int)(((byte)(83)))));
            this.btnLogin.Location = new System.Drawing.Point(107, 336);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(147, 49);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("SF Pro Display", 18.5F);
            this.txtPassword.Location = new System.Drawing.Point(41, 247);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(293, 30);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Click += new System.EventHandler(this.TxtPassword_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("SF Pro Display", 18F);
            this.txtUsername.Location = new System.Drawing.Point(41, 174);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(293, 29);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Click += new System.EventHandler(this.TxtUsername_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Ferry_Ticketing_App.Properties.Resources.x;
            this.btnMinimize.Location = new System.Drawing.Point(771, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 24);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Ferry_Ticketing_App.Properties.Resources.minimize;
            this.btnClose.Location = new System.Drawing.Point(742, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblErrorUser
            // 
            this.lblErrorUser.AutoSize = true;
            this.lblErrorUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUser.ForeColor = System.Drawing.Color.White;
            this.lblErrorUser.Location = new System.Drawing.Point(38, 151);
            this.lblErrorUser.Name = "lblErrorUser";
            this.lblErrorUser.Size = new System.Drawing.Size(83, 20);
            this.lblErrorUser.TabIndex = 3;
            this.lblErrorUser.Text = "Username";
            // 
            // lblErrorPass
            // 
            this.lblErrorPass.AutoSize = true;
            this.lblErrorPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPass.ForeColor = System.Drawing.Color.White;
            this.lblErrorPass.Location = new System.Drawing.Point(38, 223);
            this.lblErrorPass.Name = "lblErrorPass";
            this.lblErrorPass.Size = new System.Drawing.Size(78, 20);
            this.lblErrorPass.TabIndex = 3;
            this.lblErrorPass.Text = "Password";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.LoginFormbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlLoginBG);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.pnlLoginBG.ResumeLayout(false);
            this.pnlLoginPlaceholder.ResumeLayout(false);
            this.pnlLoginPlaceholder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginBG;
        private System.Windows.Forms.Panel pnlLoginPlaceholder;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblErrorPass;
        private System.Windows.Forms.Label lblErrorUser;
    }
}