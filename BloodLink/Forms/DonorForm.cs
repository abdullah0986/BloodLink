using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;

namespace BloodLink.Forms
{
    public partial class DonorForm : Form
    {
        private readonly DonorService _donorService;
        private readonly Donor _donor;
        private readonly FormMode _mode;
        private readonly User _currentUser;
        private readonly PaintHelper _paintHelper = new PaintHelper();
        public DonorForm(DonorService donorService, User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            _donorService = donorService;
            _currentUser = user;
            _mode = FormMode.Add;

            this.Load += DonorForm_Load;
        }

        public DonorForm(DonorService donorService, User user,  FormMode mode, Donor donor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _donorService = donorService;
            _currentUser = user;
            _mode = mode;
            _donor = donor;

            this.Load += DonorForm_Load;
        }
        private void DonorForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            populate_ComboBoxes();  

            if (_mode != FormMode.Add)
            {
                loadData();
            }

            pnlFormStyling.Invalidate();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.CardBackground;

            lblDonorFormHeading.ForeColor = AppTheme.PrimaryText;
            lblDonorFormHeading.Font = AppTheme.FontH3;

            pnlFormStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlFormStyling);
            pnlFormStyling.Invalidate();
            pnlFormStyling.Update();

            foreach (Label lbl in new[] {lblID, lblFullName, lblPhone, lblAge, lblCity,
                    lblArea, lblBloodGroup, lblEligibility, lblGender, lblLastDonation,
                    lblNextEligibleDate, lblWeight})
            {
                lbl.ForeColor = AppTheme.PrimaryText;
                lbl.Font = AppTheme.FontSmall;
            }

            foreach (TextBox tb in new[] { tbID, tbFullName, tbPhone, tbCity
                    , tbArea})
            {
                tb.BackColor = AppTheme.CardBackground;
                tb.ForeColor = AppTheme.PrimaryText;
            }

            foreach (ComboBox cb in new[] { cbBloodGroup, cbEligibility, cbGender })
            {
                cb.BackColor = AppTheme.CardBackground;
                cb.ForeColor = AppTheme.PrimaryText;
                cb.Font = AppTheme.FontSmall;

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;

                cb.DrawItem += _paintHelper.cbStyling_DrawItem!;
            }

            foreach(NumericUpDown nud in new[] { nudAge, nudWeight })
            {
                nudAge.BackColor = AppTheme.CardBackground;
                nudAge.ForeColor = AppTheme.PrimaryText;
            }


            saveBtnStyling();
            cancelBtnStyling();
        }

        private void saveBtnStyling()
        {
            btnSave.BackColor = AppTheme.PrimaryRed;
            btnSave.ForeColor = AppTheme.PrimaryText;
            btnSave.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(btnSave, 6);
        }

        private void cancelBtnStyling()
        {
            btnCancel.BackColor = AppTheme.LightRed;
            btnCancel.ForeColor = Color.DarkRed;
            btnCancel.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(btnCancel, 6);
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = AppTheme.PinkRed;
            btnCancel.ForeColor = Color.DarkRed;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = AppTheme.BrightRed;
            btnSave.ForeColor = AppTheme.PrimaryText;
        }

        private void populate_ComboBoxes()
        {
            var groups = Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>()
                .Select(bg => new
                {
                    BloodgroupText = EnumHelper.GetDescription(bg),
                    BloodGroupValue = (BloodGroup?)bg
                }).ToList();

            groups.Insert(0, new { BloodgroupText = "All Groups", BloodGroupValue = (BloodGroup?)null });

            cbBloodGroup.DataSource = groups;
            cbBloodGroup.DisplayMember = "BloodgroupText";
            cbBloodGroup.ValueMember = "BloodGroupValue";
            cbBloodGroup.SelectedIndex = 0;


            var gender = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                .Select(g => new
                {
                    GenderText = g.ToString(),
                    GenderValue = (Gender?)g
                }).ToList();

            gender.Insert(0, new { GenderText = "Select Gender", GenderValue = (Gender?)null });

            cbGender.DataSource = gender;
            cbGender.DisplayMember = "GenderText";
            cbGender.ValueMember = "GenderValue";
            cbGender.SelectedIndex = 0;

            var eligibility = Enum.GetValues(typeof(DonorEligibility)).Cast<DonorEligibility>()
                .Select(e => new
                {
                    EligibilityText = EnumHelper.GetDescription(e),
                    EligibilityValue = (DonorEligibility?)e
                }).ToList();

            eligibility.Insert(0, new { EligibilityText = "Select Eligibility", EligibilityValue = (DonorEligibility?)null });

            cbEligibility.DataSource = eligibility;
            cbEligibility.DisplayMember = "EligibilityText";
            cbEligibility.ValueMember = "EligibilityValue";
            cbEligibility.SelectedIndex = 0;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            saveBtnStyling();
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            cancelBtnStyling();
        }

        private void lblDonorFormHeading_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.Add)
            {
                Donor donor = new Donor
                {
                    FullName = tbFullName.Text,
                    Phone = tbPhone.Text,
                    Age = (int)nudAge.Value,
                    BloodGroup = cbBloodGroup.SelectedValue as BloodGroup?, 
                    Gender = cbGender.SelectedValue as Gender?,
                    Weight = nudWeight.Value == 0 ? null : (double)nudWeight.Value,
                    City = tbCity.Text,
                    Area = tbArea.Text ?? "",
                    IsEligible = cbEligibility.SelectedValue as DonorEligibility? == DonorEligibility.Eligible,
                    LastDonationDate = dtpLastDonation.Value,
                    UserId = _currentUser.Id
                };

                bool donorAdded = _donorService.RegisterDonor(donor);
                if (donorAdded)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to register donor. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if(_mode == FormMode.View)
            {
                this.Close();
            }

            if (_mode == FormMode.Edit)
            {
                _donor.FullName = tbFullName.Text;
                _donor.Phone = tbPhone.Text;
                _donor.Age = (int)nudAge.Value;
                _donor.BloodGroup = cbBloodGroup.SelectedValue as BloodGroup?;
                _donor.Gender = cbGender.SelectedValue as Gender?;
                _donor.Weight = nudWeight.Value == 0 ? null : (double)nudWeight.Value;
                _donor.City = tbCity.Text;
                _donor.Area = tbArea.Text ?? "";
                _donor.IsEligible = cbEligibility.SelectedValue as DonorEligibility? == DonorEligibility.Eligible;
                _donor.LastDonationDate = dtpLastDonation.Value;
                _donor.UserId = _currentUser.Id;

                bool donorUpdated = _donorService.UpdateDonor(_donor);
                if (donorUpdated)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update donor. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadData()
        {
            if (_donor == null)
            {
                MessageBox.Show("No donor data provided to View.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            tbID.Text = _donor.Id;
            tbFullName.Text = _donor.FullName;
            tbPhone.Text = _donor.Phone;
            nudAge.Value = _donor.Age;
            cbBloodGroup.SelectedValue = _donor.BloodGroup;
            cbGender.SelectedValue = _donor.Gender;
            nudWeight.Value = (decimal)(_donor.Weight ?? 0);
            tbCity.Text = _donor.City;
            tbArea.Text = _donor.Area;
            cbEligibility.SelectedValue = _donor.IsEligible ? DonorEligibility.Eligible : DonorEligibility.NotEligible;
            dtpLastDonation.Value = _donor.LastDonationDate ?? DateTime.Now;
            dtpNextEligibleDate.Value = _donor.NextEligibleDate ?? DateTime.Now;

            if (_mode == FormMode.View)
            {
                lblDonorFormHeading.Text = "View Donor";
                makeReadonly(false);
                btnCancel.Visible = false;
                btnSave.Text = "Close";
            }

            if(_mode == FormMode.Edit)
            {
                lblDonorFormHeading.Text = "Updating Donor";
                btnSave.Text = "Update";
            }
        }

        private void makeReadonly(bool action)
        {
            tbFullName.Enabled = action;
            tbCity.Enabled = action;
            tbPhone.Enabled = action;
            nudAge.Enabled = action;
            cbBloodGroup.Enabled = action;
            cbEligibility.Enabled = action;
            cbGender.Enabled = action;
            nudWeight.Enabled = action;
            tbArea.Enabled = action;
            dtpLastDonation.Enabled = action;
        }
    }
}
