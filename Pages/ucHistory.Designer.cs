namespace Ferry_Ticketing_App.Pages
{
    partial class ucHistory
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
            this.flpTicketContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTicketContainer
            // 
            this.flpTicketContainer.AutoScroll = true;
            this.flpTicketContainer.AutoSize = true;
            this.flpTicketContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpTicketContainer.BackColor = System.Drawing.Color.Transparent;
            this.flpTicketContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flpTicketContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTicketContainer.Location = new System.Drawing.Point(11, 79);
            this.flpTicketContainer.Name = "flpTicketContainer";
            this.flpTicketContainer.Size = new System.Drawing.Size(0, 0);
            this.flpTicketContainer.TabIndex = 0;
            this.flpTicketContainer.WrapContents = false;
            // 
            // ucHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.historybg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.flpTicketContainer);
            this.DoubleBuffered = true;
            this.Name = "ucHistory";
            this.Size = new System.Drawing.Size(1026, 679);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flpTicketContainer;
    }
}
