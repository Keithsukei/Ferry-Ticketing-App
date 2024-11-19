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
            this.lblDPrice = new System.Windows.Forms.Label();
            this.lblToPortName = new System.Windows.Forms.Label();
            this.lblFromPortName = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblDVesselName = new System.Windows.Forms.Label();
            this.pnlDepDropDownNoSelected = new System.Windows.Forms.Panel();
            this.lblDAircon = new System.Windows.Forms.Label();
            this.lblDSeatType = new System.Windows.Forms.Label();
            this.lblDepartureFrom = new System.Windows.Forms.Label();
            this.lblDepartureTo = new System.Windows.Forms.Label();
            this.pnlDeparture.SuspendLayout();
            this.pnlDepDropDownSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDeparture
            // 
            this.pnlDeparture.Controls.Add(this.btnDepartureOpen);
            this.pnlDeparture.Controls.Add(this.btnDepartureClosed);
            this.pnlDeparture.Controls.Add(this.pnlDepDropDownSelected);
            this.pnlDeparture.Controls.Add(this.pnlDepDropDownNoSelected);
            this.pnlDeparture.Location = new System.Drawing.Point(8, 8);
            this.pnlDeparture.Name = "pnlDeparture";
            this.pnlDeparture.Size = new System.Drawing.Size(335, 584);
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
            // 
            // pnlDepDropDownSelected
            // 
            this.pnlDepDropDownSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureDetails3;
            this.pnlDepDropDownSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlDepDropDownSelected.Controls.Add(this.lblDSeatType);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDAircon);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDPrice);
            this.pnlDepDropDownSelected.Controls.Add(this.lblToPortName);
            this.pnlDepDropDownSelected.Controls.Add(this.lblFromPortName);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartureTo);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartureFrom);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDepartureDate);
            this.pnlDepDropDownSelected.Controls.Add(this.lblDVesselName);
            this.pnlDepDropDownSelected.Location = new System.Drawing.Point(0, 44);
            this.pnlDepDropDownSelected.Name = "pnlDepDropDownSelected";
            this.pnlDepDropDownSelected.Size = new System.Drawing.Size(334, 539);
            this.pnlDepDropDownSelected.TabIndex = 3;
            // 
            // lblDPrice
            // 
            this.lblDPrice.AutoSize = true;
            this.lblDPrice.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPrice.Location = new System.Drawing.Point(22, 501);
            this.lblDPrice.Name = "lblDPrice";
            this.lblDPrice.Size = new System.Drawing.Size(53, 19);
            this.lblDPrice.TabIndex = 0;
            this.lblDPrice.Text = "label1";
            // 
            // lblToPortName
            // 
            this.lblToPortName.AutoSize = true;
            this.lblToPortName.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToPortName.Location = new System.Drawing.Point(159, 302);
            this.lblToPortName.Name = "lblToPortName";
            this.lblToPortName.Size = new System.Drawing.Size(53, 19);
            this.lblToPortName.TabIndex = 0;
            this.lblToPortName.Text = "label1";
            // 
            // lblFromPortName
            // 
            this.lblFromPortName.AutoSize = true;
            this.lblFromPortName.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromPortName.Location = new System.Drawing.Point(22, 302);
            this.lblFromPortName.Name = "lblFromPortName";
            this.lblFromPortName.Size = new System.Drawing.Size(53, 19);
            this.lblFromPortName.TabIndex = 0;
            this.lblFromPortName.Text = "label1";
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
            this.lblDVesselName.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVesselName.Location = new System.Drawing.Point(89, 16);
            this.lblDVesselName.Name = "lblDVesselName";
            this.lblDVesselName.Size = new System.Drawing.Size(75, 27);
            this.lblDVesselName.TabIndex = 0;
            this.lblDVesselName.Text = "label1";
            // 
            // pnlDepDropDownNoSelected
            // 
            this.pnlDepDropDownNoSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.departureSummaryNoSelected;
            this.pnlDepDropDownNoSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlDepDropDownNoSelected.Location = new System.Drawing.Point(0, 45);
            this.pnlDepDropDownNoSelected.Name = "pnlDepDropDownNoSelected";
            this.pnlDepDropDownNoSelected.Size = new System.Drawing.Size(334, 199);
            this.pnlDepDropDownNoSelected.TabIndex = 1;
            // 
            // lblDAircon
            // 
            this.lblDAircon.AutoSize = true;
            this.lblDAircon.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDAircon.Location = new System.Drawing.Point(22, 435);
            this.lblDAircon.Name = "lblDAircon";
            this.lblDAircon.Size = new System.Drawing.Size(53, 19);
            this.lblDAircon.TabIndex = 0;
            this.lblDAircon.Text = "label1";
            // 
            // lblDSeatType
            // 
            this.lblDSeatType.AutoSize = true;
            this.lblDSeatType.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSeatType.Location = new System.Drawing.Point(22, 369);
            this.lblDSeatType.Name = "lblDSeatType";
            this.lblDSeatType.Size = new System.Drawing.Size(53, 19);
            this.lblDSeatType.TabIndex = 0;
            this.lblDSeatType.Text = "label1";
            // 
            // lblDepartureFrom
            // 
            this.lblDepartureFrom.AutoSize = true;
            this.lblDepartureFrom.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureFrom.Location = new System.Drawing.Point(71, 92);
            this.lblDepartureFrom.Name = "lblDepartureFrom";
            this.lblDepartureFrom.Size = new System.Drawing.Size(41, 16);
            this.lblDepartureFrom.TabIndex = 0;
            this.lblDepartureFrom.Text = "label1";
            // 
            // lblDepartureTo
            // 
            this.lblDepartureTo.AutoSize = true;
            this.lblDepartureTo.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTo.Location = new System.Drawing.Point(71, 158);
            this.lblDepartureTo.Name = "lblDepartureTo";
            this.lblDepartureTo.Size = new System.Drawing.Size(41, 16);
            this.lblDepartureTo.TabIndex = 0;
            this.lblDepartureTo.Text = "label1";
            // 
            // ucDepartureSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlDeparture);
            this.Name = "ucDepartureSummary";
            this.Size = new System.Drawing.Size(348, 601);
            this.pnlDeparture.ResumeLayout(false);
            this.pnlDepDropDownSelected.ResumeLayout(false);
            this.pnlDepDropDownSelected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeparture;
        private System.Windows.Forms.Panel pnlDepDropDownSelected;
        private System.Windows.Forms.Panel pnlDepDropDownNoSelected;
        private System.Windows.Forms.Button btnDepartureOpen;
        private System.Windows.Forms.Button btnDepartureClosed;
        private System.Windows.Forms.Label lblDVesselName;
        private System.Windows.Forms.Label lblDPrice;
        private System.Windows.Forms.Label lblToPortName;
        private System.Windows.Forms.Label lblFromPortName;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblDSeatType;
        private System.Windows.Forms.Label lblDAircon;
        private System.Windows.Forms.Label lblDepartureTo;
        private System.Windows.Forms.Label lblDepartureFrom;
    }
}
