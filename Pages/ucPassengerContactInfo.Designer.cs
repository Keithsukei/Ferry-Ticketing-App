namespace Ferry_Ticketing_App.Pages
{
    partial class ucPassengerContactInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPassengerContactInfo));
            this.pnlPassengerControlInfo = new System.Windows.Forms.Panel();
            this.ucPassengerDetails1 = new Ferry_Ticketing_App.Pages.ucPassengerDetails();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlPassengerDetailsPH = new System.Windows.Forms.Panel();
            this.pnlContactInfoPH = new System.Windows.Forms.Panel();
            this.cbAgreement = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtConfirmEmailAdd = new System.Windows.Forms.TextBox();
            this.txtEmailAdd = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.pbContactInfoHeader = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.pnlItineraryPH = new System.Windows.Forms.Panel();
            this.btnModifyItenerary = new System.Windows.Forms.Button();
            this.pbArrowLR2 = new System.Windows.Forms.PictureBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblDeparture = new System.Windows.Forms.Label();
            this.lblPassenger = new System.Windows.Forms.Label();
            this.lblTCity = new System.Windows.Forms.Label();
            this.lblFCity = new System.Windows.Forms.Label();
            this.lblTCityCode = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblNoOfPassengers = new System.Windows.Forms.Label();
            this.lblFCityCode = new System.Windows.Forms.Label();
            this.lblArrival = new System.Windows.Forms.Label();
            this.lblArrivalDate = new System.Windows.Forms.Label();
            this.pnlPassengerControlInfo.SuspendLayout();
            this.pnlContactInfoPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContactInfoHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.pnlItineraryPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowLR2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPassengerControlInfo
            // 
            this.pnlPassengerControlInfo.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.pnlFindTripsbg;
            this.pnlPassengerControlInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPassengerControlInfo.Controls.Add(this.ucPassengerDetails1);
            this.pnlPassengerControlInfo.Controls.Add(this.btnContinue);
            this.pnlPassengerControlInfo.Controls.Add(this.btnBack);
            this.pnlPassengerControlInfo.Controls.Add(this.pnlPassengerDetailsPH);
            this.pnlPassengerControlInfo.Controls.Add(this.pnlContactInfoPH);
            this.pnlPassengerControlInfo.Controls.Add(this.pbContactInfoHeader);
            this.pnlPassengerControlInfo.Controls.Add(this.pbProgress);
            this.pnlPassengerControlInfo.Controls.Add(this.pnlItineraryPH);
            this.pnlPassengerControlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPassengerControlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPassengerControlInfo.Name = "pnlPassengerControlInfo";
            this.pnlPassengerControlInfo.Size = new System.Drawing.Size(1009, 1499);
            this.pnlPassengerControlInfo.TabIndex = 0;
            // 
            // ucPassengerDetails1
            // 
            this.ucPassengerDetails1.BackColor = System.Drawing.Color.Transparent;
            this.ucPassengerDetails1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPassengerDetails1.BackgroundImage")));
            this.ucPassengerDetails1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucPassengerDetails1.InstanceName = null;
            this.ucPassengerDetails1.Location = new System.Drawing.Point(54, 1042);
            this.ucPassengerDetails1.Name = "ucPassengerDetails1";
            this.ucPassengerDetails1.Size = new System.Drawing.Size(913, 302);
            this.ucPassengerDetails1.TabIndex = 7;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.btnContinuePassengerInfo;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(755, 1390);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(198, 71);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::Ferry_Ticketing_App.Properties.Resources.btnBackPassengerInfo;
            this.btnBack.Location = new System.Drawing.Point(67, 1390);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(198, 71);
            this.btnBack.TabIndex = 6;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlPassengerDetailsPH
            // 
            this.pnlPassengerDetailsPH.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassengerDetailsPH.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.Passenger_Details;
            this.pnlPassengerDetailsPH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlPassengerDetailsPH.Location = new System.Drawing.Point(56, 999);
            this.pnlPassengerDetailsPH.Name = "pnlPassengerDetailsPH";
            this.pnlPassengerDetailsPH.Size = new System.Drawing.Size(214, 26);
            this.pnlPassengerDetailsPH.TabIndex = 5;
            // 
            // pnlContactInfoPH
            // 
            this.pnlContactInfoPH.BackColor = System.Drawing.Color.Transparent;
            this.pnlContactInfoPH.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.contactInfoPH;
            this.pnlContactInfoPH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlContactInfoPH.Controls.Add(this.cbAgreement);
            this.pnlContactInfoPH.Controls.Add(this.txtAddress);
            this.pnlContactInfoPH.Controls.Add(this.txtConfirmEmailAdd);
            this.pnlContactInfoPH.Controls.Add(this.txtEmailAdd);
            this.pnlContactInfoPH.Controls.Add(this.txtMobileNo);
            this.pnlContactInfoPH.Controls.Add(this.txtContactPerson);
            this.pnlContactInfoPH.Location = new System.Drawing.Point(55, 512);
            this.pnlContactInfoPH.Name = "pnlContactInfoPH";
            this.pnlContactInfoPH.Size = new System.Drawing.Size(912, 470);
            this.pnlContactInfoPH.TabIndex = 4;
            // 
            // cbAgreement
            // 
            this.cbAgreement.AutoSize = true;
            this.cbAgreement.Location = new System.Drawing.Point(59, 420);
            this.cbAgreement.Name = "cbAgreement";
            this.cbAgreement.Size = new System.Drawing.Size(15, 14);
            this.cbAgreement.TabIndex = 8;
            this.cbAgreement.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(60, 297);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(793, 33);
            this.txtAddress.TabIndex = 5;
            // 
            // txtConfirmEmailAdd
            // 
            this.txtConfirmEmailAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmEmailAdd.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtConfirmEmailAdd.Location = new System.Drawing.Point(494, 186);
            this.txtConfirmEmailAdd.Name = "txtConfirmEmailAdd";
            this.txtConfirmEmailAdd.Size = new System.Drawing.Size(358, 33);
            this.txtConfirmEmailAdd.TabIndex = 4;
            // 
            // txtEmailAdd
            // 
            this.txtEmailAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmailAdd.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtEmailAdd.Location = new System.Drawing.Point(59, 186);
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new System.Drawing.Size(358, 33);
            this.txtEmailAdd.TabIndex = 3;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMobileNo.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtMobileNo.Location = new System.Drawing.Point(580, 75);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(272, 33);
            this.txtMobileNo.TabIndex = 2;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContactPerson.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtContactPerson.Location = new System.Drawing.Point(59, 75);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(358, 33);
            this.txtContactPerson.TabIndex = 1;
            // 
            // pbContactInfoHeader
            // 
            this.pbContactInfoHeader.BackColor = System.Drawing.Color.Transparent;
            this.pbContactInfoHeader.Image = global::Ferry_Ticketing_App.Properties.Resources.pnlContactInfoPH;
            this.pbContactInfoHeader.Location = new System.Drawing.Point(56, 266);
            this.pbContactInfoHeader.Name = "pbContactInfoHeader";
            this.pbContactInfoHeader.Size = new System.Drawing.Size(912, 223);
            this.pbContactInfoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbContactInfoHeader.TabIndex = 3;
            this.pbContactInfoHeader.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::Ferry_Ticketing_App.Properties.Resources.progressPassengerInfo;
            this.pbProgress.Location = new System.Drawing.Point(113, 153);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(800, 51);
            this.pbProgress.TabIndex = 2;
            this.pbProgress.TabStop = false;
            // 
            // pnlItineraryPH
            // 
            this.pnlItineraryPH.BackColor = System.Drawing.Color.Transparent;
            this.pnlItineraryPH.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.iteneraryPH;
            this.pnlItineraryPH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlItineraryPH.Controls.Add(this.btnModifyItenerary);
            this.pnlItineraryPH.Controls.Add(this.pbArrowLR2);
            this.pnlItineraryPH.Controls.Add(this.lblReturn);
            this.pnlItineraryPH.Controls.Add(this.lblDeparture);
            this.pnlItineraryPH.Controls.Add(this.lblPassenger);
            this.pnlItineraryPH.Controls.Add(this.lblTCity);
            this.pnlItineraryPH.Controls.Add(this.lblFCity);
            this.pnlItineraryPH.Controls.Add(this.lblTCityCode);
            this.pnlItineraryPH.Controls.Add(this.lblDepartureDate);
            this.pnlItineraryPH.Controls.Add(this.lblNoOfPassengers);
            this.pnlItineraryPH.Controls.Add(this.lblFCityCode);
            this.pnlItineraryPH.Controls.Add(this.lblArrival);
            this.pnlItineraryPH.Controls.Add(this.lblReturnDate);
            this.pnlItineraryPH.Controls.Add(this.lblArrivalDate);
            this.pnlItineraryPH.Location = new System.Drawing.Point(12, 18);
            this.pnlItineraryPH.Name = "pnlItineraryPH";
            this.pnlItineraryPH.Size = new System.Drawing.Size(986, 104);
            this.pnlItineraryPH.TabIndex = 1;
            // 
            // btnModifyItenerary
            // 
            this.btnModifyItenerary.FlatAppearance.BorderSize = 0;
            this.btnModifyItenerary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyItenerary.Image = global::Ferry_Ticketing_App.Properties.Resources.modifyitinerary;
            this.btnModifyItenerary.Location = new System.Drawing.Point(807, 0);
            this.btnModifyItenerary.Name = "btnModifyItenerary";
            this.btnModifyItenerary.Size = new System.Drawing.Size(173, 94);
            this.btnModifyItenerary.TabIndex = 2;
            this.btnModifyItenerary.UseVisualStyleBackColor = true;
            this.btnModifyItenerary.Click += new System.EventHandler(this.btnModifyItinerary_Click);
            // 
            // pbArrowLR2
            // 
            this.pbArrowLR2.Image = global::Ferry_Ticketing_App.Properties.Resources.arrowLR2;
            this.pbArrowLR2.Location = new System.Drawing.Point(118, 36);
            this.pbArrowLR2.Name = "pbArrowLR2";
            this.pbArrowLR2.Size = new System.Drawing.Size(43, 30);
            this.pbArrowLR2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbArrowLR2.TabIndex = 1;
            this.pbArrowLR2.TabStop = false;
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(688, 59);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(51, 18);
            this.lblReturn.TabIndex = 0;
            this.lblReturn.Text = "Return";
            // 
            // lblDeparture
            // 
            this.lblDeparture.AutoSize = true;
            this.lblDeparture.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparture.Location = new System.Drawing.Point(493, 60);
            this.lblDeparture.Name = "lblDeparture";
            this.lblDeparture.Size = new System.Drawing.Size(73, 18);
            this.lblDeparture.TabIndex = 0;
            this.lblDeparture.Text = "Departure";
            // 
            // lblPassenger
            // 
            this.lblPassenger.AutoSize = true;
            this.lblPassenger.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassenger.Location = new System.Drawing.Point(321, 60);
            this.lblPassenger.Name = "lblPassenger";
            this.lblPassenger.Size = new System.Drawing.Size(75, 18);
            this.lblPassenger.TabIndex = 0;
            this.lblPassenger.Text = "Passenger";
            // 
            // lblTCity
            // 
            this.lblTCity.AutoSize = true;
            this.lblTCity.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTCity.Location = new System.Drawing.Point(194, 60);
            this.lblTCity.Name = "lblTCity";
            this.lblTCity.Size = new System.Drawing.Size(33, 18);
            this.lblTCity.TabIndex = 0;
            this.lblTCity.Text = "City";
            // 
            // lblFCity
            // 
            this.lblFCity.AutoSize = true;
            this.lblFCity.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCity.Location = new System.Drawing.Point(31, 60);
            this.lblFCity.Name = "lblFCity";
            this.lblFCity.Size = new System.Drawing.Size(33, 18);
            this.lblFCity.TabIndex = 0;
            this.lblFCity.Text = "City";
            this.lblFCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTCityCode
            // 
            this.lblTCityCode.AutoSize = true;
            this.lblTCityCode.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTCityCode.Location = new System.Drawing.Point(190, 25);
            this.lblTCityCode.Name = "lblTCityCode";
            this.lblTCityCode.Size = new System.Drawing.Size(68, 27);
            this.lblTCityCode.TabIndex = 0;
            this.lblTCityCode.Text = "Code";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.Location = new System.Drawing.Point(633, 24);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(166, 27);
            this.lblReturnDate.TabIndex = 0;
            this.lblReturnDate.Text = "RDate";
            this.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureDate.Location = new System.Drawing.Point(448, 25);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(166, 27);
            this.lblDepartureDate.TabIndex = 0;
            this.lblDepartureDate.Text = "DDate";
            this.lblDepartureDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOfPassengers
            // 
            this.lblNoOfPassengers.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPassengers.Location = new System.Drawing.Point(300, 25);
            this.lblNoOfPassengers.Name = "lblNoOfPassengers";
            this.lblNoOfPassengers.Size = new System.Drawing.Size(117, 27);
            this.lblNoOfPassengers.TabIndex = 0;
            this.lblNoOfPassengers.Text = "#";
            this.lblNoOfPassengers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFCityCode
            // 
            this.lblFCityCode.AutoSize = true;
            this.lblFCityCode.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCityCode.Location = new System.Drawing.Point(29, 25);
            this.lblFCityCode.Name = "lblFCityCode";
            this.lblFCityCode.Size = new System.Drawing.Size(68, 27);
            this.lblFCityCode.TabIndex = 0;
            this.lblFCityCode.Text = "Code";
            // 
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrival.Location = new System.Drawing.Point(689, 59);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(48, 18);
            this.lblArrival.TabIndex = 0;
            this.lblArrival.Text = "Arrival";
            // 
            // lblArrivalDate
            // 
            this.lblArrivalDate.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalDate.Location = new System.Drawing.Point(633, 24);
            this.lblArrivalDate.Name = "lblArrivalDate";
            this.lblArrivalDate.Size = new System.Drawing.Size(166, 27);
            this.lblArrivalDate.TabIndex = 0;
            this.lblArrivalDate.Text = "ADate";
            this.lblArrivalDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPassengerContactInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlPassengerControlInfo);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPassengerContactInfo";
            this.Size = new System.Drawing.Size(1026, 720);
            this.pnlPassengerControlInfo.ResumeLayout(false);
            this.pnlContactInfoPH.ResumeLayout(false);
            this.pnlContactInfoPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContactInfoHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.pnlItineraryPH.ResumeLayout(false);
            this.pnlItineraryPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowLR2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlPassengerControlInfo;
        private System.Windows.Forms.Panel pnlItineraryPH;
        private System.Windows.Forms.Button btnModifyItenerary;
        private System.Windows.Forms.PictureBox pbArrowLR2;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.Label lblPassenger;
        public System.Windows.Forms.Label lblTCity;
        public System.Windows.Forms.Label lblFCity;
        public System.Windows.Forms.Label lblTCityCode;
        public System.Windows.Forms.Label lblReturnDate;
        public System.Windows.Forms.Label lblDepartureDate;
        public System.Windows.Forms.Label lblNoOfPassengers;
        public System.Windows.Forms.Label lblFCityCode;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.PictureBox pbContactInfoHeader;
        private System.Windows.Forms.Panel pnlContactInfoPH;
        private System.Windows.Forms.Panel pnlPassengerDetailsPH;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.TextBox txtContactPerson;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.TextBox txtConfirmEmailAdd;
        public System.Windows.Forms.TextBox txtEmailAdd;
        public System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.CheckBox cbAgreement;
        private System.Windows.Forms.Button btnContinue;
        public ucPassengerDetails ucPassengerDetails1;
        private System.Windows.Forms.Label lblArrival;
        public System.Windows.Forms.Label lblArrivalDate;
    }
}
