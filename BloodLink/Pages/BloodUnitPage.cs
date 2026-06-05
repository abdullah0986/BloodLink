using BloodLink.Forms;
using BloodLink.Helpers;
using BloodLink.Core.Models;
using BloodLink.Services;
using Color = System.Drawing.Color;
using System.Data;

namespace BloodLink.Pages
{
    public partial class BloodUnitPage : UserControl
    {
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private BloodUnitService _service;
        public readonly User _currentUser;
        private BindingSource _myBindingSource = new BindingSource();
        private List<BloodUnit> _bloodUnitList = new List<BloodUnit>();

        public BloodUnitPage(BloodUnitService service, User currentUser)
        {
            InitializeComponent();
            _service = service;
            _currentUser = currentUser;

            ApplyTheme();
            AdjustDgvHeight();
            this.HandleCreated += BloodUnitPage_HandleCreated;
            dgvBloodUnits.SelectionChanged += dgvDonors_SelectionChanged;
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;

            StyledStatCard(tlpTotalUnits, lblTotalUnitsHeading, lblTotalUnitsCount, lblTotalUnitsFooter, AppTheme.PrimaryText);
            StyledStatCard(tlpAvailable, lblAvailableHeadingf, lblAvailableCount, lblAvailableFooter, Color.ForestGreen);
            StyledStatCard(tlpReserved, lblReservedHeader, lblReservedCount, lblReservedFooter, Color.Orange);
            StyledStatCard(tlpExpiringSoon, lblExpiryingSoonHeader, lblExpirySoonCount, lblExpiringSoonFooter, Color.Red);

            pnlSecondRowStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlSecondRowStyling);

            lblSearchOperations.ForeColor = AppTheme.PrimaryText;
            lblSearchOperations.Font = AppTheme.FontButton;

            styleComboBox(cbBloodGroup);
            styleComboBox(cbStatus);
            populateBloodGroups();
            populateStatus();

            styleButton(btnAddBloodUnit);
            styleButton(btnUpdateBloodUnit);
            styleButton(btnViewBloodUnit);
            styleButton(btnDeleteBloodUnit);

            dgvBloodUnits.BackgroundColor = AppTheme.ContentBackground;
            dgvBloodUnits.GridColor = AppTheme.CardBackground;
            dgvBloodUnits.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvBloodUnits.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.MutedText;
            dgvBloodUnits.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontSmaller;
            dgvBloodUnits.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.ContentBackground;
            dgvBloodUnits.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvBloodUnits.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvBloodUnits.DefaultCellStyle.Font = AppTheme.FontSmaller;
            dgvBloodUnits.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvBloodUnits.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvBloodUnits.Paint -= PaintHelper.DgvHeaderLine_Paint;
            dgvBloodUnits.Paint += PaintHelper.DgvHeaderLine_Paint;
            dgvBloodUnits.AutoGenerateColumns = false;
            dgvBloodUnits.RowsAdded += (s, e) => AdjustDgvHeight();
            dgvBloodUnits.RowsRemoved += (s, e) => AdjustDgvHeight();

            pnlDonorsList.Resize += (s, e) => AdjustDgvHeight();

        }

        private void StyledStatCard(TableLayoutPanel tlp, Label heading, Label count, Label footer, Color color)
        {
            tlp.BackColor = AppTheme.ContentBackground;
            heading.ForeColor = AppTheme.MutedText;
            heading.Font = AppTheme.FontLabel;
            count.ForeColor = color;
            count.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            footer.ForeColor = AppTheme.MutedText;
            footer.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(tlp);
        }

        private void styleComboBox(ComboBox cb)
        {
            cb.BackColor = AppTheme.ContentBackground;
            cb.ForeColor = AppTheme.PrimaryText;
            cb.Font = AppTheme.FontSmall;
            cb.TabStop = false;
            cb.DrawItem += _paintHelper.cbStyling_DrawItem!;
        }

        private void styleButton(Button btn)
        {
            btn.BackColor = AppTheme.PrimaryRed;
            btn.ForeColor = AppTheme.PrimaryText;
            btn.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btn.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btn, 4);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async Task loadData()
        {
            BloodUnitStats Stats = await _service.GetBloodUnitStatsAsync();
            int totalUnits = Stats.TotalUnits;
            int availableUnits = Stats.AvailableUnits;
            int reservedUnits = Stats.ReservedUnits;

            int expiringSoon = await _service.getExpiringSoonCountAsync();
            int expiring = expiringSoon;

            lblTotalUnitsCount.Text = totalUnits.ToString() ?? "0";
            lblAvailableCount.Text = availableUnits.ToString() ?? "0";
            lblReservedCount.Text = reservedUnits.ToString() ?? "0";
            lblExpirySoonCount.Text = expiringSoon.ToString() ?? "0";


            _bloodUnitList = _service.GetAllUnits();
            var projected = _bloodUnitList
                .Select(bu => new
                {
                    bu.Id,
                    BloodGroup = EnumHelper.GetDescription(bu.BloodGroup),
                    CollectedDate = bu.CollectedDate.ToString("dd-MM-yyyy"),
                    ExpiryDate = bu.ExpiryDate.ToString("dd-MM-yyyy"),
                    DonorId = string.IsNullOrWhiteSpace(bu.DonorId) ? "Walk-in" : bu.DonorId,
                    Status = EnumHelper.GetDescription(bu.Status),
                }).ToList();

            _myBindingSource.DataSource = projected;
            dgvBloodUnits.DataSource = _myBindingSource;

            _paintHelper.AddClickEventToAllControls(this, dgvBloodUnits);
        }

        private void BloodUnitPage_HandleCreated(object sender, EventArgs e)
        {
            loadData();

            dgvBloodUnits.ClearSelection();
            dgvBloodUnits.CurrentCell = null;

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
                dgvBloodUnits.ClearSelection();
                return;
            }
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

            cbBloodGroup.DataSource = groups;
            cbBloodGroup.DisplayMember = "Text";
            cbBloodGroup.ValueMember = "Value";

            cbBloodGroup.SelectedIndex = 0;
        }

        private void populateStatus()
        {
            var statuses = Enum.GetValues(typeof(BloodUnitStatus))
                .Cast<BloodUnitStatus>()
                .Select(ds => new
                {
                    Text = EnumHelper.GetDescription(ds),
                    Value = (BloodUnitStatus?)ds
                }).ToList();
            statuses.Insert(0, new { Text = "All Status", Value = (BloodUnitStatus?)null });
            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        private void AdjustDgvHeight()
        {
            int rowsHeight = dgvBloodUnits.Rows
                .Cast<DataGridViewRow>()
                .Sum(r => r.Height);

            int headerHeight = dgvBloodUnits.ColumnHeadersHeight;
            int totalHeight = rowsHeight + headerHeight;

            // Cap at available parent height
            int maxHeight = pnlDonorsList.Height - pnlSearchOperations.Height - pnlSecondRowStyling.Padding.Top - pnlSecondRowStyling.Padding.Bottom;

            dgvBloodUnits.Height = Math.Min(totalHeight, maxHeight);
        }

        private void btnAddBloodUnit_Click(object sender, EventArgs e)
        {
            var form = new BloodUnitForm(_service, _currentUser);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnUpdateBloodUnit_Click(object sender, EventArgs e)
        {
            if (dgvBloodUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bloodUnit to view.");
                return;
            }

            int selectedRowIndex = dgvBloodUnits.CurrentRow.Index;
            BloodUnit selectedBloodUnit = _bloodUnitList[selectedRowIndex];
            if (selectedBloodUnit == null)
            {
                MessageBox.Show("BloodUnit has no data.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new BloodUnitForm(_service, _currentUser, FormMode.Edit, selectedBloodUnit);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                ApplyFilters();
            }
        }

        private void btnViewBloodUnit_Click(object sender, EventArgs e)
        {
            if (dgvBloodUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bloodUnit to view.");
                return;
            }

            int selectedRowIndex = dgvBloodUnits.CurrentRow.Index;
            BloodUnit selectedBloodUnit = _bloodUnitList[selectedRowIndex];
            if (selectedBloodUnit == null)
            {
                MessageBox.Show("BloodUnit has no data.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new BloodUnitForm(_service, _currentUser, FormMode.View, selectedBloodUnit);
            form.ShowDialog();
        }

        private void btnDeleteBloodUnit_Click(object sender, EventArgs e)
        {
            if (dgvBloodUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bloodUnit to delete.");
                return;
            }

            int selectedRowIndex = dgvBloodUnits.CurrentRow.Index;
            BloodUnit selectedBloodUnit = _bloodUnitList[selectedRowIndex];
            string bloodUnitId = selectedBloodUnit.Id;
            DialogResult result = MessageBox.Show($"Sure you want to delete {selectedBloodUnit.BloodGroup} with bagId {selectedBloodUnit.Id}", "Deleting Donor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _service.DeleteBloodUnit(bloodUnitId);
                loadData();
            }
        }

        private void cbBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            BloodGroup? bloodGroup = cbBloodGroup.SelectedValue is BloodGroup bg ? bg : null;
            BloodUnitStatus? status = cbStatus.SelectedValue is BloodUnitStatus s ? s : null;

            List<BloodUnit> results = _service.SearchUnits(bloodGroup, status);

            _bloodUnitList = results;
            var projected = _bloodUnitList
                .Select(bu => new
                {
                    bu.Id,
                    BloodGroup = EnumHelper.GetDescription(bu.BloodGroup),
                    CollectedDate = bu.CollectedDate.ToString("dd-MM-yyyy"),
                    ExpiryDate = bu.ExpiryDate.ToString("dd-MM-yyyy"),
                    DonorId = string.IsNullOrWhiteSpace(bu.DonorId) ? "Walk-in" : bu.DonorId,
                    Status = EnumHelper.GetDescription(bu.Status),
                }).ToList();

            _myBindingSource.DataSource = projected;
            dgvBloodUnits.DataSource = _myBindingSource;
        }

        private void dgvBloodUnits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                string value = e.Value.ToString();

                if (value == "Available")
                    e.CellStyle.ForeColor = Color.Green;
                else if (value == "Expired")
                    e.CellStyle.ForeColor = Color.Red;
                else if (value == "Reserved")
                    e.CellStyle.ForeColor = Color.Orange;
                else if (value == "Used")
                    e.CellStyle.ForeColor = Color.Gray;
            }
        }
    }
}
