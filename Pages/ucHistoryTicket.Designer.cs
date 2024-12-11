namespace Ferry_Ticketing_App.Pages
{
    partial class ucHistoryTicket
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
            this.btnViewTicket = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblBookingNum = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblDateBooked = new System.Windows.Forms.Label();
            this.lblTripType = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblNoOfPassengers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnViewTicket
            // 
            this.btnViewTicket.FlatAppearance.BorderSize = 0;
            this.btnViewTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTicket.Image = global::Ferry_Ticketing_App.Properties.Resources.viewbutton;
            this.btnViewTicket.Location = new System.Drawing.Point(924, 20);
            this.btnViewTicket.Name = "btnViewTicket";
            this.btnViewTicket.Size = new System.Drawing.Size(28, 29);
            this.btnViewTicket.TabIndex = 0;
            this.btnViewTicket.UseVisualStyleBackColor = true;
            this.btnViewTicket.Click += new System.EventHandler(this.btnViewTicket_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Image = global::Ferry_Ticketing_App.Properties.Resources.historydownloadbtn;
            this.btnDownload.Location = new System.Drawing.Point(924, 60);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(28, 29);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::Ferry_Ticketing_App.Properties.Resources.historydeletebtn;
            this.btnDelete.Location = new System.Drawing.Point(923, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 29);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblBookingNum
            // 
            this.lblBookingNum.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingNum.Location = new System.Drawing.Point(21, 88);
            this.lblBookingNum.Name = "lblBookingNum";
            this.lblBookingNum.Size = new System.Drawing.Size(121, 25);
            this.lblBookingNum.TabIndex = 1;
            this.lblBookingNum.Text = "#";
            this.lblBookingNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblBookingID.Location = new System.Drawing.Point(396, 23);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(56, 21);
            this.lblBookingID.TabIndex = 2;
            this.lblBookingID.Text = "label2";
            this.lblBookingID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblContactPerson.Location = new System.Drawing.Point(436, 65);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(56, 21);
            this.lblContactPerson.TabIndex = 2;
            this.lblContactPerson.Text = "label2";
            this.lblContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateBooked
            // 
            this.lblDateBooked.AutoSize = true;
            this.lblDateBooked.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblDateBooked.Location = new System.Drawing.Point(413, 110);
            this.lblDateBooked.Name = "lblDateBooked";
            this.lblDateBooked.Size = new System.Drawing.Size(56, 21);
            this.lblDateBooked.TabIndex = 2;
            this.lblDateBooked.Text = "label2";
            this.lblDateBooked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTripType
            // 
            this.lblTripType.AutoSize = true;
            this.lblTripType.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblTripType.Location = new System.Drawing.Point(714, 22);
            this.lblTripType.Name = "lblTripType";
            this.lblTripType.Size = new System.Drawing.Size(56, 21);
            this.lblTripType.TabIndex = 2;
            this.lblTripType.Text = "label2";
            this.lblTripType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblDestination.Location = new System.Drawing.Point(734, 65);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(56, 21);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "label2";
            this.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfPassengers
            // 
            this.lblNoOfPassengers.AutoSize = true;
            this.lblNoOfPassengers.Font = new System.Drawing.Font("SF Pro Display", 13F);
            this.lblNoOfPassengers.Location = new System.Drawing.Point(798, 110);
            this.lblNoOfPassengers.Name = "lblNoOfPassengers";
            this.lblNoOfPassengers.Size = new System.Drawing.Size(56, 21);
            this.lblNoOfPassengers.TabIndex = 2;
            this.lblNoOfPassengers.Text = "label2";
            this.lblNoOfPassengers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucHistoryTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.historyticket5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.lblDateBooked);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.lblNoOfPassengers);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblTripType);
            this.Controls.Add(this.lblBookingID);
            this.Controls.Add(this.lblBookingNum);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnViewTicket);
            this.DoubleBuffered = true;
            this.Name = "ucHistoryTicket";
            this.Size = new System.Drawing.Size(993, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnViewTicket;
        public System.Windows.Forms.Button btnDownload;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Label lblBookingNum;
        public System.Windows.Forms.Label lblBookingID;
        public System.Windows.Forms.Label lblContactPerson;
        public System.Windows.Forms.Label lblDateBooked;
        public System.Windows.Forms.Label lblTripType;
        public System.Windows.Forms.Label lblDestination;
        public System.Windows.Forms.Label lblNoOfPassengers;
    }
}
