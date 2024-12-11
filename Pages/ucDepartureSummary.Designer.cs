namespace Ferry_Ticketing_App.Pages
{
    partial class ucDepartureSummary
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
            this.pnlDeparture = new System.Windows.Forms.Panel();
            this.btnDepartureOpen = new System.Windows.Forms.Button();
            this.btnDepartureClosed = new System.Windows.Forms.Button();
            this.pnlDepDropDownSelected = new System.Windows.Forms.Panel();
            this.pbArrowRight = new System.Windows.Forms.PictureBox();
            this.lblDAccommodation = new System.Windows.Forms.Label();
            this.lblDSeatType = new System.Windows.Forms.Label();
            this.lblDAircon = new System.Windows.Forms.Label();
            this.lblDPrice = new System.Windows.Forms.Label();
            this.lblToPortName = new System.Windows.Forms.Label();
            this.lblFromPortName = new System.Windows.Forms.Label();
            this.lblDepartTo = new System.Windows.Forms.Label();
            this.lblDepartFrom = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblDVesselName = new System.Windows.Forms.Label();
            this.pnlDepDropDownNoSelected = new System.Windows.Forms.Panel();
            this.pnlDeparture.SuspendLayout();
            this.pnlDepDropDownSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDeparture
            // 
            this.pnlDeparture.Controls.Add(this.btnDepartureOpen);
            this.pnlDeparture.Controls.Add(this.btnDepartureClosed);
            this.pnlDeparture.Controls.Add(this.pnlDepDropDownNoSelected);
            this.pnlDeparture.Controls.Add(this.pnlDepDropDownSelected);
            this.pnlDeparture.Location = new System.Drawing.Point(8, 8);
            this.pnlDeparture.Name = "pnlDeparture";
            this.pnlDeparture.Size = new System.Drawing.Size(335, 663);
            this.pnlDeparture.TabIndex = 1;
            // 
            // btnDepartureOpen
            // 
            this.btnDepartureOpen.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureopen;
            this.btnDepartureOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDepartureOpen.FlatAppearance.BorderSize = 0;
            this.btnDepartureOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartureOpen.Location = new System.Drawing.Point(0, 0);
            this.btnDepartureOpen.Name = "btnDepartureOpen";
            this.btnDepartureOpen.Size = new System.Drawing.Size(334, 45);
            this.btnDepartureOpen.TabIndex = 0;
            this.btnDepartureOpen.UseVisualStyleBackColor = true;
            this.btnDepartureOpen.Click += new System.EventHandler(this.btnDepartureOpen_Click);
            // 
            // btnDepartureClosed
            // 
            this.btnDepartureClosed.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureclosed;
            this.btnDepartureClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDepartureClosed.FlatAppearance.BorderSize = 0;
            this.btnDepartureClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartureClosed.Location = new System.Drawing.Point(0, 0);
            this.btnDepartureClosed.Name = "btnDepartureClosed";
            this.btnDepartureClosed.Size = new System.Drawing.Size(334, 45);
            this.btnDepartureClosed.TabIndex = 0;
            this.btnDepartureClosed.UseVisualStyleBackColor = true;
            this.btnDepartureClosed.Click += new System.EventHandler(this.btnDepartureClosed_Click);
            // 
            // pnlDepDropDownSelected
            // 
            this.pnlDepDropDownSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureopen3;
            this.pnlDepDropDownSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlDepDropDownSelected.Controls.Add(this.pbArrowRight);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDAccommodation);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDSeatType);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDAircon);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDPrice);
            this.pnlDepDropDownSelected.Controls.Add(this.lblToPortName);
            this.pnlDepDropDownSelected.Controls.Add(this.lblFromPortName);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartTo);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartFrom);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartureDate);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDVesselName);
            this.pnlDepDropDownSelected.Location = new System.Drawing.Point(0, 42);
            this.pnlDepDropDownSelected.Name = "pnlDepDropDownSelected";
            this.pnlDepDropDownSelected.Size = new System.Drawing.Size(334, 620);
            this.pnlDepDropDownSelected.TabIndex = 3;
            // 
            // pbArrowRight
            // 
            this.pbArrowRight.Image = global::Ferry_Ticketing_App.Properties.Resources.arrowright1;
            this.pbArrowRight.Location = new System.Drawing.Point(115, 295);
            this.pbArrowRight.Name = "pbArrowRight";
            this.pbArrowRight.Size = new System.Drawing.Size(30, 32);
            this.pbArrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbArrowRight.TabIndex = 1;
            this.pbArrowRight.TabStop = false;
            // 
            // lblDAccommodation
            // 
            this.lblDAccommodation.AutoSize = true;
            this.lblDAccommodation.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDAccommodation.Location = new System.Drawing.Point(22, 369);
            this.lblDAccommodation.Name = "lblDAccommodation";
            this.lblDAccommodation.Size = new System.Drawing.Size(53, 19);
            this.lblDAccommodation.TabIndex = 0;
            this.lblDAccommodation.Text = "label1";
            // 
            // lblDSeatType
            // 
            this.lblDSeatType.AutoSize = true;
            this.lblDSeatType.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSeatType.Location = new System.Drawing.Point(22, 436);
            this.lblDSeatType.Name = "lblDSeatType";
            this.lblDSeatType.Size = new System.Drawing.Size(53, 19);
            this.lblDSeatType.TabIndex = 0;
            this.lblDSeatType.Text = "label1";
            // 
            // lblDAircon
            // 
            this.lblDAircon.AutoSize = true;
            this.lblDAircon.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDAircon.Location = new System.Drawing.Point(22, 502);
            this.lblDAircon.Name = "lblDAircon";
            this.lblDAircon.Size = new System.Drawing.Size(53, 19);
            this.lblDAircon.TabIndex = 0;
            this.lblDAircon.Text = "label1";
            // 
            // lblDPrice
            // 
            this.lblDPrice.AutoSize = true;
            this.lblDPrice.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPrice.Location = new System.Drawing.Point(22, 568);
            this.lblDPrice.Name = "lblDPrice";
            this.lblDPrice.Size = new System.Drawing.Size(53, 19);
            this.lblDPrice.TabIndex = 0;
            this.lblDPrice.Text = "label1";
            // 
            // lblToPortName
            // 
            this.lblToPortName.AutoEllipsis = true;
            this.lblToPortName.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToPortName.Location = new System.Drawing.Point(151, 302);
            this.lblToPortName.Name = "lblToPortName";
            this.lblToPortName.Size = new System.Drawing.Size(170, 19);
            this.lblToPortName.TabIndex = 0;
            this.lblToPortName.Text = "label1";
            // 
            // lblFromPortName
            // 
            this.lblFromPortName.AutoEllipsis = true;
            this.lblFromPortName.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromPortName.Location = new System.Drawing.Point(22, 302);
            this.lblFromPortName.Name = "lblFromPortName";
            this.lblFromPortName.Size = new System.Drawing.Size(87, 19);
            this.lblFromPortName.TabIndex = 0;
            this.lblFromPortName.Text = "label1";
            // 
            // lblDepartTo
            // 
            this.lblDepartTo.AutoSize = true;
            this.lblDepartTo.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartTo.Location = new System.Drawing.Point(71, 158);
            this.lblDepartTo.Name = "lblDepartTo";
            this.lblDepartTo.Size = new System.Drawing.Size(41, 16);
            this.lblDepartTo.TabIndex = 0;
            this.lblDepartTo.Text = "label1";
            // 
            // lblDepartFrom
            // 
            this.lblDepartFrom.AutoSize = true;
            this.lblDepartFrom.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartFrom.Location = new System.Drawing.Point(71, 92);
            this.lblDepartFrom.Name = "lblDepartFrom";
            this.lblDepartFrom.Size = new System.Drawing.Size(41, 16);
            this.lblDepartFrom.TabIndex = 0;
            this.lblDepartFrom.Text = "label1";
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureDate.Location = new System.Drawing.Point(22, 219);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(53, 19);
            this.lblDepartureDate.TabIndex = 0;
            this.lblDepartureDate.Text = "label1";
            // 
            // lblDVesselName
            // 
            this.lblDVesselName.AutoSize = true;
            this.lblDVesselName.Font = new System.Drawing.Font("SF Pro Display", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblDVesselName.Location = new System.Drawing.Point(89, 16);
            this.lblDVesselName.Name = "lblDVesselName";
            this.lblDVesselName.Size = new System.Drawing.Size(53, 20);
            this.lblDVesselName.TabIndex = 0;
            this.lblDVesselName.Text = "label1";
            // 
            // pnlDepDropDownNoSelected
            // 
            this.pnlDepDropDownNoSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureSummaryNoSelected;
            this.pnlDepDropDownNoSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlDepDropDownNoSelected.Location = new System.Drawing.Point(0, 41);
            this.pnlDepDropDownNoSelected.Name = "pnlDepDropDownNoSelected";
            this.pnlDepDropDownNoSelected.Size = new System.Drawing.Size(334, 199);
            this.pnlDepDropDownNoSelected.TabIndex = 1;
            // 
            // ucDepartureSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlDeparture);
            this.Name = "ucDepartureSummary";
            this.Size = new System.Drawing.Size(348, 675);
            this.pnlDeparture.ResumeLayout(false);
            this.pnlDepDropDownSelected.ResumeLayout(false);
            this.pnlDepDropDownSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrowRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeparture;
        public System.Windows.Forms.Panel pnlDepDropDownSelected;
        public System.Windows.Forms.Panel pnlDepDropDownNoSelected;
        private System.Windows.Forms.Button btnDepartureOpen;
        private System.Windows.Forms.Button btnDepartureClosed;
        public System.Windows.Forms.Label lblDVesselName;
        public System.Windows.Forms.Label lblDPrice;
        public System.Windows.Forms.Label lblToPortName;
        public System.Windows.Forms.Label lblFromPortName;
        public System.Windows.Forms.Label lblDepartureDate;
        public System.Windows.Forms.Label lblDSeatType;
        public System.Windows.Forms.Label lblDAircon;
        public System.Windows.Forms.Label lblDepartTo;
        public System.Windows.Forms.Label lblDepartFrom;
        private System.Windows.Forms.PictureBox pbArrowRight;
        public System.Windows.Forms.Label lblDAccommodation;
    }
}
