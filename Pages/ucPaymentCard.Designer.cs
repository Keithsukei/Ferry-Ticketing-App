namespace Ferry_Ticketing_App.Pages
{
    partial class ucPaymentCard
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
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.txtPaymentCardFName = new System.Windows.Forms.TextBox();
            this.txtPaymentCardLName = new System.Windows.Forms.TextBox();
            this.txtPaymentCardNo = new System.Windows.Forms.TextBox();
            this.txtPaymentCardExpDate = new System.Windows.Forms.TextBox();
            this.txtPaymentCardCVV = new System.Windows.Forms.TextBox();
            this.cbImNotARobot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.FlatAppearance.BorderSize = 0;
            this.btnCompleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteOrder.Image = global::Ferry_Ticketing_App.Properties.Resources.checkoutbtnContinue;
            this.btnCompleteOrder.Location = new System.Drawing.Point(278, 395);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(194, 50);
            this.btnCompleteOrder.TabIndex = 0;
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // txtPaymentCardFName
            // 
            this.txtPaymentCardFName.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardFName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardFName.Location = new System.Drawing.Point(65, 111);
            this.txtPaymentCardFName.Name = "txtPaymentCardFName";
            this.txtPaymentCardFName.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentCardFName.TabIndex = 1;
            // 
            // txtPaymentCardLName
            // 
            this.txtPaymentCardLName.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardLName.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardLName.Location = new System.Drawing.Point(294, 111);
            this.txtPaymentCardLName.Name = "txtPaymentCardLName";
            this.txtPaymentCardLName.Size = new System.Drawing.Size(153, 33);
            this.txtPaymentCardLName.TabIndex = 1;
            // 
            // txtPaymentCardNo
            // 
            this.txtPaymentCardNo.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardNo.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardNo.Location = new System.Drawing.Point(66, 204);
            this.txtPaymentCardNo.Name = "txtPaymentCardNo";
            this.txtPaymentCardNo.Size = new System.Drawing.Size(381, 33);
            this.txtPaymentCardNo.TabIndex = 1;
            // 
            // txtPaymentCardExpDate
            // 
            this.txtPaymentCardExpDate.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardExpDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardExpDate.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardExpDate.Location = new System.Drawing.Point(66, 297);
            this.txtPaymentCardExpDate.Name = "txtPaymentCardExpDate";
            this.txtPaymentCardExpDate.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentCardExpDate.TabIndex = 1;
            // 
            // txtPaymentCardCVV
            // 
            this.txtPaymentCardCVV.BackColor = System.Drawing.Color.White;
            this.txtPaymentCardCVV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentCardCVV.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCardCVV.Location = new System.Drawing.Point(294, 297);
            this.txtPaymentCardCVV.Name = "txtPaymentCardCVV";
            this.txtPaymentCardCVV.Size = new System.Drawing.Size(168, 33);
            this.txtPaymentCardCVV.TabIndex = 1;
            // 
            // cbImNotARobot
            // 
            this.cbImNotARobot.FlatAppearance.BorderSize = 0;
            this.cbImNotARobot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbImNotARobot.Location = new System.Drawing.Point(57, 353);
            this.cbImNotARobot.Name = "cbImNotARobot";
            this.cbImNotARobot.Size = new System.Drawing.Size(13, 14);
            this.cbImNotARobot.TabIndex = 2;
            this.cbImNotARobot.UseVisualStyleBackColor = true;
            // 
            // ucPaymentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentCard;
            this.Controls.Add(this.cbImNotARobot);
            this.Controls.Add(this.txtPaymentCardNo);
            this.Controls.Add(this.txtPaymentCardLName);
            this.Controls.Add(this.txtPaymentCardCVV);
            this.Controls.Add(this.txtPaymentCardExpDate);
            this.Controls.Add(this.txtPaymentCardFName);
            this.Controls.Add(this.btnCompleteOrder);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ucPaymentCard";
            this.Size = new System.Drawing.Size(511, 477);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.TextBox txtPaymentCardFName;
        private System.Windows.Forms.TextBox txtPaymentCardLName;
        private System.Windows.Forms.TextBox txtPaymentCardNo;
        private System.Windows.Forms.TextBox txtPaymentCardExpDate;
        private System.Windows.Forms.TextBox txtPaymentCardCVV;
        private System.Windows.Forms.CheckBox cbImNotARobot;
    }
}
