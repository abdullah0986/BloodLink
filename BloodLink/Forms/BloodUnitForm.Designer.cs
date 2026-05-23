namespace BloodLink.Forms
{
    partial class BloodUnitForm
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
            components = new System.ComponentModel.Container();
            pnlBloodUnitForm = new Panel();
            pnlFormStyling = new Panel();
            tblDonorForm = new TableLayoutPanel();
            pnlNotes = new Panel();
            tbNotes = new TextBox();
            lblNotes = new Label();
            pnlCreatedAt = new Panel();
            dtpNextEligibleDate = new DateTimePicker();
            lblCreatedAt = new Label();
            pnlUserId = new Panel();
            tbUserId = new TextBox();
            lblUserId = new Label();
            pnlExpiryDate = new Panel();
            dtpExpiryDate = new DateTimePicker();
            lblExpiryDate = new Label();
            pnlStatus = new Panel();
            cbStatus = new ComboBox();
            lblStatus = new Label();
            pnlLinkedDonor = new Panel();
            cbLinkedDonor = new ComboBox();
            lblLinkedDonor = new Label();
            pnlCollectionDate = new Panel();
            dtpCollectionDate = new DateTimePicker();
            lblCollectionDate = new Label();
            pnlBloodGroup = new Panel();
            cbBloodGroup = new ComboBox();
            lblBloodGroup = new Label();
            btnSave = new Button();
            pnlBloodUnitID = new Panel();
            tbID = new TextBox();
            lblID = new Label();
            btnCancel = new Button();
            pnlFormHeading = new Panel();
            lblBloodUnitFormHeading = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            pnlBloodUnitForm.SuspendLayout();
            pnlFormStyling.SuspendLayout();
            tblDonorForm.SuspendLayout();
            pnlNotes.SuspendLayout();
            pnlCreatedAt.SuspendLayout();
            pnlUserId.SuspendLayout();
            pnlExpiryDate.SuspendLayout();
            pnlStatus.SuspendLayout();
            pnlLinkedDonor.SuspendLayout();
            pnlCollectionDate.SuspendLayout();
            pnlBloodGroup.SuspendLayout();
            pnlBloodUnitID.SuspendLayout();
            pnlFormHeading.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBloodUnitForm
            // 
            pnlBloodUnitForm.Controls.Add(pnlFormStyling);
            pnlBloodUnitForm.Controls.Add(pnlFormHeading);
            pnlBloodUnitForm.Dock = DockStyle.Fill;
            pnlBloodUnitForm.Location = new Point(0, 0);
            pnlBloodUnitForm.Name = "pnlBloodUnitForm";
            pnlBloodUnitForm.Padding = new Padding(10);
            pnlBloodUnitForm.Size = new Size(754, 463);
            pnlBloodUnitForm.TabIndex = 1;
            // 
            // pnlFormStyling
            // 
            pnlFormStyling.Controls.Add(tblDonorForm);
            pnlFormStyling.Dock = DockStyle.Fill;
            pnlFormStyling.Location = new Point(10, 45);
            pnlFormStyling.Name = "pnlFormStyling";
            pnlFormStyling.Padding = new Padding(5);
            pnlFormStyling.Size = new Size(734, 408);
            pnlFormStyling.TabIndex = 1;
            // 
            // tblDonorForm
            // 
            tblDonorForm.ColumnCount = 2;
            tblDonorForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDonorForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDonorForm.Controls.Add(pnlNotes, 0, 4);
            tblDonorForm.Controls.Add(pnlCreatedAt, 1, 3);
            tblDonorForm.Controls.Add(pnlUserId, 0, 3);
            tblDonorForm.Controls.Add(pnlExpiryDate, 1, 2);
            tblDonorForm.Controls.Add(pnlStatus, 0, 2);
            tblDonorForm.Controls.Add(pnlLinkedDonor, 1, 1);
            tblDonorForm.Controls.Add(pnlCollectionDate, 0, 1);
            tblDonorForm.Controls.Add(pnlBloodGroup, 1, 0);
            tblDonorForm.Controls.Add(btnSave, 1, 5);
            tblDonorForm.Controls.Add(pnlBloodUnitID, 0, 0);
            tblDonorForm.Controls.Add(btnCancel, 0, 5);
            tblDonorForm.Dock = DockStyle.Fill;
            tblDonorForm.Location = new Point(5, 5);
            tblDonorForm.Margin = new Padding(3, 3, 6, 3);
            tblDonorForm.Name = "tblDonorForm";
            tblDonorForm.RowCount = 6;
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3250084F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 17.32502F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3250179F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3250179F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5724182F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12.127511F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblDonorForm.Size = new Size(724, 398);
            tblDonorForm.TabIndex = 2;
            // 
            // pnlNotes
            // 
            tblDonorForm.SetColumnSpan(pnlNotes, 2);
            pnlNotes.Controls.Add(tbNotes);
            pnlNotes.Controls.Add(lblNotes);
            pnlNotes.Dock = DockStyle.Fill;
            pnlNotes.Location = new Point(3, 275);
            pnlNotes.Name = "pnlNotes";
            pnlNotes.Size = new Size(718, 67);
            pnlNotes.TabIndex = 30;
            // 
            // tbNotes
            // 
            tbNotes.Dock = DockStyle.Top;
            tbNotes.Location = new Point(0, 20);
            tbNotes.Name = "tbNotes";
            tbNotes.PlaceholderText = "Donor has Fever";
            tbNotes.Size = new Size(718, 23);
            tbNotes.TabIndex = 3;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Dock = DockStyle.Top;
            lblNotes.Location = new Point(0, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Padding = new Padding(0, 0, 0, 5);
            lblNotes.Size = new Size(95, 20);
            lblNotes.TabIndex = 2;
            lblNotes.Text = "Notes (Optional)";
            // 
            // pnlCreatedAt
            // 
            pnlCreatedAt.Controls.Add(dtpNextEligibleDate);
            pnlCreatedAt.Controls.Add(lblCreatedAt);
            pnlCreatedAt.Dock = DockStyle.Fill;
            pnlCreatedAt.Location = new Point(368, 207);
            pnlCreatedAt.Margin = new Padding(6, 3, 3, 3);
            pnlCreatedAt.Name = "pnlCreatedAt";
            pnlCreatedAt.Size = new Size(353, 62);
            pnlCreatedAt.TabIndex = 29;
            // 
            // dtpNextEligibleDate
            // 
            dtpNextEligibleDate.CustomFormat = "dd-MM-yyyy";
            dtpNextEligibleDate.Dock = DockStyle.Top;
            dtpNextEligibleDate.Enabled = false;
            dtpNextEligibleDate.Format = DateTimePickerFormat.Custom;
            dtpNextEligibleDate.Location = new Point(0, 20);
            dtpNextEligibleDate.Name = "dtpNextEligibleDate";
            dtpNextEligibleDate.Size = new Size(353, 23);
            dtpNextEligibleDate.TabIndex = 2;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Dock = DockStyle.Top;
            lblCreatedAt.Location = new Point(0, 0);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Padding = new Padding(0, 0, 0, 5);
            lblCreatedAt.Size = new Size(63, 20);
            lblCreatedAt.TabIndex = 1;
            lblCreatedAt.Text = "Created At";
            // 
            // pnlUserId
            // 
            pnlUserId.Controls.Add(tbUserId);
            pnlUserId.Controls.Add(lblUserId);
            pnlUserId.Dock = DockStyle.Fill;
            pnlUserId.Location = new Point(3, 207);
            pnlUserId.Margin = new Padding(3, 3, 6, 3);
            pnlUserId.Name = "pnlUserId";
            pnlUserId.Size = new Size(353, 62);
            pnlUserId.TabIndex = 28;
            // 
            // tbUserId
            // 
            tbUserId.Dock = DockStyle.Top;
            tbUserId.Enabled = false;
            tbUserId.Location = new Point(0, 20);
            tbUserId.Name = "tbUserId";
            tbUserId.PlaceholderText = "Auto Generated";
            tbUserId.ReadOnly = true;
            tbUserId.Size = new Size(353, 23);
            tbUserId.TabIndex = 2;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Dock = DockStyle.Top;
            lblUserId.Location = new Point(0, 0);
            lblUserId.Name = "lblUserId";
            lblUserId.Padding = new Padding(0, 0, 0, 5);
            lblUserId.Size = new Size(44, 20);
            lblUserId.TabIndex = 1;
            lblUserId.Text = "User ID";
            // 
            // pnlExpiryDate
            // 
            pnlExpiryDate.Controls.Add(dtpExpiryDate);
            pnlExpiryDate.Controls.Add(lblExpiryDate);
            pnlExpiryDate.Dock = DockStyle.Fill;
            pnlExpiryDate.Location = new Point(368, 139);
            pnlExpiryDate.Margin = new Padding(6, 3, 3, 3);
            pnlExpiryDate.Name = "pnlExpiryDate";
            pnlExpiryDate.Size = new Size(353, 62);
            pnlExpiryDate.TabIndex = 27;
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.CustomFormat = "dd-MM-yyyy";
            dtpExpiryDate.Dock = DockStyle.Top;
            dtpExpiryDate.Enabled = false;
            dtpExpiryDate.Format = DateTimePickerFormat.Custom;
            dtpExpiryDate.Location = new Point(0, 20);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(353, 23);
            dtpExpiryDate.TabIndex = 3;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Dock = DockStyle.Top;
            lblExpiryDate.Location = new Point(0, 0);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Padding = new Padding(0, 0, 0, 5);
            lblExpiryDate.Size = new Size(65, 20);
            lblExpiryDate.TabIndex = 1;
            lblExpiryDate.Text = "Expiry Date";
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(cbStatus);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Dock = DockStyle.Fill;
            pnlStatus.Location = new Point(3, 139);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(356, 62);
            pnlStatus.TabIndex = 21;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Top;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(0, 20);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(356, 23);
            cbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(0, 0, 0, 5);
            lblStatus.Size = new Size(39, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            // 
            // pnlLinkedDonor
            // 
            pnlLinkedDonor.Controls.Add(cbLinkedDonor);
            pnlLinkedDonor.Controls.Add(lblLinkedDonor);
            pnlLinkedDonor.Dock = DockStyle.Fill;
            pnlLinkedDonor.Location = new Point(365, 71);
            pnlLinkedDonor.Margin = new Padding(3, 3, 6, 3);
            pnlLinkedDonor.Name = "pnlLinkedDonor";
            pnlLinkedDonor.Size = new Size(353, 62);
            pnlLinkedDonor.TabIndex = 20;
            // 
            // cbLinkedDonor
            // 
            cbLinkedDonor.Dock = DockStyle.Top;
            cbLinkedDonor.FormattingEnabled = true;
            cbLinkedDonor.Location = new Point(0, 20);
            cbLinkedDonor.Name = "cbLinkedDonor";
            cbLinkedDonor.Size = new Size(353, 23);
            cbLinkedDonor.TabIndex = 3;
            // 
            // lblLinkedDonor
            // 
            lblLinkedDonor.AutoSize = true;
            lblLinkedDonor.Dock = DockStyle.Top;
            lblLinkedDonor.Location = new Point(0, 0);
            lblLinkedDonor.Name = "lblLinkedDonor";
            lblLinkedDonor.Padding = new Padding(0, 0, 0, 5);
            lblLinkedDonor.Size = new Size(78, 20);
            lblLinkedDonor.TabIndex = 1;
            lblLinkedDonor.Text = "Linked Donor";
            // 
            // pnlCollectionDate
            // 
            pnlCollectionDate.Controls.Add(dtpCollectionDate);
            pnlCollectionDate.Controls.Add(lblCollectionDate);
            pnlCollectionDate.Dock = DockStyle.Fill;
            pnlCollectionDate.Location = new Point(6, 71);
            pnlCollectionDate.Margin = new Padding(6, 3, 3, 3);
            pnlCollectionDate.Name = "pnlCollectionDate";
            pnlCollectionDate.Size = new Size(353, 62);
            pnlCollectionDate.TabIndex = 19;
            // 
            // dtpCollectionDate
            // 
            dtpCollectionDate.CustomFormat = "dd-MM-yyyy";
            dtpCollectionDate.Dock = DockStyle.Top;
            dtpCollectionDate.Format = DateTimePickerFormat.Custom;
            dtpCollectionDate.Location = new Point(0, 20);
            dtpCollectionDate.Name = "dtpCollectionDate";
            dtpCollectionDate.Size = new Size(353, 23);
            dtpCollectionDate.TabIndex = 3;
            dtpCollectionDate.Value = new DateTime(2026, 5, 15, 0, 0, 0, 0);
            // 
            // lblCollectionDate
            // 
            lblCollectionDate.AutoSize = true;
            lblCollectionDate.Dock = DockStyle.Top;
            lblCollectionDate.Location = new Point(0, 0);
            lblCollectionDate.Name = "lblCollectionDate";
            lblCollectionDate.Padding = new Padding(0, 0, 0, 5);
            lblCollectionDate.Size = new Size(88, 20);
            lblCollectionDate.TabIndex = 1;
            lblCollectionDate.Text = "Collection Date";
            // 
            // pnlBloodGroup
            // 
            pnlBloodGroup.Controls.Add(cbBloodGroup);
            pnlBloodGroup.Controls.Add(lblBloodGroup);
            pnlBloodGroup.Dock = DockStyle.Fill;
            pnlBloodGroup.Location = new Point(365, 3);
            pnlBloodGroup.Margin = new Padding(3, 3, 6, 3);
            pnlBloodGroup.Name = "pnlBloodGroup";
            pnlBloodGroup.Size = new Size(353, 62);
            pnlBloodGroup.TabIndex = 18;
            // 
            // cbBloodGroup
            // 
            cbBloodGroup.Dock = DockStyle.Top;
            cbBloodGroup.FormattingEnabled = true;
            cbBloodGroup.Location = new Point(0, 20);
            cbBloodGroup.Name = "cbBloodGroup";
            cbBloodGroup.Size = new Size(353, 23);
            cbBloodGroup.TabIndex = 2;
            // 
            // lblBloodGroup
            // 
            lblBloodGroup.AutoSize = true;
            lblBloodGroup.Dock = DockStyle.Top;
            lblBloodGroup.Location = new Point(0, 0);
            lblBloodGroup.Name = "lblBloodGroup";
            lblBloodGroup.Padding = new Padding(0, 0, 0, 5);
            lblBloodGroup.Size = new Size(71, 20);
            lblBloodGroup.TabIndex = 1;
            lblBloodGroup.Text = "BloodGroup";
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(368, 348);
            btnSave.Margin = new Padding(6, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(353, 47);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // pnlBloodUnitID
            // 
            pnlBloodUnitID.Controls.Add(tbID);
            pnlBloodUnitID.Controls.Add(lblID);
            pnlBloodUnitID.Dock = DockStyle.Fill;
            pnlBloodUnitID.Location = new Point(3, 3);
            pnlBloodUnitID.Margin = new Padding(3, 3, 6, 3);
            pnlBloodUnitID.Name = "pnlBloodUnitID";
            pnlBloodUnitID.Size = new Size(353, 62);
            pnlBloodUnitID.TabIndex = 2;
            // 
            // tbID
            // 
            tbID.Dock = DockStyle.Top;
            tbID.Enabled = false;
            tbID.Location = new Point(0, 20);
            tbID.Name = "tbID";
            tbID.PlaceholderText = "Auto Generated";
            tbID.ReadOnly = true;
            tbID.Size = new Size(353, 23);
            tbID.TabIndex = 1;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Dock = DockStyle.Top;
            lblID.Location = new Point(0, 0);
            lblID.Name = "lblID";
            lblID.Padding = new Padding(0, 0, 0, 5);
            lblID.Size = new Size(74, 20);
            lblID.TabIndex = 1;
            lblID.Text = "BloodUnit ID";
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(3, 348);
            btnCancel.Margin = new Padding(3, 3, 6, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(353, 47);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btnCancel_MouseEnter;
            btnCancel.MouseLeave += btnCancel_MouseLeave;
            // 
            // pnlFormHeading
            // 
            pnlFormHeading.Controls.Add(lblBloodUnitFormHeading);
            pnlFormHeading.Dock = DockStyle.Top;
            pnlFormHeading.Location = new Point(10, 10);
            pnlFormHeading.Name = "pnlFormHeading";
            pnlFormHeading.Size = new Size(734, 35);
            pnlFormHeading.TabIndex = 0;
            // 
            // lblBloodUnitFormHeading
            // 
            lblBloodUnitFormHeading.AutoSize = true;
            lblBloodUnitFormHeading.Location = new Point(5, 0);
            lblBloodUnitFormHeading.Margin = new Padding(3, 0, 3, 5);
            lblBloodUnitFormHeading.Name = "lblBloodUnitFormHeading";
            lblBloodUnitFormHeading.Size = new Size(85, 15);
            lblBloodUnitFormHeading.TabIndex = 0;
            lblBloodUnitFormHeading.Text = "Add BloodUnit";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // BloodUnitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 463);
            Controls.Add(pnlBloodUnitForm);
            Name = "BloodUnitForm";
            Text = "BloodUnitForm";
            pnlBloodUnitForm.ResumeLayout(false);
            pnlFormStyling.ResumeLayout(false);
            tblDonorForm.ResumeLayout(false);
            pnlNotes.ResumeLayout(false);
            pnlNotes.PerformLayout();
            pnlCreatedAt.ResumeLayout(false);
            pnlCreatedAt.PerformLayout();
            pnlUserId.ResumeLayout(false);
            pnlUserId.PerformLayout();
            pnlExpiryDate.ResumeLayout(false);
            pnlExpiryDate.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            pnlLinkedDonor.ResumeLayout(false);
            pnlLinkedDonor.PerformLayout();
            pnlCollectionDate.ResumeLayout(false);
            pnlCollectionDate.PerformLayout();
            pnlBloodGroup.ResumeLayout(false);
            pnlBloodGroup.PerformLayout();
            pnlBloodUnitID.ResumeLayout(false);
            pnlBloodUnitID.PerformLayout();
            pnlFormHeading.ResumeLayout(false);
            pnlFormHeading.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBloodUnitForm;
        private Panel pnlFormStyling;
        private TableLayoutPanel tblDonorForm;
        private Button btnSave;
        private TextBox tbCity;
        private Label lblCity;
        private NumericUpDown nudWeight;
        private Panel pnlBloodUnitID;
        private TextBox tbID;
        private Label lblID;
        private Button btnCancel;
        private Panel pnlFormHeading;
        private Label lblBloodUnitFormHeading;
        private Panel pnlNotes;
        private TextBox tbNotes;
        private Label lblNotes;
        private Panel pnlCreatedAt;
        private DateTimePicker dtpNextEligibleDate;
        private Label lblCreatedAt;
        private Panel pnlUserId;
        private TextBox tbUserId;
        private Label lblUserId;
        private Panel pnlExpiryDate;
        private DateTimePicker dtpExpiryDate;
        private Label lblExpiryDate;
        private Panel pnlStatus;
        private ComboBox cbStatus;
        private Label lblStatus;
        private Panel pnlLinkedDonor;
        private ComboBox cbLinkedDonor;
        private Label lblLinkedDonor;
        private Panel pnlCollectionDate;
        private DateTimePicker dtpCollectionDate;
        private Label lblCollectionDate;
        private Panel pnlBloodGroup;
        private ComboBox cbBloodGroup;
        private Label lblBloodGroup;
        private ContextMenuStrip contextMenuStrip1;
    }
}