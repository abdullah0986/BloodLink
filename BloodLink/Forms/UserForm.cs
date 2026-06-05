using BloodLink.Helpers;
using BloodLink.Core.Models;
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
    public partial class UserForm : Form
    {
        private readonly FormMode _mode;
        private readonly AuthService _authService;
        private readonly User _user;
        private readonly User _selectedUser;
        private readonly PaintHelper _paintHelper = new PaintHelper();
        public UserForm(AuthService authService, User user)
        {
            InitializeComponent();
            _authService = authService;
            _user = user;
            this.StartPosition = FormStartPosition.CenterScreen;

            _mode = FormMode.Add;
            this.Load += UserForm_Load;
        }

        public UserForm(AuthService authService, User user, FormMode mode, User selectedUser)
        {
            InitializeComponent();
            _authService = authService;
            _user = user;
            _selectedUser = selectedUser;
            this.StartPosition = FormStartPosition.CenterScreen;

            _mode = mode;
            this.Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            Populate_ComboBox();

            if (_mode != FormMode.Add)
            {
                LoadData();
            }
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.CardBackground;

            lblUserFormHeading.ForeColor = AppTheme.PrimaryText;
            lblUserFormHeading.Font = AppTheme.FontH3;

            pnlFormStyling.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(pnlFormStyling);
            pnlFormStyling.Invalidate();
            pnlFormStyling.Update();

            foreach (Label lbl in new[] {lblUserId, lblName, lblEmail, lblPassword, lblRole,
                    lblPassword, lblConfirmPass, lblCreatedAt})
            {
                lbl.ForeColor = AppTheme.PrimaryText;
                lbl.Font = AppTheme.FontSmall;
            }

            foreach (TextBox tb in new[] { tbUserId, tbName, tbEmail, tbPassword, tbConfirmPass })
            {
                tb.BackColor = AppTheme.CardBackground;
                tb.ForeColor = AppTheme.PrimaryText;
            }

            foreach (ComboBox cb in new[] { cbRole })
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

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            cancelBtnStyling();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = AppTheme.BrightRed;
            btnSave.ForeColor = AppTheme.PrimaryText;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            saveBtnStyling();
        }

        private void Populate_ComboBox()
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>()
                .Select(
                    role => new
                    {
                        roleText = role.ToString(),
                        roleValue = (Role?)role
                    }).ToList();

            roles.Insert(0, new { roleText = "Select Role", roleValue = (Role?)null });

            cbRole.DataSource = roles;
            cbRole.DisplayMember = "roleText";
            cbRole.ValueMember = "roleValue";
            cbRole.SelectedIndex = 0;
        }

        private void LoadData()
        {
            if (_mode == FormMode.Edit)
            {
                lblUserFormHeading.Text = "Update User";
                btnSave.Text = "Update";

                tbUserId.Text = _selectedUser.Id;
                tbName.Text = _selectedUser.FullName;
                tbEmail.Text = _selectedUser.Email;
                cbRole.SelectedValue = (Role?)_selectedUser.Role!;
                dtpCreatedAt.Value = _selectedUser.CreatedAt;

                tbUserId.ReadOnly = true;
                dtpCreatedAt.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == FormMode.Add)
            {
                Role? selectedRole = cbRole.SelectedValue is Role role ? role : null;

                if (tbPassword.Text.Trim() != tbConfirmPass.Text.Trim())
                {
                    MessageBox.Show("Password is not matching");
                    return;
                }

                var newUser = new User
                {
                    FullName = tbName.Text,
                    Email = tbEmail.Text,
                    Role = selectedRole,
                    Password = tbPassword.Text,
                };

                (bool success, string message) = _authService.CreateOperator(newUser);

                if (!success)
                {
                    MessageBox.Show(message);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                return;
            }

            if(_mode == FormMode.Edit)
            {
                Console.WriteLine($"Updating user with Id: {_selectedUser.Id}"); // add this

                _selectedUser.FullName = tbName.Text;
                _selectedUser.Email = tbEmail.Text;
                _selectedUser.Role = cbRole.SelectedValue is Role role ? role : null;

                string newPassword = tbPassword.Text.Trim();
                string confirmPassword = tbConfirmPass.Text.Trim();

                if (!string.IsNullOrEmpty(newPassword))
                {
                    if(newPassword != confirmPassword)
                    {
                        MessageBox.Show("Password do not matching");
                        return;
                    }
                    _selectedUser.Password = newPassword;
                }
                (bool success, string message) = _authService.UpdateUser(_selectedUser, newPassword);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }
    }
}
