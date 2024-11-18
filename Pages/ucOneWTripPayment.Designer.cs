namespace Ferry_Ticketing_App.Pages
{
    partial class ucOneWTripPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOneWTripPayment));
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.ucOneWTripSummary1 = new Ferry_Ticketing_App.Pages.ucOneWTripSummary();
            this.btnPaymentContinue = new System.Windows.Forms.Button();
            this.btnPaymentBack = new System.Windows.Forms.Button();
            this.pnlPassengerInfo = new System.Windows.Forms.Panel();
            this.lblPIGender = new System.Windows.Forms.Label();
            this.lblPILName = new System.Windows.Forms.Label();
            this.lblPIMiddleInitial = new System.Windows.Forms.Label();
            this.lblPINationality = new System.Windows.Forms.Label();
            this.lblPIBirthdate = new System.Windows.Forms.Label();
            this.lblPIFName = new System.Windows.Forms.Label();
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
            this.pbPaymentOptionsHeader = new System.Windows.Forms.PictureBox();
            this.pbYoureAlmostThere = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.pnlPayment.SuspendLayout();
            this.pnlPassengerInfo.SuspendLayout();
            this.pnlContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassengerGuidelines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentOptionsHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoureAlmostThere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentBG;
            this.pnlPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPayment.Controls.Add(this.ucOneWTripSummary1);
            this.pnlPayment.Controls.Add(this.btnPaymentContinue);
            this.pnlPayment.Controls.Add(this.btnPaymentBack);
            this.pnlPayment.Controls.Add(this.pnlPassengerInfo);
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
            this.pnlPayment.Size = new System.Drawing.Size(1009, 1700);
            this.pnlPayment.TabIndex = 0;
            this.pnlPayment.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPayment_Paint);
            // 
            // ucOneWTripSummary1
            // 
            this.ucOneWTripSummary1.BackColor = System.Drawing.Color.Transparent;
            this.ucOneWTripSummary1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucOneWTripSummary1.BackgroundImage")));
            this.ucOneWTripSummary1.Location = new System.Drawing.Point(37, 874);
            this.ucOneWTripSummary1.Name = "ucOneWTripSummary1";
            this.ucOneWTripSummary1.Size = new System.Drawing.Size(545, 285);
            this.ucOneWTripSummary1.TabIndex = 12;
            // 
            // btnPaymentContinue
            // 
            this.btnPaymentContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnPaymentContinue.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnContinuePassengerInfo;
            this.btnPaymentContinue.FlatAppearance.BorderSize = 0;
            this.btnPaymentContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentContinue.Location = new System.Drawing.Point(744, 1535);
            this.btnPaymentContinue.Name = "btnPaymentContinue";
            this.btnPaymentContinue.Size = new System.Drawing.Size(198, 71);
            this.btnPaymentContinue.TabIndex = 11;
            this.btnPaymentContinue.UseVisualStyleBackColor = false;
            // 
            // btnPaymentBack
            // 
            this.btnPaymentBack.BackColor = System.Drawing.Color.Transparent;
            this.btnPaymentBack.FlatAppearance.BorderSize = 0;
            this.btnPaymentBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentBack.Image = global::Ferry_Ticketing_App.Properties.Resources.btnBackPassengerInfo;
            this.btnPaymentBack.Location = new System.Drawing.Point(60, 1534);
            this.btnPaymentBack.Name = "btnPaymentBack";
            this.btnPaymentBack.Size = new System.Drawing.Size(198, 71);
            this.btnPaymentBack.TabIndex = 10;
            this.btnPaymentBack.UseVisualStyleBackColor = false;
            // 
            // pnlPassengerInfo
            // 
            this.pnlPassengerInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassengerInfo.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentPassengerInfo;
            this.pnlPassengerInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlPassengerInfo.Controls.Add(this.lblPIGender);
            this.pnlPassengerInfo.Controls.Add(this.lblPILName);
            this.pnlPassengerInfo.Controls.Add(this.lblPIMiddleInitial);
            this.pnlPassengerInfo.Controls.Add(this.lblPINationality);
            this.pnlPassengerInfo.Controls.Add(this.lblPIBirthdate);
            this.pnlPassengerInfo.Controls.Add(this.lblPIFName);
            this.pnlPassengerInfo.Location = new System.Drawing.Point(37, 1339);
            this.pnlPassengerInfo.Name = "pnlPassengerInfo";
            this.pnlPassengerInfo.Size = new System.Drawing.Size(545, 155);
            this.pnlPassengerInfo.TabIndex = 9;
            // 
            // lblPIGender
            // 
            this.lblPIGender.AutoSize = true;
            this.lblPIGender.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIGender.ForeColor = System.Drawing.Color.Gray;
            this.lblPIGender.Location = new System.Drawing.Point(396, 64);
            this.lblPIGender.Name = "lblPIGender";
            this.lblPIGender.Size = new System.Drawing.Size(39, 13);
            this.lblPIGender.TabIndex = 18;
            this.lblPIGender.Text = "label3";
            // 
            // lblPILName
            // 
            this.lblPILName.AutoSize = true;
            this.lblPILName.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPILName.ForeColor = System.Drawing.Color.Gray;
            this.lblPILName.Location = new System.Drawing.Point(270, 64);
            this.lblPILName.Name = "lblPILName";
            this.lblPILName.Size = new System.Drawing.Size(39, 13);
            this.lblPILName.TabIndex = 18;
            this.lblPILName.Text = "label3";
            // 
            // lblPIMiddleInitial
            // 
            this.lblPIMiddleInitial.AutoSize = true;
            this.lblPIMiddleInitial.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIMiddleInitial.ForeColor = System.Drawing.Color.Gray;
            this.lblPIMiddleInitial.Location = new System.Drawing.Point(145, 64);
            this.lblPIMiddleInitial.Name = "lblPIMiddleInitial";
            this.lblPIMiddleInitial.Size = new System.Drawing.Size(39, 13);
            this.lblPIMiddleInitial.TabIndex = 18;
            this.lblPIMiddleInitial.Text = "label3";
            // 
            // lblPINationality
            // 
            this.lblPINationality.AutoSize = true;
            this.lblPINationality.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPINationality.ForeColor = System.Drawing.Color.Gray;
            this.lblPINationality.Location = new System.Drawing.Point(145, 109);
            this.lblPINationality.Name = "lblPINationality";
            this.lblPINationality.Size = new System.Drawing.Size(39, 13);
            this.lblPINationality.TabIndex = 18;
            this.lblPINationality.Text = "label3";
            // 
            // lblPIBirthdate
            // 
            this.lblPIBirthdate.AutoSize = true;
            this.lblPIBirthdate.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIBirthdate.ForeColor = System.Drawing.Color.Gray;
            this.lblPIBirthdate.Location = new System.Drawing.Point(20, 109);
            this.lblPIBirthdate.Name = "lblPIBirthdate";
            this.lblPIBirthdate.Size = new System.Drawing.Size(39, 13);
            this.lblPIBirthdate.TabIndex = 18;
            this.lblPIBirthdate.Text = "label3";
            // 
            // lblPIFName
            // 
            this.lblPIFName.AutoSize = true;
            this.lblPIFName.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIFName.ForeColor = System.Drawing.Color.Gray;
            this.lblPIFName.Location = new System.Drawing.Point(20, 64);
            this.lblPIFName.Name = "lblPIFName";
            this.lblPIFName.Size = new System.Drawing.Size(39, 13);
            this.lblPIFName.TabIndex = 18;
            this.lblPIFName.Text = "label3";
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
            this.pnlContactInfo.Location = new System.Drawing.Point(36, 1173);
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
            // 
            // pnlPaymentSummary
            // 
            this.pnlPaymentSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaymentSummary.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentSummaryBG;
            this.pnlPaymentSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlPaymentSummary.Location = new System.Drawing.Point(609, 319);
            this.pnlPaymentSummary.Name = "pnlPaymentSummary";
            this.pnlPaymentSummary.Size = new System.Drawing.Size(382, 358);
            this.pnlPaymentSummary.TabIndex = 5;
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
            // ucOneWTripPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlPayment);
            this.DoubleBuffered = true;
            this.Name = "ucOneWTripPayment";
            this.Size = new System.Drawing.Size(1026, 720);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPassengerInfo.ResumeLayout(false);
            this.pnlPassengerInfo.PerformLayout();
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassengerGuidelines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentOptionsHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoureAlmostThere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.PictureBox pbYoureAlmostThere;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.PictureBox pbPaymentOptionsHeader;
        private System.Windows.Forms.Panel pnlPaymentSummary;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnMaya;
        private System.Windows.Forms.Button btnGcash;
        private System.Windows.Forms.PictureBox pbPassengerGuidelines;
        private System.Windows.Forms.Panel pnlContactInfo;
        private System.Windows.Forms.Panel pnlPassengerInfo;
        private System.Windows.Forms.Button btnPaymentBack;
        private System.Windows.Forms.Button btnPaymentContinue;
        private System.Windows.Forms.Label lblPIGender;
        private System.Windows.Forms.Label lblPILName;
        private System.Windows.Forms.Label lblPIMiddleInitial;
        private System.Windows.Forms.Label lblPINationality;
        private System.Windows.Forms.Label lblPIBirthdate;
        private System.Windows.Forms.Label lblPIFName;
        private System.Windows.Forms.Label lblCIMobileNo;
        private System.Windows.Forms.Label lblCIAddress;
        private System.Windows.Forms.Label lblCIEmailAdd;
        private System.Windows.Forms.Label lblCIName;
        private ucOneWTripSummary ucOneWTripSummary1;
    }
}
