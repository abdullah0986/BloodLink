using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BloodLink.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            ApplyTheme();

        #if DEBUG
            txtEmail.Text = "admin@bloodlink.com";
            txtPassword.Text = "Admin@123";
        # endif
        }

        // ─────────────────────────────────────────────────
        // THEME — applies colors from AppTheme to controls
        // Called once on load, called again on theme toggle
        // ─────────────────────────────────────────────────
        private void ApplyTheme()
        {
            // ── Form ───────────────────────────────────
            this.BackColor = AppTheme.Background;

            // ── Left panel — gradient ──────────────────
            pnlLeft.BackColor = AppTheme.GradientStart;
            pnlLeft.Paint -= LeftPanel_Paint; // remove old handler first
            pnlLeft.Paint += LeftPanel_Paint;

            // ── Right panel ────────────────────────────
            pnlRight.BackColor = AppTheme.CardBackground;

            // ── Labels ─────────────────────────────────
            lblWelcome.ForeColor = AppTheme.PrimaryText;
            lblSubtitle.ForeColor = AppTheme.MutedText;
            lblEmail.ForeColor = AppTheme.BodyText;
            lblPassword.ForeColor = AppTheme.BodyText;
            lblError.ForeColor = AppTheme.ErrorRed;

            // ── Inputs ─────────────────────────────────
            txtEmail.BackColor = AppTheme.Surface;
            txtEmail.ForeColor = AppTheme.PrimaryText;
            txtPassword.BackColor = AppTheme.Surface;
            txtPassword.ForeColor = AppTheme.PrimaryText;

            // ── Button ─────────────────────────────────
            btnLogin.BackColor = AppTheme.PrimaryRed;
            btnLogin.ForeColor = AppTheme.White;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.MouseEnter -= BtnLogin_MouseEnter;
            btnLogin.MouseLeave -= BtnLogin_MouseLeave;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
        }

        // ─────────────────────────────────────────────────
        // PAINT EVENTS
        // ─────────────────────────────────────────────────
        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            using var brush = new LinearGradientBrush(
                pnlLeft.ClientRectangle,
                AppTheme.GradientStart,
                AppTheme.GradientEnd,
                LinearGradientMode.ForwardDiagonal
            );
            e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
        }

        // ─────────────────────────────────────────────────
        // EVENT HANDLERS
        // ─────────────────────────────────────────────────
        private void BtnLogin_MouseEnter(object sender, EventArgs e)
            => btnLogin.BackColor = AppTheme.BrightRed;

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
            => btnLogin.BackColor = AppTheme.PrimaryRed;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            var result = _authService.Login(email, password);

            if (!result.success)
            {
                lblError.Text = result.message;
                lblError.Visible = true;
                return;
            }

            OpenDashboard(result.user!);
        }

        private void OpenDashboard(User user)
        {
            this.Hide();
            var dashboard = new DashboardShell(user);
            dashboard.FormClosed += (s, e) => this.Close();
            dashboard.Show();
        }
    }
}