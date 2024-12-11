namespace Ferry_Ticketing_App.Pages
{
    partial class ucReturnSummary
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
            this.pnlReturn = new System.Windows.Forms.Panel();
            this.btnReturnOpen = new System.Windows.Forms.Button();
            this.btnReturnClosed = new System.Windows.Forms.Button();
            this.pnlRetDropdownNoSelected = new System.Windows.Forms.Panel();
            this.pnlRetDropdownSelected = new System.Windows.Forms.Panel();
            this.lblReturnTo = new System.Windows.Forms.Label();
            this.lblReturnFrom = new System.Windows.Forms.Label();
            this.lblRVesselName = new System.Windows.Forms.Label();
            this.pnlReturn.SuspendLayout();
            this.pnlRetDropdownSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReturn
            // 
            this.pnlReturn.Controls.Add(this.btnReturnOpen);
            this.pnlReturn.Controls.Add(this.btnReturnClosed);
            this.pnlReturn.Controls.Add(this.pnlRetDropdownSelected);
            this.pnlReturn.Controls.Add(this.pnlRetDropdownNoSelected);
            this.pnlReturn.Location = new System.Drawing.Point(3, 3);
            this.pnlReturn.Name = "pnlReturn";
            this.pnlReturn.Size = new System.Drawing.Size(335, 247);
            this.pnlReturn.TabIndex = 1;
            // 
            // btnReturnOpen
            // 
            this.btnReturnOpen.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.returnopen;
            this.btnReturnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReturnOpen.FlatAppearance.BorderSize = 0;
            this.btnReturnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnOpen.Location = new System.Drawing.Point(0, 0);
            this.btnReturnOpen.Name = "btnReturnOpen";
            this.btnReturnOpen.Size = new System.Drawing.Size(334, 45);
            this.btnReturnOpen.TabIndex = 0;
            this.btnReturnOpen.UseVisualStyleBackColor = true;
            this.btnReturnOpen.Click += new System.EventHandler(this.btnReturnOpen_Click);
            // 
            // btnReturnClosed
            // 
            this.btnReturnClosed.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.returnclosed;
            this.btnReturnClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReturnClosed.FlatAppearance.BorderSize = 0;
            this.btnReturnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnClosed.Location = new System.Drawing.Point(0, 0);
            this.btnReturnClosed.Name = "btnReturnClosed";
            this.btnReturnClosed.Size = new System.Drawing.Size(326, 45);
            this.btnReturnClosed.TabIndex = 0;
            this.btnReturnClosed.UseVisualStyleBackColor = true;
            this.btnReturnClosed.Click += new System.EventHandler(this.btnReturnClosed_Click);
            // 
            // pnlRetDropdownNoSelected
            // 
            this.pnlRetDropdownNoSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.returnSummaryNoSelectedd;
            this.pnlRetDropdownNoSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlRetDropdownNoSelected.Location = new System.Drawing.Point(0, 40);
            this.pnlRetDropdownNoSelected.Name = "pnlRetDropdownNoSelected";
            this.pnlRetDropdownNoSelected.Size = new System.Drawing.Size(334, 199);
            this.pnlRetDropdownNoSelected.TabIndex = 1;
            // 
            // pnlRetDropdownSelected
            // 
            this.pnlRetDropdownSelected.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.returnopen2;
            this.pnlRetDropdownSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlRetDropdownSelected.Controls.Add(this.lblReturnTo);
            this.pnlRetDropdownSelected.Controls.Add(this.lblReturnFrom);
            this.pnlRetDropdownSelected.Controls.Add(this.lblRVesselName);
            this.pnlRetDropdownSelected.Location = new System.Drawing.Point(0, 41);
            this.pnlRetDropdownSelected.Name = "pnlRetDropdownSelected";
            this.pnlRetDropdownSelected.Size = new System.Drawing.Size(334, 199);
            this.pnlRetDropdownSelected.TabIndex = 4;
            // 
            // lblReturnTo
            // 
            this.lblReturnTo.AutoSize = true;
            this.lblReturnTo.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnTo.Location = new System.Drawing.Point(68, 160);
            this.lblReturnTo.Name = "lblReturnTo";
            this.lblReturnTo.Size = new System.Drawing.Size(41, 16);
            this.lblReturnTo.TabIndex = 2;
            this.lblReturnTo.Text = "label1";
            // 
            // lblReturnFrom
            // 
            this.lblReturnFrom.AutoSize = true;
            this.lblReturnFrom.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnFrom.Location = new System.Drawing.Point(68, 93);
            this.lblReturnFrom.Name = "lblReturnFrom";
            this.lblReturnFrom.Size = new System.Drawing.Size(41, 16);
            this.lblReturnFrom.TabIndex = 3;
            this.lblReturnFrom.Text = "label1";
            // 
            // lblRVesselName
            // 
            this.lblRVesselName.AutoSize = true;
            this.lblRVesselName.Font = new System.Drawing.Font("SF Pro Display", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblRVesselName.Location = new System.Drawing.Point(84, 17);
            this.lblRVesselName.Name = "lblRVesselName";
            this.lblRVesselName.Size = new System.Drawing.Size(53, 20);
            this.lblRVesselName.TabIndex = 1;
            this.lblRVesselName.Text = "label1";
            // 
            // ucReturnSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlReturn);
            this.Name = "ucReturnSummary";
            this.Size = new System.Drawing.Size(340, 254);
            this.pnlReturn.ResumeLayout(false);
            this.pnlRetDropdownSelected.ResumeLayout(false);
            this.pnlRetDropdownSelected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReturn;
        public System.Windows.Forms.Panel pnlRetDropdownNoSelected;
        private System.Windows.Forms.Button btnReturnOpen;
        private System.Windows.Forms.Button btnReturnClosed;
        public System.Windows.Forms.Panel pnlRetDropdownSelected;
        public System.Windows.Forms.Label lblRVesselName;
        public System.Windows.Forms.Label lblReturnTo;
        public System.Windows.Forms.Label lblReturnFrom;
    }
}
