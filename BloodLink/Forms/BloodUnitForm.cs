using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BloodLink.Forms
{
    public partial class BloodUnitForm : Form
    {
        private readonly BloodUnitService _bloodUnitService;
        private readonly BloodUnit? _bloodUnit;
        private readonly FormMode _mode;
        private readonly User _currentUser;
        private readonly DonorService _donorService = new DonorService();
        private readonly PaintHelper _paintHelper = new PaintHelper();
        public BloodUnitForm(BloodUnitService bloodUnitService, User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            _bloodUnitService = bloodUnitService;
            _currentUser = user;
            _mode = FormMode.Add;

            this.Load += DonorForm_Load;
        }

        public BloodUnitForm(BloodUnitService bloodUnitService, User user, FormMode mode, BloodUnit bloodUnit)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _bloodUnitService = bloodUnitService;
            _currentUser = user;
            _mode = mode;
            _bloodUnit = bloodUnit;

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

            lblBloodUnitFormHeading.ForeColor = AppTheme.PrimaryText;
            lblBloodUnitFormHeading.Font = AppTheme.FontH3;

            pnlFormStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlFormStyling);
            pnlFormStyling.Invalidate();
            pnlFormStyling.Update();

            foreach (Label lbl in new[] {lblID, lblBloodGroup, lblCollectionDate, lblLinkedDonor, lblStatus,
                    lblExpiryDate, lblUserId, lblCreatedAt, lblNotes})
            {
                lbl.ForeColor = AppTheme.PrimaryText;
                lbl.Font = AppTheme.FontSmall;
            }

            foreach (TextBox tb in new[] { tbID, tbUserId, tbNotes })
            {
                tb.BackColor = AppTheme.CardBackground;
                tb.ForeColor = AppTheme.PrimaryText;
            }

            foreach (ComboBox cb in new[] { cbBloodGroup, cbLinkedDonor, cbStatus })
            {
                cb.BackColor = AppTheme.CardBackground;
                cb.ForeColor = AppTheme.PrimaryText;
                cb.Font = AppTheme.FontSmall;

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;

                cb.DrawItem += _paintHelper.cbStyling_DrawItem!;
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

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            cancelBtnStyling();
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            saveBtnStyling();
        }


        private void loadData()
        {
            tbID.Text = _bloodUnit.Id.ToString();
            cbBloodGroup.SelectedValue = _bloodUnit.BloodGroup;
            dtpCollectionDate.Value = _bloodUnit.CollectedDate;
            cbLinkedDonor.SelectedValue = _bloodUnit.DonorId ?? "null";
            cbStatus.SelectedValue = _bloodUnit.Status;
            dtpExpiryDate.Value = _bloodUnit.ExpiryDate;
            tbUserId.Text = _bloodUnit.UserId.ToString();
            tbNotes.Text = _bloodUnit.Notes;

            if (_mode == FormMode.View)
            {
                lblBloodUnitFormHeading.Text = "View Blood Unit";
                makeReadonly(false);
                btnCancel.Enabled = false;
                btnSave.Text = "Close";
            }

            if (_mode == FormMode.Edit)
            {
                lblBloodUnitFormHeading.Text = "Update Blood Unit";
                btnSave.Text = "Update";
            }
        }


        private void populate_ComboBoxes()
        {
            var groups = Enum.GetValues(typeof(BloodGroup))
                .Cast<BloodGroup>()
                .Select(
                    bg => new
                    {
                        bloodGroupText = EnumHelper.GetDescription(bg),
                        bloodGroupValue = (BloodGroup?)bg
                    }).ToList();

            groups.Insert(0, new { bloodGroupText = "All Groups", bloodGroupValue = (BloodGroup?)null });

            cbBloodGroup.DataSource = groups;
            cbBloodGroup.DisplayMember = "bloodGroupText";
            cbBloodGroup.ValueMember = "bloodGroupValue";
            cbBloodGroup.SelectedIndex = 0;


            var donors = _donorService.GetAllDonors()
               .Select(d => new { donorText = $"{d.FullName}    ------    {d.Phone}", donorValue = d.Id })
               .ToList();

            donors.Insert(0, new { donorText = "Pick Donor", donorValue = "null" });
            donors.Insert(1, new { donorText = "Walk-in", donorValue = "walk-in" });

            cbLinkedDonor.DataSource = donors;
            cbLinkedDonor.DisplayMember = "donorText";
            cbLinkedDonor.ValueMember = "donorValue";
            cbLinkedDonor.SelectedIndex = 0;

            var status = Enum.GetValues(typeof(BloodUnitStatus)).Cast<BloodUnitStatus>()
                .Select(s => new
                {
                    statusText = EnumHelper.GetDescription(s),
                    statusValue = (BloodUnitStatus?)s
                }).ToList();

            status.Insert(0, new { statusText = "All Status", statusValue = (BloodUnitStatus?)null });

            cbStatus.DataSource = status;
            cbStatus.DisplayMember = "statusText";
            cbStatus.ValueMember = "statusValue";
            cbStatus.SelectedIndex = 0;
        }

        private void makeReadonly(bool action)
        {
            cbBloodGroup.Enabled = action;
            dtpCollectionDate.Enabled = action;
            cbLinkedDonor.Enabled = action;
            cbStatus.Enabled = action;
            dtpExpiryDate.Enabled = action;
            tbNotes.ReadOnly = !action;
            btnCancel.Visible = action;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_mode == FormMode.Add)
            {
                BloodGroup? bloodGroup = cbBloodGroup.SelectedValue is BloodGroup bg ? bg : null;
                BloodUnitStatus? status = cbStatus.SelectedValue is BloodUnitStatus s ? s : null;
                var newBloodUnit = new BloodUnit
                {
                    BloodGroup = bloodGroup,
                    CollectedDate = dtpCollectionDate.Value,
                    DonorId = cbLinkedDonor.SelectedValue.ToString() == "null" ? null : cbLinkedDonor.SelectedValue.ToString(),
                    Status = status,
                    ExpiryDate = dtpExpiryDate.Value,
                    UserId = _currentUser.Id,
                    Notes = tbNotes.Text
                };

                bool added = _bloodUnitService.AddBloodUnit(newBloodUnit);
                if (added)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            else if(_mode == FormMode.Edit)
            {
                BloodGroup? bloodGroup = cbBloodGroup.SelectedValue is BloodGroup bg ? bg : null;
                BloodUnitStatus? status = cbStatus.SelectedValue is BloodUnitStatus s ? s : null;

                _bloodUnit.BloodGroup = bloodGroup;
                _bloodUnit.CollectedDate = dtpCollectionDate.Value;
                _bloodUnit.DonorId = cbLinkedDonor.SelectedValue.ToString() == "null" ? null : cbLinkedDonor.SelectedValue.ToString();
                _bloodUnit.Status = status;
                _bloodUnit.UserId = _currentUser.Id;
                _bloodUnit.Notes = tbNotes.Text;
                _bloodUnitService.UpdateBloodUnit(_bloodUnit);

                bool result = _bloodUnitService.UpdateBloodUnit(_bloodUnit);
                if (result)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }


            else if(_mode == FormMode.View)
            {
                this.Close();
                return;
            }   
        }
    }
}
