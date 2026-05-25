using BloodLink.Forms;
using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;
using Color = System.Drawing.Color;

namespace BloodLink.Pages
{
    public partial class PatientsPage : UserControl
    {
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private PatientRequestService _service;
        public readonly User _currentUser;
        private BindingSource _myBindingSource = new BindingSource();
        private List<PatientRequest> _patientRequestList = new List<PatientRequest>();

        public PatientsPage(PatientRequestService service, User currentUser)
        {
            InitializeComponent();
            _service = service;
            _currentUser = currentUser;

            ApplyTheme();
            AdjustDgvHeight();
            loadData();
            this.HandleCreated += PatientRequestPage_HandleCreated;
            dgvPatientRequests.SelectionChanged += dgvPatientRequests_SelectionChanged;
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;

            StyledStatCard(tlpTotalRequests, lblTotalRequestsHeading, lblTotalRequestsCount, lblTotalRequestsFooter, AppTheme.PrimaryText);
            StyledStatCard(tlpPending, lblPendingHeading, lblPendingCount, lblPendingFooter, Color.Orange);
            StyledStatCard(tlpFulfilled, lblFulfilledHeading, lblFulfilledCount, lblFulfilledFooter, Color.ForestGreen);
            StyledStatCard(tlpCancelled, lblCancelledHeading, lblCancelledCount, lblCancelledFooter, Color.Red);

            pnlSecondRowStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlSecondRowStyling);

            pnlSearchBox.BackColor = AppTheme.MainBackground;
            _paintHelper.AddRounding(pnlSearchBox);
            tbSearch.BackColor = AppTheme.MainBackground;
            tbSearch.ForeColor = AppTheme.MutedText;
            tbSearch.Font = AppTheme.FontSmall;

            styleComboBox(cbStatus);
            populateStatus();

            styleButton(btnAddRequest);
            styleButton(btnUpdateRequest);
            styleButton(btnViewRequest);
            styleButton(btnDeleteRequest);

            dgvPatientRequests.BackgroundColor = AppTheme.ContentBackground;
            dgvPatientRequests.GridColor = AppTheme.CardBackground;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.MutedText;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontSmaller;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.ContentBackground;
            dgvPatientRequests.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvPatientRequests.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvPatientRequests.DefaultCellStyle.Font = AppTheme.FontSmaller;
            dgvPatientRequests.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvPatientRequests.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvPatientRequests.Paint -= PaintHelper.DgvHeaderLine_Paint;
            dgvPatientRequests.Paint += PaintHelper.DgvHeaderLine_Paint;
            dgvPatientRequests.AutoGenerateColumns = false;
            dgvPatientRequests.RowsAdded += (s, e) => AdjustDgvHeight();
            dgvPatientRequests.RowsRemoved += (s, e) => AdjustDgvHeight();

            pnlPatientsList.Resize += (s, e) => AdjustDgvHeight();
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

        private void loadData()
        {
            var allRequests = _service.GetAllRequests();
            int total = allRequests.Count;
            int pending = allRequests.Count(r => r.Status == RequestStatus.Pending);
            int fulfilled = allRequests.Count(r => r.Status == RequestStatus.Fulfilled);
            int cancelled = allRequests.Count(r => r.Status == RequestStatus.Cancelled);

            lblTotalRequestsCount.Text = total.ToString();
            lblPendingCount.Text = pending.ToString();
            lblFulfilledCount.Text = fulfilled.ToString();
            lblCancelledCount.Text = cancelled.ToString();

            _patientRequestList = allRequests;
            RefreshGrid(_patientRequestList);

            _paintHelper.AddClickEventToAllControls(this, dgvPatientRequests);
        }

        private void RefreshGrid(List<PatientRequest> list)
        {
            var projected = list.Select(r => new
            {
                r.PatientName,
                BloodGroup = EnumHelper.GetDescription(r.BloodGroup),
                r.UnitsRequired,
                r.DoctorName,
                r.Ward,
                Status = r.Status.ToString(),
            }).ToList();

            _myBindingSource.DataSource = projected;
            dgvPatientRequests.DataSource = _myBindingSource;
        }

        private void PatientRequestPage_HandleCreated(object sender, EventArgs e)
        {
            loadData();

            dgvPatientRequests.ClearSelection();
            dgvPatientRequests.CurrentCell = null;

            this.BeginInvoke(new Action(() =>
            {
                _allowSelection = true;
            }));
        }

        private bool _allowSelection = false;

        private void dgvPatientRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowSelection)
            {
                dgvPatientRequests.ClearSelection();
                return;
            }
        }

        private void populateStatus()
        {
            var statuses = Enum.GetValues(typeof(RequestStatus))
                .Cast<RequestStatus>()
                .Select(rs => new
                {
                    Text = rs.ToString(),
                    Value = (RequestStatus?)rs
                }).ToList();

            statuses.Insert(0, new { Text = "All Status", Value = (RequestStatus?)null });

            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        private void AdjustDgvHeight()
        {
            int rowsHeight = dgvPatientRequests.Rows
                .Cast<DataGridViewRow>()
                .Sum(r => r.Height);

            int headerHeight = dgvPatientRequests.ColumnHeadersHeight;
            int totalHeight = rowsHeight + headerHeight;

            int maxHeight = pnlPatientsList.Height - pnlSearchOperations.Height
                - pnlSecondRowStyling.Padding.Top - pnlSecondRowStyling.Padding.Bottom;

            dgvPatientRequests.Height = Math.Min(totalHeight, maxHeight);
        }

        private void dgvPatientRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPatientRequests.Columns["prStatus"]?.Index && e.Value != null)
            {
                string value = e.Value.ToString()!;
                e.CellStyle.ForeColor = value switch
                {
                    "Pending" => Color.Orange,
                    "Fulfilled" => Color.ForestGreen,
                    "Cancelled" => Color.Red,
                    _ => AppTheme.BodyText
                };
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchTerm = tbSearch.Text;
            RequestStatus? status = cbStatus.SelectedValue is RequestStatus rs ? rs : null;

            _patientRequestList = _service.SearchPatientRecords(searchTerm, null, status);
            RefreshGrid(_patientRequestList);
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            var form = new PatientForm(_service, _currentUser);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Patient request added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateRequest_Click(object sender, EventArgs e)
        {
            if (dgvPatientRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to update.");
                return;
            }

            int selectedRowIndex = dgvPatientRequests.CurrentRow.Index;
            PatientRequest selectedRequest = _patientRequestList[selectedRowIndex];
            if (selectedRequest == null)
            {
                MessageBox.Show("Request has no data.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new PatientForm(_service, _currentUser, FormMode.Edit, selectedRequest);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Patient request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewRequest_Click(object sender, EventArgs e)
        {
            if (dgvPatientRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to view.");
                return;
            }

            int selectedRowIndex = dgvPatientRequests.CurrentRow.Index;
            PatientRequest selectedRequest = _patientRequestList[selectedRowIndex];
            if (selectedRequest == null)
            {
                MessageBox.Show("Request has no data.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new PatientForm(_service, _currentUser, FormMode.View, selectedRequest);
            form.ShowDialog();
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            if (dgvPatientRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to delete.");
                return;
            }

            int selectedRowIndex = dgvPatientRequests.CurrentRow.Index;
            PatientRequest selectedRequest = _patientRequestList[selectedRowIndex];

            DialogResult result = MessageBox.Show(
                $"Sure you want to delete request for patient \"{selectedRequest.PatientName}\"?",
                "Deleting Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                _service.DeleteRecord(selectedRequest.Id);
                loadData();
            }
        }

        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}