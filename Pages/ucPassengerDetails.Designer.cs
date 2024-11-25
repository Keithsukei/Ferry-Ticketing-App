namespace Ferry_Ticketing_App.Pages
{
    partial class ucPassengerDetails
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
            this.cmbBoxNationality = new System.Windows.Forms.ComboBox();
            this.cmbBoxGender = new System.Windows.Forms.ComboBox();
            this.cmbBType = new System.Windows.Forms.ComboBox();
            this.lblPassengerNo = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbBoxNationality
            // 
            this.cmbBoxNationality.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.cmbBoxNationality.FormattingEnabled = true;
            this.cmbBoxNationality.Location = new System.Drawing.Point(493, 211);
            this.cmbBoxNationality.Name = "cmbBoxNationality";
            this.cmbBoxNationality.Size = new System.Drawing.Size(206, 40);
            this.cmbBoxNationality.TabIndex = 17;
            // 
            // cmbBoxGender
            // 
            this.cmbBoxGender.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.cmbBoxGender.FormattingEnabled = true;
            this.cmbBoxGender.Location = new System.Drawing.Point(710, 119);
            this.cmbBoxGender.Name = "cmbBoxGender";
            this.cmbBoxGender.Size = new System.Drawing.Size(145, 40);
            this.cmbBoxGender.TabIndex = 18;
            // 
            // cmbBType
            // 
            this.cmbBType.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.cmbBType.FormattingEnabled = true;
            this.cmbBType.Location = new System.Drawing.Point(341, 211);
            this.cmbBType.Name = "cmbBType";
            this.cmbBType.Size = new System.Drawing.Size(123, 40);
            this.cmbBType.TabIndex = 19;
            // 
            // lblPassengerNo
            // 
            this.lblPassengerNo.AutoSize = true;
            this.lblPassengerNo.Font = new System.Drawing.Font("SF Pro Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassengerNo.ForeColor = System.Drawing.Color.Gray;
            this.lblPassengerNo.Location = new System.Drawing.Point(149, 15);
            this.lblPassengerNo.Name = "lblPassengerNo";
            this.lblPassengerNo.Size = new System.Drawing.Size(30, 32);
            this.lblPassengerNo.TabIndex = 16;
            this.lblPassengerNo.Text = "#";
            this.lblPassengerNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarForeColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(57, 211);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(205, 40);
            this.dtpDateOfBirth.TabIndex = 15;
            this.dtpDateOfBirth.Value = new System.DateTime(2024, 11, 17, 20, 44, 40, 0);
            // 
            // txtMI
            // 
            this.txtMI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMI.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtMI.Location = new System.Drawing.Point(343, 123);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(53, 33);
            this.txtMI.TabIndex = 12;
            this.txtMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLName
            // 
            this.txtLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLName.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtLName.Location = new System.Drawing.Point(431, 123);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(250, 33);
            this.txtLName.TabIndex = 13;
            // 
            // txtFName
            // 
            this.txtFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFName.Font = new System.Drawing.Font("SF Pro Display", 20.25F);
            this.txtFName.Location = new System.Drawing.Point(58, 123);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(250, 33);
            this.txtFName.TabIndex = 14;
            // 
            // ucPassengerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.individualPassengerDetails;
            this.Controls.Add(this.cmbBoxNationality);
            this.Controls.Add(this.cmbBoxGender);
            this.Controls.Add(this.cmbBType);
            this.Controls.Add(this.lblPassengerNo);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.txtMI);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Name = "ucPassengerDetails";
            this.Size = new System.Drawing.Size(913, 302);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxNationality;
        private System.Windows.Forms.ComboBox cmbBoxGender;
        private System.Windows.Forms.ComboBox cmbBType;
        private System.Windows.Forms.Label lblPassengerNo;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
    }
}
