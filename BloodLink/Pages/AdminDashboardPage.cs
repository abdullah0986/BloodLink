using BloodLink.Helpers;
using BloodLink.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using BloodLink.Database;
using BloodLink.Services;
using System.Net;
using System.Windows.Forms;

namespace BloodLink.Pages
{
    public partial class AdminDashboardPage : UserControl
    {
        public AdminDashboardPage()
        {
            InitializeComponent();
            ApplyTheme();
            loadData();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;
            tblDashboard.BackColor = AppTheme.MainBackground;
            tblFirstRow.BackColor = AppTheme.MainBackground;
            tblSecondRow.BackColor = AppTheme.MainBackground;

            // Stat card Total Donors
            StyleStatCard(
                pnlTotalDonor, pbDonorIcon,
                lblTotalDonor, lblTotalDonorCount, lblTotalDonorInfo,
                AppTheme.TotalDonorIconColor
            );

            // ── Stat card 2 — Blood Units ──────────────
            StyleStatCard(
                pnlBloodUnits, pbBloodUnits,
                lblBloodUnits, lblBloodUnitsCount, lblBloodUnitsInfo,
                AppTheme.BloodUnitsIconColor
            );

            // ── Stat card 3 — Patients Today ───────────
            StyleStatCard(
                pnlPatientToday, pbPatientsToday,
                lblPatientToday, lblPatientTodayCount, lblPatientTodayInfo,
                AppTheme.PatientsTodayIconColor
            );

            // ── Stat card 4 — Expiring Soon ────────────
            StyleStatCard(
                pnlExpiringSoon, pbExpiringSoon,
                lblExpiringSoon, lblExpiringSoonCount, lblExpiringSoonInfo,
                AppTheme.ExpiringSoonIconColor
            );

            // ── Blood breakdown card ───────────────────
            pnlBloodBreakdown.BackColor = AppTheme.ContentBackground;
            tblBloodBreakdown.BackColor = AppTheme.ContentBackground;
            lblBloodBreakdown.ForeColor = AppTheme.PrimaryText;
            lblBloodBreakdown.Font = AppTheme.FontButton;
            AddRounding(pnlBloodBreakdown);

            StyleBloodChips();

            // ── Expiring units card
            panel1.BackColor = AppTheme.ContentBackground;
            panel1.BorderStyle = BorderStyle.None;
            lblExpiringUnits.ForeColor = AppTheme.PrimaryText;
            lblExpiringUnits.Font = AppTheme.FontButton;
            AddRounding(panel1);

            dgvExpiringUnits.BackgroundColor = AppTheme.ContentBackground;
            dgvExpiringUnits.GridColor = AppTheme.CardBackground;
            dgvExpiringUnits.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvExpiringUnits.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvExpiringUnits.DefaultCellStyle.Font = AppTheme.FontSmall;
            dgvExpiringUnits.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvExpiringUnits.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvExpiringUnits.CurrentCell = null;
            dgvExpiringUnits.ClearSelection();

            // ── Patient requests card ──────────────────
            pnlPatientRequests.BackColor = AppTheme.ContentBackground;
            lblPatientRequests.ForeColor = AppTheme.PrimaryText;
            lblPatientRequests.Font = AppTheme.FontButton;
            AddRounding(pnlPatientRequests);

            dgvPatientRequests.BackgroundColor = AppTheme.ContentBackground;
            dgvPatientRequests.GridColor = AppTheme.CardBackground;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.MutedText;
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgvPatientRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.ContentBackground;
            dgvPatientRequests.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvPatientRequests.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvPatientRequests.DefaultCellStyle.Font = AppTheme.FontSmall;
            dgvPatientRequests.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvPatientRequests.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvPatientRequests.CurrentCell = null;
            dgvPatientRequests.ClearSelection();
            dgvPatientRequests.Paint -= DgvHeaderLine_Paint;
            dgvPatientRequests.Paint += DgvHeaderLine_Paint;
        }

        private void StyleStatCard(
            Panel panel,
            FontAwesome.Sharp.IconPictureBox icon,
            Label title, Label count, Label info,
            Color iconColor)
        {
            panel.BackColor = AppTheme.ContentBackground;
            icon.IconColor = iconColor;
            title.ForeColor = AppTheme.MutedText;
            title.Font = AppTheme.FontLabel;
            count.ForeColor = AppTheme.PrimaryText;
            count.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            info.ForeColor = AppTheme.MutedText;
            info.Font = AppTheme.FontSmall;
            AddRounding(panel);
        }

        private void StyleBloodChips()
        {
            StyleChip(pnlAPlus, tblAPlus, lblAPlus, lblAPlusCount, Color.FromArgb(255, 192, 57, 43), Color.FromArgb(34, 192, 57, 43));
            StyleChip(pnlAMinus, tblAMinus, lblAMinus, lblAMinusCount, Color.FromArgb(255, 160, 16, 4), Color.FromArgb(34, 116, 10, 3));
            StyleChip(pnlBPlus, tblBPlus, lblBPlus, lblBPlusCount, Color.FromArgb(255, 55, 138, 221), Color.FromArgb(34, 24, 95, 165));
            StyleChip(pnlBMinus, tblBMinus, lblBMinus, lblBMinusCount, Color.FromArgb(255, 29, 158, 117), Color.FromArgb(34, 15, 110, 86));
            StyleChip(pnlOPlus, tblOPlus, lblOPlus, lblOPlusCount, Color.FromArgb(255, 127, 119, 221), Color.FromArgb(34, 83, 52, 119));
            StyleChip(pnlOMinus, tblOMinus, lblOMinus, lblOMinusCount, Color.FromArgb(255, 99, 153, 34), Color.FromArgb(34, 59, 109, 17));
            StyleChip(pnlABPlus, tblABPlus, lblABPlus, lblABPlusCount, Color.FromArgb(255, 243, 156, 18), Color.FromArgb(34, 184, 134, 11));
            StyleChip(pnlABMinus, tblABMinus, lblABMinus, lblABMinusCount, Color.FromArgb(255, 212, 83, 126), Color.FromArgb(34, 153, 53, 86));
        }

        private void StyleChip(
            Panel panel, TableLayoutPanel tbl,
            Label groupLabel, Label countLabel,
            Color bloodColor, Color bloodBackColor)
        {
            panel.BackColor = AppTheme.CardBackground;
            tbl.BackColor = AppTheme.CardBackground;
            AddRoundingNoBorder(panel);

            groupLabel.BackColor = Color.Transparent;
            groupLabel.ForeColor = bloodColor;
            groupLabel.Font = AppTheme.FontHeader;
            groupLabel.Tag = (groupLabel.Text, bloodBackColor);
            groupLabel.Text = string.Empty;
            groupLabel.AutoSize = false;
            groupLabel.Dock = DockStyle.Fill;
            groupLabel.TextAlign = ContentAlignment.MiddleCenter;
            groupLabel.Paint -= LblBloodBadge_Paint;
            groupLabel.Paint += LblBloodBadge_Paint;

            countLabel.ForeColor = AppTheme.PrimaryText;
            countLabel.Font = AppTheme.FontButton;
            countLabel.BackColor = AppTheme.CardBackground;
            countLabel.Dock = DockStyle.Fill;
            countLabel.TextAlign = ContentAlignment.MiddleCenter;
            countLabel.Margin = Padding.Empty;
            countLabel.Padding = Padding.Empty;
            countLabel.Anchor = AnchorStyles.None;
        }

        // ─────────────────────────────────────────────────
        // DUMMY DATA
        // ─────────────────────────────────────────────────
        private void loadData()
        {
            var donorService = new DonorService();
            DonorStats stats = donorService.GetDashboardStats();
            lblTotalDonorCount.Text = stats != null ? stats.TotalDonors.ToString() : "0";

            var bloodUnitService = new BloodUnitService();
            int totalBloodUnits = bloodUnitService.GetTotalBloodUnits();
            lblBloodUnitsCount.Text = totalBloodUnits.ToString() ?? "0";

            var patientRequestService = new PatientRequestService();
            int totalPatientToday = patientRequestService.GetAllPatientInDay();
            lblPatientTodayCount.Text = totalPatientToday.ToString() ?? "0";
            lblExpiringSoonCount.Text = "5";

            int expiringSoonCount = bloodUnitService.getExpiringSoonCount();
            lblExpiringSoonCount.Text = expiringSoonCount.ToString() ?? "0";

            int APlusCount = bloodUnitService.getBloodGroupCount(BloodGroup.APositive);
            lblAPlusCount.Text = APlusCount.ToString() ?? "0";
            int AMiusCount = bloodUnitService.getBloodGroupCount(BloodGroup.ANegative);
            lblAMinusCount.Text = AMiusCount.ToString() ?? "0";
            int BPlusCount = bloodUnitService.getBloodGroupCount(BloodGroup.BPositive);
            lblBPlusCount.Text = BPlusCount.ToString() ?? "0";
            int BMinusCount = bloodUnitService.getBloodGroupCount(BloodGroup.BNegative);
            lblBMinusCount.Text = BMinusCount.ToString() ?? "0";
            int OPlusCount = bloodUnitService.getBloodGroupCount(BloodGroup.OPositive);
            lblOPlusCount.Text = OPlusCount.ToString() ?? "0";
            int OMinusCount = bloodUnitService.getBloodGroupCount(BloodGroup.ONegative);
            lblOMinusCount.Text = OMinusCount.ToString() ?? "0";
            int ABPlusCount = bloodUnitService.getBloodGroupCount(BloodGroup.ABPositive);
            lblABPlusCount.Text = ABPlusCount.ToString() ?? "0";
            int ABMinusCount = bloodUnitService.getBloodGroupCount(BloodGroup.ABNegative);
            lblABMinusCount.Text = ABMinusCount.ToString() ?? "0";

            dgvExpiringUnits.Rows.Clear();
            Dictionary<string, int> expiringUnits = bloodUnitService.getExpiringUnits();
            foreach (var expiryUnit in expiringUnits)
            {
                dgvExpiringUnits.Rows.Add(expiryUnit.Key, $"{expiryUnit.Value} days");
            }



            dgvPatientRequests.Rows.Clear();
            var patientRequests = patientRequestService.GetRecentPatientRequests();
            foreach(var request in patientRequests)
            {
                dgvPatientRequests.Rows.Add(
                    request.patientName,
                    request.group.ToString(),
                    request.unitsRequired.ToString(),
                    request.doctorName,
                    request.status.ToString()
                );
            }

            dgvPatientRequests.Rows.Add("Ahmed Raza", "O+", "2", "Dr. Khan", "Pending");
            dgvPatientRequests.Rows.Add("Fatima Malik", "A+", "1", "Dr. Ali", "Fulfilled");
            dgvPatientRequests.Rows.Add("Usman Ali", "B-", "3", "Dr. Sana", "Pending");
            dgvPatientRequests.Rows.Add("Sara Khan", "AB+", "1", "Dr. Tariq", "Fulfilled");
            dgvPatientRequests.Rows.Add("Irfan Shah", "O-", "2", "Dr. Malik", "Cancelled");
        }

        // ─────────────────────────────────────────────────
        // PAINT HELPERS
        // ─────────────────────────────────────────────────
        public void AddRounding(Panel panel)
        {
            panel.Paint -= PnlRounding_Paint;
            panel.Paint += PnlRounding_Paint;
            panel.Resize -= PnlResize;
            panel.Resize += PnlResize;
        }

        private void AddRoundingNoBorder(Panel panel)
        {
            panel.Paint -= PnlRoundingNoBorder_Paint;
            panel.Paint += PnlRoundingNoBorder_Paint;
            panel.Resize -= PnlResize;
            panel.Resize += PnlResize;
        }

        private void PnlResize(object sender, EventArgs e)
        {
            ((Panel)sender).Invalidate();
        }

        private void DgvHeaderLine_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                int y = dgv.ColumnHeadersHeight - 1;
                using var pen = new Pen(Color.FromArgb(160, AppTheme.BorderColor), 2f);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.DrawLine(pen, new Point(0, y), new Point(dgv.ClientSize.Width, y));
            }
        }

        public void PnlRounding_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            if (pnl.Width <= 0 || pnl.Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            using GraphicsPath path = GetRoundedPath(rect, 12);

            pnl.Region = new Region(path);

            using SolidBrush bg = new SolidBrush(pnl.BackColor);
            g.FillPath(bg, path);

            Rectangle borderRect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using GraphicsPath borderPath = GetRoundedPath(borderRect, 12);
            using Pen borderPen = new Pen(AppTheme.BorderColor, 1);
            g.DrawPath(borderPen, borderPath);
        }

        // paint rounded background without border (for small chips)
        private void PnlRoundingNoBorder_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            if (pnl.Width <= 0 || pnl.Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            using GraphicsPath path = GetRoundedPath(rect, 8);

            pnl.Region = new Region(path);

            using SolidBrush bg = new SolidBrush(pnl.BackColor);
            g.FillPath(bg, path);
        }

        private void LblBloodBadge_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // badge is a small pill/circle centered at the top of the label
            int w = lbl.Width + 5;
            int h = lbl.Height + 5;
            // draw small circular badge centered near top
            int badgeSize = Math.Min(28, Math.Min(w - 8, h - 8));
            int bx = (w - badgeSize) / 2;
            int by = 6;
            Rectangle badgeRect = new Rectangle(bx, by, badgeSize, badgeSize);
            using GraphicsPath badgePath = new GraphicsPath();
            badgePath.AddEllipse(badgeRect);

            // retrieve stored text and badge background color from Tag
            string text;
            Color badgeColor;
            if (lbl.Tag is ValueTuple<string, Color> vt)
            {
                text = vt.Item1 ?? string.Empty;
                badgeColor = vt.Item2;
            }
            else
            {
                text = lbl.Text ?? string.Empty;
                badgeColor = lbl.BackColor;
            }

            using SolidBrush brush = new SolidBrush(badgeColor);
            g.FillPath(brush, badgePath);

            TextRenderer.DrawText(g, text, lbl.Font, badgeRect, lbl.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        // ─────────────────────────────────────────────────
        // EMPTY EVENT HANDLERS
        // ─────────────────────────────────────────────────
        private void lblTotalDonor_Click(object sender, EventArgs e) { }
        private void lblPatientTodayCount_Click(object sender, EventArgs e) { }
        private void lblPatientTodayInfo_Click(object sender, EventArgs e) { }
    }
}