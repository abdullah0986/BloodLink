using BloodLink.Helpers;
using BloodLink.Core.Models;
using BloodLink.Services;

namespace BloodLink.Forms
{
    public partial class PatientForm : Form
    {
        private readonly PatientRequestService _patientRequestService;
        private readonly PatientRequest? _patientRequest;
        private readonly FormMode _mode;
        private readonly User _currentUser;
        private readonly PaintHelper _paintHelper = new PaintHelper();

        public PatientForm(PatientRequestService patientRequestService, User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _patientRequestService = patientRequestService;
            _currentUser = user;
            _mode = FormMode.Add;

            this.Load += PatientForm_Load;
        }

        public PatientForm(PatientRequestService patientRequestService, User user, FormMode mode, PatientRequest patientRequest)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _patientRequestService = patientRequestService;
            _currentUser = user;
            _mode = mode;
            _patientRequest = patientRequest;

            this.Load += PatientForm_Load;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            PopulateComboBoxes();

            if (_mode != FormMode.Add)
                LoadData();

            pnlFormStyling.Invalidate();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.CardBackground;

            lblPatientFormHeading.ForeColor = AppTheme.PrimaryText;
            lblPatientFormHeading.Font = AppTheme.FontH3;

            pnlFormStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlFormStyling);
            pnlFormStyling.Invalidate();
            pnlFormStyling.Update();

            foreach (Label lbl in new[] { lblID, lblUserId, lblPatientName, lblPatientAge,
                lblBloodGroup, lblUnitsRequired, lblStatus, lblWard, lblDoctorName, lblNotes, lblCreatedAt })
            {
                lbl.ForeColor = AppTheme.PrimaryText;
                lbl.Font = AppTheme.FontSmall;
            }

            foreach (TextBox tb in new[] { tbID, tbUserId, tbPatientName, tbDoctorName, tbWard, tbNotes })
            {
                tb.BackColor = AppTheme.CardBackground;
                tb.ForeColor = AppTheme.PrimaryText;
            }

            foreach (ComboBox cb in new[] { cbBloodGroup, cbStatus })
            {
                cb.BackColor = AppTheme.CardBackground;
                cb.ForeColor = AppTheme.PrimaryText;
                cb.Font = AppTheme.FontSmall;
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.DrawItem += _paintHelper.cbStyling_DrawItem!;
            }

            SaveBtnStyling();
            CancelBtnStyling();
        }

        private void SaveBtnStyling()
        {
            btnSave.BackColor = AppTheme.PrimaryRed;
            btnSave.ForeColor = AppTheme.PrimaryText;
            btnSave.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(btnSave, 6);
        }

        private void CancelBtnStyling()
        {
            btnCancel.BackColor = AppTheme.LightRed;
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(btnCancel, 6);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = AppTheme.BrightRed;
            btnSave.ForeColor = AppTheme.PrimaryText;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e) => SaveBtnStyling();

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = AppTheme.PinkRed;
            btnCancel.ForeColor = Color.DarkRed;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e) => CancelBtnStyling();

        private void PopulateComboBoxes()
        {
            var groups = Enum.GetValues(typeof(BloodGroup))
                .Cast<BloodGroup>()
                .Select(bg => new
                {
                    bloodGroupText = EnumHelper.GetDescription(bg),
                    bloodGroupValue = (BloodGroup?)bg
                }).ToList();

            groups.Insert(0, new { bloodGroupText = "Select Blood Group", bloodGroupValue = (BloodGroup?)null });

            cbBloodGroup.DataSource = groups;
            cbBloodGroup.DisplayMember = "bloodGroupText";
            cbBloodGroup.ValueMember = "bloodGroupValue";
            cbBloodGroup.SelectedIndex = 0;

            var statuses = Enum.GetValues(typeof(RequestStatus))
                .Cast<RequestStatus>()
                .Select(s => new
                {
                    statusText = EnumHelper.GetDescription(s),
                    statusValue = (RequestStatus?)s
                }).ToList();

            statuses.Insert(0, new { statusText = "Select Status", statusValue = (RequestStatus?)null });

            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "statusText";
            cbStatus.ValueMember = "statusValue";
            cbStatus.SelectedIndex = 0;
        }

        private void LoadData()
        {
            tbID.Text = _patientRequest!.Id;
            tbUserId.Text = _patientRequest.userId;
            tbPatientName.Text = _patientRequest.PatientName;

            nudPatientAge.Value = _patientRequest.PatientAge.HasValue
                ? Math.Max(nudPatientAge.Minimum, Math.Min(nudPatientAge.Maximum, _patientRequest.PatientAge.Value))
                : 0;

            cbBloodGroup.SelectedValue = (BloodGroup?)_patientRequest.BloodGroup;
            nudUnitsRequired.Value = Math.Max(1, _patientRequest.UnitsRequired);
            cbStatus.SelectedValue = (RequestStatus?)_patientRequest.Status;
            tbWard.Text = _patientRequest.Ward ?? string.Empty;
            tbDoctorName.Text = _patientRequest.DoctorName ?? string.Empty;
            tbNotes.Text = _patientRequest.Notes ?? string.Empty;
            dtpCreatedAt.Value = _patientRequest.CreatedAt;

            if (_mode == FormMode.View)
            {
                lblPatientFormHeading.Text = "View Patient Request";
                MakeReadOnly(false);
                btnCancel.Enabled = false;
                btnSave.Text = "Close";
            }

            if (_mode == FormMode.Edit)
            {
                lblPatientFormHeading.Text = "Update Patient Request";
                btnSave.Text = "Update";
            }
        }

        private void MakeReadOnly(bool editable)
        {
            tbID.Enabled = !editable;
            tbUserId.Enabled = !editable;
            tbPatientName.ReadOnly = !editable;
            nudPatientAge.Enabled = editable;
            cbBloodGroup.Enabled = editable;
            nudUnitsRequired.Enabled = editable;
            cbStatus.Enabled = editable;
            tbWard.ReadOnly = editable;
            tbDoctorName.ReadOnly = editable;
            tbNotes.ReadOnly = editable;
            btnCancel.Visible = editable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                this.Close();
                return;
            }

            BloodGroup? bloodGroup = cbBloodGroup.SelectedValue is BloodGroup bg ? bg : null;
            RequestStatus? status = cbStatus.SelectedValue is RequestStatus rs ? rs : null;

            if (_mode == FormMode.Add)
            {
                var newRequest = new PatientRequest
                {
                    PatientName = tbPatientName.Text.Trim(),
                    PatientAge = nudPatientAge.Value > 0 ? (int?)nudPatientAge.Value : null,
                    BloodGroup = bloodGroup ?? default,
                    UnitsRequired = (int)nudUnitsRequired.Value,
                    Ward = string.IsNullOrWhiteSpace(tbWard.Text) ? null : tbWard.Text.Trim(),
                    DoctorName = string.IsNullOrWhiteSpace(tbDoctorName.Text) ? null : tbDoctorName.Text.Trim(),
                    Status = status ?? RequestStatus.Pending,
                    Notes = string.IsNullOrWhiteSpace(tbNotes.Text) ? null : tbNotes.Text.Trim(),
                    userId = _currentUser.Id,
                };

                var (result, message) = _patientRequestService.AddRequest(newRequest);

                if (result > 0)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (_mode == FormMode.Edit)
            {
                _patientRequest!.PatientName = tbPatientName.Text.Trim();
                _patientRequest.PatientAge = nudPatientAge.Value > 0 ? (int?)nudPatientAge.Value : null;
                _patientRequest.BloodGroup = bloodGroup ?? default;
                _patientRequest.UnitsRequired = (int)nudUnitsRequired.Value;
                _patientRequest.Ward = string.IsNullOrWhiteSpace(tbWard.Text) ? null : tbWard.Text.Trim();
                _patientRequest.DoctorName = string.IsNullOrWhiteSpace(tbDoctorName.Text) ? null : tbDoctorName.Text.Trim();
                _patientRequest.Status = status ?? RequestStatus.Pending;
                _patientRequest.Notes = string.IsNullOrWhiteSpace(tbNotes.Text) ? null : tbNotes.Text.Trim();
                _patientRequest.userId = _currentUser.Id;

                var (result, message) = _patientRequestService.UpdateRequest(_patientRequest);

                if (result > 0)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}