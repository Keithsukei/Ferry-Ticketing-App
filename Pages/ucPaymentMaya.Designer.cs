﻿namespace Ferry_Ticketing_App.Pages
{
    partial class ucPaymentMaya
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
            this.txtPaymentMayaFName = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaLName = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaAccountNo = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaOTP = new System.Windows.Forms.TextBox();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.cbImNotARobot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPaymentMayaFName
            // 
            this.txtPaymentMayaFName.BackColor = System.Drawing.Color.White;
            this.txtPaymentMayaFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentMayaFName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMayaFName.Location = new System.Drawing.Point(65, 115);
            this.txtPaymentMayaFName.Name = "txtPaymentMayaFName";
            this.txtPaymentMayaFName.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentMayaFName.TabIndex = 2;
            // 
            // txtPaymentMayaLName
            // 
            this.txtPaymentMayaLName.BackColor = System.Drawing.Color.White;
            this.txtPaymentMayaLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentMayaLName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMayaLName.Location = new System.Drawing.Point(292, 115);
            this.txtPaymentMayaLName.Name = "txtPaymentMayaLName";
            this.txtPaymentMayaLName.Size = new System.Drawing.Size(158, 33);
            this.txtPaymentMayaLName.TabIndex = 2;
            // 
            // txtPaymentMayaAccountNo
            // 
            this.txtPaymentMayaAccountNo.BackColor = System.Drawing.Color.White;
            this.txtPaymentMayaAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentMayaAccountNo.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMayaAccountNo.Location = new System.Drawing.Point(65, 208);
            this.txtPaymentMayaAccountNo.Name = "txtPaymentMayaAccountNo";
            this.txtPaymentMayaAccountNo.Size = new System.Drawing.Size(385, 33);
            this.txtPaymentMayaAccountNo.TabIndex = 2;
            // 
            // txtPaymentMayaOTP
            // 
            this.txtPaymentMayaOTP.BackColor = System.Drawing.Color.White;
            this.txtPaymentMayaOTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentMayaOTP.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMayaOTP.Location = new System.Drawing.Point(65, 290);
            this.txtPaymentMayaOTP.Name = "txtPaymentMayaOTP";
            this.txtPaymentMayaOTP.Size = new System.Drawing.Size(153, 33);
            this.txtPaymentMayaOTP.TabIndex = 2;
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnSendOtp;
            this.btnSendOTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSendOTP.FlatAppearance.BorderSize = 0;
            this.btnSendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOTP.Location = new System.Drawing.Point(321, 284);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(133, 44);
            this.btnSendOTP.TabIndex = 3;
            this.btnSendOTP.UseVisualStyleBackColor = true;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // cbImNotARobot
            // 
            this.cbImNotARobot.BackColor = System.Drawing.Color.Transparent;
            this.cbImNotARobot.FlatAppearance.BorderSize = 0;
            this.cbImNotARobot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbImNotARobot.ForeColor = System.Drawing.Color.Black;
            this.cbImNotARobot.Location = new System.Drawing.Point(57, 344);
            this.cbImNotARobot.Name = "cbImNotARobot";
            this.cbImNotARobot.Size = new System.Drawing.Size(10, 11);
            this.cbImNotARobot.TabIndex = 5;
            this.cbImNotARobot.UseVisualStyleBackColor = false;
            // 
            // ucPaymentMaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentMaya;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.cbImNotARobot);
            this.Controls.Add(this.btnSendOTP);
            this.Controls.Add(this.txtPaymentMayaLName);
            this.Controls.Add(this.txtPaymentMayaAccountNo);
            this.Controls.Add(this.txtPaymentMayaOTP);
            this.Controls.Add(this.txtPaymentMayaFName);
            this.DoubleBuffered = true;
            this.Name = "ucPaymentMaya";
            this.Size = new System.Drawing.Size(512, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPaymentMayaFName;
        public System.Windows.Forms.TextBox txtPaymentMayaLName;
        public System.Windows.Forms.TextBox txtPaymentMayaAccountNo;
        public System.Windows.Forms.TextBox txtPaymentMayaOTP;
        public System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.CheckBox cbImNotARobot;
    }
}
