using BloodLink.Core.Database;
using BloodLink.Forms;
using BloodLink.Helpers;
using BloodLink.Core.Models;
using BloodLink.Services;
using System.Drawing.Drawing2D;

namespace BloodLink.Pages
{
    public partial class StaffPage : UserControl
    {
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private readonly AuthService _authService;
        private readonly User _currentUser;

        private Panel pnlStaffList;

        public StaffPage(AuthService authService, User user)
        {
            InitializeComponent();
            _authService = authService;
            _currentUser = user;

            this.Load += Load_StaffPage;
            btnAddOperator.Click += BtnAddOperator_Click;
        }

        private void Load_StaffPage(Object s, EventArgs args)
        {
            ApplyTheme();
            BuildStaffListPanel();
            LoadStaff();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;
            styleButton(btnAddOperator);
        }

        private void styleButton(Button btn)
        {
            btn.BackColor = AppTheme.PrimaryRed;
            btn.ForeColor = AppTheme.PrimaryText;
            btn.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btn.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(btn, 4);
        }

        private void BuildStaffListPanel()
        {
            pnlStaffList = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = AppTheme.MainBackground,
                Padding = new Padding(16, 8, 16, 8)
            };
            tlpStaffPage.Controls.Add(pnlStaffList, 0, 1);
        }

        private void LoadStaff()
        {
            pnlStaffList.Controls.Clear();

            var users = _authService.GetAllUsers();

            var ordered = users
                .OrderBy(u => u.Role == Role.Admin ? 0 : 1)
                .ThenBy(u => u.FullName)
                .ToList();


            var lblSection = new Label
            {
                Text = "Current Staff",
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(0, 4)
            };
            pnlStaffList.Controls.Add(lblSection);

            int yPos = lblSection.Bottom + 8;

            foreach (var user in ordered)
            {
                var card = BuildStaffCard(user);
                card.Location = new Point(0, yPos);
                card.Width = pnlStaffList.ClientSize.Width - 4;
                card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                pnlStaffList.Controls.Add(card);
                yPos += card.Height + 10;
            }

            pnlStaffList.Resize += (s, e) =>
            {
                foreach (Control c in pnlStaffList.Controls)
                    if (c is Panel)
                        c.Width = pnlStaffList.ClientSize.Width - 4;
            };
        }

        private Panel BuildStaffCard(User user)
        {
            bool isAdmin = user.Role == Role.Admin;
            bool isCurrentUserAdmin = _currentUser.Role == Role.Admin;

            var card = new Panel
            {
                Height = 58,
                BackColor = AppTheme.ContentBackground,
                Cursor = Cursors.Hand,
                Tag = user
            };
            _paintHelper.AddRounding(card);

            var avatar = new Panel
            {
                Size = new Size(36, 36),
                Location = new Point(12, 11),
                BackColor = Color.Transparent
            };
            Color avatarColor = isAdmin
                ? AppTheme.PrimaryRed
                : Color.FromArgb(24, 95, 165);

            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(avatarColor);
                e.Graphics.FillEllipse(brush, 0, 0, 35, 35);

                string initials = _paintHelper.GetInitials(user.FullName);
                using var font = new Font("Segoe UI", 10, FontStyle.Bold);
                using var tb = new SolidBrush(AppTheme.PrimaryText);
                var sz = e.Graphics.MeasureString(initials, font);
                e.Graphics.DrawString(initials, font, tb,
                    (36 - sz.Width) / 2f, (36 - sz.Height) / 2f);
            };

            var lblName = new Label
            {
                Text = user.FullName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = AppTheme.PrimaryText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(58, 10)
            };

            var lblEmail = new Label
            {
                Text = user.Email,
                Font = AppTheme.FontSmaller,
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(58, 30)
            };

            // Store the badge color BEFORE adding the Paint handler
            Color badgeBgColor = isAdmin
                ? Color.FromArgb(35, 192, 57, 43)
                : Color.FromArgb(35, 24, 95, 165);

            var lblBadge = new Label
            {
                Text = isAdmin ? "Admin" : "Operator",
                Font = AppTheme.FontSmall,
                ForeColor = isAdmin ? AppTheme.BloodRed : Color.FromArgb(55, 138, 221),
                BackColor = Color.Transparent,
                AutoSize = true,
                Padding = new Padding(6, 2, 6, 2),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            lblBadge.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(badgeBgColor);
                using var path = GetRoundedPath(new Rectangle(0, 0, lblBadge.Width - 1, lblBadge.Height - 1), 8);
                e.Graphics.FillPath(brush, path);
                TextRenderer.DrawText(e.Graphics, lblBadge.Text, lblBadge.Font,
                    new Rectangle(0, 0, lblBadge.Width, lblBadge.Height),
                    lblBadge.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            card.Controls.Add(avatar);
            card.Controls.Add(lblName);
            card.Controls.Add(lblEmail);
            card.Controls.Add(lblBadge);

            // Double-click event handler
            EventHandler card_DoubleClick = (s, e) =>
            {
                Control ctrl = (Control)s;
                while (ctrl != null && !(ctrl.Tag is User))
                    ctrl = ctrl.Parent;
                if (ctrl?.Tag is User selectedUser)
                    OpenUserFormForEditing(selectedUser);
            };

            card.DoubleClick += card_DoubleClick;
            lblName.DoubleClick += card_DoubleClick;
            lblEmail.DoubleClick += card_DoubleClick;

            // Create Update button (visible for all users if current user is Admin)
            var btnUpdate = new Button
            {
                Text = "Update",
                Size = new Size(62, 26),
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.PrimaryText,
                BackColor = AppTheme.PrimaryRed,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = user,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = isCurrentUserAdmin // Only show if current user is Admin
            };
            btnUpdate.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnUpdate.FlatAppearance.BorderSize = 1;
            btnUpdate.FlatAppearance.MouseOverBackColor = AppTheme.BrightRed;
            _paintHelper.AddRounding(btnUpdate, 4);

            btnUpdate.Click += (s, e) =>
            {
                OpenUserFormForEditing(user);
            };

            card.Controls.Add(btnUpdate);

            Button btnDelete = null;
            if (!isAdmin && isCurrentUserAdmin) // Only show delete for operators and if current user is Admin
            {
                btnDelete = new Button
                {
                    Text = "Delete",
                    Size = new Size(62, 26),
                    Font = AppTheme.FontSmall,
                    ForeColor = AppTheme.ErrorRed,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = user.Id,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                btnDelete.FlatAppearance.BorderColor = AppTheme.BorderColor;
                btnDelete.FlatAppearance.BorderSize = 1;
                btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 192, 57, 43);
                _paintHelper.AddRounding(btnDelete, 4);

                btnDelete.Click += (s, e) =>
                {
                    var result = MessageBox.Show(
                        $"Delete operator '{user.FullName}'?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _authService.DeleteUser(user.Id);
                        LoadStaff();
                    }
                };

                card.Controls.Add(btnDelete);
            }

            // Position buttons and badge responsively
            card.Layout += (s, e) =>
            {
                int rightMargin = 12;
                int buttonWidth = 62;
                int buttonSpacing = 8;

                if (btnDelete != null)
                {
                    // Both Update and Delete buttons
                    btnUpdate.Location = new Point(card.Width - (buttonWidth * 2 + buttonSpacing + rightMargin), 16);
                    btnDelete.Location = new Point(card.Width - (buttonWidth + rightMargin), 16);
                    lblBadge.Location = new Point(card.Width - (buttonWidth * 2 + buttonSpacing + 70 + rightMargin), 18);
                }
                else
                {
                    // Only Update button
                    btnUpdate.Location = new Point(card.Width - (buttonWidth + rightMargin), 16);
                    lblBadge.Location = new Point(card.Width - (buttonWidth + 70 + rightMargin), 18);
                }
            };

            return card;
        }


        private void BtnAddOperator_Click(object sender, EventArgs e)
        {

            var form = new UserForm(_authService, _currentUser);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadStaff();
            }
        }

        private void OpenUserFormForEditing(User selectedUser)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("No user selected.");
                return;
            }

           
            var form = new UserForm(_authService, _currentUser, FormMode.Edit, selectedUser);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
                LoadStaff();
        }

        private static GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}