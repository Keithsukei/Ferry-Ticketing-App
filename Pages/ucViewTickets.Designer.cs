namespace Ferry_Ticketing_App.Pages
{
    partial class ucViewTickets
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
            this.flpTicketView = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTicketView
            // 
            this.flpTicketView.AutoScroll = true;
            this.flpTicketView.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.paymentBG;
            this.flpTicketView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpTicketView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTicketView.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTicketView.Location = new System.Drawing.Point(0, 0);
            this.flpTicketView.Name = "flpTicketView";
            this.flpTicketView.Size = new System.Drawing.Size(1026, 720);
            this.flpTicketView.TabIndex = 0;
            this.flpTicketView.WrapContents = false;
            // 
            // ucViewTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpTicketView);
            this.Name = "ucViewTickets";
            this.Size = new System.Drawing.Size(1026, 720);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flpTicketView;
    }
}
