﻿namespace Ferry_Ticketing_App.Pages
{
    partial class ucSearchOneWayTrip
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
            this.pnlSearchOneWayTrip = new System.Windows.Forms.Panel();
            this.ucIndividualTrips1 = new Ferry_Ticketing_App.Pages.ucIndividualTrips();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.btnSummaryContinue = new System.Windows.Forms.Button();
            this.pblblSummary = new System.Windows.Forms.PictureBox();
            this.ucDepartureSummary1 = new Ferry_Ticketing_App.Pages.ucDepartureSummary();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.pnlItineraryPH = new System.Windows.Forms.Panel();
            this.btnModifyItenerary = new System.Windows.Forms.Button();
            this.pbArrowLR2 = new System.Windows.Forms.PictureBox();
            this.lblArrival = new System.Windows.Forms.Label();
            this.lblDeparture = new System.Windows.Forms.Label();
            this.lblPassenger = new System.Windows.Forms.Label();
            this.lblToCity = new System.Windows.Forms.Label();
            this.lblFromCity = new System.Windows.Forms.Label();
            this.lblToCode = new System.Windows.Forms.Label();
            this.lblArrivalDate = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblNoOfPassengers = new System.Windows.Forms.Label();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.pnlSearchOneWayTrip.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblblSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.pnlItineraryPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowLR2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchOneWayTrip
            // 
            this.pnlSearchOneWayTrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSearchOneWayTrip.BackColor = System.Drawing.Color.White;
            this.pnlSearchOneWayTrip.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.pnlFindTripsbg1;
            this.pnlSearchOneWayTrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSearchOneWayTrip.Controls.Add(this.ucIndividualTrips1);
            this.pnlSearchOneWayTrip.Controls.Add(this.pnlSummary);
            this.pnlSearchOneWayTrip.Controls.Add(this.pbProgress);
            this.pnlSearchOneWayTrip.Controls.Add(this.pnlItineraryPH);
            this.pnlSearchOneWayTrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchOneWayTrip.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchOneWayTrip.Name = "pnlSearchOneWayTrip";
            this.pnlSearchOneWayTrip.Size = new System.Drawing.Size(1009, 1193);
            this.pnlSearchOneWayTrip.TabIndex = 1;
            // 
            // ucIndividualTrips1
            // 
            this.ucIndividualTrips1.BackColor = System.Drawing.Color.Transparent;
            this.ucIndividualTrips1.Location = new System.Drawing.Point(15, 248);
            this.ucIndividualTrips1.Name = "ucIndividualTrips1";
            this.ucIndividualTrips1.Size = new System.Drawing.Size(602, 318);
            this.ucIndividualTrips1.TabIndex = 5;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.stateroundbg;
            this.pnlSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSummary.Controls.Add(this.btnSummaryContinue);
            this.pnlSummary.Controls.Add(this.pblblSummary);
            this.pnlSummary.Controls.Add(this.ucDepartureSummary1);
            this.pnlSummary.Location = new System.Drawing.Point(630, 230);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(374, 858);
            this.pnlSummary.TabIndex = 4;
            // 
            // btnSummaryContinue
            // 
            this.btnSummaryContinue.FlatAppearance.BorderSize = 0;
            this.btnSummaryContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummaryContinue.Image = global::Ferry_Ticketing_App.Properties.Resources.btnSummaryContinue;
            this.btnSummaryContinue.Location = new System.Drawing.Point(26, 745);
            this.btnSummaryContinue.Name = "btnSummaryContinue";
            this.btnSummaryContinue.Size = new System.Drawing.Size(326, 71);
            this.btnSummaryContinue.TabIndex = 2;
            this.btnSummaryContinue.UseVisualStyleBackColor = true;
            this.btnSummaryContinue.Click += new System.EventHandler(this.btnSummaryContinue_Click);
            // 
            // pblblSummary
            // 
            this.pblblSummary.Image = global::Ferry_Ticketing_App.Properties.Resources.Summary;
            this.pblblSummary.Location = new System.Drawing.Point(24, 18);
            this.pblblSummary.Name = "pblblSummary";
            this.pblblSummary.Size = new System.Drawing.Size(327, 27);
            this.pblblSummary.TabIndex = 1;
            this.pblblSummary.TabStop = false;
            // 
            // ucDepartureSummary1
            // 
            this.ucDepartureSummary1.BackColor = System.Drawing.Color.Transparent;
            this.ucDepartureSummary1.Location = new System.Drawing.Point(14, 51);
            this.ucDepartureSummary1.Name = "ucDepartureSummary1";
            this.ucDepartureSummary1.Size = new System.Drawing.Size(348, 675);
            this.ucDepartureSummary1.TabIndex = 3;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::Ferry_Ticketing_App.Properties.Resources.progress1;
            this.pbProgress.Location = new System.Drawing.Point(113, 150);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(800, 51);
            this.pbProgress.TabIndex = 1;
            this.pbProgress.TabStop = false;
            // 
            // pnlItineraryPH
            // 
            this.pnlItineraryPH.BackColor = System.Drawing.Color.Transparent;
            this.pnlItineraryPH.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.iteneraryPH;
            this.pnlItineraryPH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlItineraryPH.Controls.Add(this.btnModifyItenerary);
            this.pnlItineraryPH.Controls.Add(this.pbArrowLR2);
            this.pnlItineraryPH.Controls.Add(this.lblArrival);
            this.pnlItineraryPH.Controls.Add(this.lblDeparture);
            this.pnlItineraryPH.Controls.Add(this.lblPassenger);
            this.pnlItineraryPH.Controls.Add(this.lblToCity);
            this.pnlItineraryPH.Controls.Add(this.lblFromCity);
            this.pnlItineraryPH.Controls.Add(this.lblToCode);
            this.pnlItineraryPH.Controls.Add(this.lblArrivalDate);
            this.pnlItineraryPH.Controls.Add(this.lblDepartureDate);
            this.pnlItineraryPH.Controls.Add(this.lblNoOfPassengers);
            this.pnlItineraryPH.Controls.Add(this.lblFromCode);
            this.pnlItineraryPH.Location = new System.Drawing.Point(12, 18);
            this.pnlItineraryPH.Name = "pnlItineraryPH";
            this.pnlItineraryPH.Size = new System.Drawing.Size(986, 104);
            this.pnlItineraryPH.TabIndex = 0;
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
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrival.Location = new System.Drawing.Point(693, 59);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(48, 18);
            this.lblArrival.TabIndex = 0;
            this.lblArrival.Text = "Arrival";
            // 
            // lblDeparture
            // 
            this.lblDeparture.AutoSize = true;
            this.lblDeparture.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparture.Location = new System.Drawing.Point(494, 60);
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
            // lblToCity
            // 
            this.lblToCity.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCity.Location = new System.Drawing.Point(186, 60);
            this.lblToCity.Name = "lblToCity";
            this.lblToCity.Size = new System.Drawing.Size(72, 18);
            this.lblToCity.TabIndex = 0;
            this.lblToCity.Text = "City";
            this.lblToCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromCity
            // 
            this.lblFromCity.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromCity.Location = new System.Drawing.Point(27, 60);
            this.lblFromCity.Name = "lblFromCity";
            this.lblFromCity.Size = new System.Drawing.Size(70, 18);
            this.lblFromCity.TabIndex = 0;
            this.lblFromCity.Text = "City";
            this.lblFromCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToCode
            // 
            this.lblToCode.AutoSize = true;
            this.lblToCode.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCode.Location = new System.Drawing.Point(190, 25);
            this.lblToCode.Name = "lblToCode";
            this.lblToCode.Size = new System.Drawing.Size(68, 27);
            this.lblToCode.TabIndex = 0;
            this.lblToCode.Text = "Code";
            // 
            // lblArrivalDate
            // 
            this.lblArrivalDate.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalDate.Location = new System.Drawing.Point(634, 25);
            this.lblArrivalDate.Name = "lblArrivalDate";
            this.lblArrivalDate.Size = new System.Drawing.Size(166, 27);
            this.lblArrivalDate.TabIndex = 0;
            this.lblArrivalDate.Text = "ADate";
            this.lblArrivalDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromCode.Location = new System.Drawing.Point(29, 25);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(68, 27);
            this.lblFromCode.TabIndex = 0;
            this.lblFromCode.Text = "Code";
            // 
            // ucSearchOneWayTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSearchOneWayTrip);
            this.Name = "ucSearchOneWayTrip";
            this.Size = new System.Drawing.Size(1026, 720);
            this.pnlSearchOneWayTrip.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pblblSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.pnlItineraryPH.ResumeLayout(false);
            this.pnlItineraryPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowLR2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchOneWayTrip;
        public ucIndividualTrips ucIndividualTrips1;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Button btnSummaryContinue;
        private System.Windows.Forms.PictureBox pblblSummary;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Panel pnlItineraryPH;
        private System.Windows.Forms.Button btnModifyItenerary;
        private System.Windows.Forms.PictureBox pbArrowLR2;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.Label lblPassenger;
        public System.Windows.Forms.Label lblToCity;
        public System.Windows.Forms.Label lblFromCity;
        private System.Windows.Forms.Label lblToCode;
        private System.Windows.Forms.Label lblArrivalDate;
        public System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblNoOfPassengers;
        private System.Windows.Forms.Label lblFromCode;
        public ucDepartureSummary ucDepartureSummary1;
    }
}

