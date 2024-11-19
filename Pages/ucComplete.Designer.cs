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
            this.pnlComplete = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.pnlTicketPH = new System.Windows.Forms.Panel();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblETA = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblPDDiscountType = new System.Windows.Forms.Label();
            this.lblPDAccommodation = new System.Windows.Forms.Label();
            this.lblPDAgeGender = new System.Windows.Forms.Label();
            this.lblBIssuedBy = new System.Windows.Forms.Label();
            this.lblBBookingDate = new System.Windows.Forms.Label();
            this.lblPaymentTINBuyer = new System.Windows.Forms.Label();
            this.lblPPaymentMethod = new System.Windows.Forms.Label();
            this.lblPaymentDateReserved = new System.Windows.Forms.Label();
            this.lblPaymentContactNo = new System.Windows.Forms.Label();
            this.lblPaymentContactPerson = new System.Windows.Forms.Label();
            this.lblBCType = new System.Windows.Forms.Label();
            this.lblVType = new System.Windows.Forms.Label();
            this.lblBCORNo = new System.Windows.Forms.Label();
            this.lblVORNo = new System.Windows.Forms.Label();
            this.lblBCTotalAmmount = new System.Windows.Forms.Label();
            this.lblVTotalAmmount = new System.Windows.Forms.Label();
            this.lblBCAgeGender = new System.Windows.Forms.Label();
            this.lblBCDepartureDate = new System.Windows.Forms.Label();
            this.lblVAgeGender = new System.Windows.Forms.Label();
            this.lblBCVesselName = new System.Windows.Forms.Label();
            this.lblVDepartureDate = new System.Windows.Forms.Label();
            this.lblBCFromToCode = new System.Windows.Forms.Label();
            this.lblVVesselName = new System.Windows.Forms.Label();
            this.lblBCName = new System.Windows.Forms.Label();
            this.lblVFromToCode = new System.Windows.Forms.Label();
            this.lblVName = new System.Windows.Forms.Label();
            this.lblPaymentAddress = new System.Windows.Forms.Label();
            this.lblPaymentSoldTo = new System.Windows.Forms.Label();
            this.lblPaymentIssueLoc = new System.Windows.Forms.Label();
            this.lblBTransactionNo = new System.Windows.Forms.Label();
            this.lblPaymentTotalAmmount = new System.Windows.Forms.Label();
            this.lblPaymentORNo = new System.Windows.Forms.Label();
            this.lblBValidUntil = new System.Windows.Forms.Label();
            this.lblPDName = new System.Windows.Forms.Label();
            this.lblVesselName = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pbCompleteProgress = new System.Windows.Forms.PictureBox();
            this.pbCompleteHeader = new System.Windows.Forms.PictureBox();
            this.pnlComplete.SuspendLayout();
            this.pnlTicketPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlComplete
            // 
            this.pnlComplete.BackColor = System.Drawing.Color.Transparent;
            this.pnlComplete.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.pnlFindTripsbg;
            this.pnlComplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlComplete.Controls.Add(this.btnPrint);
            this.pnlComplete.Controls.Add(this.btnDownload);
            this.pnlComplete.Controls.Add(this.btnBackToHome);
            this.pnlComplete.Controls.Add(this.pnlTicketPH);
            this.pnlComplete.Controls.Add(this.pbCompleteProgress);
            this.pnlComplete.Controls.Add(this.pbCompleteHeader);
            this.pnlComplete.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComplete.Location = new System.Drawing.Point(0, 0);
            this.pnlComplete.Name = "pnlComplete";
            this.pnlComplete.Size = new System.Drawing.Size(1009, 1565);
            this.pnlComplete.TabIndex = 0;
            this.pnlComplete.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // 
            // pnlTicketPH
            // 
            this.pnlTicketPH.BackgroundImage = global::Ferry_Ticketing_App.Properties.Resources.ticketPlaceholder;
            this.pnlTicketPH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlTicketPH.Controls.Add(this.lblTo);
            this.pnlTicketPH.Controls.Add(this.lblETA);
            this.pnlTicketPH.Controls.Add(this.lblDepartureDate);
            this.pnlTicketPH.Controls.Add(this.lblPDDiscountType);
            this.pnlTicketPH.Controls.Add(this.lblPDAccommodation);
            this.pnlTicketPH.Controls.Add(this.lblPDAgeGender);
            this.pnlTicketPH.Controls.Add(this.lblBIssuedBy);
            this.pnlTicketPH.Controls.Add(this.lblBBookingDate);
            this.pnlTicketPH.Controls.Add(this.lblPaymentTINBuyer);
            this.pnlTicketPH.Controls.Add(this.lblPPaymentMethod);
            this.pnlTicketPH.Controls.Add(this.lblPaymentDateReserved);
            this.pnlTicketPH.Controls.Add(this.lblPaymentContactNo);
            this.pnlTicketPH.Controls.Add(this.lblPaymentContactPerson);
            this.pnlTicketPH.Controls.Add(this.lblBCType);
            this.pnlTicketPH.Controls.Add(this.lblVType);
            this.pnlTicketPH.Controls.Add(this.lblBCORNo);
            this.pnlTicketPH.Controls.Add(this.lblVORNo);
            this.pnlTicketPH.Controls.Add(this.lblBCTotalAmmount);
            this.pnlTicketPH.Controls.Add(this.lblVTotalAmmount);
            this.pnlTicketPH.Controls.Add(this.lblBCAgeGender);
            this.pnlTicketPH.Controls.Add(this.lblBCDepartureDate);
            this.pnlTicketPH.Controls.Add(this.lblVAgeGender);
            this.pnlTicketPH.Controls.Add(this.lblBCVesselName);
            this.pnlTicketPH.Controls.Add(this.lblVDepartureDate);
            this.pnlTicketPH.Controls.Add(this.lblBCFromToCode);
            this.pnlTicketPH.Controls.Add(this.lblVVesselName);
            this.pnlTicketPH.Controls.Add(this.lblBCName);
            this.pnlTicketPH.Controls.Add(this.lblVFromToCode);
            this.pnlTicketPH.Controls.Add(this.lblVName);
            this.pnlTicketPH.Controls.Add(this.lblPaymentAddress);
            this.pnlTicketPH.Controls.Add(this.lblPaymentSoldTo);
            this.pnlTicketPH.Controls.Add(this.lblPaymentIssueLoc);
            this.pnlTicketPH.Controls.Add(this.lblBTransactionNo);
            this.pnlTicketPH.Controls.Add(this.lblPaymentTotalAmmount);
            this.pnlTicketPH.Controls.Add(this.lblPaymentORNo);
            this.pnlTicketPH.Controls.Add(this.lblBValidUntil);
            this.pnlTicketPH.Controls.Add(this.lblPDName);
            this.pnlTicketPH.Controls.Add(this.lblVesselName);
            this.pnlTicketPH.Controls.Add(this.lblFrom);
            this.pnlTicketPH.Location = new System.Drawing.Point(23, 253);
            this.pnlTicketPH.Name = "pnlTicketPH";
            this.pnlTicketPH.Size = new System.Drawing.Size(954, 1147);
            this.pnlTicketPH.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("SF Pro Display", 19.5F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(552, 95);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(96, 31);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "Point 2";
            // 
            // lblETA
            // 
            this.lblETA.AutoSize = true;
            this.lblETA.Font = new System.Drawing.Font("SF Pro Display", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblETA.Location = new System.Drawing.Point(435, 191);
            this.lblETA.Name = "lblETA";
            this.lblETA.Size = new System.Drawing.Size(53, 20);
            this.lblETA.TabIndex = 0;
            this.lblETA.Text = "label1";
            this.lblETA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Font = new System.Drawing.Font("SF Pro Display", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblDepartureDate.Location = new System.Drawing.Point(460, 164);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(53, 20);
            this.lblDepartureDate.TabIndex = 0;
            this.lblDepartureDate.Text = "label1";
            this.lblDepartureDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPDDiscountType
            // 
            this.lblPDDiscountType.AutoSize = true;
            this.lblPDDiscountType.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDDiscountType.Location = new System.Drawing.Point(497, 306);
            this.lblPDDiscountType.Name = "lblPDDiscountType";
            this.lblPDDiscountType.Size = new System.Drawing.Size(48, 18);
            this.lblPDDiscountType.TabIndex = 0;
            this.lblPDDiscountType.Text = "Name";
            this.lblPDDiscountType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPDAccommodation
            // 
            this.lblPDAccommodation.AutoSize = true;
            this.lblPDAccommodation.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDAccommodation.Location = new System.Drawing.Point(367, 306);
            this.lblPDAccommodation.Name = "lblPDAccommodation";
            this.lblPDAccommodation.Size = new System.Drawing.Size(48, 18);
            this.lblPDAccommodation.TabIndex = 0;
            this.lblPDAccommodation.Text = "Name";
            this.lblPDAccommodation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPDAgeGender
            // 
            this.lblPDAgeGender.AutoSize = true;
            this.lblPDAgeGender.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDAgeGender.Location = new System.Drawing.Point(236, 306);
            this.lblPDAgeGender.Name = "lblPDAgeGender";
            this.lblPDAgeGender.Size = new System.Drawing.Size(48, 18);
            this.lblPDAgeGender.TabIndex = 0;
            this.lblPDAgeGender.Text = "Name";
            this.lblPDAgeGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBIssuedBy
            // 
            this.lblBIssuedBy.AutoSize = true;
            this.lblBIssuedBy.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBIssuedBy.Location = new System.Drawing.Point(367, 448);
            this.lblBIssuedBy.Name = "lblBIssuedBy";
            this.lblBIssuedBy.Size = new System.Drawing.Size(48, 18);
            this.lblBIssuedBy.TabIndex = 0;
            this.lblBIssuedBy.Text = "Name";
            this.lblBIssuedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBBookingDate
            // 
            this.lblBBookingDate.AutoSize = true;
            this.lblBBookingDate.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBBookingDate.Location = new System.Drawing.Point(391, 422);
            this.lblBBookingDate.Name = "lblBBookingDate";
            this.lblBBookingDate.Size = new System.Drawing.Size(48, 18);
            this.lblBBookingDate.TabIndex = 0;
            this.lblBBookingDate.Text = "Name";
            this.lblBBookingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTINBuyer
            // 
            this.lblPaymentTINBuyer.AutoSize = true;
            this.lblPaymentTINBuyer.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTINBuyer.Location = new System.Drawing.Point(342, 598);
            this.lblPaymentTINBuyer.Name = "lblPaymentTINBuyer";
            this.lblPaymentTINBuyer.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentTINBuyer.TabIndex = 0;
            this.lblPaymentTINBuyer.Text = "Name";
            this.lblPaymentTINBuyer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPPaymentMethod
            // 
            this.lblPPaymentMethod.AutoSize = true;
            this.lblPPaymentMethod.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPaymentMethod.Location = new System.Drawing.Point(789, 598);
            this.lblPPaymentMethod.Name = "lblPPaymentMethod";
            this.lblPPaymentMethod.Size = new System.Drawing.Size(48, 18);
            this.lblPPaymentMethod.TabIndex = 0;
            this.lblPPaymentMethod.Text = "Name";
            this.lblPPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentDateReserved
            // 
            this.lblPaymentDateReserved.AutoSize = true;
            this.lblPaymentDateReserved.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDateReserved.Location = new System.Drawing.Point(773, 572);
            this.lblPaymentDateReserved.Name = "lblPaymentDateReserved";
            this.lblPaymentDateReserved.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentDateReserved.TabIndex = 0;
            this.lblPaymentDateReserved.Text = "Name";
            this.lblPaymentDateReserved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentContactNo
            // 
            this.lblPaymentContactNo.AutoSize = true;
            this.lblPaymentContactNo.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentContactNo.Location = new System.Drawing.Point(540, 598);
            this.lblPaymentContactNo.Name = "lblPaymentContactNo";
            this.lblPaymentContactNo.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentContactNo.TabIndex = 0;
            this.lblPaymentContactNo.Text = "Name";
            this.lblPaymentContactNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentContactPerson
            // 
            this.lblPaymentContactPerson.AutoSize = true;
            this.lblPaymentContactPerson.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentContactPerson.Location = new System.Drawing.Point(566, 572);
            this.lblPaymentContactPerson.Name = "lblPaymentContactPerson";
            this.lblPaymentContactPerson.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentContactPerson.TabIndex = 0;
            this.lblPaymentContactPerson.Text = "Name";
            this.lblPaymentContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCType
            // 
            this.lblBCType.AutoSize = true;
            this.lblBCType.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCType.Location = new System.Drawing.Point(236, 1062);
            this.lblBCType.Name = "lblBCType";
            this.lblBCType.Size = new System.Drawing.Size(46, 18);
            this.lblBCType.TabIndex = 0;
            this.lblBCType.Text = "Name";
            this.lblBCType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVType
            // 
            this.lblVType.AutoSize = true;
            this.lblVType.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVType.Location = new System.Drawing.Point(236, 837);
            this.lblVType.Name = "lblVType";
            this.lblVType.Size = new System.Drawing.Size(46, 18);
            this.lblVType.TabIndex = 0;
            this.lblVType.Text = "Name";
            this.lblVType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCORNo
            // 
            this.lblBCORNo.AutoSize = true;
            this.lblBCORNo.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCORNo.Location = new System.Drawing.Point(236, 1041);
            this.lblBCORNo.Name = "lblBCORNo";
            this.lblBCORNo.Size = new System.Drawing.Size(46, 18);
            this.lblBCORNo.TabIndex = 0;
            this.lblBCORNo.Text = "Name";
            this.lblBCORNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVORNo
            // 
            this.lblVORNo.AutoSize = true;
            this.lblVORNo.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVORNo.Location = new System.Drawing.Point(236, 816);
            this.lblVORNo.Name = "lblVORNo";
            this.lblVORNo.Size = new System.Drawing.Size(46, 18);
            this.lblVORNo.TabIndex = 0;
            this.lblVORNo.Text = "Name";
            this.lblVORNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCTotalAmmount
            // 
            this.lblBCTotalAmmount.AutoSize = true;
            this.lblBCTotalAmmount.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCTotalAmmount.Location = new System.Drawing.Point(236, 1021);
            this.lblBCTotalAmmount.Name = "lblBCTotalAmmount";
            this.lblBCTotalAmmount.Size = new System.Drawing.Size(46, 18);
            this.lblBCTotalAmmount.TabIndex = 0;
            this.lblBCTotalAmmount.Text = "Name";
            this.lblBCTotalAmmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVTotalAmmount
            // 
            this.lblVTotalAmmount.AutoSize = true;
            this.lblVTotalAmmount.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVTotalAmmount.Location = new System.Drawing.Point(236, 796);
            this.lblVTotalAmmount.Name = "lblVTotalAmmount";
            this.lblVTotalAmmount.Size = new System.Drawing.Size(46, 18);
            this.lblVTotalAmmount.TabIndex = 0;
            this.lblVTotalAmmount.Text = "Name";
            this.lblVTotalAmmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCAgeGender
            // 
            this.lblBCAgeGender.AutoSize = true;
            this.lblBCAgeGender.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCAgeGender.Location = new System.Drawing.Point(236, 988);
            this.lblBCAgeGender.Name = "lblBCAgeGender";
            this.lblBCAgeGender.Size = new System.Drawing.Size(46, 18);
            this.lblBCAgeGender.TabIndex = 0;
            this.lblBCAgeGender.Text = "Name";
            this.lblBCAgeGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCDepartureDate
            // 
            this.lblBCDepartureDate.AutoSize = true;
            this.lblBCDepartureDate.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCDepartureDate.Location = new System.Drawing.Point(344, 1009);
            this.lblBCDepartureDate.Name = "lblBCDepartureDate";
            this.lblBCDepartureDate.Size = new System.Drawing.Size(46, 18);
            this.lblBCDepartureDate.TabIndex = 0;
            this.lblBCDepartureDate.Text = "Name";
            this.lblBCDepartureDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVAgeGender
            // 
            this.lblVAgeGender.AutoSize = true;
            this.lblVAgeGender.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAgeGender.Location = new System.Drawing.Point(236, 763);
            this.lblVAgeGender.Name = "lblVAgeGender";
            this.lblVAgeGender.Size = new System.Drawing.Size(46, 18);
            this.lblVAgeGender.TabIndex = 0;
            this.lblVAgeGender.Text = "Name";
            this.lblVAgeGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCVesselName
            // 
            this.lblBCVesselName.AutoSize = true;
            this.lblBCVesselName.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCVesselName.Location = new System.Drawing.Point(344, 988);
            this.lblBCVesselName.Name = "lblBCVesselName";
            this.lblBCVesselName.Size = new System.Drawing.Size(46, 18);
            this.lblBCVesselName.TabIndex = 0;
            this.lblBCVesselName.Text = "Name";
            this.lblBCVesselName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVDepartureDate
            // 
            this.lblVDepartureDate.AutoSize = true;
            this.lblVDepartureDate.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVDepartureDate.Location = new System.Drawing.Point(344, 784);
            this.lblVDepartureDate.Name = "lblVDepartureDate";
            this.lblVDepartureDate.Size = new System.Drawing.Size(46, 18);
            this.lblVDepartureDate.TabIndex = 0;
            this.lblVDepartureDate.Text = "Name";
            this.lblVDepartureDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCFromToCode
            // 
            this.lblBCFromToCode.AutoSize = true;
            this.lblBCFromToCode.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCFromToCode.Location = new System.Drawing.Point(344, 967);
            this.lblBCFromToCode.Name = "lblBCFromToCode";
            this.lblBCFromToCode.Size = new System.Drawing.Size(46, 18);
            this.lblBCFromToCode.TabIndex = 0;
            this.lblBCFromToCode.Text = "Name";
            this.lblBCFromToCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVVesselName
            // 
            this.lblVVesselName.AutoSize = true;
            this.lblVVesselName.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVVesselName.Location = new System.Drawing.Point(344, 763);
            this.lblVVesselName.Name = "lblVVesselName";
            this.lblVVesselName.Size = new System.Drawing.Size(46, 18);
            this.lblVVesselName.TabIndex = 0;
            this.lblVVesselName.Text = "Name";
            this.lblVVesselName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCName
            // 
            this.lblBCName.AutoSize = true;
            this.lblBCName.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCName.Location = new System.Drawing.Point(236, 967);
            this.lblBCName.Name = "lblBCName";
            this.lblBCName.Size = new System.Drawing.Size(46, 18);
            this.lblBCName.TabIndex = 0;
            this.lblBCName.Text = "Name";
            this.lblBCName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVFromToCode
            // 
            this.lblVFromToCode.AutoSize = true;
            this.lblVFromToCode.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVFromToCode.Location = new System.Drawing.Point(344, 742);
            this.lblVFromToCode.Name = "lblVFromToCode";
            this.lblVFromToCode.Size = new System.Drawing.Size(46, 18);
            this.lblVFromToCode.TabIndex = 0;
            this.lblVFromToCode.Text = "Name";
            this.lblVFromToCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVName
            // 
            this.lblVName.AutoSize = true;
            this.lblVName.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVName.Location = new System.Drawing.Point(236, 742);
            this.lblVName.Name = "lblVName";
            this.lblVName.Size = new System.Drawing.Size(46, 18);
            this.lblVName.TabIndex = 0;
            this.lblVName.Text = "Name";
            this.lblVName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentAddress
            // 
            this.lblPaymentAddress.AutoSize = true;
            this.lblPaymentAddress.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAddress.Location = new System.Drawing.Point(340, 572);
            this.lblPaymentAddress.Name = "lblPaymentAddress";
            this.lblPaymentAddress.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentAddress.TabIndex = 0;
            this.lblPaymentAddress.Text = "Name";
            this.lblPaymentAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentSoldTo
            // 
            this.lblPaymentSoldTo.AutoSize = true;
            this.lblPaymentSoldTo.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentSoldTo.Location = new System.Drawing.Point(121, 598);
            this.lblPaymentSoldTo.Name = "lblPaymentSoldTo";
            this.lblPaymentSoldTo.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentSoldTo.TabIndex = 0;
            this.lblPaymentSoldTo.Text = "Name";
            this.lblPaymentSoldTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentIssueLoc
            // 
            this.lblPaymentIssueLoc.AutoSize = true;
            this.lblPaymentIssueLoc.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentIssueLoc.Location = new System.Drawing.Point(165, 572);
            this.lblPaymentIssueLoc.Name = "lblPaymentIssueLoc";
            this.lblPaymentIssueLoc.Size = new System.Drawing.Size(48, 18);
            this.lblPaymentIssueLoc.TabIndex = 0;
            this.lblPaymentIssueLoc.Text = "Name";
            this.lblPaymentIssueLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBTransactionNo
            // 
            this.lblBTransactionNo.AutoSize = true;
            this.lblBTransactionNo.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTransactionNo.Location = new System.Drawing.Point(188, 448);
            this.lblBTransactionNo.Name = "lblBTransactionNo";
            this.lblBTransactionNo.Size = new System.Drawing.Size(48, 18);
            this.lblBTransactionNo.TabIndex = 0;
            this.lblBTransactionNo.Text = "Name";
            this.lblBTransactionNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTotalAmmount
            // 
            this.lblPaymentTotalAmmount.AutoSize = true;
            this.lblPaymentTotalAmmount.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTotalAmmount.Location = new System.Drawing.Point(829, 641);
            this.lblPaymentTotalAmmount.Name = "lblPaymentTotalAmmount";
            this.lblPaymentTotalAmmount.Size = new System.Drawing.Size(61, 23);
            this.lblPaymentTotalAmmount.TabIndex = 0;
            this.lblPaymentTotalAmmount.Text = "Name";
            this.lblPaymentTotalAmmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentORNo
            // 
            this.lblPaymentORNo.AutoSize = true;
            this.lblPaymentORNo.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentORNo.Location = new System.Drawing.Point(106, 540);
            this.lblPaymentORNo.Name = "lblPaymentORNo";
            this.lblPaymentORNo.Size = new System.Drawing.Size(52, 19);
            this.lblPaymentORNo.TabIndex = 0;
            this.lblPaymentORNo.Text = "Name";
            this.lblPaymentORNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBValidUntil
            // 
            this.lblBValidUntil.AutoSize = true;
            this.lblBValidUntil.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBValidUntil.Location = new System.Drawing.Point(155, 422);
            this.lblBValidUntil.Name = "lblBValidUntil";
            this.lblBValidUntil.Size = new System.Drawing.Size(48, 18);
            this.lblBValidUntil.TabIndex = 0;
            this.lblBValidUntil.Text = "Name";
            this.lblBValidUntil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPDName
            // 
            this.lblPDName.AutoSize = true;
            this.lblPDName.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDName.Location = new System.Drawing.Point(113, 306);
            this.lblPDName.Name = "lblPDName";
            this.lblPDName.Size = new System.Drawing.Size(48, 18);
            this.lblPDName.TabIndex = 0;
            this.lblPDName.Text = "Name";
            this.lblPDName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVesselName
            // 
            this.lblVesselName.AutoSize = true;
            this.lblVesselName.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVesselName.Location = new System.Drawing.Point(439, 133);
            this.lblVesselName.Name = "lblVesselName";
            this.lblVesselName.Size = new System.Drawing.Size(100, 19);
            this.lblVesselName.TabIndex = 0;
            this.lblVesselName.Text = "VesselName";
            this.lblVesselName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("SF Pro Display", 19.5F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(337, 95);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 31);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Point 1";
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
            this.pbCompleteHeader.Image = global::Ferry_Ticketing_App.Properties.Resources.completepageHeader;
            this.pbCompleteHeader.Location = new System.Drawing.Point(23, 24);
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
            this.Size = new System.Drawing.Size(1009, 720);
            this.pnlComplete.ResumeLayout(false);
            this.pnlTicketPH.ResumeLayout(false);
            this.pnlTicketPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleteHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlComplete;
        private System.Windows.Forms.PictureBox pbCompleteHeader;
        private System.Windows.Forms.PictureBox pbCompleteProgress;
        private System.Windows.Forms.Panel pnlTicketPH;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblVesselName;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblETA;
        private System.Windows.Forms.Label lblPDDiscountType;
        private System.Windows.Forms.Label lblPDAccommodation;
        private System.Windows.Forms.Label lblPDAgeGender;
        private System.Windows.Forms.Label lblPDName;
        private System.Windows.Forms.Label lblBIssuedBy;
        private System.Windows.Forms.Label lblBBookingDate;
        private System.Windows.Forms.Label lblBTransactionNo;
        private System.Windows.Forms.Label lblBValidUntil;
        private System.Windows.Forms.Label lblPaymentTotalAmmount;
        private System.Windows.Forms.Label lblPaymentORNo;
        private System.Windows.Forms.Label lblPaymentTINBuyer;
        private System.Windows.Forms.Label lblPPaymentMethod;
        private System.Windows.Forms.Label lblPaymentDateReserved;
        private System.Windows.Forms.Label lblPaymentContactNo;
        private System.Windows.Forms.Label lblPaymentContactPerson;
        private System.Windows.Forms.Label lblPaymentAddress;
        private System.Windows.Forms.Label lblPaymentSoldTo;
        private System.Windows.Forms.Label lblPaymentIssueLoc;
        private System.Windows.Forms.Label lblVType;
        private System.Windows.Forms.Label lblVORNo;
        private System.Windows.Forms.Label lblVTotalAmmount;
        private System.Windows.Forms.Label lblVAgeGender;
        private System.Windows.Forms.Label lblVDepartureDate;
        private System.Windows.Forms.Label lblVVesselName;
        private System.Windows.Forms.Label lblVFromToCode;
        private System.Windows.Forms.Label lblVName;
        private System.Windows.Forms.Label lblBCType;
        private System.Windows.Forms.Label lblBCORNo;
        private System.Windows.Forms.Label lblBCTotalAmmount;
        private System.Windows.Forms.Label lblBCAgeGender;
        private System.Windows.Forms.Label lblBCDepartureDate;
        private System.Windows.Forms.Label lblBCVesselName;
        private System.Windows.Forms.Label lblBCFromToCode;
        private System.Windows.Forms.Label lblBCName;
    }
}
