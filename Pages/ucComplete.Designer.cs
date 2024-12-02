namespace Ferry_Ticketing_App.Pages
{
    partial class ucComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucComplete));
            this.pnlComplete = new System.Windows.Forms.Panel();
            this.ucTicket1 = new Ferry_Ticketing_App.Pages.ucTicket();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.pbCompleteProgress = new System.Windows.Forms.PictureBox();
            this.pbCompleteHeader = new System.Windows.Forms.PictureBox();
            this.pnlComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlComplete
            // 
            this.pnlComplete.BackColor = System.Drawing.Color.Transparent;
            this.pnlComplete.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.pnlFindTripsbg;
            this.pnlComplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlComplete.Controls.Add(this.ucTicket1);
            this.pnlComplete.Controls.Add(this.btnPrint);
            this.pnlComplete.Controls.Add(this.btnDownload);
            this.pnlComplete.Controls.Add(this.btnBackToHome);
            this.pnlComplete.Controls.Add(this.pbCompleteProgress);
            this.pnlComplete.Controls.Add(this.pbCompleteHeader);
            this.pnlComplete.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComplete.Location = new System.Drawing.Point(0, 0);
            this.pnlComplete.Name = "pnlComplete";
            this.pnlComplete.Size = new System.Drawing.Size(992, 1565);
            this.pnlComplete.TabIndex = 0;
            // 
            // ucTicket1
            // 
            this.ucTicket1.BackColor = System.Drawing.Color.Transparent;
            this.ucTicket1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucTicket1.BackgroundImage")));
            this.ucTicket1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucTicket1.Location = new System.Drawing.Point(24, 245);
            this.ucTicket1.Name = "ucTicket1";
            this.ucTicket1.Size = new System.Drawing.Size(954, 1147);
            this.ucTicket1.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::Ferry_Ticketing_App.Properties.Resources.btnCompletePrint;
            this.btnPrint.Location = new System.Drawing.Point(767, 1438);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(210, 75);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Image = global::Ferry_Ticketing_App.Properties.Resources.btnCompleteDownload;
            this.btnDownload.Location = new System.Drawing.Point(531, 1439);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(202, 74);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.FlatAppearance.BorderSize = 0;
            this.btnBackToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToHome.Image = global::Ferry_Ticketing_App.Properties.Resources.btnCompleteBTH;
            this.btnBackToHome.Location = new System.Drawing.Point(33, 1439);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(219, 74);
            this.btnBackToHome.TabIndex = 4;
            this.btnBackToHome.UseVisualStyleBackColor = true;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // pbCompleteProgress
            // 
            this.pbCompleteProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbCompleteProgress.Image = global::Ferry_Ticketing_App.Properties.Resources.progressComplete;
            this.pbCompleteProgress.Location = new System.Drawing.Point(113, 170);
            this.pbCompleteProgress.Name = "pbCompleteProgress";
            this.pbCompleteProgress.Size = new System.Drawing.Size(800, 51);
            this.pbCompleteProgress.TabIndex = 2;
            this.pbCompleteProgress.TabStop = false;
            // 
            // pbCompleteHeader
            // 
            this.pbCompleteHeader.Image = global::Ferry_Ticketing_App.Properties.Resources.completePageHeader2;
            this.pbCompleteHeader.Location = new System.Drawing.Point(24, 24);
            this.pbCompleteHeader.Name = "pbCompleteHeader";
            this.pbCompleteHeader.Size = new System.Drawing.Size(954, 127);
            this.pbCompleteHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCompleteHeader.TabIndex = 0;
            this.pbCompleteHeader.TabStop = false;
            // 
            // ucComplete
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlComplete);
            this.Name = "ucComplete";
            this.Size = new System.Drawing.Size(992, 720);
            this.pnlComplete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlComplete;
        private System.Windows.Forms.PictureBox pbCompleteHeader;
        private System.Windows.Forms.PictureBox pbCompleteProgress;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.Button btnPrint;
        public ucTicket ucTicket1;
    }
}
