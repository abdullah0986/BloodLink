namespace BloodLink.Pages
{
    partial class BloodUnitPage
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
            tlpBloodUnit = new TableLayoutPanel();
            pnlDonorsList = new Panel();
            pnlSecondRowStyling = new Panel();
            dgvBloodUnits = new DataGridView();
            buBagId = new DataGridViewTextBoxColumn();
            buGroup = new DataGridViewTextBoxColumn();
            buCollected = new DataGridViewTextBoxColumn();
            buExpires = new DataGridViewTextBoxColumn();
            buDonor = new DataGridViewTextBoxColumn();
            buStatus = new DataGridViewTextBoxColumn();
            pnlSearchOperations = new Panel();
            tlpSerachOperation = new TableLayoutPanel();
            flpSerachOperations = new FlowLayoutPanel();
            btnDeleteBloodUnit = new Button();
            btnViewBloodUnit = new Button();
            btnUpdateBloodUnit = new Button();
            btnAddBloodUnit = new Button();
            cbStatus = new ComboBox();
            cbBloodGroup = new ComboBox();
            pnlListHeading = new Panel();
            lblSearchOperations = new Label();
            tblFirstRow = new TableLayoutPanel();
            tlpExpiringSoon = new TableLayoutPanel();
            pnlExpiringSoonCount = new Panel();
            lblExpirySoonCount = new Label();
            pnlExpiringSoonHeader = new Panel();
            lblExpiryingSoonHeader = new Label();
            pnlExpiringSoonFooter = new Panel();
            lblExpiringSoonFooter = new Label();
            tlpReserved = new TableLayoutPanel();
            pnlReservedCount = new Panel();
            lblReservedCount = new Label();
            pnlReservedHeader = new Panel();
            lblReservedHeader = new Label();
            pnlReservedFooter = new Panel();
            lblReservedFooter = new Label();
            tlpAvailable = new TableLayoutPanel();
            pnlAvailableCount = new Panel();
            lblAvailableCount = new Label();
            pnlAvailableHeading = new Panel();
            lblAvailableHeadingf = new Label();
            pnlAvailableFooter = new Panel();
            lblAvailableFooter = new Label();
            tlpTotalUnits = new TableLayoutPanel();
            pnlTotalUnitsCount = new Panel();
            lblTotalUnitsCount = new Label();
            pnlTotalUnisHeading = new Panel();
            lblTotalUnitsHeading = new Label();
            pnlTotalUnistFooter = new Panel();
            lblTotalUnitsFooter = new Label();
            tlpBloodUnit.SuspendLayout();
            pnlDonorsList.SuspendLayout();
            pnlSecondRowStyling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBloodUnits).BeginInit();
            pnlSearchOperations.SuspendLayout();
            tlpSerachOperation.SuspendLayout();
            flpSerachOperations.SuspendLayout();
            pnlListHeading.SuspendLayout();
            tblFirstRow.SuspendLayout();
            tlpExpiringSoon.SuspendLayout();
            pnlExpiringSoonCount.SuspendLayout();
            pnlExpiringSoonHeader.SuspendLayout();
            pnlExpiringSoonFooter.SuspendLayout();
            tlpReserved.SuspendLayout();
            pnlReservedCount.SuspendLayout();
            pnlReservedHeader.SuspendLayout();
            pnlReservedFooter.SuspendLayout();
            tlpAvailable.SuspendLayout();
            pnlAvailableCount.SuspendLayout();
            pnlAvailableHeading.SuspendLayout();
            pnlAvailableFooter.SuspendLayout();
            tlpTotalUnits.SuspendLayout();
            pnlTotalUnitsCount.SuspendLayout();
            pnlTotalUnisHeading.SuspendLayout();
            pnlTotalUnistFooter.SuspendLayout();
            SuspendLayout();
            // 
            // tlpBloodUnit
            // 
            tlpBloodUnit.ColumnCount = 1;
            tlpBloodUnit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBloodUnit.Controls.Add(pnlDonorsList, 0, 1);
            tlpBloodUnit.Controls.Add(tblFirstRow, 0, 0);
            tlpBloodUnit.Dock = DockStyle.Fill;
            tlpBloodUnit.Location = new Point(0, 0);
            tlpBloodUnit.Name = "tlpBloodUnit";
            tlpBloodUnit.RowCount = 2;
            tlpBloodUnit.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpBloodUnit.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tlpBloodUnit.Size = new Size(853, 489);
            tlpBloodUnit.TabIndex = 0;
            // 
            // pnlDonorsList
            // 
            pnlDonorsList.AutoScroll = true;
            pnlDonorsList.Controls.Add(pnlSecondRowStyling);
            pnlDonorsList.Dock = DockStyle.Fill;
            pnlDonorsList.Location = new Point(3, 104);
            pnlDonorsList.Margin = new Padding(3, 7, 3, 3);
            pnlDonorsList.Name = "pnlDonorsList";
            pnlDonorsList.Size = new Size(847, 382);
            pnlDonorsList.TabIndex = 2;
            // 
            // pnlSecondRowStyling
            // 
            pnlSecondRowStyling.AutoSize = true;
            pnlSecondRowStyling.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlSecondRowStyling.Controls.Add(dgvBloodUnits);
            pnlSecondRowStyling.Controls.Add(pnlSearchOperations);
            pnlSecondRowStyling.Dock = DockStyle.Top;
            pnlSecondRowStyling.Location = new Point(0, 0);
            pnlSecondRowStyling.Name = "pnlSecondRowStyling";
            pnlSecondRowStyling.Padding = new Padding(15, 23, 15, 23);
            pnlSecondRowStyling.Size = new Size(847, 339);
            pnlSecondRowStyling.TabIndex = 1;
            // 
            // dgvBloodUnits
            // 
            dgvBloodUnits.AllowUserToAddRows = false;
            dgvBloodUnits.AllowUserToDeleteRows = false;
            dgvBloodUnits.AllowUserToResizeColumns = false;
            dgvBloodUnits.AllowUserToResizeRows = false;
            dgvBloodUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBloodUnits.BorderStyle = BorderStyle.None;
            dgvBloodUnits.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBloodUnits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBloodUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBloodUnits.Columns.AddRange(new DataGridViewColumn[] { buBagId, buGroup, buCollected, buExpires, buDonor, buStatus });
            dgvBloodUnits.Dock = DockStyle.Top;
            dgvBloodUnits.EnableHeadersVisualStyles = false;
            dgvBloodUnits.Location = new Point(15, 69);
            dgvBloodUnits.Margin = new Padding(0);
            dgvBloodUnits.MultiSelect = false;
            dgvBloodUnits.Name = "dgvBloodUnits";
            dgvBloodUnits.ReadOnly = true;
            dgvBloodUnits.RowHeadersVisible = false;
            dgvBloodUnits.ScrollBars = ScrollBars.None;
            dgvBloodUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloodUnits.Size = new Size(817, 247);
            dgvBloodUnits.TabIndex = 8;
            // 
            // buBagId
            // 
            buBagId.DataPropertyName = "Id";
            buBagId.HeaderText = "BAG ID";
            buBagId.Name = "buBagId";
            buBagId.ReadOnly = true;
            buBagId.Resizable = DataGridViewTriState.True;
            // 
            // buGroup
            // 
            buGroup.DataPropertyName = "BloodGroup";
            buGroup.HeaderText = "GROUP";
            buGroup.Name = "buGroup";
            buGroup.ReadOnly = true;
            // 
            // buCollected
            // 
            buCollected.DataPropertyName = "CollectedDate";
            buCollected.HeaderText = "COLLECTED";
            buCollected.Name = "buCollected";
            buCollected.ReadOnly = true;
            // 
            // buExpires
            // 
            buExpires.DataPropertyName = "ExpiryDate";
            buExpires.HeaderText = "EXPIRES";
            buExpires.Name = "buExpires";
            buExpires.ReadOnly = true;
            // 
            // buDonor
            // 
            buDonor.DataPropertyName = "DonorId";
            buDonor.HeaderText = "DONOR";
            buDonor.Name = "buDonor";
            buDonor.ReadOnly = true;
            // 
            // buStatus
            // 
            buStatus.DataPropertyName = "Status";
            buStatus.HeaderText = "STATUS";
            buStatus.Name = "buStatus";
            buStatus.ReadOnly = true;
            // 
            // pnlSearchOperations
            // 
            pnlSearchOperations.Controls.Add(tlpSerachOperation);
            pnlSearchOperations.Dock = DockStyle.Top;
            pnlSearchOperations.Location = new Point(15, 23);
            pnlSearchOperations.Name = "pnlSearchOperations";
            pnlSearchOperations.Size = new Size(817, 46);
            pnlSearchOperations.TabIndex = 1;
            // 
            // tlpSerachOperation
            // 
            tlpSerachOperation.ColumnCount = 2;
            tlpSerachOperation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSerachOperation.ColumnStyles.Add(new ColumnStyle());
            tlpSerachOperation.Controls.Add(flpSerachOperations, 1, 0);
            tlpSerachOperation.Controls.Add(pnlListHeading, 0, 0);
            tlpSerachOperation.Dock = DockStyle.Fill;
            tlpSerachOperation.Location = new Point(0, 0);
            tlpSerachOperation.Name = "tlpSerachOperation";
            tlpSerachOperation.Padding = new Padding(0, 0, 0, 10);
            tlpSerachOperation.RowCount = 1;
            tlpSerachOperation.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSerachOperation.Size = new Size(817, 46);
            tlpSerachOperation.TabIndex = 2;
            // 
            // flpSerachOperations
            // 
            flpSerachOperations.AutoSize = true;
            flpSerachOperations.Controls.Add(btnDeleteBloodUnit);
            flpSerachOperations.Controls.Add(btnViewBloodUnit);
            flpSerachOperations.Controls.Add(btnUpdateBloodUnit);
            flpSerachOperations.Controls.Add(btnAddBloodUnit);
            flpSerachOperations.Controls.Add(cbStatus);
            flpSerachOperations.Controls.Add(cbBloodGroup);
            flpSerachOperations.Dock = DockStyle.Fill;
            flpSerachOperations.FlowDirection = FlowDirection.RightToLeft;
            flpSerachOperations.Location = new Point(224, 3);
            flpSerachOperations.Name = "flpSerachOperations";
            flpSerachOperations.Size = new Size(590, 30);
            flpSerachOperations.TabIndex = 0;
            flpSerachOperations.WrapContents = false;
            // 
            // btnDeleteBloodUnit
            // 
            btnDeleteBloodUnit.AutoSize = true;
            btnDeleteBloodUnit.Dock = DockStyle.Fill;
            btnDeleteBloodUnit.FlatStyle = FlatStyle.Flat;
            btnDeleteBloodUnit.Location = new Point(487, 3);
            btnDeleteBloodUnit.Margin = new Padding(4, 3, 0, 7);
            btnDeleteBloodUnit.Name = "btnDeleteBloodUnit";
            btnDeleteBloodUnit.Size = new Size(103, 27);
            btnDeleteBloodUnit.TabIndex = 9;
            btnDeleteBloodUnit.Text = "🗑 Delete Unit";
            btnDeleteBloodUnit.UseVisualStyleBackColor = false;
            btnDeleteBloodUnit.Click += btnDeleteBloodUnit_Click;
            // 
            // btnViewBloodUnit
            // 
            btnViewBloodUnit.AutoSize = true;
            btnViewBloodUnit.Dock = DockStyle.Fill;
            btnViewBloodUnit.FlatStyle = FlatStyle.Flat;
            btnViewBloodUnit.Location = new Point(388, 3);
            btnViewBloodUnit.Margin = new Padding(4, 3, 0, 7);
            btnViewBloodUnit.Name = "btnViewBloodUnit";
            btnViewBloodUnit.Size = new Size(95, 27);
            btnViewBloodUnit.TabIndex = 10;
            btnViewBloodUnit.Text = "👁️ View Unit";
            btnViewBloodUnit.UseVisualStyleBackColor = false;
            btnViewBloodUnit.Click += btnViewBloodUnit_Click;
            // 
            // btnUpdateBloodUnit
            // 
            btnUpdateBloodUnit.AutoSize = true;
            btnUpdateBloodUnit.Dock = DockStyle.Fill;
            btnUpdateBloodUnit.FlatStyle = FlatStyle.Flat;
            btnUpdateBloodUnit.Location = new Point(276, 3);
            btnUpdateBloodUnit.Margin = new Padding(4, 3, 0, 7);
            btnUpdateBloodUnit.Name = "btnUpdateBloodUnit";
            btnUpdateBloodUnit.Size = new Size(108, 27);
            btnUpdateBloodUnit.TabIndex = 11;
            btnUpdateBloodUnit.Text = "⟳ Update Unit";
            btnUpdateBloodUnit.UseVisualStyleBackColor = false;
            btnUpdateBloodUnit.Click += btnUpdateBloodUnit_Click;
            // 
            // btnAddBloodUnit
            // 
            btnAddBloodUnit.AutoSize = true;
            btnAddBloodUnit.Dock = DockStyle.Fill;
            btnAddBloodUnit.FlatStyle = FlatStyle.Flat;
            btnAddBloodUnit.Location = new Point(184, 3);
            btnAddBloodUnit.Margin = new Padding(4, 3, 0, 7);
            btnAddBloodUnit.Name = "btnAddBloodUnit";
            btnAddBloodUnit.Size = new Size(88, 27);
            btnAddBloodUnit.TabIndex = 12;
            btnAddBloodUnit.Text = "+ Add Unit";
            btnAddBloodUnit.UseVisualStyleBackColor = false;
            btnAddBloodUnit.Click += btnAddBloodUnit_Click;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Fill;
            cbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(94, 3);
            cbStatus.Margin = new Padding(4, 3, 4, 3);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(82, 24);
            cbStatus.TabIndex = 13;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // cbBloodGroup
            // 
            cbBloodGroup.Dock = DockStyle.Fill;
            cbBloodGroup.DrawMode = DrawMode.OwnerDrawFixed;
            cbBloodGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBloodGroup.FormattingEnabled = true;
            cbBloodGroup.Location = new Point(4, 3);
            cbBloodGroup.Margin = new Padding(4, 3, 4, 3);
            cbBloodGroup.Name = "cbBloodGroup";
            cbBloodGroup.Size = new Size(82, 24);
            cbBloodGroup.TabIndex = 14;
            cbBloodGroup.SelectedIndexChanged += cbBloodGroup_SelectedIndexChanged;
            // 
            // pnlListHeading
            // 
            pnlListHeading.Controls.Add(lblSearchOperations);
            pnlListHeading.Dock = DockStyle.Fill;
            pnlListHeading.Location = new Point(3, 3);
            pnlListHeading.Name = "pnlListHeading";
            pnlListHeading.Size = new Size(215, 30);
            pnlListHeading.TabIndex = 1;
            // 
            // lblSearchOperations
            // 
            lblSearchOperations.Dock = DockStyle.Fill;
            lblSearchOperations.Location = new Point(0, 0);
            lblSearchOperations.Name = "lblSearchOperations";
            lblSearchOperations.Size = new Size(215, 30);
            lblSearchOperations.TabIndex = 0;
            lblSearchOperations.Text = "All Blood Units";
            lblSearchOperations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tblFirstRow
            // 
            tblFirstRow.ColumnCount = 4;
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.Controls.Add(tlpExpiringSoon, 3, 0);
            tblFirstRow.Controls.Add(tlpReserved, 2, 0);
            tblFirstRow.Controls.Add(tlpAvailable, 1, 0);
            tblFirstRow.Controls.Add(tlpTotalUnits, 0, 0);
            tblFirstRow.Dock = DockStyle.Fill;
            tblFirstRow.Location = new Point(3, 3);
            tblFirstRow.Name = "tblFirstRow";
            tblFirstRow.RowCount = 1;
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblFirstRow.Size = new Size(847, 91);
            tblFirstRow.TabIndex = 1;
            // 
            // tlpExpiringSoon
            // 
            tlpExpiringSoon.BackColor = SystemColors.Control;
            tlpExpiringSoon.ColumnCount = 1;
            tlpExpiringSoon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpExpiringSoon.Controls.Add(pnlExpiringSoonCount, 0, 1);
            tlpExpiringSoon.Controls.Add(pnlExpiringSoonHeader, 0, 0);
            tlpExpiringSoon.Controls.Add(pnlExpiringSoonFooter, 0, 2);
            tlpExpiringSoon.Dock = DockStyle.Fill;
            tlpExpiringSoon.Location = new Point(636, 3);
            tlpExpiringSoon.Name = "tlpExpiringSoon";
            tlpExpiringSoon.RowCount = 3;
            tlpExpiringSoon.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpExpiringSoon.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpExpiringSoon.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpExpiringSoon.Size = new Size(208, 85);
            tlpExpiringSoon.TabIndex = 9;
            // 
            // pnlExpiringSoonCount
            // 
            pnlExpiringSoonCount.Controls.Add(lblExpirySoonCount);
            pnlExpiringSoonCount.Dock = DockStyle.Fill;
            pnlExpiringSoonCount.Location = new Point(3, 32);
            pnlExpiringSoonCount.Name = "pnlExpiringSoonCount";
            pnlExpiringSoonCount.Size = new Size(202, 20);
            pnlExpiringSoonCount.TabIndex = 3;
            // 
            // lblExpirySoonCount
            // 
            lblExpirySoonCount.Dock = DockStyle.Fill;
            lblExpirySoonCount.Location = new Point(0, 0);
            lblExpirySoonCount.Name = "lblExpirySoonCount";
            lblExpirySoonCount.Padding = new Padding(8, 0, 0, 0);
            lblExpirySoonCount.Size = new Size(202, 20);
            lblExpirySoonCount.TabIndex = 0;
            lblExpirySoonCount.Text = "5";
            lblExpirySoonCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlExpiringSoonHeader
            // 
            pnlExpiringSoonHeader.Controls.Add(lblExpiryingSoonHeader);
            pnlExpiringSoonHeader.Dock = DockStyle.Fill;
            pnlExpiringSoonHeader.Location = new Point(3, 3);
            pnlExpiringSoonHeader.Name = "pnlExpiringSoonHeader";
            pnlExpiringSoonHeader.Size = new Size(202, 23);
            pnlExpiringSoonHeader.TabIndex = 2;
            // 
            // lblExpiryingSoonHeader
            // 
            lblExpiryingSoonHeader.Dock = DockStyle.Fill;
            lblExpiryingSoonHeader.Location = new Point(0, 0);
            lblExpiryingSoonHeader.Name = "lblExpiryingSoonHeader";
            lblExpiryingSoonHeader.Padding = new Padding(8, 0, 0, 0);
            lblExpiryingSoonHeader.Size = new Size(202, 23);
            lblExpiryingSoonHeader.TabIndex = 0;
            lblExpiryingSoonHeader.Text = "Expiring Soon";
            lblExpiryingSoonHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlExpiringSoonFooter
            // 
            pnlExpiringSoonFooter.Controls.Add(lblExpiringSoonFooter);
            pnlExpiringSoonFooter.Dock = DockStyle.Fill;
            pnlExpiringSoonFooter.Location = new Point(3, 58);
            pnlExpiringSoonFooter.Name = "pnlExpiringSoonFooter";
            pnlExpiringSoonFooter.Size = new Size(202, 24);
            pnlExpiringSoonFooter.TabIndex = 4;
            // 
            // lblExpiringSoonFooter
            // 
            lblExpiringSoonFooter.Dock = DockStyle.Fill;
            lblExpiringSoonFooter.Location = new Point(0, 0);
            lblExpiringSoonFooter.Name = "lblExpiringSoonFooter";
            lblExpiringSoonFooter.Padding = new Padding(8, 0, 0, 0);
            lblExpiringSoonFooter.Size = new Size(202, 24);
            lblExpiringSoonFooter.TabIndex = 0;
            lblExpiringSoonFooter.Text = "within 7 days";
            // 
            // tlpReserved
            // 
            tlpReserved.BackColor = SystemColors.Control;
            tlpReserved.ColumnCount = 1;
            tlpReserved.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpReserved.Controls.Add(pnlReservedCount, 0, 1);
            tlpReserved.Controls.Add(pnlReservedHeader, 0, 0);
            tlpReserved.Controls.Add(pnlReservedFooter, 0, 2);
            tlpReserved.Dock = DockStyle.Fill;
            tlpReserved.Location = new Point(425, 3);
            tlpReserved.Name = "tlpReserved";
            tlpReserved.RowCount = 3;
            tlpReserved.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpReserved.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpReserved.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpReserved.Size = new Size(205, 85);
            tlpReserved.TabIndex = 8;
            // 
            // pnlReservedCount
            // 
            pnlReservedCount.Controls.Add(lblReservedCount);
            pnlReservedCount.Dock = DockStyle.Fill;
            pnlReservedCount.Location = new Point(3, 32);
            pnlReservedCount.Name = "pnlReservedCount";
            pnlReservedCount.Size = new Size(199, 20);
            pnlReservedCount.TabIndex = 3;
            // 
            // lblReservedCount
            // 
            lblReservedCount.Dock = DockStyle.Fill;
            lblReservedCount.Location = new Point(0, 0);
            lblReservedCount.Name = "lblReservedCount";
            lblReservedCount.Padding = new Padding(8, 0, 0, 0);
            lblReservedCount.Size = new Size(199, 20);
            lblReservedCount.TabIndex = 0;
            lblReservedCount.Text = "8";
            lblReservedCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlReservedHeader
            // 
            pnlReservedHeader.Controls.Add(lblReservedHeader);
            pnlReservedHeader.Dock = DockStyle.Fill;
            pnlReservedHeader.Location = new Point(3, 3);
            pnlReservedHeader.Name = "pnlReservedHeader";
            pnlReservedHeader.Size = new Size(199, 23);
            pnlReservedHeader.TabIndex = 2;
            // 
            // lblReservedHeader
            // 
            lblReservedHeader.Dock = DockStyle.Fill;
            lblReservedHeader.Location = new Point(0, 0);
            lblReservedHeader.Name = "lblReservedHeader";
            lblReservedHeader.Padding = new Padding(8, 0, 0, 0);
            lblReservedHeader.Size = new Size(199, 23);
            lblReservedHeader.TabIndex = 0;
            lblReservedHeader.Text = "Reserved";
            lblReservedHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlReservedFooter
            // 
            pnlReservedFooter.Controls.Add(lblReservedFooter);
            pnlReservedFooter.Dock = DockStyle.Fill;
            pnlReservedFooter.Location = new Point(3, 58);
            pnlReservedFooter.Name = "pnlReservedFooter";
            pnlReservedFooter.Size = new Size(199, 24);
            pnlReservedFooter.TabIndex = 4;
            // 
            // lblReservedFooter
            // 
            lblReservedFooter.Dock = DockStyle.Fill;
            lblReservedFooter.Location = new Point(0, 0);
            lblReservedFooter.Name = "lblReservedFooter";
            lblReservedFooter.Padding = new Padding(8, 0, 0, 0);
            lblReservedFooter.Size = new Size(199, 24);
            lblReservedFooter.TabIndex = 0;
            lblReservedFooter.Text = "for patients";
            // 
            // tlpAvailable
            // 
            tlpAvailable.BackColor = SystemColors.Control;
            tlpAvailable.ColumnCount = 1;
            tlpAvailable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAvailable.Controls.Add(pnlAvailableCount, 0, 1);
            tlpAvailable.Controls.Add(pnlAvailableHeading, 0, 0);
            tlpAvailable.Controls.Add(pnlAvailableFooter, 0, 2);
            tlpAvailable.Dock = DockStyle.Fill;
            tlpAvailable.Location = new Point(214, 3);
            tlpAvailable.Name = "tlpAvailable";
            tlpAvailable.RowCount = 3;
            tlpAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpAvailable.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpAvailable.Size = new Size(205, 85);
            tlpAvailable.TabIndex = 7;
            // 
            // pnlAvailableCount
            // 
            pnlAvailableCount.Controls.Add(lblAvailableCount);
            pnlAvailableCount.Dock = DockStyle.Fill;
            pnlAvailableCount.Location = new Point(3, 32);
            pnlAvailableCount.Name = "pnlAvailableCount";
            pnlAvailableCount.Size = new Size(199, 20);
            pnlAvailableCount.TabIndex = 3;
            // 
            // lblAvailableCount
            // 
            lblAvailableCount.Dock = DockStyle.Fill;
            lblAvailableCount.Location = new Point(0, 0);
            lblAvailableCount.Name = "lblAvailableCount";
            lblAvailableCount.Padding = new Padding(8, 0, 0, 0);
            lblAvailableCount.Size = new Size(199, 20);
            lblAvailableCount.TabIndex = 0;
            lblAvailableCount.Text = "71";
            lblAvailableCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAvailableHeading
            // 
            pnlAvailableHeading.Controls.Add(lblAvailableHeadingf);
            pnlAvailableHeading.Dock = DockStyle.Fill;
            pnlAvailableHeading.Location = new Point(3, 3);
            pnlAvailableHeading.Name = "pnlAvailableHeading";
            pnlAvailableHeading.Size = new Size(199, 23);
            pnlAvailableHeading.TabIndex = 2;
            // 
            // lblAvailableHeadingf
            // 
            lblAvailableHeadingf.Dock = DockStyle.Fill;
            lblAvailableHeadingf.Location = new Point(0, 0);
            lblAvailableHeadingf.Name = "lblAvailableHeadingf";
            lblAvailableHeadingf.Padding = new Padding(8, 0, 0, 0);
            lblAvailableHeadingf.Size = new Size(199, 23);
            lblAvailableHeadingf.TabIndex = 0;
            lblAvailableHeadingf.Text = "Available";
            lblAvailableHeadingf.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlAvailableFooter
            // 
            pnlAvailableFooter.Controls.Add(lblAvailableFooter);
            pnlAvailableFooter.Dock = DockStyle.Fill;
            pnlAvailableFooter.Location = new Point(3, 58);
            pnlAvailableFooter.Name = "pnlAvailableFooter";
            pnlAvailableFooter.Size = new Size(199, 24);
            pnlAvailableFooter.TabIndex = 4;
            // 
            // lblAvailableFooter
            // 
            lblAvailableFooter.Dock = DockStyle.Fill;
            lblAvailableFooter.Location = new Point(0, 0);
            lblAvailableFooter.Name = "lblAvailableFooter";
            lblAvailableFooter.Padding = new Padding(8, 0, 0, 0);
            lblAvailableFooter.Size = new Size(199, 24);
            lblAvailableFooter.TabIndex = 0;
            lblAvailableFooter.Text = "ready to issue";
            // 
            // tlpTotalUnits
            // 
            tlpTotalUnits.BackColor = SystemColors.Control;
            tlpTotalUnits.ColumnCount = 1;
            tlpTotalUnits.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTotalUnits.Controls.Add(pnlTotalUnitsCount, 0, 1);
            tlpTotalUnits.Controls.Add(pnlTotalUnisHeading, 0, 0);
            tlpTotalUnits.Controls.Add(pnlTotalUnistFooter, 0, 2);
            tlpTotalUnits.Dock = DockStyle.Fill;
            tlpTotalUnits.Location = new Point(3, 3);
            tlpTotalUnits.Name = "tlpTotalUnits";
            tlpTotalUnits.RowCount = 3;
            tlpTotalUnits.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpTotalUnits.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpTotalUnits.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpTotalUnits.Size = new Size(205, 85);
            tlpTotalUnits.TabIndex = 6;
            // 
            // pnlTotalUnitsCount
            // 
            pnlTotalUnitsCount.Controls.Add(lblTotalUnitsCount);
            pnlTotalUnitsCount.Dock = DockStyle.Fill;
            pnlTotalUnitsCount.Location = new Point(3, 32);
            pnlTotalUnitsCount.Name = "pnlTotalUnitsCount";
            pnlTotalUnitsCount.Size = new Size(199, 20);
            pnlTotalUnitsCount.TabIndex = 3;
            // 
            // lblTotalUnitsCount
            // 
            lblTotalUnitsCount.Dock = DockStyle.Fill;
            lblTotalUnitsCount.Location = new Point(0, 0);
            lblTotalUnitsCount.Name = "lblTotalUnitsCount";
            lblTotalUnitsCount.Padding = new Padding(8, 0, 0, 0);
            lblTotalUnitsCount.Size = new Size(199, 20);
            lblTotalUnitsCount.TabIndex = 0;
            lblTotalUnitsCount.Text = "86";
            lblTotalUnitsCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTotalUnisHeading
            // 
            pnlTotalUnisHeading.Controls.Add(lblTotalUnitsHeading);
            pnlTotalUnisHeading.Dock = DockStyle.Fill;
            pnlTotalUnisHeading.Location = new Point(3, 3);
            pnlTotalUnisHeading.Name = "pnlTotalUnisHeading";
            pnlTotalUnisHeading.Size = new Size(199, 23);
            pnlTotalUnisHeading.TabIndex = 2;
            // 
            // lblTotalUnitsHeading
            // 
            lblTotalUnitsHeading.Dock = DockStyle.Fill;
            lblTotalUnitsHeading.Location = new Point(0, 0);
            lblTotalUnitsHeading.Name = "lblTotalUnitsHeading";
            lblTotalUnitsHeading.Padding = new Padding(8, 0, 0, 0);
            lblTotalUnitsHeading.Size = new Size(199, 23);
            lblTotalUnitsHeading.TabIndex = 0;
            lblTotalUnitsHeading.Text = "Total Units";
            lblTotalUnitsHeading.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlTotalUnistFooter
            // 
            pnlTotalUnistFooter.Controls.Add(lblTotalUnitsFooter);
            pnlTotalUnistFooter.Dock = DockStyle.Fill;
            pnlTotalUnistFooter.Location = new Point(3, 58);
            pnlTotalUnistFooter.Name = "pnlTotalUnistFooter";
            pnlTotalUnistFooter.Size = new Size(199, 24);
            pnlTotalUnistFooter.TabIndex = 4;
            // 
            // lblTotalUnitsFooter
            // 
            lblTotalUnitsFooter.Dock = DockStyle.Fill;
            lblTotalUnitsFooter.Location = new Point(0, 0);
            lblTotalUnitsFooter.Name = "lblTotalUnitsFooter";
            lblTotalUnitsFooter.Padding = new Padding(8, 0, 0, 0);
            lblTotalUnitsFooter.Size = new Size(199, 24);
            lblTotalUnitsFooter.TabIndex = 0;
            lblTotalUnitsFooter.Text = "all groups";
            // 
            // BloodUnitPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpBloodUnit);
            Name = "BloodUnitPage";
            Size = new Size(853, 489);
            tlpBloodUnit.ResumeLayout(false);
            pnlDonorsList.ResumeLayout(false);
            pnlDonorsList.PerformLayout();
            pnlSecondRowStyling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBloodUnits).EndInit();
            pnlSearchOperations.ResumeLayout(false);
            tlpSerachOperation.ResumeLayout(false);
            tlpSerachOperation.PerformLayout();
            flpSerachOperations.ResumeLayout(false);
            flpSerachOperations.PerformLayout();
            pnlListHeading.ResumeLayout(false);
            tblFirstRow.ResumeLayout(false);
            tlpExpiringSoon.ResumeLayout(false);
            pnlExpiringSoonCount.ResumeLayout(false);
            pnlExpiringSoonHeader.ResumeLayout(false);
            pnlExpiringSoonFooter.ResumeLayout(false);
            tlpReserved.ResumeLayout(false);
            pnlReservedCount.ResumeLayout(false);
            pnlReservedHeader.ResumeLayout(false);
            pnlReservedFooter.ResumeLayout(false);
            tlpAvailable.ResumeLayout(false);
            pnlAvailableCount.ResumeLayout(false);
            pnlAvailableHeading.ResumeLayout(false);
            pnlAvailableFooter.ResumeLayout(false);
            tlpTotalUnits.ResumeLayout(false);
            pnlTotalUnitsCount.ResumeLayout(false);
            pnlTotalUnisHeading.ResumeLayout(false);
            pnlTotalUnistFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpBloodUnit;
        private TableLayoutPanel tblFirstRow;
        private TableLayoutPanel tlpExpiringSoon;
        private Panel pnlExpiringSoonCount;
        private Label lblExpirySoonCount;
        private Panel pnlExpiringSoonHeader;
        private Label lblExpiryingSoonHeader;
        private Panel pnlExpiringSoonFooter;
        private Label lblExpiringSoonFooter;
        private TableLayoutPanel tlpReserved;
        private Panel pnlReservedCount;
        private Label lblReservedCount;
        private Panel pnlReservedHeader;
        private Label lblReservedHeader;
        private Panel pnlReservedFooter;
        private Label lblReservedFooter;
        private TableLayoutPanel tlpAvailable;
        private Panel pnlAvailableCount;
        private Label lblAvailableCount;
        private Panel pnlAvailableHeading;
        private Label lblAvailableHeadingf;
        private Panel pnlAvailableFooter;
        private Label lblAvailableFooter;
        private TableLayoutPanel tlpTotalUnits;
        private Panel pnlTotalUnitsCount;
        private Label lblTotalUnitsCount;
        private Panel pnlTotalUnisHeading;
        private Label lblTotalUnitsHeading;
        private Panel pnlTotalUnistFooter;
        private Label lblTotalUnitsFooter;
        private Panel pnlDonorsList;
        private Panel pnlSecondRowStyling;
        private Panel pnlSearchOperations;
        private TableLayoutPanel tlpSerachOperation;
        private FlowLayoutPanel flpSerachOperations;
        private Button btnDeleteBloodUnit;
        private Button btnViewBloodUnit;
        private Button btnUpdateBloodUnit;
        private Button btnAddBloodUnit;
        private ComboBox cbStatus;
        private ComboBox cbBloodGroup;
        private Panel pnlListHeading;
        private Label lblSearchOperations;
        private DataGridView dgvBloodUnits;
        private DataGridViewTextBoxColumn buBagId;
        private DataGridViewTextBoxColumn buGroup;
        private DataGridViewTextBoxColumn buCollected;
        private DataGridViewTextBoxColumn buExpires;
        private DataGridViewTextBoxColumn buDonor;
        private DataGridViewTextBoxColumn buStatus;
    }
}
