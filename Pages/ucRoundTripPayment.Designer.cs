namespace Ferry_Ticketing_App.Pages
{
    partial class ucRoundTripPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRoundTripPayment));
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.ucPaymentPassengerInfo1 = new Ferry_Ticketing_App.Pages.ucPaymentPassengerInfo();
            this.ucRoundTripTripSummary1 = new Ferry_Ticketing_App.Pages.ucRoundTripTripSummary();
            this.btnPaymentContinue = new System.Windows.Forms.Button();
            this.btnPaymentBack = new System.Windows.Forms.Button();
            this.pnlContactInfo = new System.Windows.Forms.Panel();
            this.lblCIMobileNo = new System.Windows.Forms.Label();
            this.lblCIAddress = new System.Windows.Forms.Label();
            this.lblCIEmailAdd = new System.Windows.Forms.Label();
            this.lblCIName = new System.Windows.Forms.Label();
            this.pbPassengerGuidelines = new System.Windows.Forms.PictureBox();
            this.btnMaya = new System.Windows.Forms.Button();
            this.btnGcash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.pnlPaymentSummary = new System.Windows.Forms.Panel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTerminalFee = new System.Windows.Forms.Label();
            this.lblServiceCharge = new System.Windows.Forms.Label();
            this.lblNoOfPassengers = new System.Windows.Forms.Label();
            this.pbPaymentOptionsHeader = new System.Windows.Forms.PictureBox();
            this.pbYoureAlmostThere = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.pnlPayment.SuspendLayout();
            this.pnlContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassengerGuidelines)).BeginInit();
            this.pnlPaymentSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentOptionsHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoureAlmostThere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentBG;
            this.pnlPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPayment.Controls.Add(this.ucPaymentPassengerInfo1);
            this.pnlPayment.Controls.Add(this.ucRoundTripTripSummary1);
            this.pnlPayment.Controls.Add(this.btnPaymentContinue);
            this.pnlPayment.Controls.Add(this.btnPaymentBack);
            this.pnlPayment.Controls.Add(this.pnlContactInfo);
            this.pnlPayment.Controls.Add(this.pbPassengerGuidelines);
            this.pnlPayment.Controls.Add(this.btnMaya);
            this.pnlPayment.Controls.Add(this.btnGcash);
            this.pnlPayment.Controls.Add(this.btnCard);
            this.pnlPayment.Controls.Add(this.pnlPaymentSummary);
            this.pnlPayment.Controls.Add(this.pbPaymentOptionsHeader);
            this.pnlPayment.Controls.Add(this.pbYoureAlmostThere);
            this.pnlPayment.Controls.Add(this.pbProgress);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPayment.Location = new System.Drawing.Point(0, 0);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(1009, 2000);
            this.pnlPayment.TabIndex = 1;
            // 
            // ucPaymentPassengerInfo1
            // 
            this.ucPaymentPassengerInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ucPaymentPassengerInfo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPaymentPassengerInfo1.BackgroundImage")));
            this.ucPaymentPassengerInfo1.Location = new System.Drawing.Point(38, 1614);
            this.ucPaymentPassengerInfo1.Name = "ucPaymentPassengerInfo1";
            this.ucPaymentPassengerInfo1.Size = new System.Drawing.Size(545, 155);
            this.ucPaymentPassengerInfo1.TabIndex = 13;
            // 
            // ucRoundTripTripSummary1
            // 
            this.ucRoundTripTripSummary1.BackColor = System.Drawing.Color.Transparent;
            this.ucRoundTripTripSummary1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucRoundTripTripSummary1.BackgroundImage")));
            this.ucRoundTripTripSummary1.Location = new System.Drawing.Point(38, 875);
            this.ucRoundTripTripSummary1.Name = "ucRoundTripTripSummary1";
            this.ucRoundTripTripSummary1.Size = new System.Drawing.Size(545, 562);
            this.ucRoundTripTripSummary1.TabIndex = 12;
            // 
            // btnPaymentContinue
            // 
            this.btnPaymentContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnPaymentContinue.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnContinuePassengerInfo;
            this.btnPaymentContinue.FlatAppearance.BorderSize = 0;
            this.btnPaymentContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentContinue.Location = new System.Drawing.Point(757, 1832);
            this.btnPaymentContinue.Name = "btnPaymentContinue";
            this.btnPaymentContinue.Size = new System.Drawing.Size(198, 71);
            this.btnPaymentContinue.TabIndex = 11;
            this.btnPaymentContinue.UseVisualStyleBackColor = false;
            this.btnPaymentContinue.Click += new System.EventHandler(this.btnPaymentContinue_Click);
            // 
            // btnPaymentBack
            // 
            this.btnPaymentBack.BackColor = System.Drawing.Color.Transparent;
            this.btnPaymentBack.FlatAppearance.BorderSize = 0;
            this.btnPaymentBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentBack.Image = global::Ferry_Ticketing_App.Properties.Resources.btnBackPassengerInfo;
            this.btnPaymentBack.Location = new System.Drawing.Point(61, 1830);
            this.btnPaymentBack.Name = "btnPaymentBack";
            this.btnPaymentBack.Size = new System.Drawing.Size(198, 71);
            this.btnPaymentBack.TabIndex = 10;
            this.btnPaymentBack.UseVisualStyleBackColor = false;
            // 
            // pnlContactInfo
            // 
            this.pnlContactInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlContactInfo.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentContactInfo;
            this.pnlContactInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlContactInfo.Controls.Add(this.lblCIMobileNo);
            this.pnlContactInfo.Controls.Add(this.lblCIAddress);
            this.pnlContactInfo.Controls.Add(this.lblCIEmailAdd);
            this.pnlContactInfo.Controls.Add(this.lblCIName);
            this.pnlContactInfo.Location = new System.Drawing.Point(37, 1448);
            this.pnlContactInfo.Name = "pnlContactInfo";
            this.pnlContactInfo.Size = new System.Drawing.Size(547, 155);
            this.pnlContactInfo.TabIndex = 9;
            // 
            // lblCIMobileNo
            // 
            this.lblCIMobileNo.AutoSize = true;
            this.lblCIMobileNo.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIMobileNo.ForeColor = System.Drawing.Color.Gray;
            this.lblCIMobileNo.Location = new System.Drawing.Point(380, 61);
            this.lblCIMobileNo.Name = "lblCIMobileNo";
            this.lblCIMobileNo.Size = new System.Drawing.Size(39, 13);
            this.lblCIMobileNo.TabIndex = 18;
            this.lblCIMobileNo.Text = "label3";
            // 
            // lblCIAddress
            // 
            this.lblCIAddress.AutoSize = true;
            this.lblCIAddress.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIAddress.ForeColor = System.Drawing.Color.Gray;
            this.lblCIAddress.Location = new System.Drawing.Point(21, 109);
            this.lblCIAddress.Name = "lblCIAddress";
            this.lblCIAddress.Size = new System.Drawing.Size(39, 13);
            this.lblCIAddress.TabIndex = 18;
            this.lblCIAddress.Text = "label3";
            // 
            // lblCIEmailAdd
            // 
            this.lblCIEmailAdd.AutoSize = true;
            this.lblCIEmailAdd.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIEmailAdd.ForeColor = System.Drawing.Color.Gray;
            this.lblCIEmailAdd.Location = new System.Drawing.Point(207, 61);
            this.lblCIEmailAdd.Name = "lblCIEmailAdd";
            this.lblCIEmailAdd.Size = new System.Drawing.Size(39, 13);
            this.lblCIEmailAdd.TabIndex = 18;
            this.lblCIEmailAdd.Text = "label3";
            // 
            // lblCIName
            // 
            this.lblCIName.AutoSize = true;
            this.lblCIName.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIName.ForeColor = System.Drawing.Color.Gray;
            this.lblCIName.Location = new System.Drawing.Point(21, 64);
            this.lblCIName.Name = "lblCIName";
            this.lblCIName.Size = new System.Drawing.Size(39, 13);
            this.lblCIName.TabIndex = 18;
            this.lblCIName.Text = "label3";
            // 
            // pbPassengerGuidelines
            // 
            this.pbPassengerGuidelines.BackColor = System.Drawing.Color.Transparent;
            this.pbPassengerGuidelines.Image = global::Ferry_Ticketing_App.Properties.Resources.PassengerGuidelines;
            this.pbPassengerGuidelines.Location = new System.Drawing.Point(38, 676);
            this.pbPassengerGuidelines.Name = "pbPassengerGuidelines";
            this.pbPassengerGuidelines.Size = new System.Drawing.Size(545, 184);
            this.pbPassengerGuidelines.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPassengerGuidelines.TabIndex = 7;
            this.pbPassengerGuidelines.TabStop = false;
            // 
            // btnMaya
            // 
            this.btnMaya.BackColor = System.Drawing.Color.Transparent;
            this.btnMaya.FlatAppearance.BorderSize = 0;
            this.btnMaya.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaya.Image = global::Ferry_Ticketing_App.Properties.Resources.btnPaymentMaya;
            this.btnMaya.Location = new System.Drawing.Point(229, 496);
            this.btnMaya.Name = "btnMaya";
            this.btnMaya.Size = new System.Drawing.Size(162, 153);
            this.btnMaya.TabIndex = 6;
            this.btnMaya.UseVisualStyleBackColor = false;
            this.btnMaya.Click += new System.EventHandler(this.btnMaya_Click);
            // 
            // btnGcash
            // 
            this.btnGcash.BackColor = System.Drawing.Color.Transparent;
            this.btnGcash.FlatAppearance.BorderSize = 0;
            this.btnGcash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGcash.Image = global::Ferry_Ticketing_App.Properties.Resources.btnPaymentGcash;
            this.btnGcash.Location = new System.Drawing.Point(416, 496);
            this.btnGcash.Name = "btnGcash";
            this.btnGcash.Size = new System.Drawing.Size(162, 153);
            this.btnGcash.TabIndex = 6;
            this.btnGcash.UseVisualStyleBackColor = false;
            this.btnGcash.Click += new System.EventHandler(this.btnGcash_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.Transparent;
            this.btnCard.FlatAppearance.BorderSize = 0;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Image = global::Ferry_Ticketing_App.Properties.Resources.btnPaymentCard;
            this.btnCard.Location = new System.Drawing.Point(41, 496);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(162, 153);
            this.btnCard.TabIndex = 6;
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // pnlPaymentSummary
            // 
            this.pnlPaymentSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaymentSummary.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentSummaryBG;
            this.pnlPaymentSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlPaymentSummary.Controls.Add(this.lblTotalPrice);
            this.pnlPaymentSummary.Controls.Add(this.lblTerminalFee);
            this.pnlPaymentSummary.Controls.Add(this.lblServiceCharge);
            this.pnlPaymentSummary.Controls.Add(this.lblNoOfPassengers);
            this.pnlPaymentSummary.Location = new System.Drawing.Point(609, 319);
            this.pnlPaymentSummary.Name = "pnlPaymentSummary";
            this.pnlPaymentSummary.Size = new System.Drawing.Size(382, 358);
            this.pnlPaymentSummary.TabIndex = 5;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.White;
            this.lblTotalPrice.Location = new System.Drawing.Point(188, 295);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(179, 35);
            this.lblTotalPrice.TabIndex = 0;
            this.lblTotalPrice.Text = "#";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTerminalFee
            // 
            this.lblTerminalFee.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalFee.ForeColor = System.Drawing.Color.White;
            this.lblTerminalFee.Location = new System.Drawing.Point(289, 115);
            this.lblTerminalFee.Name = "lblTerminalFee";
            this.lblTerminalFee.Size = new System.Drawing.Size(78, 23);
            this.lblTerminalFee.TabIndex = 0;
            this.lblTerminalFee.Text = "#";
            this.lblTerminalFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServiceCharge
            // 
            this.lblServiceCharge.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceCharge.ForeColor = System.Drawing.Color.White;
            this.lblServiceCharge.Location = new System.Drawing.Point(284, 53);
            this.lblServiceCharge.Name = "lblServiceCharge";
            this.lblServiceCharge.Size = new System.Drawing.Size(85, 23);
            this.lblServiceCharge.TabIndex = 0;
            this.lblServiceCharge.Text = "PM";
            this.lblServiceCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOfPassengers
            // 
            this.lblNoOfPassengers.AutoSize = true;
            this.lblNoOfPassengers.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPassengers.ForeColor = System.Drawing.Color.White;
            this.lblNoOfPassengers.Location = new System.Drawing.Point(36, 21);
            this.lblNoOfPassengers.Name = "lblNoOfPassengers";
            this.lblNoOfPassengers.Size = new System.Drawing.Size(21, 23);
            this.lblNoOfPassengers.TabIndex = 0;
            this.lblNoOfPassengers.Text = "#";
            // 
            // pbPaymentOptionsHeader
            // 
            this.pbPaymentOptionsHeader.BackColor = System.Drawing.Color.Transparent;
            this.pbPaymentOptionsHeader.Image = global::Ferry_Ticketing_App.Properties.Resources.PaymentOptionsHeader;
            this.pbPaymentOptionsHeader.Location = new System.Drawing.Point(41, 282);
            this.pbPaymentOptionsHeader.Name = "pbPaymentOptionsHeader";
            this.pbPaymentOptionsHeader.Size = new System.Drawing.Size(537, 195);
            this.pbPaymentOptionsHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPaymentOptionsHeader.TabIndex = 4;
            this.pbPaymentOptionsHeader.TabStop = false;
            // 
            // pbYoureAlmostThere
            // 
            this.pbYoureAlmostThere.BackColor = System.Drawing.Color.Transparent;
            this.pbYoureAlmostThere.Image = global::Ferry_Ticketing_App.Properties.Resources.yourealmostthereheader;
            this.pbYoureAlmostThere.Location = new System.Drawing.Point(41, 128);
            this.pbYoureAlmostThere.Name = "pbYoureAlmostThere";
            this.pbYoureAlmostThere.Size = new System.Drawing.Size(944, 110);
            this.pbYoureAlmostThere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbYoureAlmostThere.TabIndex = 3;
            this.pbYoureAlmostThere.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::Ferry_Ticketing_App.Properties.Resources.progressPayment;
            this.pbProgress.Location = new System.Drawing.Point(113, 33);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(800, 51);
            this.pbProgress.TabIndex = 2;
            this.pbProgress.TabStop = false;
            // 
            // ucRoundTripPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlPayment);
            this.Name = "ucRoundTripPayment";
            this.Size = new System.Drawing.Size(1009, 720);
            this.pnlPayment.ResumeLayout(false);
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassengerGuidelines)).EndInit();
            this.pnlPaymentSummary.ResumeLayout(false);
            this.pnlPaymentSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentOptionsHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoureAlmostThere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPaymentContinue;
        private System.Windows.Forms.Button btnPaymentBack;
        private System.Windows.Forms.Panel pnlContactInfo;
        public System.Windows.Forms.Label lblCIMobileNo;
        public System.Windows.Forms.Label lblCIAddress;
        public System.Windows.Forms.Label lblCIEmailAdd;
        public System.Windows.Forms.Label lblCIName;
        private System.Windows.Forms.PictureBox pbPassengerGuidelines;
        private System.Windows.Forms.Button btnMaya;
        private System.Windows.Forms.Button btnGcash;
        private System.Windows.Forms.Button btnCard;
        public System.Windows.Forms.Panel pnlPaymentSummary;
        private System.Windows.Forms.PictureBox pbPaymentOptionsHeader;
        private System.Windows.Forms.PictureBox pbYoureAlmostThere;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Panel pnlPayment;
        public ucRoundTripTripSummary ucRoundTripTripSummary1;
        public ucPaymentPassengerInfo ucPaymentPassengerInfo1;
        public System.Windows.Forms.Label lblNoOfPassengers;
        public System.Windows.Forms.Label lblServiceCharge;
        public System.Windows.Forms.Label lblTotalPrice;
        public System.Windows.Forms.Label lblTerminalFee;
    }
}
