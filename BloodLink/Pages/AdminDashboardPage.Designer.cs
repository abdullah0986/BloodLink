namespace BloodLink.Pages
{
    partial class AdminDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tblDashboard = new TableLayoutPanel();
            tblFirstRow = new TableLayoutPanel();
            pnlTotalDonor = new Panel();
            pbDonorIcon = new FontAwesome.Sharp.IconPictureBox();
            lblTotalDonorInfo = new Label();
            lblTotalDonorCount = new Label();
            lblTotalDonor = new Label();
            pnlBloodUnits = new Panel();
            pbBloodUnits = new FontAwesome.Sharp.IconPictureBox();
            lblBloodUnitsInfo = new Label();
            lblBloodUnitsCount = new Label();
            lblBloodUnits = new Label();
            pnlPatientToday = new Panel();
            pbPatientsToday = new FontAwesome.Sharp.IconPictureBox();
            lblPatientTodayInfo = new Label();
            lblPatientTodayCount = new Label();
            lblPatientToday = new Label();
            pnlExpiringSoon = new Panel();
            lblExpiringSoon = new Label();
            pbExpiringSoon = new FontAwesome.Sharp.IconPictureBox();
            lblExpiringSoonInfo = new Label();
            lblExpiringSoonCount = new Label();
            tblSecondRow = new TableLayoutPanel();
            panel1 = new Panel();
            dgvExpiringUnits = new DataGridView();
            colBloodInfo = new DataGridViewTextBoxColumn();
            colExpiringDays = new DataGridViewTextBoxColumn();
            lblExpiringUnits = new Label();
            pnlBloodBreakdown = new Panel();
            tblBloodBreakdown = new TableLayoutPanel();
            pnlAPlus = new Panel();
            tblAPlus = new TableLayoutPanel();
            lblAPlusCount = new Label();
            pnlForAPlus = new Panel();
            lblAPlus = new Label();
            pnlAMinus = new Panel();
            tblAMinus = new TableLayoutPanel();
            lblAMinusCount = new Label();
            pnlForAMinus = new Panel();
            lblAMinus = new Label();
            pnlBPlus = new Panel();
            tblBPlus = new TableLayoutPanel();
            lblBPlusCount = new Label();
            pnlForBPlus = new Panel();
            lblBPlus = new Label();
            pnlBMinus = new Panel();
            tblBMinus = new TableLayoutPanel();
            lblBMinusCount = new Label();
            pnlForBMinus = new Panel();
            lblBMinus = new Label();
            pnlOPlus = new Panel();
            tblOPlus = new TableLayoutPanel();
            lblOPlusCount = new Label();
            pnlForOPlus = new Panel();
            lblOPlus = new Label();
            pnlOMinus = new Panel();
            tblOMinus = new TableLayoutPanel();
            lblOMinusCount = new Label();
            pnlForOMinus = new Panel();
            lblOMinus = new Label();
            pnlABPlus = new Panel();
            tblABPlus = new TableLayoutPanel();
            lblABPlusCount = new Label();
            pnlForABPlus = new Panel();
            lblABPlus = new Label();
            pnlABMinus = new Panel();
            tblABMinus = new TableLayoutPanel();
            lblABMinusCount = new Label();
            pnlForABMinus = new Panel();
            lblABMinus = new Label();
            lblBloodBreakdown = new Label();
            pnlPatientRequests = new Panel();
            dgvPatientRequests = new DataGridView();
            colPatient = new DataGridViewTextBoxColumn();
            colGroup = new DataGridViewTextBoxColumn();
            colUnits = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblPatientRequests = new Label();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            tblDashboard.SuspendLayout();
            tblFirstRow.SuspendLayout();
            pnlTotalDonor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDonorIcon).BeginInit();
            pnlBloodUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBloodUnits).BeginInit();
            pnlPatientToday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPatientsToday).BeginInit();
            pnlExpiringSoon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExpiringSoon).BeginInit();
            tblSecondRow.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpiringUnits).BeginInit();
            pnlBloodBreakdown.SuspendLayout();
            tblBloodBreakdown.SuspendLayout();
            pnlAPlus.SuspendLayout();
            tblAPlus.SuspendLayout();
            pnlForAPlus.SuspendLayout();
            pnlAMinus.SuspendLayout();
            tblAMinus.SuspendLayout();
            pnlForAMinus.SuspendLayout();
            pnlBPlus.SuspendLayout();
            tblBPlus.SuspendLayout();
            pnlForBPlus.SuspendLayout();
            pnlBMinus.SuspendLayout();
            tblBMinus.SuspendLayout();
            pnlForBMinus.SuspendLayout();
            pnlOPlus.SuspendLayout();
            tblOPlus.SuspendLayout();
            pnlForOPlus.SuspendLayout();
            pnlOMinus.SuspendLayout();
            tblOMinus.SuspendLayout();
            pnlForOMinus.SuspendLayout();
            pnlABPlus.SuspendLayout();
            tblABPlus.SuspendLayout();
            pnlForABPlus.SuspendLayout();
            pnlABMinus.SuspendLayout();
            tblABMinus.SuspendLayout();
            pnlForABMinus.SuspendLayout();
            pnlPatientRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatientRequests).BeginInit();
            SuspendLayout();
            // 
            // tblDashboard
            // 
            tblDashboard.ColumnCount = 1;
            tblDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDashboard.Controls.Add(tblFirstRow, 0, 0);
            tblDashboard.Controls.Add(tblSecondRow, 0, 1);
            tblDashboard.Controls.Add(pnlPatientRequests, 0, 2);
            tblDashboard.Dock = DockStyle.Fill;
            tblDashboard.Location = new Point(0, 0);
            tblDashboard.Name = "tblDashboard";
            tblDashboard.RowCount = 3;
            tblDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
            tblDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tblDashboard.Size = new Size(819, 555);
            tblDashboard.TabIndex = 0;
            // 
            // tblFirstRow
            // 
            tblFirstRow.ColumnCount = 4;
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.Controls.Add(pnlTotalDonor, 0, 0);
            tblFirstRow.Controls.Add(pnlBloodUnits, 1, 0);
            tblFirstRow.Controls.Add(pnlPatientToday, 2, 0);
            tblFirstRow.Controls.Add(pnlExpiringSoon, 3, 0);
            tblFirstRow.Dock = DockStyle.Fill;
            tblFirstRow.Location = new Point(3, 3);
            tblFirstRow.Name = "tblFirstRow";
            tblFirstRow.RowCount = 1;
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblFirstRow.Size = new Size(813, 105);
            tblFirstRow.TabIndex = 0;
            // 
            // pnlTotalDonor
            // 
            pnlTotalDonor.AutoSize = true;
            pnlTotalDonor.BackColor = SystemColors.ActiveCaption;
            pnlTotalDonor.Controls.Add(pbDonorIcon);
            pnlTotalDonor.Controls.Add(lblTotalDonorInfo);
            pnlTotalDonor.Controls.Add(lblTotalDonorCount);
            pnlTotalDonor.Controls.Add(lblTotalDonor);
            pnlTotalDonor.Dock = DockStyle.Fill;
            pnlTotalDonor.Location = new Point(3, 3);
            pnlTotalDonor.Name = "pnlTotalDonor";
            pnlTotalDonor.Padding = new Padding(20);
            pnlTotalDonor.Size = new Size(197, 99);
            pnlTotalDonor.TabIndex = 0;
            // 
            // pbDonorIcon
            // 
            pbDonorIcon.BackColor = SystemColors.ActiveCaption;
            pbDonorIcon.ForeColor = SystemColors.ControlText;
            pbDonorIcon.IconChar = FontAwesome.Sharp.IconChar.Users;
            pbDonorIcon.IconColor = SystemColors.ControlText;
            pbDonorIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            pbDonorIcon.Location = new Point(20, 14);
            pbDonorIcon.Name = "pbDonorIcon";
            pbDonorIcon.Size = new Size(32, 32);
            pbDonorIcon.TabIndex = 4;
            pbDonorIcon.TabStop = false;
            // 
            // lblTotalDonorInfo
            // 
            lblTotalDonorInfo.AutoSize = true;
            lblTotalDonorInfo.Location = new Point(20, 85);
            lblTotalDonorInfo.Name = "lblTotalDonorInfo";
            lblTotalDonorInfo.Size = new Size(88, 15);
            lblTotalDonorInfo.TabIndex = 3;
            lblTotalDonorInfo.Text = "+12 this month";
            // 
            // lblTotalDonorCount
            // 
            lblTotalDonorCount.AutoSize = true;
            lblTotalDonorCount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalDonorCount.Location = new Point(20, 55);
            lblTotalDonorCount.Name = "lblTotalDonorCount";
            lblTotalDonorCount.Size = new Size(48, 28);
            lblTotalDonorCount.TabIndex = 2;
            lblTotalDonorCount.Text = "298";
            // 
            // lblTotalDonor
            // 
            lblTotalDonor.AutoSize = true;
            lblTotalDonor.Location = new Point(20, 43);
            lblTotalDonor.Name = "lblTotalDonor";
            lblTotalDonor.Size = new Size(74, 15);
            lblTotalDonor.TabIndex = 1;
            lblTotalDonor.Text = "Total Donors";
            lblTotalDonor.Click += lblTotalDonor_Click;
            // 
            // pnlBloodUnits
            // 
            pnlBloodUnits.Controls.Add(pbBloodUnits);
            pnlBloodUnits.Controls.Add(lblBloodUnitsInfo);
            pnlBloodUnits.Controls.Add(lblBloodUnitsCount);
            pnlBloodUnits.Controls.Add(lblBloodUnits);
            pnlBloodUnits.Dock = DockStyle.Fill;
            pnlBloodUnits.Location = new Point(206, 3);
            pnlBloodUnits.Name = "pnlBloodUnits";
            pnlBloodUnits.Size = new Size(197, 99);
            pnlBloodUnits.TabIndex = 1;
            // 
            // pbBloodUnits
            // 
            pbBloodUnits.BackColor = SystemColors.Control;
            pbBloodUnits.ForeColor = SystemColors.ControlText;
            pbBloodUnits.IconChar = FontAwesome.Sharp.IconChar.Tint;
            pbBloodUnits.IconColor = SystemColors.ControlText;
            pbBloodUnits.IconFont = FontAwesome.Sharp.IconFont.Auto;
            pbBloodUnits.Location = new Point(20, 14);
            pbBloodUnits.Name = "pbBloodUnits";
            pbBloodUnits.Size = new Size(32, 32);
            pbBloodUnits.TabIndex = 8;
            pbBloodUnits.TabStop = false;
            // 
            // lblBloodUnitsInfo
            // 
            lblBloodUnitsInfo.AutoSize = true;
            lblBloodUnitsInfo.Location = new Point(21, 85);
            lblBloodUnitsInfo.Name = "lblBloodUnitsInfo";
            lblBloodUnitsInfo.Size = new Size(53, 15);
            lblBloodUnitsInfo.TabIndex = 7;
            lblBloodUnitsInfo.Text = "in stocks";
            // 
            // lblBloodUnitsCount
            // 
            lblBloodUnitsCount.AutoSize = true;
            lblBloodUnitsCount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBloodUnitsCount.Location = new Point(21, 55);
            lblBloodUnitsCount.Name = "lblBloodUnitsCount";
            lblBloodUnitsCount.Size = new Size(48, 28);
            lblBloodUnitsCount.TabIndex = 6;
            lblBloodUnitsCount.Text = "298";
            // 
            // lblBloodUnits
            // 
            lblBloodUnits.AutoSize = true;
            lblBloodUnits.Location = new Point(21, 43);
            lblBloodUnits.Name = "lblBloodUnits";
            lblBloodUnits.Size = new Size(68, 15);
            lblBloodUnits.TabIndex = 5;
            lblBloodUnits.Text = "Blood Units";
            // 
            // pnlPatientToday
            // 
            pnlPatientToday.Controls.Add(pbPatientsToday);
            pnlPatientToday.Controls.Add(lblPatientTodayInfo);
            pnlPatientToday.Controls.Add(lblPatientTodayCount);
            pnlPatientToday.Controls.Add(lblPatientToday);
            pnlPatientToday.Dock = DockStyle.Fill;
            pnlPatientToday.Location = new Point(409, 3);
            pnlPatientToday.Name = "pnlPatientToday";
            pnlPatientToday.Size = new Size(197, 99);
            pnlPatientToday.TabIndex = 2;
            // 
            // pbPatientsToday
            // 
            pbPatientsToday.BackColor = SystemColors.Control;
            pbPatientsToday.ForeColor = SystemColors.ControlText;
            pbPatientsToday.IconChar = FontAwesome.Sharp.IconChar.BedPulse;
            pbPatientsToday.IconColor = SystemColors.ControlText;
            pbPatientsToday.IconFont = FontAwesome.Sharp.IconFont.Auto;
            pbPatientsToday.Location = new Point(20, 14);
            pbPatientsToday.Name = "pbPatientsToday";
            pbPatientsToday.Size = new Size(32, 32);
            pbPatientsToday.TabIndex = 8;
            pbPatientsToday.TabStop = false;
            // 
            // lblPatientTodayInfo
            // 
            lblPatientTodayInfo.AutoSize = true;
            lblPatientTodayInfo.Location = new Point(20, 85);
            lblPatientTodayInfo.Name = "lblPatientTodayInfo";
            lblPatientTodayInfo.Size = new Size(73, 15);
            lblPatientTodayInfo.TabIndex = 7;
            lblPatientTodayInfo.Text = "3 in Pending";
            lblPatientTodayInfo.Click += lblPatientTodayInfo_Click;
            // 
            // lblPatientTodayCount
            // 
            lblPatientTodayCount.AutoSize = true;
            lblPatientTodayCount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPatientTodayCount.Location = new Point(20, 55);
            lblPatientTodayCount.Name = "lblPatientTodayCount";
            lblPatientTodayCount.Size = new Size(48, 28);
            lblPatientTodayCount.TabIndex = 6;
            lblPatientTodayCount.Text = "298";
            lblPatientTodayCount.Click += lblPatientTodayCount_Click;
            // 
            // lblPatientToday
            // 
            lblPatientToday.AutoSize = true;
            lblPatientToday.Location = new Point(20, 43);
            lblPatientToday.Name = "lblPatientToday";
            lblPatientToday.Size = new Size(84, 15);
            lblPatientToday.TabIndex = 5;
            lblPatientToday.Text = "Patients Today";
            // 
            // pnlExpiringSoon
            // 
            pnlExpiringSoon.Controls.Add(lblExpiringSoon);
            pnlExpiringSoon.Controls.Add(pbExpiringSoon);
            pnlExpiringSoon.Controls.Add(lblExpiringSoonInfo);
            pnlExpiringSoon.Controls.Add(lblExpiringSoonCount);
            pnlExpiringSoon.Dock = DockStyle.Fill;
            pnlExpiringSoon.Location = new Point(612, 3);
            pnlExpiringSoon.Name = "pnlExpiringSoon";
            pnlExpiringSoon.Size = new Size(198, 99);
            pnlExpiringSoon.TabIndex = 3;
            // 
            // lblExpiringSoon
            // 
            lblExpiringSoon.AutoSize = true;
            lblExpiringSoon.Location = new Point(20, 43);
            lblExpiringSoon.Name = "lblExpiringSoon";
            lblExpiringSoon.Size = new Size(79, 15);
            lblExpiringSoon.TabIndex = 5;
            lblExpiringSoon.Text = "Expiring Soon";
            // 
            // pbExpiringSoon
            // 
            pbExpiringSoon.BackColor = SystemColors.Control;
            pbExpiringSoon.ForeColor = SystemColors.ControlText;
            pbExpiringSoon.IconChar = FontAwesome.Sharp.IconChar.TintSlash;
            pbExpiringSoon.IconColor = SystemColors.ControlText;
            pbExpiringSoon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            pbExpiringSoon.Location = new Point(20, 14);
            pbExpiringSoon.Name = "pbExpiringSoon";
            pbExpiringSoon.Size = new Size(32, 32);
            pbExpiringSoon.TabIndex = 8;
            pbExpiringSoon.TabStop = false;
            // 
            // lblExpiringSoonInfo
            // 
            lblExpiringSoonInfo.AutoSize = true;
            lblExpiringSoonInfo.Location = new Point(20, 85);
            lblExpiringSoonInfo.Name = "lblExpiringSoonInfo";
            lblExpiringSoonInfo.Size = new Size(76, 15);
            lblExpiringSoonInfo.TabIndex = 7;
            lblExpiringSoonInfo.Text = "within 7 days";
            // 
            // lblExpiringSoonCount
            // 
            lblExpiringSoonCount.AutoSize = true;
            lblExpiringSoonCount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblExpiringSoonCount.Location = new Point(20, 55);
            lblExpiringSoonCount.Name = "lblExpiringSoonCount";
            lblExpiringSoonCount.Size = new Size(48, 28);
            lblExpiringSoonCount.TabIndex = 6;
            lblExpiringSoonCount.Text = "298";
            // 
            // tblSecondRow
            // 
            tblSecondRow.ColumnCount = 2;
            tblSecondRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSecondRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSecondRow.Controls.Add(panel1, 1, 0);
            tblSecondRow.Controls.Add(pnlBloodBreakdown, 0, 0);
            tblSecondRow.Dock = DockStyle.Fill;
            tblSecondRow.Location = new Point(3, 114);
            tblSecondRow.Name = "tblSecondRow";
            tblSecondRow.RowCount = 1;
            tblSecondRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSecondRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblSecondRow.Size = new Size(813, 227);
            tblSecondRow.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvExpiringUnits);
            panel1.Controls.Add(lblExpiringUnits);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(409, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 23, 15, 23);
            panel1.Size = new Size(401, 221);
            panel1.TabIndex = 1;
            // 
            // dgvExpiringUnits
            // 
            dgvExpiringUnits.AllowUserToAddRows = false;
            dgvExpiringUnits.AllowUserToDeleteRows = false;
            dgvExpiringUnits.AllowUserToResizeColumns = false;
            dgvExpiringUnits.AllowUserToResizeRows = false;
            dgvExpiringUnits.BorderStyle = BorderStyle.None;
            dgvExpiringUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpiringUnits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvExpiringUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpiringUnits.ColumnHeadersVisible = false;
            dgvExpiringUnits.Columns.AddRange(new DataGridViewColumn[] { colBloodInfo, colExpiringDays });
            dgvExpiringUnits.Dock = DockStyle.Fill;
            dgvExpiringUnits.EnableHeadersVisualStyles = false;
            dgvExpiringUnits.Location = new Point(15, 53);
            dgvExpiringUnits.Margin = new Padding(7);
            dgvExpiringUnits.Name = "dgvExpiringUnits";
            dgvExpiringUnits.ReadOnly = true;
            dgvExpiringUnits.RowHeadersVisible = false;
            dgvExpiringUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpiringUnits.Size = new Size(371, 145);
            dgvExpiringUnits.TabIndex = 1;
            // 
            // colBloodInfo
            // 
            colBloodInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBloodInfo.DataPropertyName = "BloodInfo";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Padding = new Padding(3, 0, 0, 0);
            colBloodInfo.DefaultCellStyle = dataGridViewCellStyle1;
            colBloodInfo.HeaderText = "Blood Info";
            colBloodInfo.Name = "colBloodInfo";
            colBloodInfo.ReadOnly = true;
            // 
            // colExpiringDays
            // 
            colExpiringDays.DataPropertyName = "ExpiringDays";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new Padding(0, 0, 3, 0);
            colExpiringDays.DefaultCellStyle = dataGridViewCellStyle2;
            colExpiringDays.HeaderText = "Expiring Days";
            colExpiringDays.Name = "colExpiringDays";
            colExpiringDays.ReadOnly = true;
            colExpiringDays.Width = 90;
            // 
            // lblExpiringUnits
            // 
            lblExpiringUnits.AutoSize = true;
            lblExpiringUnits.Dock = DockStyle.Top;
            lblExpiringUnits.Location = new Point(15, 23);
            lblExpiringUnits.Name = "lblExpiringUnits";
            lblExpiringUnits.Padding = new Padding(0, 0, 0, 15);
            lblExpiringUnits.Size = new Size(79, 30);
            lblExpiringUnits.TabIndex = 0;
            lblExpiringUnits.Text = "Expiring Units";
            // 
            // pnlBloodBreakdown
            // 
            pnlBloodBreakdown.Controls.Add(tblBloodBreakdown);
            pnlBloodBreakdown.Controls.Add(lblBloodBreakdown);
            pnlBloodBreakdown.Dock = DockStyle.Fill;
            pnlBloodBreakdown.Location = new Point(3, 3);
            pnlBloodBreakdown.Name = "pnlBloodBreakdown";
            pnlBloodBreakdown.Padding = new Padding(15, 23, 15, 23);
            pnlBloodBreakdown.Size = new Size(400, 221);
            pnlBloodBreakdown.TabIndex = 2;
            // 
            // tblBloodBreakdown
            // 
            tblBloodBreakdown.ColumnCount = 4;
            tblBloodBreakdown.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBloodBreakdown.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBloodBreakdown.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBloodBreakdown.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBloodBreakdown.Controls.Add(pnlAPlus, 0, 0);
            tblBloodBreakdown.Controls.Add(pnlAMinus, 1, 0);
            tblBloodBreakdown.Controls.Add(pnlBPlus, 2, 0);
            tblBloodBreakdown.Controls.Add(pnlBMinus, 3, 0);
            tblBloodBreakdown.Controls.Add(pnlOPlus, 0, 1);
            tblBloodBreakdown.Controls.Add(pnlOMinus, 1, 1);
            tblBloodBreakdown.Controls.Add(pnlABPlus, 2, 1);
            tblBloodBreakdown.Controls.Add(pnlABMinus, 3, 1);
            tblBloodBreakdown.Dock = DockStyle.Fill;
            tblBloodBreakdown.Location = new Point(15, 53);
            tblBloodBreakdown.Name = "tblBloodBreakdown";
            tblBloodBreakdown.RowCount = 2;
            tblBloodBreakdown.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBloodBreakdown.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBloodBreakdown.Size = new Size(370, 145);
            tblBloodBreakdown.TabIndex = 2;
            // 
            // pnlAPlus
            // 
            pnlAPlus.Controls.Add(tblAPlus);
            pnlAPlus.Dock = DockStyle.Fill;
            pnlAPlus.Location = new Point(3, 3);
            pnlAPlus.Name = "pnlAPlus";
            pnlAPlus.Padding = new Padding(2);
            pnlAPlus.Size = new Size(86, 66);
            pnlAPlus.TabIndex = 0;
            // 
            // tblAPlus
            // 
            tblAPlus.ColumnCount = 1;
            tblAPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblAPlus.Controls.Add(lblAPlusCount, 0, 1);
            tblAPlus.Controls.Add(pnlForAPlus, 0, 0);
            tblAPlus.Dock = DockStyle.Fill;
            tblAPlus.Location = new Point(2, 2);
            tblAPlus.Name = "tblAPlus";
            tblAPlus.RowCount = 2;
            tblAPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblAPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblAPlus.Size = new Size(82, 62);
            tblAPlus.TabIndex = 0;
            // 
            // lblAPlusCount
            // 
            lblAPlusCount.AutoSize = true;
            lblAPlusCount.Dock = DockStyle.Fill;
            lblAPlusCount.Location = new Point(3, 31);
            lblAPlusCount.Margin = new Padding(3, 0, 3, 5);
            lblAPlusCount.Name = "lblAPlusCount";
            lblAPlusCount.Size = new Size(76, 26);
            lblAPlusCount.TabIndex = 1;
            lblAPlusCount.Text = "42";
            lblAPlusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForAPlus
            // 
            pnlForAPlus.Controls.Add(lblAPlus);
            pnlForAPlus.Dock = DockStyle.Fill;
            pnlForAPlus.Location = new Point(0, 0);
            pnlForAPlus.Margin = new Padding(0);
            pnlForAPlus.Name = "pnlForAPlus";
            pnlForAPlus.Size = new Size(82, 31);
            pnlForAPlus.TabIndex = 2;
            // 
            // lblAPlus
            // 
            lblAPlus.Anchor = AnchorStyles.None;
            lblAPlus.Location = new Point(35, 8);
            lblAPlus.Margin = new Padding(0);
            lblAPlus.Name = "lblAPlus";
            lblAPlus.Padding = new Padding(0, 5, 0, 0);
            lblAPlus.Size = new Size(30, 30);
            lblAPlus.TabIndex = 1;
            lblAPlus.Text = "A+";
            lblAPlus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAMinus
            // 
            pnlAMinus.Controls.Add(tblAMinus);
            pnlAMinus.Dock = DockStyle.Fill;
            pnlAMinus.Location = new Point(95, 3);
            pnlAMinus.Name = "pnlAMinus";
            pnlAMinus.Padding = new Padding(2);
            pnlAMinus.Size = new Size(86, 66);
            pnlAMinus.TabIndex = 1;
            // 
            // tblAMinus
            // 
            tblAMinus.ColumnCount = 1;
            tblAMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblAMinus.Controls.Add(lblAMinusCount, 0, 1);
            tblAMinus.Controls.Add(pnlForAMinus, 0, 0);
            tblAMinus.Dock = DockStyle.Fill;
            tblAMinus.Location = new Point(2, 2);
            tblAMinus.Name = "tblAMinus";
            tblAMinus.RowCount = 2;
            tblAMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblAMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblAMinus.Size = new Size(82, 62);
            tblAMinus.TabIndex = 1;
            // 
            // lblAMinusCount
            // 
            lblAMinusCount.AutoSize = true;
            lblAMinusCount.Dock = DockStyle.Fill;
            lblAMinusCount.Location = new Point(3, 31);
            lblAMinusCount.Name = "lblAMinusCount";
            lblAMinusCount.Padding = new Padding(0, 0, 0, 5);
            lblAMinusCount.Size = new Size(76, 31);
            lblAMinusCount.TabIndex = 1;
            lblAMinusCount.Text = "18";
            lblAMinusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForAMinus
            // 
            pnlForAMinus.Controls.Add(lblAMinus);
            pnlForAMinus.Dock = DockStyle.Fill;
            pnlForAMinus.Location = new Point(3, 3);
            pnlForAMinus.Name = "pnlForAMinus";
            pnlForAMinus.Size = new Size(76, 25);
            pnlForAMinus.TabIndex = 2;
            // 
            // lblAMinus
            // 
            lblAMinus.Anchor = AnchorStyles.None;
            lblAMinus.Location = new Point(23, -3);
            lblAMinus.Name = "lblAMinus";
            lblAMinus.Padding = new Padding(0, 5, 0, 0);
            lblAMinus.Size = new Size(30, 30);
            lblAMinus.TabIndex = 1;
            lblAMinus.Text = "A-";
            lblAMinus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBPlus
            // 
            pnlBPlus.Controls.Add(tblBPlus);
            pnlBPlus.Dock = DockStyle.Fill;
            pnlBPlus.Location = new Point(187, 3);
            pnlBPlus.Name = "pnlBPlus";
            pnlBPlus.Padding = new Padding(2);
            pnlBPlus.Size = new Size(86, 66);
            pnlBPlus.TabIndex = 2;
            // 
            // tblBPlus
            // 
            tblBPlus.ColumnCount = 1;
            tblBPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblBPlus.Controls.Add(lblBPlusCount, 0, 1);
            tblBPlus.Controls.Add(pnlForBPlus, 0, 0);
            tblBPlus.Dock = DockStyle.Fill;
            tblBPlus.Location = new Point(2, 2);
            tblBPlus.Name = "tblBPlus";
            tblBPlus.RowCount = 2;
            tblBPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBPlus.Size = new Size(82, 62);
            tblBPlus.TabIndex = 1;
            // 
            // lblBPlusCount
            // 
            lblBPlusCount.AutoSize = true;
            lblBPlusCount.Dock = DockStyle.Fill;
            lblBPlusCount.Location = new Point(3, 31);
            lblBPlusCount.Name = "lblBPlusCount";
            lblBPlusCount.Padding = new Padding(0, 0, 0, 5);
            lblBPlusCount.Size = new Size(76, 31);
            lblBPlusCount.TabIndex = 1;
            lblBPlusCount.Text = "35";
            lblBPlusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForBPlus
            // 
            pnlForBPlus.Controls.Add(lblBPlus);
            pnlForBPlus.Dock = DockStyle.Fill;
            pnlForBPlus.Location = new Point(3, 3);
            pnlForBPlus.Name = "pnlForBPlus";
            pnlForBPlus.Size = new Size(76, 25);
            pnlForBPlus.TabIndex = 2;
            // 
            // lblBPlus
            // 
            lblBPlus.Anchor = AnchorStyles.None;
            lblBPlus.Location = new Point(23, -3);
            lblBPlus.Name = "lblBPlus";
            lblBPlus.Padding = new Padding(0, 5, 0, 0);
            lblBPlus.Size = new Size(30, 30);
            lblBPlus.TabIndex = 1;
            lblBPlus.Text = "B+";
            lblBPlus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBMinus
            // 
            pnlBMinus.Controls.Add(tblBMinus);
            pnlBMinus.Dock = DockStyle.Fill;
            pnlBMinus.Location = new Point(279, 3);
            pnlBMinus.Name = "pnlBMinus";
            pnlBMinus.Padding = new Padding(2);
            pnlBMinus.Size = new Size(88, 66);
            pnlBMinus.TabIndex = 3;
            // 
            // tblBMinus
            // 
            tblBMinus.ColumnCount = 1;
            tblBMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblBMinus.Controls.Add(lblBMinusCount, 0, 1);
            tblBMinus.Controls.Add(pnlForBMinus, 0, 0);
            tblBMinus.Dock = DockStyle.Fill;
            tblBMinus.Location = new Point(2, 2);
            tblBMinus.Name = "tblBMinus";
            tblBMinus.RowCount = 2;
            tblBMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBMinus.Size = new Size(84, 62);
            tblBMinus.TabIndex = 1;
            // 
            // lblBMinusCount
            // 
            lblBMinusCount.AutoSize = true;
            lblBMinusCount.Dock = DockStyle.Fill;
            lblBMinusCount.Location = new Point(3, 31);
            lblBMinusCount.Name = "lblBMinusCount";
            lblBMinusCount.Padding = new Padding(0, 0, 0, 5);
            lblBMinusCount.Size = new Size(78, 31);
            lblBMinusCount.TabIndex = 1;
            lblBMinusCount.Text = "12";
            lblBMinusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForBMinus
            // 
            pnlForBMinus.Controls.Add(lblBMinus);
            pnlForBMinus.Dock = DockStyle.Fill;
            pnlForBMinus.Location = new Point(3, 3);
            pnlForBMinus.Name = "pnlForBMinus";
            pnlForBMinus.Size = new Size(78, 25);
            pnlForBMinus.TabIndex = 2;
            // 
            // lblBMinus
            // 
            lblBMinus.Location = new Point(36, 5);
            lblBMinus.Name = "lblBMinus";
            lblBMinus.Padding = new Padding(0, 5, 0, 0);
            lblBMinus.Size = new Size(30, 30);
            lblBMinus.TabIndex = 1;
            lblBMinus.Text = "B-";
            lblBMinus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOPlus
            // 
            pnlOPlus.Controls.Add(tblOPlus);
            pnlOPlus.Dock = DockStyle.Fill;
            pnlOPlus.Location = new Point(3, 75);
            pnlOPlus.Name = "pnlOPlus";
            pnlOPlus.Padding = new Padding(2);
            pnlOPlus.Size = new Size(86, 67);
            pnlOPlus.TabIndex = 4;
            // 
            // tblOPlus
            // 
            tblOPlus.ColumnCount = 1;
            tblOPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblOPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblOPlus.Controls.Add(lblOPlusCount, 0, 1);
            tblOPlus.Controls.Add(pnlForOPlus, 0, 0);
            tblOPlus.Dock = DockStyle.Fill;
            tblOPlus.Location = new Point(2, 2);
            tblOPlus.Name = "tblOPlus";
            tblOPlus.RowCount = 2;
            tblOPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOPlus.Size = new Size(82, 63);
            tblOPlus.TabIndex = 1;
            // 
            // lblOPlusCount
            // 
            lblOPlusCount.AutoSize = true;
            lblOPlusCount.Dock = DockStyle.Fill;
            lblOPlusCount.Location = new Point(3, 31);
            lblOPlusCount.Name = "lblOPlusCount";
            lblOPlusCount.Padding = new Padding(0, 0, 0, 5);
            lblOPlusCount.Size = new Size(76, 32);
            lblOPlusCount.TabIndex = 1;
            lblOPlusCount.Text = "61";
            lblOPlusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForOPlus
            // 
            pnlForOPlus.Controls.Add(lblOPlus);
            pnlForOPlus.Dock = DockStyle.Fill;
            pnlForOPlus.Location = new Point(3, 3);
            pnlForOPlus.Name = "pnlForOPlus";
            pnlForOPlus.Size = new Size(76, 25);
            pnlForOPlus.TabIndex = 2;
            // 
            // lblOPlus
            // 
            lblOPlus.Location = new Point(32, 5);
            lblOPlus.Name = "lblOPlus";
            lblOPlus.Padding = new Padding(0, 5, 0, 0);
            lblOPlus.Size = new Size(30, 30);
            lblOPlus.TabIndex = 1;
            lblOPlus.Text = "O+";
            lblOPlus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOMinus
            // 
            pnlOMinus.Controls.Add(tblOMinus);
            pnlOMinus.Dock = DockStyle.Fill;
            pnlOMinus.Location = new Point(95, 75);
            pnlOMinus.Name = "pnlOMinus";
            pnlOMinus.Padding = new Padding(2);
            pnlOMinus.Size = new Size(86, 67);
            pnlOMinus.TabIndex = 5;
            // 
            // tblOMinus
            // 
            tblOMinus.ColumnCount = 1;
            tblOMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblOMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblOMinus.Controls.Add(lblOMinusCount, 0, 1);
            tblOMinus.Controls.Add(pnlForOMinus, 0, 0);
            tblOMinus.Dock = DockStyle.Fill;
            tblOMinus.Location = new Point(2, 2);
            tblOMinus.Name = "tblOMinus";
            tblOMinus.RowCount = 2;
            tblOMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOMinus.Size = new Size(82, 63);
            tblOMinus.TabIndex = 1;
            // 
            // lblOMinusCount
            // 
            lblOMinusCount.AutoSize = true;
            lblOMinusCount.Dock = DockStyle.Fill;
            lblOMinusCount.Location = new Point(3, 31);
            lblOMinusCount.Name = "lblOMinusCount";
            lblOMinusCount.Padding = new Padding(0, 0, 0, 5);
            lblOMinusCount.Size = new Size(76, 32);
            lblOMinusCount.TabIndex = 1;
            lblOMinusCount.Text = "19";
            lblOMinusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForOMinus
            // 
            pnlForOMinus.Controls.Add(lblOMinus);
            pnlForOMinus.Dock = DockStyle.Fill;
            pnlForOMinus.Location = new Point(3, 3);
            pnlForOMinus.Name = "pnlForOMinus";
            pnlForOMinus.Size = new Size(76, 25);
            pnlForOMinus.TabIndex = 2;
            // 
            // lblOMinus
            // 
            lblOMinus.Location = new Point(34, 5);
            lblOMinus.Name = "lblOMinus";
            lblOMinus.Padding = new Padding(0, 5, 0, 0);
            lblOMinus.Size = new Size(30, 30);
            lblOMinus.TabIndex = 1;
            lblOMinus.Text = "O-";
            lblOMinus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlABPlus
            // 
            pnlABPlus.Controls.Add(tblABPlus);
            pnlABPlus.Dock = DockStyle.Fill;
            pnlABPlus.Location = new Point(187, 75);
            pnlABPlus.Name = "pnlABPlus";
            pnlABPlus.Padding = new Padding(2);
            pnlABPlus.Size = new Size(86, 67);
            pnlABPlus.TabIndex = 6;
            // 
            // tblABPlus
            // 
            tblABPlus.ColumnCount = 1;
            tblABPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblABPlus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblABPlus.Controls.Add(lblABPlusCount, 0, 1);
            tblABPlus.Controls.Add(pnlForABPlus, 0, 0);
            tblABPlus.Dock = DockStyle.Fill;
            tblABPlus.Location = new Point(2, 2);
            tblABPlus.Name = "tblABPlus";
            tblABPlus.RowCount = 2;
            tblABPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblABPlus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblABPlus.Size = new Size(82, 63);
            tblABPlus.TabIndex = 1;
            // 
            // lblABPlusCount
            // 
            lblABPlusCount.AutoSize = true;
            lblABPlusCount.Dock = DockStyle.Fill;
            lblABPlusCount.Location = new Point(3, 31);
            lblABPlusCount.Name = "lblABPlusCount";
            lblABPlusCount.Padding = new Padding(0, 0, 0, 5);
            lblABPlusCount.Size = new Size(76, 32);
            lblABPlusCount.TabIndex = 1;
            lblABPlusCount.Text = "19";
            lblABPlusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForABPlus
            // 
            pnlForABPlus.Controls.Add(lblABPlus);
            pnlForABPlus.Dock = DockStyle.Fill;
            pnlForABPlus.Location = new Point(3, 3);
            pnlForABPlus.Name = "pnlForABPlus";
            pnlForABPlus.Size = new Size(76, 25);
            pnlForABPlus.TabIndex = 2;
            // 
            // lblABPlus
            // 
            lblABPlus.Location = new Point(29, 5);
            lblABPlus.Name = "lblABPlus";
            lblABPlus.Padding = new Padding(0, 5, 0, 0);
            lblABPlus.Size = new Size(30, 30);
            lblABPlus.TabIndex = 1;
            lblABPlus.Text = "AB+";
            lblABPlus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlABMinus
            // 
            pnlABMinus.Controls.Add(tblABMinus);
            pnlABMinus.Dock = DockStyle.Fill;
            pnlABMinus.Location = new Point(279, 75);
            pnlABMinus.Name = "pnlABMinus";
            pnlABMinus.Padding = new Padding(2);
            pnlABMinus.Size = new Size(88, 67);
            pnlABMinus.TabIndex = 7;
            // 
            // tblABMinus
            // 
            tblABMinus.ColumnCount = 1;
            tblABMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblABMinus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblABMinus.Controls.Add(lblABMinusCount, 0, 1);
            tblABMinus.Controls.Add(pnlForABMinus, 0, 0);
            tblABMinus.Dock = DockStyle.Fill;
            tblABMinus.Location = new Point(2, 2);
            tblABMinus.Name = "tblABMinus";
            tblABMinus.RowCount = 2;
            tblABMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblABMinus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblABMinus.Size = new Size(84, 63);
            tblABMinus.TabIndex = 1;
            // 
            // lblABMinusCount
            // 
            lblABMinusCount.AutoSize = true;
            lblABMinusCount.Dock = DockStyle.Fill;
            lblABMinusCount.Location = new Point(3, 31);
            lblABMinusCount.Name = "lblABMinusCount";
            lblABMinusCount.Padding = new Padding(0, 0, 0, 5);
            lblABMinusCount.Size = new Size(78, 32);
            lblABMinusCount.TabIndex = 1;
            lblABMinusCount.Text = "8";
            lblABMinusCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlForABMinus
            // 
            pnlForABMinus.Controls.Add(lblABMinus);
            pnlForABMinus.Dock = DockStyle.Fill;
            pnlForABMinus.Location = new Point(3, 3);
            pnlForABMinus.Name = "pnlForABMinus";
            pnlForABMinus.Size = new Size(78, 25);
            pnlForABMinus.TabIndex = 2;
            // 
            // lblABMinus
            // 
            lblABMinus.Location = new Point(32, 5);
            lblABMinus.Name = "lblABMinus";
            lblABMinus.Padding = new Padding(0, 5, 0, 0);
            lblABMinus.Size = new Size(30, 30);
            lblABMinus.TabIndex = 1;
            lblABMinus.Text = "AB-";
            lblABMinus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBloodBreakdown
            // 
            lblBloodBreakdown.AutoSize = true;
            lblBloodBreakdown.Dock = DockStyle.Top;
            lblBloodBreakdown.Location = new Point(15, 23);
            lblBloodBreakdown.Name = "lblBloodBreakdown";
            lblBloodBreakdown.Padding = new Padding(0, 0, 0, 15);
            lblBloodBreakdown.Size = new Size(135, 30);
            lblBloodBreakdown.TabIndex = 1;
            lblBloodBreakdown.Text = "Blood group breakdown";
            // 
            // pnlPatientRequests
            // 
            pnlPatientRequests.Controls.Add(dgvPatientRequests);
            pnlPatientRequests.Controls.Add(lblPatientRequests);
            pnlPatientRequests.Dock = DockStyle.Fill;
            pnlPatientRequests.Location = new Point(3, 347);
            pnlPatientRequests.Name = "pnlPatientRequests";
            pnlPatientRequests.Padding = new Padding(15, 23, 15, 15);
            pnlPatientRequests.Size = new Size(813, 205);
            pnlPatientRequests.TabIndex = 2;
            // 
            // dgvPatientRequests
            // 
            dgvPatientRequests.AllowUserToAddRows = false;
            dgvPatientRequests.AllowUserToDeleteRows = false;
            dgvPatientRequests.AllowUserToResizeColumns = false;
            dgvPatientRequests.AllowUserToResizeRows = false;
            dgvPatientRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatientRequests.BorderStyle = BorderStyle.None;
            dgvPatientRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatientRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPatientRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPatientRequests.Columns.AddRange(new DataGridViewColumn[] { colPatient, colGroup, colUnits, colDoctor, colStatus });
            dgvPatientRequests.Dock = DockStyle.Fill;
            dgvPatientRequests.EnableHeadersVisualStyles = false;
            dgvPatientRequests.Location = new Point(15, 50);
            dgvPatientRequests.Name = "dgvPatientRequests";
            dgvPatientRequests.ReadOnly = true;
            dgvPatientRequests.RowHeadersVisible = false;
            dgvPatientRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientRequests.Size = new Size(783, 140);
            dgvPatientRequests.TabIndex = 1;
            // 
            // colPatient
            // 
            colPatient.DataPropertyName = "dgvPatient";
            colPatient.HeaderText = "PATIENT";
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colGroup
            // 
            colGroup.DataPropertyName = "dgvGroup";
            colGroup.HeaderText = "GROUP";
            colGroup.Name = "colGroup";
            colGroup.ReadOnly = true;
            // 
            // colUnits
            // 
            colUnits.DataPropertyName = "dgvUnits";
            colUnits.HeaderText = "UNITS";
            colUnits.Name = "colUnits";
            colUnits.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.DataPropertyName = "dgvDoctor";
            colDoctor.HeaderText = "DOCTOR";
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "dgvStatus";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colStatus.DefaultCellStyle = dataGridViewCellStyle3;
            colStatus.HeaderText = "STATUS";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblPatientRequests
            // 
            lblPatientRequests.AutoSize = true;
            lblPatientRequests.Dock = DockStyle.Top;
            lblPatientRequests.Location = new Point(15, 23);
            lblPatientRequests.Name = "lblPatientRequests";
            lblPatientRequests.Padding = new Padding(0, 0, 0, 12);
            lblPatientRequests.Size = new Size(133, 27);
            lblPatientRequests.TabIndex = 0;
            lblPatientRequests.Text = "Recent Patient Requests";
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // AdminDashboardPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblDashboard);
            Name = "AdminDashboardPage";
            Size = new Size(819, 555);
            tblDashboard.ResumeLayout(false);
            tblFirstRow.ResumeLayout(false);
            tblFirstRow.PerformLayout();
            pnlTotalDonor.ResumeLayout(false);
            pnlTotalDonor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDonorIcon).EndInit();
            pnlBloodUnits.ResumeLayout(false);
            pnlBloodUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBloodUnits).EndInit();
            pnlPatientToday.ResumeLayout(false);
            pnlPatientToday.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPatientsToday).EndInit();
            pnlExpiringSoon.ResumeLayout(false);
            pnlExpiringSoon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbExpiringSoon).EndInit();
            tblSecondRow.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpiringUnits).EndInit();
            pnlBloodBreakdown.ResumeLayout(false);
            pnlBloodBreakdown.PerformLayout();
            tblBloodBreakdown.ResumeLayout(false);
            pnlAPlus.ResumeLayout(false);
            tblAPlus.ResumeLayout(false);
            tblAPlus.PerformLayout();
            pnlForAPlus.ResumeLayout(false);
            pnlAMinus.ResumeLayout(false);
            tblAMinus.ResumeLayout(false);
            tblAMinus.PerformLayout();
            pnlForAMinus.ResumeLayout(false);
            pnlBPlus.ResumeLayout(false);
            tblBPlus.ResumeLayout(false);
            tblBPlus.PerformLayout();
            pnlForBPlus.ResumeLayout(false);
            pnlBMinus.ResumeLayout(false);
            tblBMinus.ResumeLayout(false);
            tblBMinus.PerformLayout();
            pnlForBMinus.ResumeLayout(false);
            pnlOPlus.ResumeLayout(false);
            tblOPlus.ResumeLayout(false);
            tblOPlus.PerformLayout();
            pnlForOPlus.ResumeLayout(false);
            pnlOMinus.ResumeLayout(false);
            tblOMinus.ResumeLayout(false);
            tblOMinus.PerformLayout();
            pnlForOMinus.ResumeLayout(false);
            pnlABPlus.ResumeLayout(false);
            tblABPlus.ResumeLayout(false);
            tblABPlus.PerformLayout();
            pnlForABPlus.ResumeLayout(false);
            pnlABMinus.ResumeLayout(false);
            tblABMinus.ResumeLayout(false);
            tblABMinus.PerformLayout();
            pnlForABMinus.ResumeLayout(false);
            pnlPatientRequests.ResumeLayout(false);
            pnlPatientRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatientRequests).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel tblDashboard;
        private TableLayoutPanel tblFirstRow;
        private Panel pnlTotalDonor;
        private Panel pnlBloodUnits;
        private Panel pnlPatientToday;
        private Panel pnlExpiringSoon;
        private Label lblTotalDonorInfo;
        private Label lblTotalDonorCount;
        private Label lblTotalDonor;
        private Label lblBloodUnitsInfo;
        private Label lblBloodUnitsCount;
        private Label lblBloodUnits;
        private Label lblPatientTodayInfo;
        private Label lblPatientTodayCount;
        private Label lblPatientToday;
        private Label lblExpiringSoonInfo;
        private Label lblExpiringSoonCount;
        private Label lblExpiringSoon;
        private TableLayoutPanel tblSecondRow;
        private Panel panel1;
        private Label lblExpiringUnits;
        private Panel pnlBloodBreakdown;
        private Label lblBloodBreakdown;
        private TableLayoutPanel tblBloodBreakdown;
        private Panel pnlAPlus;
        private Panel pnlAMinus;
        private Panel pnlBPlus;
        private Panel pnlBMinus;
        private Panel pnlOPlus;
        private Panel pnlOMinus;
        private Panel pnlABPlus;
        private Panel pnlABMinus;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private TableLayoutPanel tblAPlus;
        private Label lblAPlusCount;
        private TableLayoutPanel tblAMinus;
        private Label lblAMinusCount;
        private TableLayoutPanel tblBPlus;
        private Label lblBPlusCount;
        private TableLayoutPanel tblBMinus;
        private Label lblBMinusCount;
        private TableLayoutPanel tblOPlus;
        private Label lblOPlusCount;
        private TableLayoutPanel tblOMinus;
        private Label lblOMinusCount;
        private TableLayoutPanel tblABPlus;
        private Label lblABPlusCount;
        private TableLayoutPanel tblABMinus;
        private Label lblABMinusCount;
        private DataGridView dgvExpiringUnits;
        private DataGridViewTextBoxColumn colBloodInfo;
        private DataGridViewTextBoxColumn colExpiringDays;
        private Panel pnlPatientRequests;
        private DataGridView dgvPatientRequests;
        private Label lblPatientRequests;
        private FontAwesome.Sharp.IconPictureBox pbDonorIcon;
        private FontAwesome.Sharp.IconPictureBox pbBloodUnits;
        private FontAwesome.Sharp.IconPictureBox pbPatientsToday;
        private FontAwesome.Sharp.IconPictureBox pbExpiringSoon;
        private Panel pnlForAPlus;
        private Label lblAPlus;
        private Panel pnlForAMinus;
        private Label lblAMinus;
        private Panel pnlForBPlus;
        private Label lblBPlus;
        private Panel pnlForBMinus;
        private Label lblBMinus;
        private Panel pnlForOPlus;
        private Label lblOPlus;
        private Panel pnlForOMinus;
        private Label lblOMinus;
        private Panel pnlForABPlus;
        private Label lblABPlus;
        private Panel pnlForABMinus;
        private Label lblABMinus;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colGroup;
        private DataGridViewTextBoxColumn colUnits;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colStatus;
    }
}