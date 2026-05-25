namespace BloodLink.Pages
{
    partial class PatientsPage
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
            tlpPatientPage = new TableLayoutPanel();
            pnlPatientsList = new Panel();
            pnlSecondRowStyling = new Panel();
            dgvPatientRequests = new DataGridView();
            prPatient = new DataGridViewTextBoxColumn();
            prBloodGroup = new DataGridViewTextBoxColumn();
            prUnits = new DataGridViewTextBoxColumn();
            prDoctor = new DataGridViewTextBoxColumn();
            prWard = new DataGridViewTextBoxColumn();
            prStatus = new DataGridViewTextBoxColumn();
            pnlSearchOperations = new Panel();
            tlpSearchOperations = new TableLayoutPanel();
            flpOperations = new FlowLayoutPanel();
            btnDeleteRequest = new Button();
            btnViewRequest = new Button();
            btnUpdateRequest = new Button();
            btnAddRequest = new Button();
            cbStatus = new ComboBox();
            pnlListHeading = new Panel();
            pnlSearchBox = new Panel();
            tbSearch = new TextBox();
            tblFirstRow = new TableLayoutPanel();
            tlpCancelled = new TableLayoutPanel();
            pnlCancelledCount = new Panel();
            lblCancelledCount = new Label();
            pnlCancelledHeading = new Panel();
            lblCancelledHeading = new Label();
            pnlCancelledFooter = new Panel();
            lblCancelledFooter = new Label();
            tlpFulfilled = new TableLayoutPanel();
            pnlFulfilledCount = new Panel();
            lblFulfilledCount = new Label();
            pnlFulfilledHeading = new Panel();
            lblFulfilledHeading = new Label();
            pnlFulfilledFooter = new Panel();
            lblFulfilledFooter = new Label();
            tlpPending = new TableLayoutPanel();
            pnlPendingCount = new Panel();
            lblPendingCount = new Label();
            pnlPendingHeading = new Panel();
            lblPendingHeading = new Label();
            pnlPendingFooter = new Panel();
            lblPendingFooter = new Label();
            tlpTotalRequests = new TableLayoutPanel();
            pnlTotalRequestsCount = new Panel();
            lblTotalRequestsCount = new Label();
            pnlTotalRequestsHeading = new Panel();
            lblTotalRequestsHeading = new Label();
            pnlTotalRequestsFooter = new Panel();
            lblTotalRequestsFooter = new Label();
            tlpPatientPage.SuspendLayout();
            pnlPatientsList.SuspendLayout();
            pnlSecondRowStyling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatientRequests).BeginInit();
            pnlSearchOperations.SuspendLayout();
            tlpSearchOperations.SuspendLayout();
            flpOperations.SuspendLayout();
            pnlListHeading.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            tblFirstRow.SuspendLayout();
            tlpCancelled.SuspendLayout();
            pnlCancelledCount.SuspendLayout();
            pnlCancelledHeading.SuspendLayout();
            pnlCancelledFooter.SuspendLayout();
            tlpFulfilled.SuspendLayout();
            pnlFulfilledCount.SuspendLayout();
            pnlFulfilledHeading.SuspendLayout();
            pnlFulfilledFooter.SuspendLayout();
            tlpPending.SuspendLayout();
            pnlPendingCount.SuspendLayout();
            pnlPendingHeading.SuspendLayout();
            pnlPendingFooter.SuspendLayout();
            tlpTotalRequests.SuspendLayout();
            pnlTotalRequestsCount.SuspendLayout();
            pnlTotalRequestsHeading.SuspendLayout();
            pnlTotalRequestsFooter.SuspendLayout();
            SuspendLayout();
            // 
            // tlpPatientPage
            // 
            tlpPatientPage.ColumnCount = 1;
            tlpPatientPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPatientPage.Controls.Add(pnlPatientsList, 0, 1);
            tlpPatientPage.Controls.Add(tblFirstRow, 0, 0);
            tlpPatientPage.Dock = DockStyle.Fill;
            tlpPatientPage.Location = new Point(0, 0);
            tlpPatientPage.Name = "tlpPatientPage";
            tlpPatientPage.RowCount = 2;
            tlpPatientPage.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpPatientPage.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tlpPatientPage.Size = new Size(853, 489);
            tlpPatientPage.TabIndex = 0;
            // 
            // pnlPatientsList
            // 
            pnlPatientsList.AutoScroll = true;
            pnlPatientsList.Controls.Add(pnlSecondRowStyling);
            pnlPatientsList.Dock = DockStyle.Fill;
            pnlPatientsList.Location = new Point(3, 104);
            pnlPatientsList.Margin = new Padding(3, 7, 3, 3);
            pnlPatientsList.Name = "pnlPatientsList";
            pnlPatientsList.Size = new Size(847, 382);
            pnlPatientsList.TabIndex = 2;
            // 
            // pnlSecondRowStyling
            // 
            pnlSecondRowStyling.AutoSize = true;
            pnlSecondRowStyling.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlSecondRowStyling.Controls.Add(dgvPatientRequests);
            pnlSecondRowStyling.Controls.Add(pnlSearchOperations);
            pnlSecondRowStyling.Dock = DockStyle.Top;
            pnlSecondRowStyling.Location = new Point(0, 0);
            pnlSecondRowStyling.Name = "pnlSecondRowStyling";
            pnlSecondRowStyling.Padding = new Padding(15, 23, 15, 23);
            pnlSecondRowStyling.Size = new Size(847, 339);
            pnlSecondRowStyling.TabIndex = 1;
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
            dgvPatientRequests.Columns.AddRange(new DataGridViewColumn[] { prPatient, prBloodGroup, prUnits, prDoctor, prWard, prStatus });
            dgvPatientRequests.Dock = DockStyle.Top;
            dgvPatientRequests.EnableHeadersVisualStyles = false;
            dgvPatientRequests.Location = new Point(15, 69);
            dgvPatientRequests.Margin = new Padding(0);
            dgvPatientRequests.MultiSelect = false;
            dgvPatientRequests.Name = "dgvPatientRequests";
            dgvPatientRequests.ReadOnly = true;
            dgvPatientRequests.RowHeadersVisible = false;
            dgvPatientRequests.ScrollBars = ScrollBars.None;
            dgvPatientRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientRequests.Size = new Size(817, 247);
            dgvPatientRequests.TabIndex = 8;
            dgvPatientRequests.CellFormatting += dgvPatientRequests_CellFormatting;
            // 
            // prPatient
            // 
            prPatient.DataPropertyName = "PatientName";
            prPatient.HeaderText = "PATIENT";
            prPatient.Name = "prPatient";
            prPatient.ReadOnly = true;
            // 
            // prBloodGroup
            // 
            prBloodGroup.DataPropertyName = "BloodGroup";
            prBloodGroup.HeaderText = "GROUP";
            prBloodGroup.Name = "prBloodGroup";
            prBloodGroup.ReadOnly = true;
            // 
            // prUnits
            // 
            prUnits.DataPropertyName = "UnitsRequired";
            prUnits.HeaderText = "UNITS";
            prUnits.Name = "prUnits";
            prUnits.ReadOnly = true;
            // 
            // prDoctor
            // 
            prDoctor.DataPropertyName = "DoctorName";
            prDoctor.HeaderText = "DOCTOR";
            prDoctor.Name = "prDoctor";
            prDoctor.ReadOnly = true;
            // 
            // prWard
            // 
            prWard.DataPropertyName = "Ward";
            prWard.HeaderText = "WARD";
            prWard.Name = "prWard";
            prWard.ReadOnly = true;
            // 
            // prStatus
            // 
            prStatus.DataPropertyName = "Status";
            prStatus.HeaderText = "STATUS";
            prStatus.Name = "prStatus";
            prStatus.ReadOnly = true;
            // 
            // pnlSearchOperations
            // 
            pnlSearchOperations.Controls.Add(tlpSearchOperations);
            pnlSearchOperations.Dock = DockStyle.Top;
            pnlSearchOperations.Location = new Point(15, 23);
            pnlSearchOperations.Name = "pnlSearchOperations";
            pnlSearchOperations.Size = new Size(817, 46);
            pnlSearchOperations.TabIndex = 1;
            // 
            // tlpSearchOperations
            // 
            tlpSearchOperations.ColumnCount = 2;
            tlpSearchOperations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSearchOperations.ColumnStyles.Add(new ColumnStyle());
            tlpSearchOperations.Controls.Add(flpOperations, 1, 0);
            tlpSearchOperations.Controls.Add(pnlListHeading, 0, 0);
            tlpSearchOperations.Dock = DockStyle.Fill;
            tlpSearchOperations.Location = new Point(0, 0);
            tlpSearchOperations.Name = "tlpSearchOperations";
            tlpSearchOperations.Padding = new Padding(0, 0, 0, 10);
            tlpSearchOperations.RowCount = 1;
            tlpSearchOperations.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSearchOperations.Size = new Size(817, 46);
            tlpSearchOperations.TabIndex = 2;
            // 
            // flpOperations
            // 
            flpOperations.AutoSize = true;
            flpOperations.Controls.Add(btnDeleteRequest);
            flpOperations.Controls.Add(btnViewRequest);
            flpOperations.Controls.Add(btnUpdateRequest);
            flpOperations.Controls.Add(btnAddRequest);
            flpOperations.Controls.Add(cbStatus);
            flpOperations.Dock = DockStyle.Fill;
            flpOperations.FlowDirection = FlowDirection.RightToLeft;
            flpOperations.Location = new Point(303, 3);
            flpOperations.Name = "flpOperations";
            flpOperations.Size = new Size(511, 30);
            flpOperations.TabIndex = 0;
            flpOperations.WrapContents = false;
            // 
            // btnDeleteRequest
            // 
            btnDeleteRequest.AutoSize = true;
            btnDeleteRequest.Dock = DockStyle.Fill;
            btnDeleteRequest.FlatStyle = FlatStyle.Flat;
            btnDeleteRequest.Location = new Point(408, 3);
            btnDeleteRequest.Margin = new Padding(4, 3, 0, 7);
            btnDeleteRequest.Name = "btnDeleteRequest";
            btnDeleteRequest.Size = new Size(103, 27);
            btnDeleteRequest.TabIndex = 9;
            btnDeleteRequest.Text = "🗑 Delete";
            btnDeleteRequest.UseVisualStyleBackColor = false;
            btnDeleteRequest.Click += btnDeleteRequest_Click;
            // 
            // btnViewRequest
            // 
            btnViewRequest.AutoSize = true;
            btnViewRequest.Dock = DockStyle.Fill;
            btnViewRequest.FlatStyle = FlatStyle.Flat;
            btnViewRequest.Location = new Point(309, 3);
            btnViewRequest.Margin = new Padding(4, 3, 0, 7);
            btnViewRequest.Name = "btnViewRequest";
            btnViewRequest.Size = new Size(95, 27);
            btnViewRequest.TabIndex = 10;
            btnViewRequest.Text = "👁️ View";
            btnViewRequest.UseVisualStyleBackColor = false;
            btnViewRequest.Click += btnViewRequest_Click;
            // 
            // btnUpdateRequest
            // 
            btnUpdateRequest.AutoSize = true;
            btnUpdateRequest.Dock = DockStyle.Fill;
            btnUpdateRequest.FlatStyle = FlatStyle.Flat;
            btnUpdateRequest.Location = new Point(197, 3);
            btnUpdateRequest.Margin = new Padding(4, 3, 0, 7);
            btnUpdateRequest.Name = "btnUpdateRequest";
            btnUpdateRequest.Size = new Size(108, 27);
            btnUpdateRequest.TabIndex = 11;
            btnUpdateRequest.Text = "⟳ Update";
            btnUpdateRequest.UseVisualStyleBackColor = false;
            btnUpdateRequest.Click += btnUpdateRequest_Click;
            // 
            // btnAddRequest
            // 
            btnAddRequest.AutoSize = true;
            btnAddRequest.Dock = DockStyle.Fill;
            btnAddRequest.FlatStyle = FlatStyle.Flat;
            btnAddRequest.Location = new Point(94, 3);
            btnAddRequest.Margin = new Padding(4, 3, 0, 7);
            btnAddRequest.Name = "btnAddRequest";
            btnAddRequest.Size = new Size(99, 27);
            btnAddRequest.TabIndex = 12;
            btnAddRequest.Text = "+ New Request";
            btnAddRequest.UseVisualStyleBackColor = false;
            btnAddRequest.Click += btnAddRequest_Click;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Fill;
            cbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(4, 3);
            cbStatus.Margin = new Padding(4, 3, 4, 3);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(82, 24);
            cbStatus.TabIndex = 13;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // pnlListHeading
            // 
            pnlListHeading.Controls.Add(pnlSearchBox);
            pnlListHeading.Dock = DockStyle.Fill;
            pnlListHeading.Location = new Point(3, 3);
            pnlListHeading.Name = "pnlListHeading";
            pnlListHeading.Size = new Size(294, 30);
            pnlListHeading.TabIndex = 1;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = SystemColors.ActiveCaption;
            pnlSearchBox.Controls.Add(tbSearch);
            pnlSearchBox.Dock = DockStyle.Fill;
            pnlSearchBox.Location = new Point(0, 0);
            pnlSearchBox.Margin = new Padding(4, 2, 4, 3);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Padding = new Padding(12, 5, 0, 5);
            pnlSearchBox.Size = new Size(294, 30);
            pnlSearchBox.TabIndex = 15;
            // 
            // tbSearch
            // 
            tbSearch.BorderStyle = BorderStyle.None;
            tbSearch.Dock = DockStyle.Top;
            tbSearch.Location = new Point(12, 5);
            tbSearch.Margin = new Padding(0);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search by patient name...";
            tbSearch.Size = new Size(282, 16);
            tbSearch.TabIndex = 1;
            tbSearch.TextChanged += tbSearch_TextChanged_1;
            // 
            // tblFirstRow
            // 
            tblFirstRow.ColumnCount = 4;
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblFirstRow.Controls.Add(tlpCancelled, 3, 0);
            tblFirstRow.Controls.Add(tlpFulfilled, 2, 0);
            tblFirstRow.Controls.Add(tlpPending, 1, 0);
            tblFirstRow.Controls.Add(tlpTotalRequests, 0, 0);
            tblFirstRow.Dock = DockStyle.Fill;
            tblFirstRow.Location = new Point(3, 3);
            tblFirstRow.Name = "tblFirstRow";
            tblFirstRow.RowCount = 1;
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFirstRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblFirstRow.Size = new Size(847, 91);
            tblFirstRow.TabIndex = 1;
            // 
            // tlpCancelled
            // 
            tlpCancelled.BackColor = SystemColors.Control;
            tlpCancelled.ColumnCount = 1;
            tlpCancelled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCancelled.Controls.Add(pnlCancelledCount, 0, 1);
            tlpCancelled.Controls.Add(pnlCancelledHeading, 0, 0);
            tlpCancelled.Controls.Add(pnlCancelledFooter, 0, 2);
            tlpCancelled.Dock = DockStyle.Fill;
            tlpCancelled.Location = new Point(636, 3);
            tlpCancelled.Name = "tlpCancelled";
            tlpCancelled.RowCount = 3;
            tlpCancelled.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpCancelled.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpCancelled.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpCancelled.Size = new Size(208, 85);
            tlpCancelled.TabIndex = 9;
            // 
            // pnlCancelledCount
            // 
            pnlCancelledCount.Controls.Add(lblCancelledCount);
            pnlCancelledCount.Dock = DockStyle.Fill;
            pnlCancelledCount.Location = new Point(3, 32);
            pnlCancelledCount.Name = "pnlCancelledCount";
            pnlCancelledCount.Size = new Size(202, 20);
            pnlCancelledCount.TabIndex = 3;
            // 
            // lblCancelledCount
            // 
            lblCancelledCount.Dock = DockStyle.Fill;
            lblCancelledCount.Location = new Point(0, 0);
            lblCancelledCount.Name = "lblCancelledCount";
            lblCancelledCount.Padding = new Padding(8, 0, 0, 0);
            lblCancelledCount.Size = new Size(202, 20);
            lblCancelledCount.TabIndex = 0;
            lblCancelledCount.Text = "0";
            lblCancelledCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCancelledHeading
            // 
            pnlCancelledHeading.Controls.Add(lblCancelledHeading);
            pnlCancelledHeading.Dock = DockStyle.Fill;
            pnlCancelledHeading.Location = new Point(3, 3);
            pnlCancelledHeading.Name = "pnlCancelledHeading";
            pnlCancelledHeading.Size = new Size(202, 23);
            pnlCancelledHeading.TabIndex = 2;
            // 
            // lblCancelledHeading
            // 
            lblCancelledHeading.Dock = DockStyle.Fill;
            lblCancelledHeading.Location = new Point(0, 0);
            lblCancelledHeading.Name = "lblCancelledHeading";
            lblCancelledHeading.Padding = new Padding(8, 0, 0, 0);
            lblCancelledHeading.Size = new Size(202, 23);
            lblCancelledHeading.TabIndex = 0;
            lblCancelledHeading.Text = "Cancelled";
            lblCancelledHeading.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlCancelledFooter
            // 
            pnlCancelledFooter.Controls.Add(lblCancelledFooter);
            pnlCancelledFooter.Dock = DockStyle.Fill;
            pnlCancelledFooter.Location = new Point(3, 58);
            pnlCancelledFooter.Name = "pnlCancelledFooter";
            pnlCancelledFooter.Size = new Size(202, 24);
            pnlCancelledFooter.TabIndex = 4;
            // 
            // lblCancelledFooter
            // 
            lblCancelledFooter.Dock = DockStyle.Fill;
            lblCancelledFooter.Location = new Point(0, 0);
            lblCancelledFooter.Name = "lblCancelledFooter";
            lblCancelledFooter.Padding = new Padding(8, 0, 0, 0);
            lblCancelledFooter.Size = new Size(202, 24);
            lblCancelledFooter.TabIndex = 0;
            lblCancelledFooter.Text = "not fulfilled";
            // 
            // tlpFulfilled
            // 
            tlpFulfilled.BackColor = SystemColors.Control;
            tlpFulfilled.ColumnCount = 1;
            tlpFulfilled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFulfilled.Controls.Add(pnlFulfilledCount, 0, 1);
            tlpFulfilled.Controls.Add(pnlFulfilledHeading, 0, 0);
            tlpFulfilled.Controls.Add(pnlFulfilledFooter, 0, 2);
            tlpFulfilled.Dock = DockStyle.Fill;
            tlpFulfilled.Location = new Point(425, 3);
            tlpFulfilled.Name = "tlpFulfilled";
            tlpFulfilled.RowCount = 3;
            tlpFulfilled.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpFulfilled.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpFulfilled.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpFulfilled.Size = new Size(205, 85);
            tlpFulfilled.TabIndex = 8;
            // 
            // pnlFulfilledCount
            // 
            pnlFulfilledCount.Controls.Add(lblFulfilledCount);
            pnlFulfilledCount.Dock = DockStyle.Fill;
            pnlFulfilledCount.Location = new Point(3, 32);
            pnlFulfilledCount.Name = "pnlFulfilledCount";
            pnlFulfilledCount.Size = new Size(199, 20);
            pnlFulfilledCount.TabIndex = 3;
            // 
            // lblFulfilledCount
            // 
            lblFulfilledCount.Dock = DockStyle.Fill;
            lblFulfilledCount.Location = new Point(0, 0);
            lblFulfilledCount.Name = "lblFulfilledCount";
            lblFulfilledCount.Padding = new Padding(8, 0, 0, 0);
            lblFulfilledCount.Size = new Size(199, 20);
            lblFulfilledCount.TabIndex = 0;
            lblFulfilledCount.Text = "0";
            lblFulfilledCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFulfilledHeading
            // 
            pnlFulfilledHeading.Controls.Add(lblFulfilledHeading);
            pnlFulfilledHeading.Dock = DockStyle.Fill;
            pnlFulfilledHeading.Location = new Point(3, 3);
            pnlFulfilledHeading.Name = "pnlFulfilledHeading";
            pnlFulfilledHeading.Size = new Size(199, 23);
            pnlFulfilledHeading.TabIndex = 2;
            // 
            // lblFulfilledHeading
            // 
            lblFulfilledHeading.Dock = DockStyle.Fill;
            lblFulfilledHeading.Location = new Point(0, 0);
            lblFulfilledHeading.Name = "lblFulfilledHeading";
            lblFulfilledHeading.Padding = new Padding(8, 0, 0, 0);
            lblFulfilledHeading.Size = new Size(199, 23);
            lblFulfilledHeading.TabIndex = 0;
            lblFulfilledHeading.Text = "Fulfilled";
            lblFulfilledHeading.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlFulfilledFooter
            // 
            pnlFulfilledFooter.Controls.Add(lblFulfilledFooter);
            pnlFulfilledFooter.Dock = DockStyle.Fill;
            pnlFulfilledFooter.Location = new Point(3, 58);
            pnlFulfilledFooter.Name = "pnlFulfilledFooter";
            pnlFulfilledFooter.Size = new Size(199, 24);
            pnlFulfilledFooter.TabIndex = 4;
            // 
            // lblFulfilledFooter
            // 
            lblFulfilledFooter.Dock = DockStyle.Fill;
            lblFulfilledFooter.Location = new Point(0, 0);
            lblFulfilledFooter.Name = "lblFulfilledFooter";
            lblFulfilledFooter.Padding = new Padding(8, 0, 0, 0);
            lblFulfilledFooter.Size = new Size(199, 24);
            lblFulfilledFooter.TabIndex = 0;
            lblFulfilledFooter.Text = "successfully issued";
            // 
            // tlpPending
            // 
            tlpPending.BackColor = SystemColors.Control;
            tlpPending.ColumnCount = 1;
            tlpPending.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPending.Controls.Add(pnlPendingCount, 0, 1);
            tlpPending.Controls.Add(pnlPendingHeading, 0, 0);
            tlpPending.Controls.Add(pnlPendingFooter, 0, 2);
            tlpPending.Dock = DockStyle.Fill;
            tlpPending.Location = new Point(214, 3);
            tlpPending.Name = "tlpPending";
            tlpPending.RowCount = 3;
            tlpPending.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpPending.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpPending.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpPending.Size = new Size(205, 85);
            tlpPending.TabIndex = 7;
            // 
            // pnlPendingCount
            // 
            pnlPendingCount.Controls.Add(lblPendingCount);
            pnlPendingCount.Dock = DockStyle.Fill;
            pnlPendingCount.Location = new Point(3, 32);
            pnlPendingCount.Name = "pnlPendingCount";
            pnlPendingCount.Size = new Size(199, 20);
            pnlPendingCount.TabIndex = 3;
            // 
            // lblPendingCount
            // 
            lblPendingCount.Dock = DockStyle.Fill;
            lblPendingCount.Location = new Point(0, 0);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Padding = new Padding(8, 0, 0, 0);
            lblPendingCount.Size = new Size(199, 20);
            lblPendingCount.TabIndex = 0;
            lblPendingCount.Text = "0";
            lblPendingCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPendingHeading
            // 
            pnlPendingHeading.Controls.Add(lblPendingHeading);
            pnlPendingHeading.Dock = DockStyle.Fill;
            pnlPendingHeading.Location = new Point(3, 3);
            pnlPendingHeading.Name = "pnlPendingHeading";
            pnlPendingHeading.Size = new Size(199, 23);
            pnlPendingHeading.TabIndex = 2;
            // 
            // lblPendingHeading
            // 
            lblPendingHeading.Dock = DockStyle.Fill;
            lblPendingHeading.Location = new Point(0, 0);
            lblPendingHeading.Name = "lblPendingHeading";
            lblPendingHeading.Padding = new Padding(8, 0, 0, 0);
            lblPendingHeading.Size = new Size(199, 23);
            lblPendingHeading.TabIndex = 0;
            lblPendingHeading.Text = "Pending";
            lblPendingHeading.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlPendingFooter
            // 
            pnlPendingFooter.Controls.Add(lblPendingFooter);
            pnlPendingFooter.Dock = DockStyle.Fill;
            pnlPendingFooter.Location = new Point(3, 58);
            pnlPendingFooter.Name = "pnlPendingFooter";
            pnlPendingFooter.Size = new Size(199, 24);
            pnlPendingFooter.TabIndex = 4;
            // 
            // lblPendingFooter
            // 
            lblPendingFooter.Dock = DockStyle.Fill;
            lblPendingFooter.Location = new Point(0, 0);
            lblPendingFooter.Name = "lblPendingFooter";
            lblPendingFooter.Padding = new Padding(8, 0, 0, 0);
            lblPendingFooter.Size = new Size(199, 24);
            lblPendingFooter.TabIndex = 0;
            lblPendingFooter.Text = "awaiting fulfillment";
            // 
            // tlpTotalRequests
            // 
            tlpTotalRequests.BackColor = SystemColors.Control;
            tlpTotalRequests.ColumnCount = 1;
            tlpTotalRequests.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTotalRequests.Controls.Add(pnlTotalRequestsCount, 0, 1);
            tlpTotalRequests.Controls.Add(pnlTotalRequestsHeading, 0, 0);
            tlpTotalRequests.Controls.Add(pnlTotalRequestsFooter, 0, 2);
            tlpTotalRequests.Dock = DockStyle.Fill;
            tlpTotalRequests.Location = new Point(3, 3);
            tlpTotalRequests.Name = "tlpTotalRequests";
            tlpTotalRequests.RowCount = 3;
            tlpTotalRequests.RowStyles.Add(new RowStyle(SizeType.Percent, 34.277092F));
            tlpTotalRequests.RowStyles.Add(new RowStyle(SizeType.Percent, 31.4458084F));
            tlpTotalRequests.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2770958F));
            tlpTotalRequests.Size = new Size(205, 85);
            tlpTotalRequests.TabIndex = 6;
            // 
            // pnlTotalRequestsCount
            // 
            pnlTotalRequestsCount.Controls.Add(lblTotalRequestsCount);
            pnlTotalRequestsCount.Dock = DockStyle.Fill;
            pnlTotalRequestsCount.Location = new Point(3, 32);
            pnlTotalRequestsCount.Name = "pnlTotalRequestsCount";
            pnlTotalRequestsCount.Size = new Size(199, 20);
            pnlTotalRequestsCount.TabIndex = 3;
            // 
            // lblTotalRequestsCount
            // 
            lblTotalRequestsCount.Dock = DockStyle.Fill;
            lblTotalRequestsCount.Location = new Point(0, 0);
            lblTotalRequestsCount.Name = "lblTotalRequestsCount";
            lblTotalRequestsCount.Padding = new Padding(8, 0, 0, 0);
            lblTotalRequestsCount.Size = new Size(199, 20);
            lblTotalRequestsCount.TabIndex = 0;
            lblTotalRequestsCount.Text = "0";
            lblTotalRequestsCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTotalRequestsHeading
            // 
            pnlTotalRequestsHeading.Controls.Add(lblTotalRequestsHeading);
            pnlTotalRequestsHeading.Dock = DockStyle.Fill;
            pnlTotalRequestsHeading.Location = new Point(3, 3);
            pnlTotalRequestsHeading.Name = "pnlTotalRequestsHeading";
            pnlTotalRequestsHeading.Size = new Size(199, 23);
            pnlTotalRequestsHeading.TabIndex = 2;
            // 
            // lblTotalRequestsHeading
            // 
            lblTotalRequestsHeading.Dock = DockStyle.Fill;
            lblTotalRequestsHeading.Location = new Point(0, 0);
            lblTotalRequestsHeading.Name = "lblTotalRequestsHeading";
            lblTotalRequestsHeading.Padding = new Padding(8, 0, 0, 0);
            lblTotalRequestsHeading.Size = new Size(199, 23);
            lblTotalRequestsHeading.TabIndex = 0;
            lblTotalRequestsHeading.Text = "Total Requests";
            lblTotalRequestsHeading.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlTotalRequestsFooter
            // 
            pnlTotalRequestsFooter.Controls.Add(lblTotalRequestsFooter);
            pnlTotalRequestsFooter.Dock = DockStyle.Fill;
            pnlTotalRequestsFooter.Location = new Point(3, 58);
            pnlTotalRequestsFooter.Name = "pnlTotalRequestsFooter";
            pnlTotalRequestsFooter.Size = new Size(199, 24);
            pnlTotalRequestsFooter.TabIndex = 4;
            // 
            // lblTotalRequestsFooter
            // 
            lblTotalRequestsFooter.Dock = DockStyle.Fill;
            lblTotalRequestsFooter.Location = new Point(0, 0);
            lblTotalRequestsFooter.Name = "lblTotalRequestsFooter";
            lblTotalRequestsFooter.Padding = new Padding(8, 0, 0, 0);
            lblTotalRequestsFooter.Size = new Size(199, 24);
            lblTotalRequestsFooter.TabIndex = 0;
            lblTotalRequestsFooter.Text = "all time";
            // 
            // PatientsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpPatientPage);
            Name = "PatientsPage";
            Size = new Size(853, 489);
            tlpPatientPage.ResumeLayout(false);
            pnlPatientsList.ResumeLayout(false);
            pnlPatientsList.PerformLayout();
            pnlSecondRowStyling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatientRequests).EndInit();
            pnlSearchOperations.ResumeLayout(false);
            tlpSearchOperations.ResumeLayout(false);
            tlpSearchOperations.PerformLayout();
            flpOperations.ResumeLayout(false);
            flpOperations.PerformLayout();
            pnlListHeading.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            tblFirstRow.ResumeLayout(false);
            tlpCancelled.ResumeLayout(false);
            pnlCancelledCount.ResumeLayout(false);
            pnlCancelledHeading.ResumeLayout(false);
            pnlCancelledFooter.ResumeLayout(false);
            tlpFulfilled.ResumeLayout(false);
            pnlFulfilledCount.ResumeLayout(false);
            pnlFulfilledHeading.ResumeLayout(false);
            pnlFulfilledFooter.ResumeLayout(false);
            tlpPending.ResumeLayout(false);
            pnlPendingCount.ResumeLayout(false);
            pnlPendingHeading.ResumeLayout(false);
            pnlPendingFooter.ResumeLayout(false);
            tlpTotalRequests.ResumeLayout(false);
            pnlTotalRequestsCount.ResumeLayout(false);
            pnlTotalRequestsHeading.ResumeLayout(false);
            pnlTotalRequestsFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPatientPage;
        private TableLayoutPanel tblFirstRow;
        private TableLayoutPanel tlpTotalRequests;
        private Panel pnlTotalRequestsCount;
        private Label lblTotalRequestsCount;
        private Panel pnlTotalRequestsHeading;
        private Label lblTotalRequestsHeading;
        private Panel pnlTotalRequestsFooter;
        private Label lblTotalRequestsFooter;
        private TableLayoutPanel tlpPending;
        private Panel pnlPendingCount;
        private Label lblPendingCount;
        private Panel pnlPendingHeading;
        private Label lblPendingHeading;
        private Panel pnlPendingFooter;
        private Label lblPendingFooter;
        private TableLayoutPanel tlpFulfilled;
        private Panel pnlFulfilledCount;
        private Label lblFulfilledCount;
        private Panel pnlFulfilledHeading;
        private Label lblFulfilledHeading;
        private Panel pnlFulfilledFooter;
        private Label lblFulfilledFooter;
        private TableLayoutPanel tlpCancelled;
        private Panel pnlCancelledCount;
        private Label lblCancelledCount;
        private Panel pnlCancelledHeading;
        private Label lblCancelledHeading;
        private Panel pnlCancelledFooter;
        private Label lblCancelledFooter;
        private Panel pnlPatientsList;
        private Panel pnlSecondRowStyling;
        private Panel pnlSearchOperations;
        private TableLayoutPanel tlpSearchOperations;
        private DataGridView dgvPatientRequests;
        private FlowLayoutPanel flpOperations;
        private Button btnDeleteRequest;
        private Button btnViewRequest;
        private Button btnUpdateRequest;
        private Button btnAddRequest;
        private ComboBox cbStatus;
        private Panel pnlListHeading;
        private Panel pnlSearchBox;
        private TextBox tbSearch;
        private DataGridViewTextBoxColumn prPatient;
        private DataGridViewTextBoxColumn prBloodGroup;
        private DataGridViewTextBoxColumn prUnits;
        private DataGridViewTextBoxColumn prDoctor;
        private DataGridViewTextBoxColumn prWard;
        private DataGridViewTextBoxColumn prStatus;
    }
}