namespace BloodLink.Pages
{
    partial class DonorPage
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
            pnlDonorPage = new Panel();
            tlpDonorPage = new TableLayoutPanel();
            pnlDonorsList = new Panel();
            pnlDgvDonorsStyling = new Panel();
            dgvDonors = new DataGridView();
            DonorName = new DataGridViewTextBoxColumn();
            DonorGroups = new DataGridViewTextBoxColumn();
            DonorPhone = new DataGridViewTextBoxColumn();
            DonorCity = new DataGridViewTextBoxColumn();
            DonorLastDonation = new DataGridViewTextBoxColumn();
            DonorEligiblility = new DataGridViewTextBoxColumn();
            tlpDonorMenuStripe = new TableLayoutPanel();
            cbStatus = new ComboBox();
            cbBloodGroups = new ComboBox();
            pnlTextBoxDonorSearch = new Panel();
            tbSearchDonor = new TextBox();
            btnAddDonor = new Button();
            pnlDonorPage.SuspendLayout();
            tlpDonorPage.SuspendLayout();
            pnlDonorsList.SuspendLayout();
            pnlDgvDonorsStyling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonors).BeginInit();
            tlpDonorMenuStripe.SuspendLayout();
            pnlTextBoxDonorSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDonorPage
            // 
            pnlDonorPage.AutoScroll = true;
            pnlDonorPage.Controls.Add(tlpDonorPage);
            pnlDonorPage.Dock = DockStyle.Fill;
            pnlDonorPage.Location = new Point(0, 0);
            pnlDonorPage.Name = "pnlDonorPage";
            pnlDonorPage.Size = new Size(725, 462);
            pnlDonorPage.TabIndex = 0;
            // 
            // tlpDonorPage
            // 
            tlpDonorPage.ColumnCount = 1;
            tlpDonorPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDonorPage.Controls.Add(pnlDonorsList, 0, 1);
            tlpDonorPage.Controls.Add(tlpDonorMenuStripe, 0, 0);
            tlpDonorPage.Dock = DockStyle.Fill;
            tlpDonorPage.Location = new Point(0, 0);
            tlpDonorPage.Name = "tlpDonorPage";
            tlpDonorPage.RowCount = 2;
            tlpDonorPage.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpDonorPage.RowStyles.Add(new RowStyle());
            tlpDonorPage.Size = new Size(725, 462);
            tlpDonorPage.TabIndex = 1;
            // 
            // pnlDonorsList
            // 
            pnlDonorsList.AutoScroll = true;
            pnlDonorsList.Controls.Add(pnlDgvDonorsStyling);
            pnlDonorsList.Dock = DockStyle.Fill;
            pnlDonorsList.Location = new Point(3, 47);
            pnlDonorsList.Margin = new Padding(3, 7, 3, 3);
            pnlDonorsList.Name = "pnlDonorsList";
            pnlDonorsList.Size = new Size(719, 421);
            pnlDonorsList.TabIndex = 1;
            // 
            // pnlDgvDonorsStyling
            // 
            pnlDgvDonorsStyling.AutoSize = true;
            pnlDgvDonorsStyling.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlDgvDonorsStyling.Controls.Add(dgvDonors);
            pnlDgvDonorsStyling.Dock = DockStyle.Top;
            pnlDgvDonorsStyling.Location = new Point(0, 0);
            pnlDgvDonorsStyling.Name = "pnlDgvDonorsStyling";
            pnlDgvDonorsStyling.Padding = new Padding(15, 23, 15, 23);
            pnlDgvDonorsStyling.Size = new Size(719, 412);
            pnlDgvDonorsStyling.TabIndex = 0;
            // 
            // dgvDonors
            // 
            dgvDonors.AllowUserToAddRows = false;
            dgvDonors.AllowUserToDeleteRows = false;
            dgvDonors.AllowUserToResizeColumns = false;
            dgvDonors.AllowUserToResizeRows = false;
            dgvDonors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonors.BorderStyle = BorderStyle.None;
            dgvDonors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDonors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDonors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDonors.Columns.AddRange(new DataGridViewColumn[] { DonorName, DonorGroups, DonorPhone, DonorCity, DonorLastDonation, DonorEligiblility });
            dgvDonors.Dock = DockStyle.Top;
            dgvDonors.EnableHeadersVisualStyles = false;
            dgvDonors.Location = new Point(15, 23);
            dgvDonors.Margin = new Padding(0);
            dgvDonors.Name = "dgvDonors";
            dgvDonors.ReadOnly = true;
            dgvDonors.RowHeadersVisible = false;
            dgvDonors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonors.Size = new Size(689, 366);
            dgvDonors.TabIndex = 5;
            // 
            // DonorName
            // 
            DonorName.HeaderText = "Name";
            DonorName.Name = "DonorName";
            DonorName.ReadOnly = true;
            // 
            // DonorGroups
            // 
            DonorGroups.HeaderText = "Group";
            DonorGroups.Name = "DonorGroups";
            DonorGroups.ReadOnly = true;
            // 
            // DonorPhone
            // 
            DonorPhone.HeaderText = "Phone";
            DonorPhone.Name = "DonorPhone";
            DonorPhone.ReadOnly = true;
            // 
            // DonorCity
            // 
            DonorCity.HeaderText = "City";
            DonorCity.Name = "DonorCity";
            DonorCity.ReadOnly = true;
            // 
            // DonorLastDonation
            // 
            DonorLastDonation.HeaderText = "Last Donated";
            DonorLastDonation.Name = "DonorLastDonation";
            DonorLastDonation.ReadOnly = true;
            // 
            // DonorEligiblility
            // 
            DonorEligiblility.HeaderText = "Eligible";
            DonorEligiblility.Name = "DonorEligiblility";
            DonorEligiblility.ReadOnly = true;
            // 
            // tlpDonorMenuStripe
            // 
            tlpDonorMenuStripe.ColumnCount = 4;
            tlpDonorMenuStripe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDonorMenuStripe.ColumnStyles.Add(new ColumnStyle());
            tlpDonorMenuStripe.ColumnStyles.Add(new ColumnStyle());
            tlpDonorMenuStripe.ColumnStyles.Add(new ColumnStyle());
            tlpDonorMenuStripe.Controls.Add(cbStatus, 2, 0);
            tlpDonorMenuStripe.Controls.Add(cbBloodGroups, 1, 0);
            tlpDonorMenuStripe.Controls.Add(pnlTextBoxDonorSearch, 0, 0);
            tlpDonorMenuStripe.Controls.Add(btnAddDonor, 3, 0);
            tlpDonorMenuStripe.Dock = DockStyle.Fill;
            tlpDonorMenuStripe.Location = new Point(3, 3);
            tlpDonorMenuStripe.Name = "tlpDonorMenuStripe";
            tlpDonorMenuStripe.RowCount = 1;
            tlpDonorMenuStripe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDonorMenuStripe.Size = new Size(719, 34);
            tlpDonorMenuStripe.TabIndex = 2;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Fill;
            cbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(541, 3);
            cbStatus.Margin = new Padding(4, 3, 4, 3);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(82, 24);
            cbStatus.TabIndex = 2;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // cbBloodGroups
            // 
            cbBloodGroups.BackColor = SystemColors.Window;
            cbBloodGroups.Dock = DockStyle.Fill;
            cbBloodGroups.DrawMode = DrawMode.OwnerDrawFixed;
            cbBloodGroups.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBloodGroups.FormattingEnabled = true;
            cbBloodGroups.Location = new Point(451, 3);
            cbBloodGroups.Margin = new Padding(4, 3, 4, 3);
            cbBloodGroups.Name = "cbBloodGroups";
            cbBloodGroups.Size = new Size(82, 24);
            cbBloodGroups.TabIndex = 1;
            cbBloodGroups.TabStop = false;
            cbBloodGroups.SelectedIndexChanged += cbBloodGroups_SelectedIndexChanged;
            // 
            // pnlTextBoxDonorSearch
            // 
            pnlTextBoxDonorSearch.BackColor = SystemColors.ActiveCaption;
            pnlTextBoxDonorSearch.Controls.Add(tbSearchDonor);
            pnlTextBoxDonorSearch.Dock = DockStyle.Fill;
            pnlTextBoxDonorSearch.Location = new Point(3, 2);
            pnlTextBoxDonorSearch.Margin = new Padding(3, 2, 4, 3);
            pnlTextBoxDonorSearch.Name = "pnlTextBoxDonorSearch";
            pnlTextBoxDonorSearch.Padding = new Padding(12, 5, 0, 5);
            pnlTextBoxDonorSearch.Size = new Size(440, 29);
            pnlTextBoxDonorSearch.TabIndex = 5;
            // 
            // tbSearchDonor
            // 
            tbSearchDonor.BorderStyle = BorderStyle.None;
            tbSearchDonor.Dock = DockStyle.Top;
            tbSearchDonor.Location = new Point(12, 5);
            tbSearchDonor.Margin = new Padding(0);
            tbSearchDonor.Name = "tbSearchDonor";
            tbSearchDonor.PlaceholderText = "Search by Name or Phone";
            tbSearchDonor.Size = new Size(428, 16);
            tbSearchDonor.TabIndex = 1;
            tbSearchDonor.TextChanged += tbSearchDonor_TextChanged;
            // 
            // btnAddDonor
            // 
            btnAddDonor.AutoSize = true;
            btnAddDonor.Dock = DockStyle.Fill;
            btnAddDonor.FlatStyle = FlatStyle.Flat;
            btnAddDonor.Location = new Point(631, 3);
            btnAddDonor.Margin = new Padding(4, 3, 0, 7);
            btnAddDonor.Name = "btnAddDonor";
            btnAddDonor.Size = new Size(88, 24);
            btnAddDonor.TabIndex = 4;
            btnAddDonor.Text = "+ Add Donor";
            btnAddDonor.UseVisualStyleBackColor = false;
            // 
            // DonorPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDonorPage);
            Name = "DonorPage";
            Size = new Size(725, 462);
            pnlDonorPage.ResumeLayout(false);
            tlpDonorPage.ResumeLayout(false);
            pnlDonorsList.ResumeLayout(false);
            pnlDonorsList.PerformLayout();
            pnlDgvDonorsStyling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDonors).EndInit();
            tlpDonorMenuStripe.ResumeLayout(false);
            tlpDonorMenuStripe.PerformLayout();
            pnlTextBoxDonorSearch.ResumeLayout(false);
            pnlTextBoxDonorSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDonorPage;
        private TableLayoutPanel tlpDonorPage;
        private Panel pnlDonorsList;
        private TableLayoutPanel tlpDonorMenuStripe;
        private Button btnAddDonor;
        private ComboBox cbStatus;
        private ComboBox cbBloodGroups;
        private Panel pnlTextBoxDonorSearch;
        private TextBox tbSearchDonor;
        private Panel pnlDgvDonorsStyling;
        private DataGridView dgvDonors;
        private DataGridViewTextBoxColumn DonorName;
        private DataGridViewTextBoxColumn DonorGroups;
        private DataGridViewTextBoxColumn DonorPhone;
        private DataGridViewTextBoxColumn DonorCity;
        private DataGridViewTextBoxColumn DonorLastDonation;
        private DataGridViewTextBoxColumn DonorEligiblility;
    }
}
