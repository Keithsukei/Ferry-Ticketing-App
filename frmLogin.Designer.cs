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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pblblPassword = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pblblUsername = new System.Windows.Forms.PictureBox();
            this.pblblLogin = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLoginBG.SuspendLayout();
            this.pnlLoginPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblblPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblblUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblblLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoginBG
            // 
            this.pnlLoginBG.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoginBG.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.loginpanelbgw;
            this.pnlLoginBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLoginBG.Controls.Add(this.pnlLoginPlaceholder);
            this.pnlLoginBG.Location = new System.Drawing.Point(28, 39);
            this.pnlLoginBG.Name = "pnlLoginBG";
            this.pnlLoginBG.Size = new System.Drawing.Size(743, 437);
            this.pnlLoginBG.TabIndex = 5;
            // 
            // pnlLoginPlaceholder
            // 
            this.pnlLoginPlaceholder.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.loginpanelplaceholder;
            this.pnlLoginPlaceholder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLoginPlaceholder.Controls.Add(this.btnLogin);
            this.pnlLoginPlaceholder.Controls.Add(this.txtPassword);
            this.pnlLoginPlaceholder.Controls.Add(this.pblblPassword);
            this.pnlLoginPlaceholder.Controls.Add(this.txtUsername);
            this.pnlLoginPlaceholder.Controls.Add(this.pblblUsername);
            this.pnlLoginPlaceholder.Controls.Add(this.pblblLogin);
            this.pnlLoginPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginPlaceholder.Name = "pnlLoginPlaceholder";
            this.pnlLoginPlaceholder.Size = new System.Drawing.Size(374, 437);
            this.pnlLoginPlaceholder.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnLogin;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("SF Pro Display", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(74)))), ((int)(((byte)(83)))));
            this.btnLogin.Location = new System.Drawing.Point(114, 333);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(147, 49);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("SF Pro Display", 27.5F);
            this.txtPassword.Location = new System.Drawing.Point(41, 254);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(293, 44);
            this.txtPassword.TabIndex = 1;
            // 
            // pblblPassword
            // 
            this.pblblPassword.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.Password;
            this.pblblPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pblblPassword.Location = new System.Drawing.Point(41, 232);
            this.pblblPassword.Name = "pblblPassword";
            this.pblblPassword.Size = new System.Drawing.Size(59, 17);
            this.pblblPassword.TabIndex = 0;
            this.pblblPassword.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("SF Pro Display", 27.5F);
            this.txtUsername.Location = new System.Drawing.Point(41, 175);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(293, 44);
            this.txtUsername.TabIndex = 1;
            // 
            // pblblUsername
            // 
            this.pblblUsername.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.Username;
            this.pblblUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pblblUsername.Location = new System.Drawing.Point(41, 153);
            this.pblblUsername.Name = "pblblUsername";
            this.pblblUsername.Size = new System.Drawing.Size(63, 17);
            this.pblblUsername.TabIndex = 0;
            this.pblblUsername.TabStop = false;
            // 
            // pblblLogin
            // 
            this.pblblLogin.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.Login;
            this.pblblLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pblblLogin.Location = new System.Drawing.Point(144, 77);
            this.pblblLogin.Name = "pblblLogin";
            this.pblblLogin.Size = new System.Drawing.Size(86, 41);
            this.pblblLogin.TabIndex = 0;
            this.pblblLogin.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.pblblPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblblUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblblLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginBG;
        private System.Windows.Forms.Panel pnlLoginPlaceholder;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pblblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pblblUsername;
        private System.Windows.Forms.PictureBox pblblLogin;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
    }
}