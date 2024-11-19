namespace Ferry_Ticketing_App.Pages
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
            this.txtPaymentCardFName = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaLName = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaAccountNo = new System.Windows.Forms.TextBox();
            this.txtPaymentMayaOTP = new System.Windows.Forms.TextBox();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.cbImNotARobot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPaymentCardFName
            // 
            this.txtPaymentCardFName.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardFName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardFName.Location = new System.Drawing.Point(65, 115);
            this.txtPaymentCardFName.Name = "txtPaymentCardFName";
            this.txtPaymentCardFName.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentCardFName.TabIndex = 2;
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
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.FlatAppearance.BorderSize = 0;
            this.btnCompleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteOrder.Image = global::Ferry_Ticketing_App.Properties.Resources.checkoutbtnContinue;
            this.btnCompleteOrder.Location = new System.Drawing.Point(281, 403);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(194, 50);
            this.btnCompleteOrder.TabIndex = 4;
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // cbImNotARobot
            // 
            this.cbImNotARobot.AutoSize = true;
            this.cbImNotARobot.FlatAppearance.BorderSize = 0;
            this.cbImNotARobot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbImNotARobot.ForeColor = System.Drawing.Color.Transparent;
            this.cbImNotARobot.Location = new System.Drawing.Point(56, 343);
            this.cbImNotARobot.Name = "cbImNotARobot";
            this.cbImNotARobot.Size = new System.Drawing.Size(12, 11);
            this.cbImNotARobot.TabIndex = 5;
            this.cbImNotARobot.UseVisualStyleBackColor = true;
            // 
            // ucPaymentMaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentMaya;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.cbImNotARobot);
            this.Controls.Add(this.btnCompleteOrder);
            this.Controls.Add(this.btnSendOTP);
            this.Controls.Add(this.txtPaymentMayaLName);
            this.Controls.Add(this.txtPaymentMayaAccountNo);
            this.Controls.Add(this.txtPaymentMayaOTP);
            this.Controls.Add(this.txtPaymentCardFName);
            this.DoubleBuffered = true;
            this.Name = "ucPaymentMaya";
            this.Size = new System.Drawing.Size(512, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaymentCardFName;
        private System.Windows.Forms.TextBox txtPaymentMayaLName;
        private System.Windows.Forms.TextBox txtPaymentMayaAccountNo;
        private System.Windows.Forms.TextBox txtPaymentMayaOTP;
        private System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.CheckBox cbImNotARobot;
    }
}
