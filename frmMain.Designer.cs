﻿using Ferry_Ticketing_App.Pages;

namespace Ferry_Ticketing_App
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSidePanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.ucFindTrips1 = new Ferry_Ticketing_App.Pages.ucFindTrips();
            this.ucSearchRoundTrip1 = new Ferry_Ticketing_App.Pages.ucSearchRoundTrip();
            this.pnlSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Ferry_Ticketing_App.Properties.Resources.minimize;
            this.btnMinimize.Location = new System.Drawing.Point(1220, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 24);
            this.btnMinimize.TabIndex = 8;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Ferry_Ticketing_App.Properties.Resources.x;
            this.btnClose.Location = new System.Drawing.Point(1249, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlSidePanel
            // 
            this.pnlSidePanel.BackColor = System.Drawing.Color.Transparent;
            this.pnlSidePanel.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.mainFormSidePanel;
            this.pnlSidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSidePanel.Controls.Add(this.btnLogout);
            this.pnlSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidePanel.Location = new System.Drawing.Point(0, 0);
            this.pnlSidePanel.Name = "pnlSidePanel";
            this.pnlSidePanel.Size = new System.Drawing.Size(254, 720);
            this.pnlSidePanel.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(8, 676);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(38, 35);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ucFindTrips1
            // 
            this.ucFindTrips1.Location = new System.Drawing.Point(254, 36);
            this.ucFindTrips1.Name = "ucFindTrips1";
            this.ucFindTrips1.Size = new System.Drawing.Size(1026, 720);
            this.ucFindTrips1.TabIndex = 11;
            // 
            // ucSearchRoundTrip1
            // 
            this.ucSearchRoundTrip1.AutoScroll = true;
            this.ucSearchRoundTrip1.BackColor = System.Drawing.Color.White;
            this.ucSearchRoundTrip1.Location = new System.Drawing.Point(254, 36);
            this.ucSearchRoundTrip1.Name = "ucSearchRoundTrip1";
            this.ucSearchRoundTrip1.Size = new System.Drawing.Size(1026, 720);
            this.ucSearchRoundTrip1.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.ucFindTrips1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlSidePanel);
            this.Controls.Add(this.ucSearchRoundTrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aerian Shipping Lines";
            this.pnlSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidePanel;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private Pages.ucSearchRoundTrip ucSearchRoundTrip1;
        private ucFindTrips ucFindTrips1;
    }
}

