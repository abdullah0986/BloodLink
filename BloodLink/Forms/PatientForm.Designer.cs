namespace BloodLink.Forms
{
    partial class PatientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlPatientForm = new Panel();
            pnlFormStyling = new Panel();
            tblPatientForm = new TableLayoutPanel();
            pnlNotes = new Panel();
            tbNotes = new TextBox();
            lblNotes = new Label();
            pnlDoctorName = new Panel();
            tbDoctorName = new TextBox();
            lblDoctorName = new Label();
            pnlWard = new Panel();
            tbWard = new TextBox();
            lblWard = new Label();
            pnlStatus = new Panel();
            cbStatus = new ComboBox();
            lblStatus = new Label();
            pnlUnitsRequired = new Panel();
            nudUnitsRequired = new NumericUpDown();
            lblUnitsRequired = new Label();
            pnlBloodGroup = new Panel();
            cbBloodGroup = new ComboBox();
            lblBloodGroup = new Label();
            pnlPatientAge = new Panel();
            nudPatientAge = new NumericUpDown();
            lblPatientAge = new Label();
            pnlPatientName = new Panel();
            tbPatientName = new TextBox();
            lblPatientName = new Label();
            pnlPatientID = new Panel();
            tbID = new TextBox();
            lblID = new Label();
            pnlUserId = new Panel();
            tbUserId = new TextBox();
            lblUserId = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            pnlCreatedAt = new Panel();
            dtpCreatedAt = new DateTimePicker();
            lblCreatedAt = new Label();
            pnlFormHeading = new Panel();
            lblPatientFormHeading = new Label();
            pnlPatientForm.SuspendLayout();
            pnlFormStyling.SuspendLayout();
            tblPatientForm.SuspendLayout();
            pnlNotes.SuspendLayout();
            pnlDoctorName.SuspendLayout();
            pnlWard.SuspendLayout();
            pnlStatus.SuspendLayout();
            pnlUnitsRequired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitsRequired).BeginInit();
            pnlBloodGroup.SuspendLayout();
            pnlPatientAge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatientAge).BeginInit();
            pnlPatientName.SuspendLayout();
            pnlPatientID.SuspendLayout();
            pnlUserId.SuspendLayout();
            pnlCreatedAt.SuspendLayout();
            pnlFormHeading.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPatientForm
            // 
            pnlPatientForm.Controls.Add(pnlFormStyling);
            pnlPatientForm.Controls.Add(pnlFormHeading);
            pnlPatientForm.Dock = DockStyle.Fill;
            pnlPatientForm.Location = new Point(0, 0);
            pnlPatientForm.Name = "pnlPatientForm";
            pnlPatientForm.Padding = new Padding(10);
            pnlPatientForm.Size = new Size(754, 530);
            pnlPatientForm.TabIndex = 1;
            // 
            // pnlFormStyling
            // 
            pnlFormStyling.Controls.Add(tblPatientForm);
            pnlFormStyling.Dock = DockStyle.Fill;
            pnlFormStyling.Location = new Point(10, 45);
            pnlFormStyling.Name = "pnlFormStyling";
            pnlFormStyling.Padding = new Padding(5);
            pnlFormStyling.Size = new Size(734, 475);
            pnlFormStyling.TabIndex = 1;
            // 
            // tblPatientForm
            // 
            tblPatientForm.ColumnCount = 2;
            tblPatientForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPatientForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPatientForm.Controls.Add(pnlNotes, 0, 5);
            tblPatientForm.Controls.Add(pnlDoctorName, 1, 4);
            tblPatientForm.Controls.Add(pnlWard, 0, 4);
            tblPatientForm.Controls.Add(pnlStatus, 1, 3);
            tblPatientForm.Controls.Add(pnlUnitsRequired, 0, 3);
            tblPatientForm.Controls.Add(pnlBloodGroup, 1, 2);
            tblPatientForm.Controls.Add(pnlPatientAge, 0, 2);
            tblPatientForm.Controls.Add(pnlPatientName, 1, 1);
            tblPatientForm.Controls.Add(pnlPatientID, 0, 1);
            tblPatientForm.Controls.Add(pnlUserId, 0, 0);
            tblPatientForm.Controls.Add(btnSave, 1, 6);
            tblPatientForm.Controls.Add(btnCancel, 0, 6);
            tblPatientForm.Controls.Add(pnlCreatedAt, 1, 5);
            tblPatientForm.Dock = DockStyle.Fill;
            tblPatientForm.Location = new Point(5, 5);
            tblPatientForm.Name = "tblPatientForm";
            tblPatientForm.RowCount = 7;
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            tblPatientForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblPatientForm.Size = new Size(724, 465);
            tblPatientForm.TabIndex = 2;
            // 
            // pnlNotes
            // 
            pnlNotes.Controls.Add(tbNotes);
            pnlNotes.Controls.Add(lblNotes);
            pnlNotes.Dock = DockStyle.Fill;
            pnlNotes.Location = new Point(3, 328);
            pnlNotes.Name = "pnlNotes";
            pnlNotes.Size = new Size(356, 77);
            pnlNotes.TabIndex = 30;
            // 
            // tbNotes
            // 
            tbNotes.Dock = DockStyle.Top;
            tbNotes.Location = new Point(0, 20);
            tbNotes.Name = "tbNotes";
            tbNotes.PlaceholderText = "Any additional notes...";
            tbNotes.Size = new Size(356, 23);
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
            // pnlDoctorName
            // 
            pnlDoctorName.Controls.Add(tbDoctorName);
            pnlDoctorName.Controls.Add(lblDoctorName);
            pnlDoctorName.Dock = DockStyle.Fill;
            pnlDoctorName.Location = new Point(368, 263);
            pnlDoctorName.Margin = new Padding(6, 3, 3, 3);
            pnlDoctorName.Name = "pnlDoctorName";
            pnlDoctorName.Size = new Size(353, 59);
            pnlDoctorName.TabIndex = 29;
            // 
            // tbDoctorName
            // 
            tbDoctorName.Dock = DockStyle.Top;
            tbDoctorName.Location = new Point(0, 20);
            tbDoctorName.Name = "tbDoctorName";
            tbDoctorName.PlaceholderText = "Dr. Usman";
            tbDoctorName.Size = new Size(353, 23);
            tbDoctorName.TabIndex = 2;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.Dock = DockStyle.Top;
            lblDoctorName.Location = new Point(0, 0);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Padding = new Padding(0, 0, 0, 5);
            lblDoctorName.Size = new Size(135, 20);
            lblDoctorName.TabIndex = 1;
            lblDoctorName.Text = "Doctor Name (Optional)";
            // 
            // pnlWard
            // 
            pnlWard.Controls.Add(tbWard);
            pnlWard.Controls.Add(lblWard);
            pnlWard.Dock = DockStyle.Fill;
            pnlWard.Location = new Point(3, 263);
            pnlWard.Margin = new Padding(3, 3, 6, 3);
            pnlWard.Name = "pnlWard";
            pnlWard.Size = new Size(353, 59);
            pnlWard.TabIndex = 28;
            // 
            // tbWard
            // 
            tbWard.Dock = DockStyle.Top;
            tbWard.Location = new Point(0, 20);
            tbWard.Name = "tbWard";
            tbWard.PlaceholderText = "Ward A";
            tbWard.Size = new Size(353, 23);
            tbWard.TabIndex = 2;
            // 
            // lblWard
            // 
            lblWard.AutoSize = true;
            lblWard.Dock = DockStyle.Top;
            lblWard.Location = new Point(0, 0);
            lblWard.Name = "lblWard";
            lblWard.Padding = new Padding(0, 0, 0, 5);
            lblWard.Size = new Size(92, 20);
            lblWard.TabIndex = 1;
            lblWard.Text = "Ward (Optional)";
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(cbStatus);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Dock = DockStyle.Fill;
            pnlStatus.Location = new Point(368, 198);
            pnlStatus.Margin = new Padding(6, 3, 3, 3);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(353, 59);
            pnlStatus.TabIndex = 27;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Top;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(0, 20);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(353, 23);
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
            // pnlUnitsRequired
            // 
            pnlUnitsRequired.Controls.Add(nudUnitsRequired);
            pnlUnitsRequired.Controls.Add(lblUnitsRequired);
            pnlUnitsRequired.Dock = DockStyle.Fill;
            pnlUnitsRequired.Location = new Point(3, 198);
            pnlUnitsRequired.Margin = new Padding(3, 3, 6, 3);
            pnlUnitsRequired.Name = "pnlUnitsRequired";
            pnlUnitsRequired.Size = new Size(353, 59);
            pnlUnitsRequired.TabIndex = 26;
            // 
            // nudUnitsRequired
            // 
            nudUnitsRequired.Dock = DockStyle.Top;
            nudUnitsRequired.Location = new Point(0, 20);
            nudUnitsRequired.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUnitsRequired.Name = "nudUnitsRequired";
            nudUnitsRequired.Size = new Size(353, 23);
            nudUnitsRequired.TabIndex = 2;
            nudUnitsRequired.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblUnitsRequired
            // 
            lblUnitsRequired.AutoSize = true;
            lblUnitsRequired.Dock = DockStyle.Top;
            lblUnitsRequired.Location = new Point(0, 0);
            lblUnitsRequired.Name = "lblUnitsRequired";
            lblUnitsRequired.Padding = new Padding(0, 0, 0, 5);
            lblUnitsRequired.Size = new Size(84, 20);
            lblUnitsRequired.TabIndex = 1;
            lblUnitsRequired.Text = "Units Required";
            // 
            // pnlBloodGroup
            // 
            pnlBloodGroup.Controls.Add(cbBloodGroup);
            pnlBloodGroup.Controls.Add(lblBloodGroup);
            pnlBloodGroup.Dock = DockStyle.Fill;
            pnlBloodGroup.Location = new Point(368, 133);
            pnlBloodGroup.Margin = new Padding(6, 3, 3, 3);
            pnlBloodGroup.Name = "pnlBloodGroup";
            pnlBloodGroup.Size = new Size(353, 59);
            pnlBloodGroup.TabIndex = 25;
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
            lblBloodGroup.Size = new Size(74, 20);
            lblBloodGroup.TabIndex = 1;
            lblBloodGroup.Text = "Blood Group";
            // 
            // pnlPatientAge
            // 
            pnlPatientAge.Controls.Add(nudPatientAge);
            pnlPatientAge.Controls.Add(lblPatientAge);
            pnlPatientAge.Dock = DockStyle.Fill;
            pnlPatientAge.Location = new Point(3, 133);
            pnlPatientAge.Margin = new Padding(3, 3, 6, 3);
            pnlPatientAge.Name = "pnlPatientAge";
            pnlPatientAge.Size = new Size(353, 59);
            pnlPatientAge.TabIndex = 24;
            // 
            // nudPatientAge
            // 
            nudPatientAge.Dock = DockStyle.Top;
            nudPatientAge.Location = new Point(0, 20);
            nudPatientAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudPatientAge.Name = "nudPatientAge";
            nudPatientAge.Size = new Size(353, 23);
            nudPatientAge.TabIndex = 2;
            // 
            // lblPatientAge
            // 
            lblPatientAge.AutoSize = true;
            lblPatientAge.Dock = DockStyle.Top;
            lblPatientAge.Location = new Point(0, 0);
            lblPatientAge.Name = "lblPatientAge";
            lblPatientAge.Padding = new Padding(0, 0, 0, 5);
            lblPatientAge.Size = new Size(125, 20);
            lblPatientAge.TabIndex = 1;
            lblPatientAge.Text = "Patient Age (Optional)";
            // 
            // pnlPatientName
            // 
            pnlPatientName.Controls.Add(tbPatientName);
            pnlPatientName.Controls.Add(lblPatientName);
            pnlPatientName.Dock = DockStyle.Fill;
            pnlPatientName.Location = new Point(368, 68);
            pnlPatientName.Margin = new Padding(6, 3, 3, 3);
            pnlPatientName.Name = "pnlPatientName";
            pnlPatientName.Size = new Size(353, 59);
            pnlPatientName.TabIndex = 23;
            // 
            // tbPatientName
            // 
            tbPatientName.Dock = DockStyle.Top;
            tbPatientName.Location = new Point(0, 20);
            tbPatientName.Name = "tbPatientName";
            tbPatientName.PlaceholderText = "Asad Khan";
            tbPatientName.Size = new Size(353, 23);
            tbPatientName.TabIndex = 2;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Dock = DockStyle.Top;
            lblPatientName.Location = new Point(0, 0);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Padding = new Padding(0, 0, 0, 5);
            lblPatientName.Size = new Size(79, 20);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Patient Name";
            // 
            // pnlPatientID
            // 
            pnlPatientID.Controls.Add(tbID);
            pnlPatientID.Controls.Add(lblID);
            pnlPatientID.Dock = DockStyle.Fill;
            pnlPatientID.Location = new Point(3, 68);
            pnlPatientID.Margin = new Padding(3, 3, 6, 3);
            pnlPatientID.Name = "pnlPatientID";
            pnlPatientID.Size = new Size(353, 59);
            pnlPatientID.TabIndex = 22;
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
            lblID.Size = new Size(63, 20);
            lblID.TabIndex = 1;
            lblID.Text = "Request ID";
            // 
            // pnlUserId
            // 
            pnlUserId.Controls.Add(tbUserId);
            pnlUserId.Controls.Add(lblUserId);
            pnlUserId.Dock = DockStyle.Fill;
            pnlUserId.Location = new Point(3, 3);
            pnlUserId.Margin = new Padding(3, 3, 6, 3);
            pnlUserId.Name = "pnlUserId";
            pnlUserId.Size = new Size(353, 59);
            pnlUserId.TabIndex = 21;
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
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(368, 411);
            btnSave.Margin = new Padding(6, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(353, 51);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(3, 411);
            btnCancel.Margin = new Padding(3, 3, 6, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(353, 51);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btnCancel_MouseEnter;
            btnCancel.MouseLeave += btnCancel_MouseLeave;
            // 
            // pnlCreatedAt
            // 
            pnlCreatedAt.Controls.Add(dtpCreatedAt);
            pnlCreatedAt.Controls.Add(lblCreatedAt);
            pnlCreatedAt.Dock = DockStyle.Fill;
            pnlCreatedAt.Location = new Point(365, 328);
            pnlCreatedAt.Name = "pnlCreatedAt";
            pnlCreatedAt.Size = new Size(356, 77);
            pnlCreatedAt.TabIndex = 31;
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.CustomFormat = "dd-MM-yyyy";
            dtpCreatedAt.Dock = DockStyle.Top;
            dtpCreatedAt.Enabled = false;
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;
            dtpCreatedAt.Location = new Point(0, 20);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(356, 23);
            dtpCreatedAt.TabIndex = 4;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Dock = DockStyle.Top;
            lblCreatedAt.Location = new Point(0, 0);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Padding = new Padding(0, 0, 0, 5);
            lblCreatedAt.Size = new Size(63, 20);
            lblCreatedAt.TabIndex = 3;
            lblCreatedAt.Text = "Created At";
            // 
            // pnlFormHeading
            // 
            pnlFormHeading.Controls.Add(lblPatientFormHeading);
            pnlFormHeading.Dock = DockStyle.Top;
            pnlFormHeading.Location = new Point(10, 10);
            pnlFormHeading.Name = "pnlFormHeading";
            pnlFormHeading.Size = new Size(734, 35);
            pnlFormHeading.TabIndex = 0;
            // 
            // lblPatientFormHeading
            // 
            lblPatientFormHeading.AutoSize = true;
            lblPatientFormHeading.Location = new Point(5, 0);
            lblPatientFormHeading.Margin = new Padding(3, 0, 3, 5);
            lblPatientFormHeading.Name = "lblPatientFormHeading";
            lblPatientFormHeading.Size = new Size(114, 15);
            lblPatientFormHeading.TabIndex = 0;
            lblPatientFormHeading.Text = "Add Patient Request";
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 530);
            Controls.Add(pnlPatientForm);
            Name = "PatientForm";
            Text = "PatientForm";
            pnlPatientForm.ResumeLayout(false);
            pnlFormStyling.ResumeLayout(false);
            tblPatientForm.ResumeLayout(false);
            pnlNotes.ResumeLayout(false);
            pnlNotes.PerformLayout();
            pnlDoctorName.ResumeLayout(false);
            pnlDoctorName.PerformLayout();
            pnlWard.ResumeLayout(false);
            pnlWard.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            pnlUnitsRequired.ResumeLayout(false);
            pnlUnitsRequired.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitsRequired).EndInit();
            pnlBloodGroup.ResumeLayout(false);
            pnlBloodGroup.PerformLayout();
            pnlPatientAge.ResumeLayout(false);
            pnlPatientAge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatientAge).EndInit();
            pnlPatientName.ResumeLayout(false);
            pnlPatientName.PerformLayout();
            pnlPatientID.ResumeLayout(false);
            pnlPatientID.PerformLayout();
            pnlUserId.ResumeLayout(false);
            pnlUserId.PerformLayout();
            pnlCreatedAt.ResumeLayout(false);
            pnlCreatedAt.PerformLayout();
            pnlFormHeading.ResumeLayout(false);
            pnlFormHeading.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPatientForm;
        private Panel pnlFormStyling;
        private TableLayoutPanel tblPatientForm;
        private Panel pnlNotes;
        private TextBox tbNotes;
        private Label lblNotes;
        private Panel pnlDoctorName;
        private TextBox tbDoctorName;
        private Label lblDoctorName;
        private Panel pnlWard;
        private TextBox tbWard;
        private Label lblWard;
        private Panel pnlStatus;
        private ComboBox cbStatus;
        private Label lblStatus;
        private Panel pnlUnitsRequired;
        private NumericUpDown nudUnitsRequired;
        private Label lblUnitsRequired;
        private Panel pnlBloodGroup;
        private ComboBox cbBloodGroup;
        private Label lblBloodGroup;
        private Panel pnlPatientAge;
        private NumericUpDown nudPatientAge;
        private Label lblPatientAge;
        private Panel pnlPatientName;
        private TextBox tbPatientName;
        private Label lblPatientName;
        private Panel pnlPatientID;
        private TextBox tbID;
        private Label lblID;
        private Panel pnlUserId;
        private TextBox tbUserId;
        private Label lblUserId;
        private Button btnSave;
        private Button btnCancel;
        private Panel pnlFormHeading;
        private Label lblPatientFormHeading;
        private Panel pnlCreatedAt;
        private Label lblCreatedAt;
        private DateTimePicker dtpCreatedAt;
    }
}