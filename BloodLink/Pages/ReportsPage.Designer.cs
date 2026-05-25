namespace BloodLink.Pages
{
    partial class ReportsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsPage));
            tlpReports = new TableLayoutPanel();
            tblFirstRow = new TableLayoutPanel();
            tlpUnitsExpired = new TableLayoutPanel();
            pnlExpiredUnitsCount = new Panel();
            lblUnitsExpiredCount = new Label();
            pnlExpiredUnitsHeader = new Panel();
            lblUnitsExpiredHeader = new Label();
            pnlExpiredUnitsFooter = new Panel();
            lblUnitsExpiredFooter = new Label();
            tlpUnitsAvailable = new TableLayoutPanel();
            pnlAvailableUnitsCount = new Panel();
            lblUnitsIssuedCount = new Label();
            pnlAvailableUnitsHeading = new Panel();
            lblUntisIssuedHeader = new Label();
            pnlAvailableUnitsFooter = new Panel();
            lblUnitsIssuedFooter = new Label();
            tlpUnitsCollection = new TableLayoutPanel();
            pnlUnitsCollectedCount = new Panel();
            lblUnitsColledtedCount = new Label();
            pnlUnitsCollectedHeading = new Panel();
            lblUnitsCollectedHeader = new Label();
            pnlUnitstCollectedFooter = new Panel();
            lblUnitsCollectedFooter = new Label();
            tlpSecondSection = new TableLayoutPanel();
            tlpBloodStock = new TableLayoutPanel();
            pnlBloodStock = new Panel();
            lblCurrentAvailableUnits = new Label();
            lblBloodStock = new Label();
            tlpRightStockReports = new TableLayoutPanel();
            tlpMonthlyDonations = new TableLayoutPanel();
            pnlMonthlyDonationsHeading = new Panel();
            lblMonthlyDonationsTime = new Label();
            lblMonthlyDonations = new Label();
            tlpRequestsStaus = new TableLayoutPanel();
            tlpPiChart = new TableLayoutPanel();
            pnlPiChart = new Panel();
            tlpPiChartStats = new TableLayoutPanel();
            lblRejectedCount = new Label();
            lblRejected = new Label();
            lblPendingCount = new Label();
            lblPending = new Label();
            lblFulfilledCount = new Label();
            lblFulfilled = new Label();
            panel1 = new Panel();
            lblRequestStatusTime = new Label();
            lblRequestStatus = new Label();
            tlpReports.SuspendLayout();
            tblFirstRow.SuspendLayout();
            tlpUnitsExpired.SuspendLayout();
            pnlExpiredUnitsCount.SuspendLayout();
            pnlExpiredUnitsHeader.SuspendLayout();
            pnlExpiredUnitsFooter.SuspendLayout();
            tlpUnitsAvailable.SuspendLayout();
            pnlAvailableUnitsCount.SuspendLayout();
            pnlAvailableUnitsHeading.SuspendLayout();
            pnlAvailableUnitsFooter.SuspendLayout();
            tlpUnitsCollection.SuspendLayout();
            pnlUnitsCollectedCount.SuspendLayout();
            pnlUnitsCollectedHeading.SuspendLayout();
            pnlUnitstCollectedFooter.SuspendLayout();
            tlpSecondSection.SuspendLayout();
            tlpBloodStock.SuspendLayout();
            pnlBloodStock.SuspendLayout();
            tlpRightStockReports.SuspendLayout();
            tlpMonthlyDonations.SuspendLayout();
            pnlMonthlyDonationsHeading.SuspendLayout();
            tlpRequestsStaus.SuspendLayout();
            tlpPiChart.SuspendLayout();
            tlpPiChartStats.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpReports
            // 
            tlpReports.ColumnCount = 1;
            tlpReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpReports.Controls.Add(tblFirstRow, 0, 0);
            tlpReports.Controls.Add(tlpSecondSection, 0, 1);
            tlpReports.Dock = DockStyle.Fill;
            tlpReports.Location = new Point(0, 0);
            tlpReports.Name = "tlpReports";
            tlpReports.RowCount = 2;
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tlpReports.Size = new Size(857, 560);
            tlpReports.TabIndex = 1;
            // 
            // tblFirstRow
            // 
            tblFirstRow.ColumnCount = 3;
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblFirstRow.Controls.Add(tlpUnitsExpired, 2, 0);
            tblFirstRow.Controls.Add(tlpUnitsAvailable, 1, 0);
            tblFirstRow.Controls.Add(tlpUnitsCollection, 0, 0);
            tblFirstRow.Dock = DockStyle.Fill;
            tblFirstRow.Location = new Point(3, 3);
            tblFirstRow.Name = "tblFirstRow";
            tblFirstRow.RowCount = 1;
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFirstRow.Size = new Size(851, 106);
            tblFirstRow.TabIndex = 1;
            // 
            // tlpUnitsExpired
            // 
            tlpUnitsExpired.BackColor = SystemColors.Control;
            tlpUnitsExpired.ColumnCount = 1;
            tlpUnitsExpired.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpUnitsExpired.Controls.Add(pnlExpiredUnitsCount, 0, 1);
            tlpUnitsExpired.Controls.Add(pnlExpiredUnitsHeader, 0, 0);
            tlpUnitsExpired.Controls.Add(pnlExpiredUnitsFooter, 0, 2);
            tlpUnitsExpired.Dock = DockStyle.Fill;
            tlpUnitsExpired.Location = new Point(569, 3);
            tlpUnitsExpired.Name = "tlpUnitsExpired";
            tlpUnitsExpired.RowCount = 3;
            tlpUnitsExpired.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpUnitsExpired.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpUnitsExpired.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpUnitsExpired.Size = new Size(279, 100);
            tlpUnitsExpired.TabIndex = 8;
            // 
            // pnlExpiredUnitsCount
            // 
            pnlExpiredUnitsCount.Controls.Add(lblUnitsExpiredCount);
            pnlExpiredUnitsCount.Dock = DockStyle.Fill;
            pnlExpiredUnitsCount.Location = new Point(3, 37);
            pnlExpiredUnitsCount.Name = "pnlExpiredUnitsCount";
            pnlExpiredUnitsCount.Size = new Size(273, 25);
            pnlExpiredUnitsCount.TabIndex = 3;
            // 
            // lblUnitsExpiredCount
            // 
            lblUnitsExpiredCount.Dock = DockStyle.Fill;
            lblUnitsExpiredCount.Location = new Point(0, 0);
            lblUnitsExpiredCount.Name = "lblUnitsExpiredCount";
            lblUnitsExpiredCount.Padding = new Padding(8, 0, 0, 0);
            lblUnitsExpiredCount.Size = new Size(273, 25);
            lblUnitsExpiredCount.TabIndex = 0;
            lblUnitsExpiredCount.Text = "8";
            lblUnitsExpiredCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlExpiredUnitsHeader
            // 
            pnlExpiredUnitsHeader.Controls.Add(lblUnitsExpiredHeader);
            pnlExpiredUnitsHeader.Dock = DockStyle.Fill;
            pnlExpiredUnitsHeader.Location = new Point(3, 3);
            pnlExpiredUnitsHeader.Name = "pnlExpiredUnitsHeader";
            pnlExpiredUnitsHeader.Size = new Size(273, 28);
            pnlExpiredUnitsHeader.TabIndex = 2;
            // 
            // lblUnitsExpiredHeader
            // 
            lblUnitsExpiredHeader.Dock = DockStyle.Fill;
            lblUnitsExpiredHeader.Location = new Point(0, 0);
            lblUnitsExpiredHeader.Name = "lblUnitsExpiredHeader";
            lblUnitsExpiredHeader.Padding = new Padding(8, 0, 0, 0);
            lblUnitsExpiredHeader.Size = new Size(273, 28);
            lblUnitsExpiredHeader.TabIndex = 0;
            lblUnitsExpiredHeader.Text = "Units Expired";
            lblUnitsExpiredHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlExpiredUnitsFooter
            // 
            pnlExpiredUnitsFooter.Controls.Add(lblUnitsExpiredFooter);
            pnlExpiredUnitsFooter.Dock = DockStyle.Fill;
            pnlExpiredUnitsFooter.Location = new Point(3, 68);
            pnlExpiredUnitsFooter.Name = "pnlExpiredUnitsFooter";
            pnlExpiredUnitsFooter.Size = new Size(273, 29);
            pnlExpiredUnitsFooter.TabIndex = 4;
            // 
            // lblUnitsExpiredFooter
            // 
            lblUnitsExpiredFooter.Dock = DockStyle.Fill;
            lblUnitsExpiredFooter.Location = new Point(0, 0);
            lblUnitsExpiredFooter.Name = "lblUnitsExpiredFooter";
            lblUnitsExpiredFooter.Padding = new Padding(8, 0, 0, 0);
            lblUnitsExpiredFooter.Size = new Size(273, 29);
            lblUnitsExpiredFooter.TabIndex = 0;
            lblUnitsExpiredFooter.Text = "this month";
            // 
            // tlpUnitsAvailable
            // 
            tlpUnitsAvailable.BackColor = SystemColors.Control;
            tlpUnitsAvailable.ColumnCount = 1;
            tlpUnitsAvailable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpUnitsAvailable.Controls.Add(pnlAvailableUnitsCount, 0, 1);
            tlpUnitsAvailable.Controls.Add(pnlAvailableUnitsHeading, 0, 0);
            tlpUnitsAvailable.Controls.Add(pnlAvailableUnitsFooter, 0, 2);
            tlpUnitsAvailable.Dock = DockStyle.Fill;
            tlpUnitsAvailable.Location = new Point(286, 3);
            tlpUnitsAvailable.Name = "tlpUnitsAvailable";
            tlpUnitsAvailable.RowCount = 3;
            tlpUnitsAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpUnitsAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpUnitsAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpUnitsAvailable.Size = new Size(277, 100);
            tlpUnitsAvailable.TabIndex = 7;
            // 
            // pnlAvailableUnitsCount
            // 
            pnlAvailableUnitsCount.Controls.Add(lblUnitsIssuedCount);
            pnlAvailableUnitsCount.Dock = DockStyle.Fill;
            pnlAvailableUnitsCount.Location = new Point(3, 37);
            pnlAvailableUnitsCount.Name = "pnlAvailableUnitsCount";
            pnlAvailableUnitsCount.Size = new Size(271, 25);
            pnlAvailableUnitsCount.TabIndex = 3;
            // 
            // lblUnitsIssuedCount
            // 
            lblUnitsIssuedCount.Dock = DockStyle.Fill;
            lblUnitsIssuedCount.Location = new Point(0, 0);
            lblUnitsIssuedCount.Name = "lblUnitsIssuedCount";
            lblUnitsIssuedCount.Padding = new Padding(8, 0, 0, 0);
            lblUnitsIssuedCount.Size = new Size(271, 25);
            lblUnitsIssuedCount.TabIndex = 0;
            lblUnitsIssuedCount.Text = "71";
            lblUnitsIssuedCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAvailableUnitsHeading
            // 
            pnlAvailableUnitsHeading.Controls.Add(lblUntisIssuedHeader);
            pnlAvailableUnitsHeading.Dock = DockStyle.Fill;
            pnlAvailableUnitsHeading.Location = new Point(3, 3);
            pnlAvailableUnitsHeading.Name = "pnlAvailableUnitsHeading";
            pnlAvailableUnitsHeading.Size = new Size(271, 28);
            pnlAvailableUnitsHeading.TabIndex = 2;
            // 
            // lblUntisIssuedHeader
            // 
            lblUntisIssuedHeader.Dock = DockStyle.Fill;
            lblUntisIssuedHeader.Location = new Point(0, 0);
            lblUntisIssuedHeader.Name = "lblUntisIssuedHeader";
            lblUntisIssuedHeader.Padding = new Padding(8, 0, 0, 0);
            lblUntisIssuedHeader.Size = new Size(271, 28);
            lblUntisIssuedHeader.TabIndex = 0;
            lblUntisIssuedHeader.Text = "Untis Issued";
            lblUntisIssuedHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlAvailableUnitsFooter
            // 
            pnlAvailableUnitsFooter.Controls.Add(lblUnitsIssuedFooter);
            pnlAvailableUnitsFooter.Dock = DockStyle.Fill;
            pnlAvailableUnitsFooter.Location = new Point(3, 68);
            pnlAvailableUnitsFooter.Name = "pnlAvailableUnitsFooter";
            pnlAvailableUnitsFooter.Size = new Size(271, 29);
            pnlAvailableUnitsFooter.TabIndex = 4;
            // 
            // lblUnitsIssuedFooter
            // 
            lblUnitsIssuedFooter.Dock = DockStyle.Fill;
            lblUnitsIssuedFooter.Location = new Point(0, 0);
            lblUnitsIssuedFooter.Name = "lblUnitsIssuedFooter";
            lblUnitsIssuedFooter.Padding = new Padding(8, 0, 0, 0);
            lblUnitsIssuedFooter.Size = new Size(271, 29);
            lblUnitsIssuedFooter.TabIndex = 0;
            lblUnitsIssuedFooter.Text = "this month";
            // 
            // tlpUnitsCollection
            // 
            tlpUnitsCollection.BackColor = SystemColors.Control;
            tlpUnitsCollection.ColumnCount = 1;
            tlpUnitsCollection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpUnitsCollection.Controls.Add(pnlUnitsCollectedCount, 0, 1);
            tlpUnitsCollection.Controls.Add(pnlUnitsCollectedHeading, 0, 0);
            tlpUnitsCollection.Controls.Add(pnlUnitstCollectedFooter, 0, 2);
            tlpUnitsCollection.Dock = DockStyle.Fill;
            tlpUnitsCollection.Location = new Point(3, 3);
            tlpUnitsCollection.Name = "tlpUnitsCollection";
            tlpUnitsCollection.RowCount = 3;
            tlpUnitsCollection.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpUnitsCollection.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpUnitsCollection.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpUnitsCollection.Size = new Size(277, 100);
            tlpUnitsCollection.TabIndex = 6;
            // 
            // pnlUnitsCollectedCount
            // 
            pnlUnitsCollectedCount.Controls.Add(lblUnitsColledtedCount);
            pnlUnitsCollectedCount.Dock = DockStyle.Fill;
            pnlUnitsCollectedCount.Location = new Point(3, 37);
            pnlUnitsCollectedCount.Name = "pnlUnitsCollectedCount";
            pnlUnitsCollectedCount.Size = new Size(271, 25);
            pnlUnitsCollectedCount.TabIndex = 3;
            // 
            // lblUnitsColledtedCount
            // 
            lblUnitsColledtedCount.Dock = DockStyle.Fill;
            lblUnitsColledtedCount.Location = new Point(0, 0);
            lblUnitsColledtedCount.Name = "lblUnitsColledtedCount";
            lblUnitsColledtedCount.Padding = new Padding(8, 0, 0, 0);
            lblUnitsColledtedCount.Size = new Size(271, 25);
            lblUnitsColledtedCount.TabIndex = 0;
            lblUnitsColledtedCount.Text = "86";
            lblUnitsColledtedCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlUnitsCollectedHeading
            // 
            pnlUnitsCollectedHeading.Controls.Add(lblUnitsCollectedHeader);
            pnlUnitsCollectedHeading.Dock = DockStyle.Fill;
            pnlUnitsCollectedHeading.Location = new Point(3, 3);
            pnlUnitsCollectedHeading.Name = "pnlUnitsCollectedHeading";
            pnlUnitsCollectedHeading.Size = new Size(271, 28);
            pnlUnitsCollectedHeading.TabIndex = 2;
            // 
            // lblUnitsCollectedHeader
            // 
            lblUnitsCollectedHeader.Dock = DockStyle.Fill;
            lblUnitsCollectedHeader.Location = new Point(0, 0);
            lblUnitsCollectedHeader.Name = "lblUnitsCollectedHeader";
            lblUnitsCollectedHeader.Padding = new Padding(8, 0, 0, 0);
            lblUnitsCollectedHeader.Size = new Size(271, 28);
            lblUnitsCollectedHeader.TabIndex = 0;
            lblUnitsCollectedHeader.Text = "Units Collected";
            lblUnitsCollectedHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlUnitstCollectedFooter
            // 
            pnlUnitstCollectedFooter.Controls.Add(lblUnitsCollectedFooter);
            pnlUnitstCollectedFooter.Dock = DockStyle.Fill;
            pnlUnitstCollectedFooter.Location = new Point(3, 68);
            pnlUnitstCollectedFooter.Name = "pnlUnitstCollectedFooter";
            pnlUnitstCollectedFooter.Size = new Size(271, 29);
            pnlUnitstCollectedFooter.TabIndex = 4;
            // 
            // lblUnitsCollectedFooter
            // 
            lblUnitsCollectedFooter.Dock = DockStyle.Fill;
            lblUnitsCollectedFooter.Location = new Point(0, 0);
            lblUnitsCollectedFooter.Name = "lblUnitsCollectedFooter";
            lblUnitsCollectedFooter.Padding = new Padding(8, 0, 0, 0);
            lblUnitsCollectedFooter.Size = new Size(271, 29);
            lblUnitsCollectedFooter.TabIndex = 0;
            lblUnitsCollectedFooter.Text = "this month";
            // 
            // tlpSecondSection
            // 
            tlpSecondSection.ColumnCount = 2;
            tlpSecondSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSecondSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSecondSection.Controls.Add(tlpBloodStock, 0, 0);
            tlpSecondSection.Controls.Add(tlpRightStockReports, 1, 0);
            tlpSecondSection.Dock = DockStyle.Fill;
            tlpSecondSection.Location = new Point(3, 115);
            tlpSecondSection.Name = "tlpSecondSection";
            tlpSecondSection.RowCount = 1;
            tlpSecondSection.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSecondSection.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpSecondSection.Size = new Size(851, 442);
            tlpSecondSection.TabIndex = 2;
            // 
            // tlpBloodStock
            // 
            tlpBloodStock.ColumnCount = 1;
            tlpBloodStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBloodStock.Controls.Add(pnlBloodStock, 0, 0);
            tlpBloodStock.Dock = DockStyle.Fill;
            tlpBloodStock.Location = new Point(3, 3);
            tlpBloodStock.Name = "tlpBloodStock";
            tlpBloodStock.Padding = new Padding(10, 18, 10, 18);
            tlpBloodStock.RowCount = 2;
            tlpBloodStock.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tlpBloodStock.RowStyles.Add(new RowStyle(SizeType.Percent, 85.71429F));
            tlpBloodStock.Size = new Size(419, 436);
            tlpBloodStock.TabIndex = 0;
            // 
            // pnlBloodStock
            // 
            pnlBloodStock.Controls.Add(lblCurrentAvailableUnits);
            pnlBloodStock.Controls.Add(lblBloodStock);
            pnlBloodStock.Dock = DockStyle.Fill;
            pnlBloodStock.Location = new Point(13, 21);
            pnlBloodStock.Name = "pnlBloodStock";
            pnlBloodStock.Size = new Size(393, 51);
            pnlBloodStock.TabIndex = 0;
            // 
            // lblCurrentAvailableUnits
            // 
            lblCurrentAvailableUnits.AutoSize = true;
            lblCurrentAvailableUnits.Dock = DockStyle.Top;
            lblCurrentAvailableUnits.Location = new Point(0, 15);
            lblCurrentAvailableUnits.Name = "lblCurrentAvailableUnits";
            lblCurrentAvailableUnits.Size = new Size(123, 15);
            lblCurrentAvailableUnits.TabIndex = 1;
            lblCurrentAvailableUnits.Text = "current available units";
            // 
            // lblBloodStock
            // 
            lblBloodStock.AutoSize = true;
            lblBloodStock.Dock = DockStyle.Top;
            lblBloodStock.Location = new Point(0, 0);
            lblBloodStock.Name = "lblBloodStock";
            lblBloodStock.Size = new Size(121, 15);
            lblBloodStock.TabIndex = 0;
            lblBloodStock.Text = "Stock by blood group";
            // 
            // tlpRightStockReports
            // 
            tlpRightStockReports.ColumnCount = 1;
            tlpRightStockReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRightStockReports.Controls.Add(tlpMonthlyDonations, 0, 0);
            tlpRightStockReports.Controls.Add(tlpRequestsStaus, 0, 1);
            tlpRightStockReports.Dock = DockStyle.Fill;
            tlpRightStockReports.Location = new Point(428, 3);
            tlpRightStockReports.Name = "tlpRightStockReports";
            tlpRightStockReports.RowCount = 2;
            tlpRightStockReports.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlpRightStockReports.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpRightStockReports.Size = new Size(420, 436);
            tlpRightStockReports.TabIndex = 1;
            // 
            // tlpMonthlyDonations
            // 
            tlpMonthlyDonations.ColumnCount = 1;
            tlpMonthlyDonations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMonthlyDonations.Controls.Add(pnlMonthlyDonationsHeading, 0, 0);
            tlpMonthlyDonations.Dock = DockStyle.Fill;
            tlpMonthlyDonations.Location = new Point(3, 3);
            tlpMonthlyDonations.Name = "tlpMonthlyDonations";
            tlpMonthlyDonations.Padding = new Padding(10, 16, 10, 16);
            tlpMonthlyDonations.RowCount = 2;
            tlpMonthlyDonations.RowStyles.Add(new RowStyle(SizeType.Percent, 23.1381588F));
            tlpMonthlyDonations.RowStyles.Add(new RowStyle(SizeType.Percent, 76.86184F));
            tlpMonthlyDonations.Size = new Size(414, 233);
            tlpMonthlyDonations.TabIndex = 0;
            // 
            // pnlMonthlyDonationsHeading
            // 
            pnlMonthlyDonationsHeading.Controls.Add(lblMonthlyDonationsTime);
            pnlMonthlyDonationsHeading.Controls.Add(lblMonthlyDonations);
            pnlMonthlyDonationsHeading.Dock = DockStyle.Fill;
            pnlMonthlyDonationsHeading.Location = new Point(13, 19);
            pnlMonthlyDonationsHeading.Name = "pnlMonthlyDonationsHeading";
            pnlMonthlyDonationsHeading.Size = new Size(388, 40);
            pnlMonthlyDonationsHeading.TabIndex = 0;
            // 
            // lblMonthlyDonationsTime
            // 
            lblMonthlyDonationsTime.AutoSize = true;
            lblMonthlyDonationsTime.Dock = DockStyle.Top;
            lblMonthlyDonationsTime.Location = new Point(0, 15);
            lblMonthlyDonationsTime.Name = "lblMonthlyDonationsTime";
            lblMonthlyDonationsTime.Size = new Size(81, 15);
            lblMonthlyDonationsTime.TabIndex = 3;
            lblMonthlyDonationsTime.Text = "Last 6 months";
            // 
            // lblMonthlyDonations
            // 
            lblMonthlyDonations.AutoSize = true;
            lblMonthlyDonations.Dock = DockStyle.Top;
            lblMonthlyDonations.Location = new Point(0, 0);
            lblMonthlyDonations.Name = "lblMonthlyDonations";
            lblMonthlyDonations.Size = new Size(109, 15);
            lblMonthlyDonations.TabIndex = 2;
            lblMonthlyDonations.Text = "Monthly Donations";
            // 
            // tlpRequestsStaus
            // 
            tlpRequestsStaus.ColumnCount = 1;
            tlpRequestsStaus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRequestsStaus.Controls.Add(tlpPiChart, 0, 1);
            tlpRequestsStaus.Controls.Add(panel1, 0, 0);
            tlpRequestsStaus.Dock = DockStyle.Fill;
            tlpRequestsStaus.Location = new Point(3, 242);
            tlpRequestsStaus.Name = "tlpRequestsStaus";
            tlpRequestsStaus.Padding = new Padding(10, 16, 10, 16);
            tlpRequestsStaus.RowCount = 2;
            tlpRequestsStaus.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpRequestsStaus.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tlpRequestsStaus.Size = new Size(414, 191);
            tlpRequestsStaus.TabIndex = 1;
            // 
            // tlpPiChart
            // 
            tlpPiChart.ColumnCount = 2;
            tlpPiChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpPiChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpPiChart.Controls.Add(pnlPiChart, 0, 0);
            tlpPiChart.Controls.Add(tlpPiChartStats, 1, 0);
            tlpPiChart.Dock = DockStyle.Fill;
            tlpPiChart.Location = new Point(13, 58);
            tlpPiChart.Name = "tlpPiChart";
            tlpPiChart.Padding = new Padding(8, 0, 0, 0);
            tlpPiChart.RowCount = 1;
            tlpPiChart.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPiChart.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPiChart.Size = new Size(388, 114);
            tlpPiChart.TabIndex = 4;
            // 
            // pnlPiChart
            // 
            pnlPiChart.Dock = DockStyle.Fill;
            pnlPiChart.Location = new Point(11, 3);
            pnlPiChart.Name = "pnlPiChart";
            pnlPiChart.Size = new Size(127, 108);
            pnlPiChart.TabIndex = 0;
            // 
            // tlpPiChartStats
            // 
            tlpPiChartStats.ColumnCount = 2;
            tlpPiChartStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tlpPiChartStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPiChartStats.Controls.Add(lblRejectedCount, 1, 2);
            tlpPiChartStats.Controls.Add(lblRejected, 0, 2);
            tlpPiChartStats.Controls.Add(lblPendingCount, 1, 1);
            tlpPiChartStats.Controls.Add(lblPending, 0, 1);
            tlpPiChartStats.Controls.Add(lblFulfilledCount, 1, 0);
            tlpPiChartStats.Controls.Add(lblFulfilled, 0, 0);
            tlpPiChartStats.Dock = DockStyle.Fill;
            tlpPiChartStats.Location = new Point(149, 8);
            tlpPiChartStats.Margin = new Padding(8);
            tlpPiChartStats.Name = "tlpPiChartStats";
            tlpPiChartStats.Padding = new Padding(0, 6, 0, 6);
            tlpPiChartStats.RowCount = 3;
            tlpPiChartStats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpPiChartStats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpPiChartStats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpPiChartStats.Size = new Size(231, 98);
            tlpPiChartStats.TabIndex = 1;
            // 
            // lblRejectedCount
            // 
            lblRejectedCount.AutoSize = true;
            lblRejectedCount.Dock = DockStyle.Fill;
            lblRejectedCount.Location = new Point(176, 62);
            lblRejectedCount.Name = "lblRejectedCount";
            lblRejectedCount.Size = new Size(52, 30);
            lblRejectedCount.TabIndex = 5;
            lblRejectedCount.Text = "4";
            lblRejectedCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRejected
            // 
            lblRejected.AutoSize = true;
            lblRejected.Dock = DockStyle.Fill;
            lblRejected.Image = (Image)resources.GetObject("lblRejected.Image");
            lblRejected.ImageAlign = ContentAlignment.MiddleLeft;
            lblRejected.Location = new Point(3, 62);
            lblRejected.Name = "lblRejected";
            lblRejected.Padding = new Padding(15, 0, 0, 0);
            lblRejected.Size = new Size(167, 30);
            lblRejected.TabIndex = 4;
            lblRejected.Text = "       Rejected";
            lblRejected.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Dock = DockStyle.Fill;
            lblPendingCount.Location = new Point(176, 34);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(52, 28);
            lblPendingCount.TabIndex = 3;
            lblPendingCount.Text = "11";
            lblPendingCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Dock = DockStyle.Fill;
            lblPending.Image = (Image)resources.GetObject("lblPending.Image");
            lblPending.ImageAlign = ContentAlignment.MiddleLeft;
            lblPending.Location = new Point(3, 34);
            lblPending.Name = "lblPending";
            lblPending.Padding = new Padding(15, 0, 0, 0);
            lblPending.Size = new Size(167, 28);
            lblPending.TabIndex = 2;
            lblPending.Text = "       Pending";
            lblPending.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFulfilledCount
            // 
            lblFulfilledCount.AutoSize = true;
            lblFulfilledCount.Dock = DockStyle.Fill;
            lblFulfilledCount.Location = new Point(176, 6);
            lblFulfilledCount.Name = "lblFulfilledCount";
            lblFulfilledCount.Size = new Size(52, 28);
            lblFulfilledCount.TabIndex = 1;
            lblFulfilledCount.Text = "12";
            lblFulfilledCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFulfilled
            // 
            lblFulfilled.AutoSize = true;
            lblFulfilled.Dock = DockStyle.Fill;
            lblFulfilled.Image = (Image)resources.GetObject("lblFulfilled.Image");
            lblFulfilled.ImageAlign = ContentAlignment.MiddleLeft;
            lblFulfilled.Location = new Point(3, 6);
            lblFulfilled.Name = "lblFulfilled";
            lblFulfilled.Padding = new Padding(15, 0, 0, 0);
            lblFulfilled.Size = new Size(167, 28);
            lblFulfilled.TabIndex = 0;
            lblFulfilled.Text = "       Fulfilled";
            lblFulfilled.TextAlign = ContentAlignment.MiddleLeft;
            lblFulfilled.Paint += lblFulfilled_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblRequestStatusTime);
            panel1.Controls.Add(lblRequestStatus);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(13, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 33);
            panel1.TabIndex = 1;
            // 
            // lblRequestStatusTime
            // 
            lblRequestStatusTime.AutoSize = true;
            lblRequestStatusTime.Dock = DockStyle.Top;
            lblRequestStatusTime.Location = new Point(0, 15);
            lblRequestStatusTime.Name = "lblRequestStatusTime";
            lblRequestStatusTime.Size = new Size(65, 15);
            lblRequestStatusTime.TabIndex = 3;
            lblRequestStatusTime.Text = "this month";
            // 
            // lblRequestStatus
            // 
            lblRequestStatus.AutoSize = true;
            lblRequestStatus.Dock = DockStyle.Top;
            lblRequestStatus.Location = new Point(0, 0);
            lblRequestStatus.Name = "lblRequestStatus";
            lblRequestStatus.Size = new Size(89, 15);
            lblRequestStatus.TabIndex = 2;
            lblRequestStatus.Text = "Requests Status";
            // 
            // ReportsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpReports);
            Name = "ReportsPage";
            Size = new Size(857, 560);
            tlpReports.ResumeLayout(false);
            tblFirstRow.ResumeLayout(false);
            tlpUnitsExpired.ResumeLayout(false);
            pnlExpiredUnitsCount.ResumeLayout(false);
            pnlExpiredUnitsHeader.ResumeLayout(false);
            pnlExpiredUnitsFooter.ResumeLayout(false);
            tlpUnitsAvailable.ResumeLayout(false);
            pnlAvailableUnitsCount.ResumeLayout(false);
            pnlAvailableUnitsHeading.ResumeLayout(false);
            pnlAvailableUnitsFooter.ResumeLayout(false);
            tlpUnitsCollection.ResumeLayout(false);
            pnlUnitsCollectedCount.ResumeLayout(false);
            pnlUnitsCollectedHeading.ResumeLayout(false);
            pnlUnitstCollectedFooter.ResumeLayout(false);
            tlpSecondSection.ResumeLayout(false);
            tlpBloodStock.ResumeLayout(false);
            pnlBloodStock.ResumeLayout(false);
            pnlBloodStock.PerformLayout();
            tlpRightStockReports.ResumeLayout(false);
            tlpMonthlyDonations.ResumeLayout(false);
            pnlMonthlyDonationsHeading.ResumeLayout(false);
            pnlMonthlyDonationsHeading.PerformLayout();
            tlpRequestsStaus.ResumeLayout(false);
            tlpPiChart.ResumeLayout(false);
            tlpPiChartStats.ResumeLayout(false);
            tlpPiChartStats.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpReports;
        private TableLayoutPanel tblFirstRow;
        private TableLayoutPanel tlpUnitsExpired;
        private Panel pnlExpiredUnitsCount;
        private Label lblUnitsExpiredCount;
        private Panel pnlExpiredUnitsHeader;
        private Label lblUnitsExpiredHeader;
        private Panel pnlExpiredUnitsFooter;
        private Label lblUnitsExpiredFooter;
        private TableLayoutPanel tlpUnitsAvailable;
        private Panel pnlAvailableUnitsCount;
        private Label lblUnitsIssuedCount;
        private Panel pnlAvailableUnitsHeading;
        private Label lblUntisIssuedHeader;
        private Panel pnlAvailableUnitsFooter;
        private Label lblUnitsIssuedFooter;
        private TableLayoutPanel tlpUnitsCollection;
        private Panel pnlUnitsCollectedCount;
        private Label lblUnitsColledtedCount;
        private Panel pnlUnitsCollectedHeading;
        private Label lblUnitsCollectedHeader;
        private Panel pnlUnitstCollectedFooter;
        private Label lblUnitsCollectedFooter;
        private TableLayoutPanel tlpSecondSection;
        private TableLayoutPanel tlpBloodStock;
        private Panel pnlBloodStock;
        private Label lblCurrentAvailableUnits;
        private Label lblBloodStock;
        private TableLayoutPanel tlpRightStockReports;
        private TableLayoutPanel tlpMonthlyDonations;
        private Panel pnlMonthlyDonationsHeading;
        private Label lblMonthlyDonationsTime;
        private Label lblMonthlyDonations;
        private TableLayoutPanel tlpRequestsStaus;
        private Panel panel1;
        private Label lblRequestStatusTime;
        private Label lblRequestStatus;
        private TableLayoutPanel tlpPiChart;
        private Panel pnlPiChart;
        private TableLayoutPanel tlpPiChartStats;
        private Label lblRejectedCount;
        private Label lblRejected;
        private Label lblPendingCount;
        private Label lblPending;
        private Label lblFulfilledCount;
        private Label lblFulfilled;
    }
}
