using BloodLink.Forms;
using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BloodLink.Pages
{
    public partial class DonorPage : UserControl
    {

        private DonorService _DonorService;
        private readonly User _currentUser;
        private PaintHelper _paintHelper = new PaintHelper();
        public DonorPage(DonorService _service, User user)
        {
            InitializeComponent();
            applyTheme();
            _DonorService = _service;
            _currentUser = user;
            this.HandleCreated += DonorPage_HandleCreated;
            dgvDonors.SelectionChanged += dgvDonors_SelectionChanged;
        }

        private void applyTheme()
        {
            pnlTextBoxDonorSearch.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlTextBoxDonorSearch);

            tbSearchDonor.BackColor = AppTheme.ContentBackground;
            tbSearchDonor.Font = AppTheme.FontSmall;
            tbSearchDonor.ForeColor = AppTheme.MutedText;

            cbBloodGroups.BackColor = AppTheme.ContentBackground;
            cbBloodGroups.ForeColor = AppTheme.PrimaryText;
            cbBloodGroups.Font = AppTheme.FontSmall;
            cbBloodGroups.TabStop = false;
            cbBloodGroups.DrawItem += _paintHelper.cbStyling_DrawItem!;

            cbStatus.BackColor = AppTheme.ContentBackground;
            cbStatus.ForeColor = AppTheme.PrimaryText;
            cbStatus.Font = AppTheme.FontSmall;
            cbStatus.TabStop = false;
            cbStatus.DrawItem += _paintHelper.cbStyling_DrawItem!;

            btnAddDonor.BackColor = AppTheme.PrimaryRed;
            btnAddDonor.ForeColor = AppTheme.PrimaryText;
            btnAddDonor.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnAddDonor.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btnAddDonor, 4);

            btnUpdate.BackColor = AppTheme.PrimaryRed;
            btnUpdate.ForeColor = AppTheme.PrimaryText;
            btnUpdate.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnUpdate.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btnUpdate, 4);

            btnView.BackColor = AppTheme.PrimaryRed;
            btnView.ForeColor = AppTheme.PrimaryText;
            btnView.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnView.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btnView, 4);

            btnDelete.BackColor = AppTheme.PrimaryRed;
            btnDelete.ForeColor = AppTheme.PrimaryText;
            btnDelete.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnDelete.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btnDelete, 4);

            pnlDgvDonorsStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlDgvDonorsStyling);

            dgvDonors.BackgroundColor = AppTheme.ContentBackground;
            dgvDonors.GridColor = AppTheme.CardBackground;
            dgvDonors.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.MutedText;
            dgvDonors.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontSmall;
            dgvDonors.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.ContentBackground;
            dgvDonors.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvDonors.DefaultCellStyle.Font = AppTheme.FontSmall;
            dgvDonors.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvDonors.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvDonors.Paint -= PaintHelper.DgvHeaderLine_Paint;
            dgvDonors.Paint += PaintHelper.DgvHeaderLine_Paint;

        }

        private void CbBloodGroups_DrawItem(object? sender, DrawItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DonorPage_HandleCreated(object sender, EventArgs e)
        {
            loadData();

            dgvDonors.ClearSelection();
            dgvDonors.CurrentCell = null;

            this.BeginInvoke(new Action(() =>
            {
                _allowSelection = true;
            }));
        }

        private bool _allowSelection = false;

        private void dgvDonors_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowSelection)
            {
                dgvDonors.ClearSelection();
                return;
            }

            if (dgvDonors.SelectedRows.Count > 0 && dgvDonors.SelectedRows[0].Index == 0)
            {
                dgvDonors.ClearSelection();
            }
        }


        private void loadData()
        {
            dgvDonors.Rows.Insert(0, "");
            dgvDonors.Rows[0].Height = 10;
            dgvDonors.Rows[0].DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.Rows[0].ReadOnly = true;
            List<Donor> donors = _DonorService.GetAllDonors();
            foreach (Donor donor in donors)
            {
                int rowIndex = dgvDonors.Rows.Add(
                    donor.FullName,
                    EnumHelper.GetDescription(donor.BloodGroup),
                    donor.Phone,
                    donor.City,
                    donor.LastDonationDate.HasValue ? donor.LastDonationDate.Value.ToString("yyyy-MM-dd") : "N/A",
                    donor.IsEligible ? "Yes" : "No"
                );

                dgvDonors.Rows[rowIndex].Tag = donor;
            }
            dgvDonors.CellFormatting += dgvDonors_CellFormatting;

            UpdateGridHeight();
            dgvDonors.Paint -= PaintHelper.DgvHeaderLine_Paint;
            dgvDonors.Paint += PaintHelper.DgvHeaderLine_Paint;
            dgvDonors.RowsAdded += (s, e) => UpdateGridHeight();

            populateBloodGroups();
            populateStatus();
            _paintHelper.AddClickEventToAllControls(this, dgvDonors);
        }

        private void populateBloodGroups()
        {

            var groups = Enum.GetValues(typeof(BloodGroup))
                .Cast<BloodGroup>()
                .Select(bg => new
                {
                    Text = EnumHelper.GetDescription(bg),
                    Value = (BloodGroup?)bg
                }).ToList();

            groups.Insert(0, new { Text = "All Groups", Value = (BloodGroup?)null });

            cbBloodGroups.DataSource = groups;
            cbBloodGroups.DisplayMember = "Text";
            cbBloodGroups.ValueMember = "Value";

            cbBloodGroups.SelectedIndex = 0;
        }

        private void populateStatus()
        {
            var statuses = Enum.GetValues(typeof(DonorEligibility))
                .Cast<DonorEligibility>()
                .Select(ds => new
                {
                    Text = EnumHelper.GetDescription(ds),
                    Value = (DonorEligibility?)ds
                }).ToList();
            statuses.Insert(0, new { Text = "All Status", Value = (DonorEligibility?)null });
            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        private void dgvDonors_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                string value = e.Value.ToString();

                if (value == "Yes")
                    e.CellStyle.ForeColor = Color.Green;
                else if (value == "No")
                    e.CellStyle.ForeColor = Color.Red;
            }
        }


        private void UpdateGridHeight()
        {
            int totalHeight = dgvDonors.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dgvDonors.Rows)
            {
                if (row.Visible)
                    totalHeight += row.Height;
            }

            totalHeight += 26;
            dgvDonors.Height = totalHeight;
        }

        private void tbSearchDonor_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbBloodGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }


        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string search = tbSearchDonor.Text;
            BloodGroup? selectedGroup = cbBloodGroups.SelectedValue as BloodGroup?;
            DonorEligibility? selectedStatus = cbStatus.SelectedValue as DonorEligibility?;

            var donors = _DonorService.SerachDonors(search, selectedGroup, selectedStatus);

            dgvDonors.Rows.Clear();
            InsertSpacerRow();

            foreach (Donor donor in donors)
            {
                int rowIndex = dgvDonors.Rows.Add(
                    donor.FullName,
                    EnumHelper.GetDescription(donor.BloodGroup),
                    donor.Phone,
                    donor.City,
                    donor.LastDonationDate.HasValue ? donor.LastDonationDate.Value.ToString("dd-MM-yyyy") : "N/A",
                    donor.IsEligible ? "Yes" : "No"
                );

                dgvDonors.Rows[rowIndex].Tag = donor;
            }

            UpdateGridHeight();
        }

        private void InsertSpacerRow()
        {
            dgvDonors.Rows.Insert(0, "", "", "", "", "", "", "");
            dgvDonors.Rows[0].Height = 10;
            dgvDonors.Rows[0].DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.Rows[0].ReadOnly = true;
        }

        private void btnAddDonor_Click(object sender, EventArgs e)
        {
            using var form = new DonorForm(_DonorService, _currentUser);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvDonors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a donor to view.");
                return;
            }

            var donor = dgvDonors.SelectedRows[0].Tag as Donor;

            if (donor == null)
            {
                MessageBox.Show("No donor data found.");
                return;
            }

            var form = new DonorForm(_DonorService, _currentUser, FormMode.View, donor);
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDonors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a donor to Update.");
                return;
            }

            var donor = dgvDonors.SelectedRows[0].Tag as Donor;

            if (donor == null)
            {
                MessageBox.Show("No donor data found.");
                return;
            }

            var form = new DonorForm(_DonorService, _currentUser, FormMode.Edit, donor);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDonors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a donor to Delete.");
                return;
            }

            var donor = dgvDonors.SelectedRows[0].Tag as Donor;

            if (donor == null)
            {
                MessageBox.Show("No donor data found.");
                return;
            }


            DialogResult result = MessageBox.Show($"Sure you want to delete {donor.FullName}", "Deleting Donor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _DonorService.DeleteDonor(donor.Id);
                loadData();
            }

        }

        private void pnlDgvDonorsStyling_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
