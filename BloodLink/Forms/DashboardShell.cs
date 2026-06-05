using BloodLink.Core.Database;
using BloodLink.Helpers;
using BloodLink.Core.Models;
using BloodLink.Pages;
using BloodLink.Services;
using System.Drawing;
using System.Drawing.Drawing2D;
using Timer =  System.Windows.Forms.Timer;
using BloodLink.Core.Interfaces;

namespace BloodLink.Forms
{
    public partial class DashboardShell : Form
    {
        private readonly BloodUnitService _unitService = new BloodUnitService();
        private readonly IAppSettingRepository _appSettingRepository = new AppSettingsRepository();
        private readonly Dictionary<Type, UserControl> _views = new Dictionary<Type, UserControl>();
        private Timer _expiryTimer;
        private readonly LoginForm _loginForm;
        private readonly User _currentUser;
        private Button _activeNavButton;
        private System.Windows.Forms.Timer _sessionTimer;
        private DateTime _lastActivityTime = DateTime.Now;
        private List<(string icon, string label, Action onClick)> _navItems;

        private Label _pageTitle;
        private Panel _themeTogglePanel;
        private bool _isAnimating = false;

        public DashboardShell(User user, LoginForm form)
        {
            InitializeComponent();
            _currentUser = user;
            _loginForm = form;
            ApplyTheme();
            BuildNavItems();
            BuildSidebarContent();
            BuildHeaderContent();
            LoadDefaultPage();
            CheckAndExpireUnits();
            LoadSavedSettings();
        }
        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;
            pnlSidebar.BackColor = AppTheme.SidebarBackground;
            pnlHeader.BackColor = AppTheme.CardBackground;
            pnlContent.BackColor = AppTheme.MainBackground;
        }

        // ─────────────────────────────────────────────────
        // NAV ITEMS
        // ─────────────────────────────────────────────────
        private void BuildNavItems()
        {
            if (_currentUser.Role == Role.Admin)
            {
                _navItems = new List<(string, string, Action)>
        {
            ("⊞", "Dashboard",        () => LoadPage("Dashboard")),
            ("♥", "Donors",           () => LoadPage("Donors")),
            ("✦", "Blood Inventory",  () => LoadPage("Inventory")),
            ("☻", "Patients",         () => LoadPage("Patients")),
            ("▤", "Reports",          () => LoadPage("Reports")),
            ("☺", "Staff",            () => LoadPage("Staff")),
            ("✿", "Settings",         () => LoadPage("Settings")),
        };
            }
            else // Operator
            {
                _navItems = new List<(string, string, Action)>
        {
            ("⊞", "Dashboard",        () => LoadPage("Dashboard")),
            ("♥", "Donors",           () => LoadPage("Donors")),
            ("✦", "Blood Inventory",  () => LoadPage("Inventory")),
            ("☻", "Patients",         () => LoadPage("Patients")),
        };
            }
        }

        // ─────────────────────────────────────────────────
        // SIDEBAR CONTENT
        // ─────────────────────────────────────────────────
        private void BuildSidebarContent()
        {
            pnlSidebar.Controls.Clear();
            _activeNavButton = null;

            // ── Logo area ──────────────────────────────
            var pnlLogo = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(AppTheme.SidebarWidth, 70),
                BackColor = Color.Transparent
            };

            var lblLogo = new Label
            {
                Text = "🩸 BloodLink",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = AppTheme.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };
            lblLogo.Location = new Point(
                (pnlLogo.Width - lblLogo.PreferredWidth) / 2, 22);
            pnlLogo.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(pnlLogo);

            // ── Divider ────────────────────────────────
            var divider = new Panel
            {
                Location = new Point(16, 70),
                Size = new Size(AppTheme.SidebarWidth - 32, 1),
                BackColor = AppTheme.BorderColor
            };
            pnlSidebar.Controls.Add(divider);

            // ── Menu label ─────────────────────────────
            var lblMenu = new Label
            {
                Text = "MAIN MENU",
                Font = new Font("Segoe UI", 7, FontStyle.Bold),
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(20, 84)
            };
            pnlSidebar.Controls.Add(lblMenu);

            // ── Nav buttons ────────────────────────────
            int yPos = 106;
            foreach (var (icon, label, onClick) in _navItems)
            {
                var btn = CreateNavButton(icon, label, onClick);
                btn.Location = new Point(10, yPos);
                pnlSidebar.Controls.Add(btn);
                yPos += 48;

                if (_activeNavButton == null)
                    SetActiveNav(btn);
            }

            // ── User card ──────────────────────────────
            BuildSidebarUserCard();
        }

        private Button CreateNavButton(string icon, string label, Action onClick)
        {
            var btn = new Button
            {
                // Empty text — we draw text manually in Paint
                Text = "",
                Size = new Size(AppTheme.SidebarWidth - 20, 40),
                Font = new Font("Segoe UI", 10),
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand,
                Tag = label
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btn.Paint += (s, e) =>
            {
                var b = (Button)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                bool isActive = b == _activeNavButton;
                bool isHover = b.ClientRectangle.Contains(
                    b.PointToClient(Cursor.Position));

                // ── Draw rounded background ────────────────
                if (isActive)
                {
                    using var brush = new SolidBrush(AppTheme.PrimaryRed);
                    FillRoundedRect(e.Graphics, brush,
                        new Rectangle(0, 0, b.Width - 1, b.Height - 1), 10);
                }
                else if (isHover)
                {
                    using var brush = new SolidBrush(AppTheme.SurfaceHover);
                    FillRoundedRect(e.Graphics, brush,
                        new Rectangle(0, 0, b.Width - 1, b.Height - 1), 10);
                }

                // ── Draw icon ──────────────────────────────
                Color textColor = isActive ? AppTheme.White : AppTheme.MutedText;
                using var iconFont = new Font("Segoe UI", 11);
                using var iconBrush = new SolidBrush(textColor);
                e.Graphics.DrawString(icon, iconFont, iconBrush,
                    new RectangleF(12, 0, 28, b.Height),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                // ── Draw label text ────────────────────────
                using var textFont = new Font("Segoe UI", 10);
                using var textBrush = new SolidBrush(textColor);
                e.Graphics.DrawString(label, textFont, textBrush,
                    new RectangleF(44, 0, b.Width - 44, b.Height),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    });
            };

            btn.MouseEnter += (s, e) => btn.Invalidate();
            btn.MouseLeave += (s, e) => btn.Invalidate();

            var capturedBtn = btn;
            var capturedAction = onClick;
            btn.Click += (s, e) =>
            {
                SetActiveNav(capturedBtn);
                capturedAction();
            };

            return btn;
        }
        private void SetActiveNav(Button btn)
        {
            if (_activeNavButton != null)
                _activeNavButton.Invalidate();

            _activeNavButton = btn;
            btn.Invalidate();
        }

        private void BuildSidebarUserCard()
        {
            var userCard = new Panel
            {
                Size = new Size(AppTheme.SidebarWidth - 20, 60),
                Location = new Point(10, pnlSidebar.Height - 72),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };

            // Rounded card background via paint
            userCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(AppTheme.Surface);
                FillRoundedRect(e.Graphics, brush,
                    new Rectangle(0, 0, userCard.Width - 1, userCard.Height - 1), 12);
            };

            // Avatar circle
            var avatar = new Panel
            {
                Size = new Size(36, 36),
                Location = new Point(12, 12),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(AppTheme.PrimaryRed);
                e.Graphics.FillEllipse(brush, 0, 0, 35, 35);
                string initials = GetInitials(_currentUser.FullName);
                using var font = new Font("Segoe UI", 11, FontStyle.Bold);
                using var textBrush = new SolidBrush(AppTheme.White);
                var sz = e.Graphics.MeasureString(initials, font);
                e.Graphics.DrawString(initials, font, textBrush,
                    (36 - sz.Width) / 2, (36 - sz.Height) / 2);
            };

            var lblName = new Label
            {
                Text = TruncateText(_currentUser.FullName, 14),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = AppTheme.PrimaryText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(56, 12)
            };

            var lblRole = new Label
            {
                Text = _currentUser.Role == Role.Admin ? "Administrator"
                                            : _currentUser.Role.ToString(),
                Font = new Font("Segoe UI", 8),
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(56, 30)
            };

            userCard.Controls.Add(avatar);
            userCard.Controls.Add(lblName);
            userCard.Controls.Add(lblRole);
            pnlSidebar.Controls.Add(userCard);
        }

        // ─────────────────────────────────────────────────
        // HEADER CONTENT
        // ─────────────────────────────────────────────────
        private void BuildHeaderContent()
        {
            pnlHeader.Controls.Clear();

            // ── Page title ─────────────────────────────
            _pageTitle = new Label
            {
                Text = "Dashboard",
                Font = AppTheme.FontH2,
                ForeColor = AppTheme.PrimaryText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(28, 18)
            };
            pnlHeader.Controls.Add(_pageTitle);

            // ── Theme toggle pill ──────────────────────
            BuildThemeToggle();

            // ── User info ──────────────────────────────
            BuildHeaderUserInfo();

            // ── Bottom border ──────────────────────────
            var border = new Panel
            {
                Location = new Point(0, pnlHeader.Height - 1),
                Size = new Size(pnlHeader.Width, 1),
                BackColor = AppTheme.BorderColor,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlHeader.Controls.Add(border);
        }

        private void BuildThemeToggle()
        {
            // Pill container — shows both 🌙 and ☀️
            _themeTogglePanel = new Panel
            {
                Size = new Size(80, 32),
                Location = new Point(pnlHeader.Width - 280, 12),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Paint the pill background + sliding indicator
            _themeTogglePanel.Paint += ThemeTogglePanel_Paint;
            _themeTogglePanel.Click += ThemeToggle_Click;

            // Moon label (left side)
            var lblMoon = new Label
            {
                Text = "🌙",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(6, 7),
                Cursor = Cursors.Hand
            };
            lblMoon.Click += ThemeToggle_Click;

            // Sun label (right side)
            var lblSun = new Label
            {
                Text = "☀",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(46, 7),
                Cursor = Cursors.Hand
            };
            lblSun.Click += ThemeToggle_Click;

            _themeTogglePanel.Controls.Add(lblMoon);
            _themeTogglePanel.Controls.Add(lblSun);
            pnlHeader.Controls.Add(_themeTogglePanel);
        }

        private void ThemeTogglePanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Pill background
            using var bgBrush = new SolidBrush(AppTheme.Surface);
            FillRoundedRect(g, bgBrush,
                new Rectangle(0, 0, _themeTogglePanel.Width - 1,
                              _themeTogglePanel.Height - 1), 16);

            // Sliding indicator position
            // Dark mode → indicator on left (moon side)
            // Light mode → indicator on right (sun side)
            int indicatorX = AppTheme.IsDarkMode ? 2 : 42;

            using var indicatorBrush = new SolidBrush(AppTheme.PrimaryRed);
            FillRoundedRect(g, indicatorBrush,
                new Rectangle(indicatorX, 2, 36, 28), 14);
        }

        private void BuildHeaderUserInfo()
        {
            var pnlUser = new Panel
            {
                Size = new Size(180, AppTheme.HeaderHeight),
                Location = new Point(pnlHeader.Width - 180, 0),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Avatar circle
            var avatar = new Panel
            {
                Size = new Size(32, 32),
                Location = new Point(8, 12),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(AppTheme.PrimaryRed);
                e.Graphics.FillEllipse(brush, 0, 0, 31, 31);
                string initials = GetInitials(_currentUser.FullName);
                using var font = new Font("Segoe UI", 9, FontStyle.Bold);
                using var tb = new SolidBrush(AppTheme.White);
                var sz = e.Graphics.MeasureString(initials, font);
                e.Graphics.DrawString(initials, font, tb,
                    (32 - sz.Width) / 2, (32 - sz.Height) / 2);
            };

            var lblName = new Label
            {
                Text = TruncateText(_currentUser.FullName, 14),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = AppTheme.PrimaryText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(48, 10)
            };

            var lblRole = new Label
            {
                Text = _currentUser.Role == Role.Admin ? "Administrator"
                                            : _currentUser.Role.ToString(),
                Font = new Font("Segoe UI", 8),
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(48, 28)
            };

            var btnLogout = new Button
            {
                Text = "⏻",
                Size = new Size(28, 28),
                Location = new Point(148, 14),
                Font = new Font("Segoe UI", 10),
                ForeColor = AppTheme.ErrorRed,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += LogoutBtn_Click;

            pnlUser.Controls.Add(avatar);
            pnlUser.Controls.Add(lblName);
            pnlUser.Controls.Add(lblRole);
            pnlUser.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(pnlUser);
        }

        // ─────────────────────────────────────────────────
        // PAGE LOADING
        // ─────────────────────────────────────────────────

        private void ShowView<T>(Func<T> factory) where T : UserControl
        {
            var key = typeof(T);

            if (!_views.TryGetValue(key, out var view))
            {
                view = factory();
                view.Dock = DockStyle.Fill;
                _views[key] = view;
            }

            // Remove old views safely from the layout panel
            while (pnlContent.Controls.Count > 0)
            {
                pnlContent.Controls.RemoveAt(0);
            }

            // Add current view to the panel layout
            pnlContent.Controls.Add(view);

            // CRITICAL FIX: If the page supports refreshing, force it to reload data right now
            if (view is IRefreshablePage refreshablePage)
            {
                refreshablePage.RefreshPageData();
            }
        }
        private void LoadPage(string pageName)
        {
            if (_pageTitle != null)
            {
                _pageTitle.Text = pageName switch
                {
                    "Dashboard" => "Dashboard",
                    "Donors" => "Donors",
                    "Inventory" => "Blood Inventory",
                    "Patients" => "Patients",
                    "Reports" => "Reports",
                    "Staff" => "Staff Management",
                    "Settings" => "Settings",
                    _ => pageName
                };
            }

            switch (pageName)
            {
                case "Dashboard":
                    ShowView(() => new AdminDashboardPage());
                    break;

                case "Donors":
                    ShowView(() => new DonorPage(new DonorService(), _currentUser));
                    break;

                case "Inventory":
                    ShowView(() => new BloodUnitPage(new BloodUnitService(), _currentUser));
                    break;

                case "Patients":
                    ShowView(() => new PatientsPage(new PatientRequestService(), _currentUser));
                    break;

                case "Reports":
                    ShowView(() => new ReportsPage());
                    break;

                case "Staff":
                    ShowView(() => new StaffPage(new AuthService(), _currentUser));
                    break;

                case "Settings":
                    ShowView(() => new SettingPage(this));
                    break;
            }
        }

        private void LoadDefaultPage() => LoadPage("Dashboard");

        // ─────────────────────────────────────────────────
        // EVENT HANDLERS
        // ─────────────────────────────────────────────────
        private void ThemeToggle_Click(object sender, EventArgs e)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            // Animate the sliding indicator
            bool targetDark = !AppTheme.IsDarkMode;
            int startX = AppTheme.IsDarkMode ? 2 : 42;
            int endX = AppTheme.IsDarkMode ? 42 : 2;
            int currentX = startX;

            var animTimer = new System.Windows.Forms.Timer { Interval = 12 };
            animTimer.Tick += (s, ev) =>
            {
                int step = AppTheme.IsDarkMode ? 4 : -4;
                currentX += step;

                bool done = AppTheme.IsDarkMode
                    ? currentX >= endX
                    : currentX <= endX;

                if (done)
                {
                    animTimer.Stop();
                    _isAnimating = false;

                    // Apply theme after animation completes
                    AppTheme.ToggleTheme();
                    _activeNavButton = null;
                    ApplyTheme();
                    BuildSidebarContent();
                    BuildHeaderContent();
                    LoadDefaultPage();
                }
                else
                {
                    _themeTogglePanel?.Invalidate();
                }
            };

            animTimer.Start();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                 _loginForm.ResetFields();

                _loginForm.Show();

                this.Dispose(); 
                this.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // If the user closed the form by clicking the 'X' button or via Alt+F4, 
            // shut down the entire application pool.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void FillRoundedRect(Graphics g, Brush brush,
                                     Rectangle rect, int radius)
        {
            using var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y,
                        radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2,
                        radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2,
                        radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        // ─────────────────────────────────────────────────
        // UTILITY HELPERS
        // ─────────────────────────────────────────────────
        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "?";
            var parts = fullName.Trim().Split(' ');
            if (parts.Length == 1) return parts[0][0].ToString().ToUpper();
            return $"{parts[0][0]}{parts[^1][0]}".ToUpper();
        }

        private string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= maxLength ? text : text[..maxLength] + "...";
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (pnlSidebar != null)
                pnlSidebar.Height = this.ClientSize.Height;
        }

        private void CheckAndExpireUnits()
        {
            _unitService.CheckAndExpireUnits();
            _expiryTimer = new Timer();
            _expiryTimer.Interval = 60 * 60 * 1000;
            _expiryTimer.Tick += (s, e) => _unitService.CheckAndExpireUnits();
            _expiryTimer.Start();
        }

        private void LoadSavedSettings()
        {
            string? saved = _appSettingRepository.GetSetting("SessionTimeout");
            if (saved != null && Enum.TryParse<SessionTimeout>(saved, out var timeout))
                ApplySessionTimeout(timeout);
        }

        public void ApplySessionTimeout(SessionTimeout timeout)
        {
            if (_sessionTimer != null)
            {
                _sessionTimer.Stop();
                _sessionTimer.Dispose();
                _sessionTimer = null;
            }

            if (timeout == SessionTimeout.Never) return;

            int minutes = (int)timeout;

            this.MouseMove += (s, e) => _lastActivityTime = DateTime.Now;
            this.KeyDown += (s, e) => _lastActivityTime = DateTime.Now;
            this.MouseClick += (s, e) => _lastActivityTime = DateTime.Now;

            _sessionTimer = new System.Windows.Forms.Timer();
            _sessionTimer.Interval = 30 * 1000;
            _sessionTimer.Tick += (s, e) =>
            {
                double idleMinutes = (DateTime.Now - _lastActivityTime).TotalMinutes;
                if (idleMinutes >= minutes)
                {
                    _sessionTimer.Stop();
                    MessageBox.Show(
                        "Your session has expired due to inactivity.",
                        "Session Expired",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    _loginForm.Show();
                    this.Close();
                }
            };
            _sessionTimer.Start();
        }
    }
}