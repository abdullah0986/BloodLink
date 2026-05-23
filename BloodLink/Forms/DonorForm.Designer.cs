namespace BloodLink.Forms
{
    partial class DonorForm
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
            pnDonorForm = new Panel();
            pnlFormStyling = new Panel();
            tblDonorForm = new TableLayoutPanel();
            btnSave = new Button();
            panel11 = new Panel();
            dtpNextEligibleDate = new DateTimePicker();
            lblNextEligibleDate = new Label();
            panel10 = new Panel();
            dtpLastDonation = new DateTimePicker();
            lblLastDonation = new Label();
            panel9 = new Panel();
            cbEligibility = new ComboBox();
            lblEligibility = new Label();
            panel8 = new Panel();
            tbArea = new TextBox();
            lblArea = new Label();
            panel7 = new Panel();
            tbCity = new TextBox();
            lblCity = new Label();
            panel6 = new Panel();
            nudWeight = new NumericUpDown();
            lblWeight = new Label();
            panel5 = new Panel();
            cbGender = new ComboBox();
            lblGender = new Label();
            panel4 = new Panel();
            cbBloodGroup = new ComboBox();
            lblBloodGroup = new Label();
            panel3 = new Panel();
            nudAge = new NumericUpDown();
            lblAge = new Label();
            panel2 = new Panel();
            tbPhone = new TextBox();
            lblPhone = new Label();
            panel1 = new Panel();
            tbFullName = new TextBox();
            lblFullName = new Label();
            pnlDonorID = new Panel();
            tbID = new TextBox();
            lblID = new Label();
            btnCancel = new Button();
            pnlFormHeading = new Panel();
            lblDonorFormHeading = new Label();
            pnDonorForm.SuspendLayout();
            pnlFormStyling.SuspendLayout();
            tblDonorForm.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pnlDonorID.SuspendLayout();
            pnlFormHeading.SuspendLayout();
            SuspendLayout();
            // 
            // pnDonorForm
            // 
            pnDonorForm.Controls.Add(pnlFormStyling);
            pnDonorForm.Controls.Add(pnlFormHeading);
            pnDonorForm.Dock = DockStyle.Fill;
            pnDonorForm.Location = new Point(0, 0);
            pnDonorForm.Name = "pnDonorForm";
            pnDonorForm.Padding = new Padding(10);
            pnDonorForm.Size = new Size(713, 542);
            pnDonorForm.TabIndex = 0;
            // 
            // pnlFormStyling
            // 
            pnlFormStyling.Controls.Add(tblDonorForm);
            pnlFormStyling.Dock = DockStyle.Fill;
            pnlFormStyling.Location = new Point(10, 45);
            pnlFormStyling.Name = "pnlFormStyling";
            pnlFormStyling.Padding = new Padding(5);
            pnlFormStyling.Size = new Size(693, 487);
            pnlFormStyling.TabIndex = 1;
            // 
            // tblDonorForm
            // 
            tblDonorForm.ColumnCount = 2;
            tblDonorForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDonorForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDonorForm.Controls.Add(btnSave, 1, 6);
            tblDonorForm.Controls.Add(panel11, 1, 5);
            tblDonorForm.Controls.Add(panel10, 0, 5);
            tblDonorForm.Controls.Add(panel9, 1, 4);
            tblDonorForm.Controls.Add(panel8, 0, 4);
            tblDonorForm.Controls.Add(panel7, 1, 3);
            tblDonorForm.Controls.Add(panel6, 0, 3);
            tblDonorForm.Controls.Add(panel5, 1, 2);
            tblDonorForm.Controls.Add(panel4, 0, 2);
            tblDonorForm.Controls.Add(panel3, 1, 1);
            tblDonorForm.Controls.Add(panel2, 0, 1);
            tblDonorForm.Controls.Add(panel1, 1, 0);
            tblDonorForm.Controls.Add(pnlDonorID, 0, 0);
            tblDonorForm.Controls.Add(btnCancel, 0, 6);
            tblDonorForm.Dock = DockStyle.Fill;
            tblDonorForm.Location = new Point(5, 5);
            tblDonorForm.Margin = new Padding(3, 3, 6, 3);
            tblDonorForm.Name = "tblDonorForm";
            tblDonorForm.RowCount = 7;
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7666807F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7666883F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7666883F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7666883F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7666883F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 15.8298893F));
            tblDonorForm.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3366814F));
            tblDonorForm.Size = new Size(683, 477);
            tblDonorForm.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(347, 428);
            btnSave.Margin = new Padding(6, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(333, 46);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // panel11
            // 
            panel11.Controls.Add(dtpNextEligibleDate);
            panel11.Controls.Add(lblNextEligibleDate);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(347, 353);
            panel11.Margin = new Padding(6, 3, 3, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(333, 69);
            panel11.TabIndex = 13;
            // 
            // dtpNextEligibleDate
            // 
            dtpNextEligibleDate.CustomFormat = "dd-MM-yyyy";
            dtpNextEligibleDate.Dock = DockStyle.Top;
            dtpNextEligibleDate.Enabled = false;
            dtpNextEligibleDate.Format = DateTimePickerFormat.Custom;
            dtpNextEligibleDate.Location = new Point(0, 20);
            dtpNextEligibleDate.Name = "dtpNextEligibleDate";
            dtpNextEligibleDate.Size = new Size(333, 23);
            dtpNextEligibleDate.TabIndex = 2;
            // 
            // lblNextEligibleDate
            // 
            lblNextEligibleDate.AutoSize = true;
            lblNextEligibleDate.Dock = DockStyle.Top;
            lblNextEligibleDate.Location = new Point(0, 0);
            lblNextEligibleDate.Name = "lblNextEligibleDate";
            lblNextEligibleDate.Padding = new Padding(0, 0, 0, 5);
            lblNextEligibleDate.Size = new Size(134, 20);
            lblNextEligibleDate.TabIndex = 1;
            lblNextEligibleDate.Text = "Next Eligible Date (auto)";
            // 
            // panel10
            // 
            panel10.Controls.Add(dtpLastDonation);
            panel10.Controls.Add(lblLastDonation);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 353);
            panel10.Margin = new Padding(3, 3, 6, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(332, 69);
            panel10.TabIndex = 12;
            // 
            // dtpLastDonation
            // 
            dtpLastDonation.CustomFormat = "dd-MM-yyyy";
            dtpLastDonation.Dock = DockStyle.Top;
            dtpLastDonation.Format = DateTimePickerFormat.Custom;
            dtpLastDonation.Location = new Point(0, 20);
            dtpLastDonation.Name = "dtpLastDonation";
            dtpLastDonation.Size = new Size(332, 23);
            dtpLastDonation.TabIndex = 2;
            dtpLastDonation.Value = new DateTime(2026, 5, 15, 0, 0, 0, 0);
            // 
            // lblLastDonation
            // 
            lblLastDonation.AutoSize = true;
            lblLastDonation.Dock = DockStyle.Top;
            lblLastDonation.Location = new Point(0, 0);
            lblLastDonation.Name = "lblLastDonation";
            lblLastDonation.Padding = new Padding(0, 0, 0, 5);
            lblLastDonation.Size = new Size(164, 20);
            lblLastDonation.TabIndex = 1;
            lblLastDonation.Text = "Last Donation Date (Optinoal)";
            // 
            // panel9
            // 
            panel9.Controls.Add(cbEligibility);
            panel9.Controls.Add(lblEligibility);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(347, 283);
            panel9.Margin = new Padding(6, 3, 3, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(333, 64);
            panel9.TabIndex = 11;
            // 
            // cbEligibility
            // 
            cbEligibility.Dock = DockStyle.Top;
            cbEligibility.FormattingEnabled = true;
            cbEligibility.Location = new Point(0, 20);
            cbEligibility.Name = "cbEligibility";
            cbEligibility.Size = new Size(333, 23);
            cbEligibility.TabIndex = 2;
            // 
            // lblEligibility
            // 
            lblEligibility.AutoSize = true;
            lblEligibility.Dock = DockStyle.Top;
            lblEligibility.Location = new Point(0, 0);
            lblEligibility.Name = "lblEligibility";
            lblEligibility.Padding = new Padding(0, 0, 0, 5);
            lblEligibility.Size = new Size(55, 20);
            lblEligibility.TabIndex = 1;
            lblEligibility.Text = "Eligibility";
            // 
            // panel8
            // 
            panel8.Controls.Add(tbArea);
            panel8.Controls.Add(lblArea);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 283);
            panel8.Margin = new Padding(3, 3, 6, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(332, 64);
            panel8.TabIndex = 10;
            // 
            // tbArea
            // 
            tbArea.Dock = DockStyle.Top;
            tbArea.Location = new Point(0, 20);
            tbArea.Name = "tbArea";
            tbArea.PlaceholderText = "Area / Locality";
            tbArea.Size = new Size(332, 23);
            tbArea.TabIndex = 1;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Dock = DockStyle.Top;
            lblArea.Location = new Point(0, 0);
            lblArea.Name = "lblArea";
            lblArea.Padding = new Padding(0, 0, 0, 5);
            lblArea.Size = new Size(31, 20);
            lblArea.TabIndex = 1;
            lblArea.Text = "Area";
            // 
            // panel7
            // 
            panel7.Controls.Add(tbCity);
            panel7.Controls.Add(lblCity);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(347, 213);
            panel7.Margin = new Padding(6, 3, 3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(333, 64);
            panel7.TabIndex = 9;
            // 
            // tbCity
            // 
            tbCity.Dock = DockStyle.Top;
            tbCity.Location = new Point(0, 20);
            tbCity.Name = "tbCity";
            tbCity.PlaceholderText = "Dunyapur";
            tbCity.Size = new Size(333, 23);
            tbCity.TabIndex = 1;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Dock = DockStyle.Top;
            lblCity.Location = new Point(0, 0);
            lblCity.Name = "lblCity";
            lblCity.Padding = new Padding(0, 0, 0, 5);
            lblCity.Size = new Size(28, 20);
            lblCity.TabIndex = 1;
            lblCity.Text = "City";
            // 
            // panel6
            // 
            panel6.Controls.Add(nudWeight);
            panel6.Controls.Add(lblWeight);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 213);
            panel6.Margin = new Padding(3, 3, 6, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(332, 64);
            panel6.TabIndex = 8;
            // 
            // nudWeight
            // 
            nudWeight.DecimalPlaces = 2;
            nudWeight.Dock = DockStyle.Fill;
            nudWeight.Location = new Point(0, 20);
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new Size(332, 23);
            nudWeight.TabIndex = 3;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Dock = DockStyle.Top;
            lblWeight.Location = new Point(0, 0);
            lblWeight.Name = "lblWeight";
            lblWeight.Padding = new Padding(0, 0, 0, 5);
            lblWeight.Size = new Size(70, 20);
            lblWeight.TabIndex = 1;
            lblWeight.Text = "Weight (Kg)";
            // 
            // panel5
            // 
            panel5.Controls.Add(cbGender);
            panel5.Controls.Add(lblGender);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(347, 143);
            panel5.Margin = new Padding(6, 3, 3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(333, 64);
            panel5.TabIndex = 7;
            // 
            // cbGender
            // 
            cbGender.Dock = DockStyle.Top;
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(0, 20);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(333, 23);
            cbGender.TabIndex = 3;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Dock = DockStyle.Top;
            lblGender.Location = new Point(0, 0);
            lblGender.Name = "lblGender";
            lblGender.Padding = new Padding(0, 0, 0, 5);
            lblGender.Size = new Size(45, 20);
            lblGender.TabIndex = 1;
            lblGender.Text = "Gender";
            // 
            // panel4
            // 
            panel4.Controls.Add(cbBloodGroup);
            panel4.Controls.Add(lblBloodGroup);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 143);
            panel4.Margin = new Padding(3, 3, 6, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(332, 64);
            panel4.TabIndex = 6;
            // 
            // cbBloodGroup
            // 
            cbBloodGroup.Dock = DockStyle.Top;
            cbBloodGroup.FormattingEnabled = true;
            cbBloodGroup.Location = new Point(0, 20);
            cbBloodGroup.Name = "cbBloodGroup";
            cbBloodGroup.Size = new Size(332, 23);
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
            // panel3
            // 
            panel3.Controls.Add(nudAge);
            panel3.Controls.Add(lblAge);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(347, 73);
            panel3.Margin = new Padding(6, 3, 3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 64);
            panel3.TabIndex = 5;
            // 
            // nudAge
            // 
            nudAge.Dock = DockStyle.Fill;
            nudAge.Location = new Point(0, 20);
            nudAge.Name = "nudAge";
            nudAge.Size = new Size(333, 23);
            nudAge.TabIndex = 2;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Dock = DockStyle.Top;
            lblAge.Location = new Point(0, 0);
            lblAge.Name = "lblAge";
            lblAge.Padding = new Padding(0, 0, 0, 5);
            lblAge.Size = new Size(28, 20);
            lblAge.TabIndex = 1;
            lblAge.Text = "Age";
            // 
            // panel2
            // 
            panel2.Controls.Add(tbPhone);
            panel2.Controls.Add(lblPhone);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 73);
            panel2.Margin = new Padding(3, 3, 6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 64);
            panel2.TabIndex = 4;
            // 
            // tbPhone
            // 
            tbPhone.Dock = DockStyle.Top;
            tbPhone.Location = new Point(0, 20);
            tbPhone.Name = "tbPhone";
            tbPhone.PlaceholderText = "03XX-XXXXXXX";
            tbPhone.Size = new Size(332, 23);
            tbPhone.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Dock = DockStyle.Top;
            lblPhone.Location = new Point(0, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Padding = new Padding(0, 0, 0, 5);
            lblPhone.Size = new Size(41, 20);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone";
            lblPhone.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbFullName);
            panel1.Controls.Add(lblFullName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(347, 3);
            panel1.Margin = new Padding(6, 3, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(333, 64);
            panel1.TabIndex = 3;
            // 
            // tbFullName
            // 
            tbFullName.Dock = DockStyle.Top;
            tbFullName.Location = new Point(0, 20);
            tbFullName.Name = "tbFullName";
            tbFullName.PlaceholderText = "Enter Full Name";
            tbFullName.Size = new Size(333, 23);
            tbFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Dock = DockStyle.Top;
            lblFullName.Location = new Point(0, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Padding = new Padding(0, 0, 0, 5);
            lblFullName.Size = new Size(61, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name";
            // 
            // pnlDonorID
            // 
            pnlDonorID.Controls.Add(tbID);
            pnlDonorID.Controls.Add(lblID);
            pnlDonorID.Dock = DockStyle.Fill;
            pnlDonorID.Location = new Point(3, 3);
            pnlDonorID.Margin = new Padding(3, 3, 6, 3);
            pnlDonorID.Name = "pnlDonorID";
            pnlDonorID.Size = new Size(332, 64);
            pnlDonorID.TabIndex = 2;
            // 
            // tbID
            // 
            tbID.Dock = DockStyle.Top;
            tbID.Enabled = false;
            tbID.Location = new Point(0, 20);
            tbID.Name = "tbID";
            tbID.PlaceholderText = "Auto Generated";
            tbID.Size = new Size(332, 23);
            tbID.TabIndex = 1;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Dock = DockStyle.Top;
            lblID.Location = new Point(0, 0);
            lblID.Name = "lblID";
            lblID.Padding = new Padding(0, 0, 0, 5);
            lblID.Size = new Size(54, 20);
            lblID.TabIndex = 1;
            lblID.Text = "Donor ID";
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(3, 428);
            btnCancel.Margin = new Padding(3, 3, 6, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(332, 46);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btnCancel_MouseEnter;
            btnCancel.MouseLeave += btnCancel_MouseLeave;
            // 
            // pnlFormHeading
            // 
            pnlFormHeading.Controls.Add(lblDonorFormHeading);
            pnlFormHeading.Dock = DockStyle.Top;
            pnlFormHeading.Location = new Point(10, 10);
            pnlFormHeading.Name = "pnlFormHeading";
            pnlFormHeading.Size = new Size(693, 35);
            pnlFormHeading.TabIndex = 0;
            // 
            // lblDonorFormHeading
            // 
            lblDonorFormHeading.AutoSize = true;
            lblDonorFormHeading.Location = new Point(5, 0);
            lblDonorFormHeading.Margin = new Padding(3, 0, 3, 5);
            lblDonorFormHeading.Name = "lblDonorFormHeading";
            lblDonorFormHeading.Size = new Size(65, 15);
            lblDonorFormHeading.TabIndex = 0;
            lblDonorFormHeading.Text = "Add Donor";
            lblDonorFormHeading.Click += lblDonorFormHeading_Click;
            // 
            // DonorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 542);
            Controls.Add(pnDonorForm);
            Name = "DonorForm";
            Text = "DonorForm";
            pnDonorForm.ResumeLayout(false);
            pnlFormStyling.ResumeLayout(false);
            tblDonorForm.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlDonorID.ResumeLayout(false);
            pnlDonorID.PerformLayout();
            pnlFormHeading.ResumeLayout(false);
            pnlFormHeading.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnDonorForm;
        private Panel pnlFormHeading;
        private Label lblDonorFormHeading;
        private Panel pnlFormStyling;
        private TableLayoutPanel tblDonorForm;
        private Button btnSave;
        private Panel panel11;
        private DateTimePicker dtpNextEligibleDate;
        private Label lblNextEligibleDate;
        private Panel panel10;
        private DateTimePicker dtpLastDonation;
        private Label lblLastDonation;
        private Panel panel9;
        private ComboBox cbEligibility;
        private Label lblEligibility;
        private Panel panel8;
        private TextBox tbArea;
        private Label lblArea;
        private Panel panel7;
        private TextBox tbCity;
        private Label lblCity;
        private Panel panel6;
        private Label lblWeight;
        private Panel panel5;
        private ComboBox cbGender;
        private Label lblGender;
        private Panel panel4;
        private ComboBox cbBloodGroup;
        private Label lblBloodGroup;
        private Panel panel3;
        private Label lblAge;
        private Panel panel2;
        private Label lblPhone;
        private Panel panel1;
        private TextBox tbFullName;
        private Label lblFullName;
        private Panel pnlDonorID;
        private TextBox tbID;
        private Label lblID;
        private Button btnCancel;
        private NumericUpDown nudAge;
        private NumericUpDown nudWeight;
        private TextBox tbPhone;
    }
}