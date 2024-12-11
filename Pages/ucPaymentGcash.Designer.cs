namespace Ferry_Ticketing_App.Pages
{
    partial class ucPaymentGcash
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.txtPaymentGcashLName = new System.Windows.Forms.TextBox();
            this.txtPaymentGcashAccountNo = new System.Windows.Forms.TextBox();
            this.txtPaymentGcashOTP = new System.Windows.Forms.TextBox();
            this.txtPaymentGcashFName = new System.Windows.Forms.TextBox();
            this.cbImNotARobot = new System.Windows.Forms.CheckBox();
            this.txtCaptchaAnswer = new System.Windows.Forms.TextBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnSendOtp;
            this.btnSendOTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSendOTP.FlatAppearance.BorderSize = 0;
            this.btnSendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOTP.Location = new System.Drawing.Point(320, 284);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(133, 44);
            this.btnSendOTP.TabIndex = 10;
            this.btnSendOTP.UseVisualStyleBackColor = true;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // txtPaymentGcashLName
            // 
            this.txtPaymentGcashLName.BackColor = System.Drawing.Color.White;
            this.txtPaymentGcashLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentGcashLName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentGcashLName.Location = new System.Drawing.Point(291, 114);
            this.txtPaymentGcashLName.Name = "txtPaymentGcashLName";
            this.txtPaymentGcashLName.Size = new System.Drawing.Size(158, 33);
            this.txtPaymentGcashLName.TabIndex = 6;
            // 
            // txtPaymentGcashAccountNo
            // 
            this.txtPaymentGcashAccountNo.BackColor = System.Drawing.Color.White;
            this.txtPaymentGcashAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentGcashAccountNo.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentGcashAccountNo.Location = new System.Drawing.Point(64, 207);
            this.txtPaymentGcashAccountNo.Name = "txtPaymentGcashAccountNo";
            this.txtPaymentGcashAccountNo.Size = new System.Drawing.Size(385, 33);
            this.txtPaymentGcashAccountNo.TabIndex = 7;
            // 
            // txtPaymentGcashOTP
            // 
            this.txtPaymentGcashOTP.BackColor = System.Drawing.Color.White;
            this.txtPaymentGcashOTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentGcashOTP.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentGcashOTP.Location = new System.Drawing.Point(64, 289);
            this.txtPaymentGcashOTP.Name = "txtPaymentGcashOTP";
            this.txtPaymentGcashOTP.Size = new System.Drawing.Size(153, 33);
            this.txtPaymentGcashOTP.TabIndex = 8;
            // 
            // txtPaymentGcashFName
            // 
            this.txtPaymentGcashFName.BackColor = System.Drawing.Color.White;
            this.txtPaymentGcashFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentGcashFName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentGcashFName.Location = new System.Drawing.Point(64, 114);
            this.txtPaymentGcashFName.Name = "txtPaymentGcashFName";
            this.txtPaymentGcashFName.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentGcashFName.TabIndex = 9;
            // 
            // cbImNotARobot
            // 
            this.cbImNotARobot.AutoSize = true;
            this.cbImNotARobot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.cbImNotARobot.Location = new System.Drawing.Point(56, 343);
            this.cbImNotARobot.Name = "cbImNotARobot";
            this.cbImNotARobot.Size = new System.Drawing.Size(15, 14);
            this.cbImNotARobot.TabIndex = 11;
            this.cbImNotARobot.UseVisualStyleBackColor = true;
            // 
            // txtCaptchaAnswer
            // 
            this.txtCaptchaAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaptchaAnswer.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptchaAnswer.Location = new System.Drawing.Point(49, 389);
            this.txtCaptchaAnswer.Name = "txtCaptchaAnswer";
            this.txtCaptchaAnswer.Size = new System.Drawing.Size(50, 23);
            this.txtCaptchaAnswer.TabIndex = 17;
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptcha.ForeColor = System.Drawing.Color.Black;
            this.lblCaptcha.Location = new System.Drawing.Point(52, 367);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(47, 19);
            this.lblCaptcha.TabIndex = 16;
            this.lblCaptcha.Text = "label1";
            // 
            // ucPaymentGcash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentGcash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.txtCaptchaAnswer);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.cbImNotARobot);
            this.Controls.Add(this.btnSendOTP);
            this.Controls.Add(this.txtPaymentGcashLName);
            this.Controls.Add(this.txtPaymentGcashAccountNo);
            this.Controls.Add(this.txtPaymentGcashOTP);
            this.Controls.Add(this.txtPaymentGcashFName);
            this.DoubleBuffered = true;
            this.Name = "ucPaymentGcash";
            this.Size = new System.Drawing.Size(512, 488);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnSendOTP;
        public System.Windows.Forms.TextBox txtPaymentGcashLName;
        public System.Windows.Forms.TextBox txtPaymentGcashAccountNo;
        public System.Windows.Forms.TextBox txtPaymentGcashOTP;
        public System.Windows.Forms.TextBox txtPaymentGcashFName;
        private System.Windows.Forms.CheckBox cbImNotARobot;
        private System.Windows.Forms.TextBox txtCaptchaAnswer;
        private System.Windows.Forms.Label lblCaptcha;
    }
}
