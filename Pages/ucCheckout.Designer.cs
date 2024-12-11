namespace Ferry_Ticketing_App.Pages
{
    partial class ucCheckout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCheckout));
            this.pnlCheckout = new System.Windows.Forms.Panel();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.ucPaymentCard1 = new Ferry_Ticketing_App.Pages.ucPaymentCard();
            this.pnlOrderSummary = new System.Windows.Forms.Panel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.pnlCheckout.SuspendLayout();
            this.pnlOrderSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCheckout
            // 
            this.pnlCheckout.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.pnlFindTripsbg;
            this.pnlCheckout.Controls.Add(this.btnCompleteOrder);
            this.pnlCheckout.Controls.Add(this.ucPaymentCard1);
            this.pnlCheckout.Controls.Add(this.pnlOrderSummary);
            this.pnlCheckout.Controls.Add(this.pbHeader);
            this.pnlCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckout.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckout.Name = "pnlCheckout";
            this.pnlCheckout.Size = new System.Drawing.Size(1009, 753);
            this.pnlCheckout.TabIndex = 0;
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.FlatAppearance.BorderSize = 0;
            this.btnCompleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCompleteOrder.Image = global::Ferry_Ticketing_App.Properties.Resources.checkoutbtnContinue;
            this.btnCompleteOrder.Location = new System.Drawing.Point(302, 579);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(208, 62);
            this.btnCompleteOrder.TabIndex = 3;
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            this.btnCompleteOrder.Click += new System.EventHandler(this.btnCompleteOrder_Click);
            // 
            // ucPaymentCard1
            // 
            this.ucPaymentCard1.BackColor = System.Drawing.Color.Transparent;
            this.ucPaymentCard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPaymentCard1.BackgroundImage")));
            this.ucPaymentCard1.ForeColor = System.Drawing.Color.Transparent;
            this.ucPaymentCard1.Location = new System.Drawing.Point(20, 186);
            this.ucPaymentCard1.Name = "ucPaymentCard1";
            this.ucPaymentCard1.Size = new System.Drawing.Size(511, 477);
            this.ucPaymentCard1.TabIndex = 4;
            // 
            // pnlOrderSummary
            // 
            this.pnlOrderSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlOrderSummary.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.ordersummary;
            this.pnlOrderSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlOrderSummary.Controls.Add(this.lblTotalPrice);
            this.pnlOrderSummary.Controls.Add(this.lblPaymentID);
            this.pnlOrderSummary.Location = new System.Drawing.Point(540, 186);
            this.pnlOrderSummary.Name = "pnlOrderSummary";
            this.pnlOrderSummary.Size = new System.Drawing.Size(433, 280);
            this.pnlOrderSummary.TabIndex = 1;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(267, 211);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(129, 23);
            this.lblTotalPrice.TabIndex = 0;
            this.lblTotalPrice.Text = "label1";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.Location = new System.Drawing.Point(267, 138);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(129, 23);
            this.lblPaymentID.TabIndex = 0;
            this.lblPaymentID.Text = "label1";
            this.lblPaymentID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbHeader
            // 
            this.pbHeader.BackColor = System.Drawing.Color.Transparent;
            this.pbHeader.Image = global::Ferry_Ticketing_App.Properties.Resources.headerCheckout;
            this.pbHeader.Location = new System.Drawing.Point(20, 18);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(956, 113);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHeader.TabIndex = 0;
            this.pbHeader.TabStop = false;
            // 
            // ucCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlCheckout);
            this.Name = "ucCheckout";
            this.Size = new System.Drawing.Size(1026, 720);
            this.pnlCheckout.ResumeLayout(false);
            this.pnlOrderSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Panel pnlOrderSummary;
        public System.Windows.Forms.Label lblTotalPrice;
        public System.Windows.Forms.Label lblPaymentID;
        public System.Windows.Forms.Button btnCompleteOrder;
        public ucPaymentCard ucPaymentCard1;
        public System.Windows.Forms.Panel pnlCheckout;
    }
}
