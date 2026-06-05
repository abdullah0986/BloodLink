using BloodLink.Core.Database;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using BloodLink.Helpers;
using BloodLink.Services;
using System.Drawing.Drawing2D;

namespace BloodLink.Pages
{
    public partial class AdminDashboardPage : UserControl, IRefreshablePage
    {
        private readonly DonorService _donorService = new DonorService();
        private readonly DonorService donorService = new DonorService();
        private readonly BloodUnitService bloodUnitService = new BloodUnitService();
        private readonly PatientRequestService patientRequestService = new PatientRequestService();
        private readonly IAppSettingRepository _appSettingRepository = new AppSettingsRepository();
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private bool _allowSelection = false;
        public AdminDashboardPage()
        {
            InitializeComponent();
            ApplyTheme();
            _ = LoadDataAsync();

            this.HandleCreated += AdminDashboardPage_HandleCreated;
            dgvExpiringUnits.SelectionChanged += (s, e) => {
                if (!_allowSelection) dgvExpiringUnits.ClearSelection();
            };
            dgvPatientRequests.SelectionChanged += (s, e) => {
                if (!_allowSelection) dgvPatientRequests.ClearSelection();
            };
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;

            StyleStatCard(
                pnlTotalDonor, pbDonorIcon,
                lblTotalDonor, lblTotalDonorCount, lblTotalDonorInfo,
                AppTheme.TotalDonorIconColor
            );

            StyleStatCard(
                pnlBloodUnits, pbBloodUnits,
                lblBloodUnits, lblBloodUnitsCount, lblBloodUnitsInfo,
                AppTheme.BloodUnitsIconColor
            );

            StyleStatCard(
                pnlPatientToday, pbPatientsToday,
                lblPatientToday, lblPatientTodayCount, lblPatientTodayInfo,
                AppTheme.PatientsTodayIconColor
            );

            StyleStatCard(
                pnlExpiringSoon, pbExpiringSoon,
                lblExpiringSoon, lblExpiringSoonCount, lblExpiringSoonInfo,
                AppTheme.ExpiringSoonIconColor
            );

            pnlBloodBreakdown.BackColor = AppTheme.ContentBackground;
            tblBloodBreakdown.BackColor = AppTheme.ContentBackground;
            lblBloodBreakdown.ForeColor = AppTheme.PrimaryText;
            lblBloodBreakdown.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(pnlBloodBreakdown);

            StyleBloodChips();

            panel1.BackColor = AppTheme.ContentBackground;
            panel1.BorderStyle = BorderStyle.None;
            lblExpiringUnits.ForeColor = AppTheme.PrimaryText;
            lblExpiringUnits.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(panel1);

            dgvExpiringUnits.BackgroundColor = AppTheme.ContentBackground;
            dgvExpiringUnits.GridColor = AppTheme.CardBackground;
            dgvExpiringUnits.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvExpiringUnits.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvExpiringUnits.DefaultCellStyle.Font = AppTheme.FontSmall;
            dgvExpiringUnits.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvExpiringUnits.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvExpiringUnits.CurrentCell = null;
            dgvExpiringUnits.ClearSelection();

            pnlPatientRequests.BackColor = AppTheme.ContentBackground;
            lblPatientRequests.ForeColor = AppTheme.PrimaryText;
            lblPatientRequests.Font = AppTheme.FontButton;
            _paintHelper.AddRounding(pnlPatientRequests);

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
            dgvPatientRequests.Paint -= PaintHelper.DgvHeaderLine_Paint;
            dgvPatientRequests.Paint += PaintHelper.DgvHeaderLine_Paint;
            _paintHelper.AddClickEventToAllControls(this, dgvExpiringUnits);
            _paintHelper.AddClickEventToAllControls(this, dgvPatientRequests);
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
            _paintHelper.AddRounding(panel);
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

        public async Task LoadDataAsync()
        {
            await loadData();
        }
        public void RefreshPageData()
        {
            _allowSelection = false;
            _ = LoadDataAsync();
            _allowSelection = true;
        }
        private async Task loadData()
        {
            DonorStats stats = await donorService.GetDonorStatsAsync();
            lblTotalDonorCount.Text = stats != null ? stats.TotalDonors.ToString() : "0";
            string donorThisMonth = _donorService.DonorsThisMonth().ToString();
            lblTotalDonorInfo.Text = $"+{donorThisMonth} this month";

            var bloodUnitStats = await bloodUnitService.GetBloodUnitStatsAsync();
            lblBloodUnitsCount.Text = bloodUnitStats.TotalUnits.ToString() ?? "0";

            int totalPatientToday = await patientRequestService.GetAllPatientInDayAsync();
            lblPatientTodayCount.Text = totalPatientToday.ToString() ?? "0";
            int patientsPendingToday = await patientRequestService.GetPatientsPendingTodayAsync();
            lblPatientTodayInfo.Text = $"{patientsPendingToday} in Pending";

            int expiringSoonCount = await bloodUnitService.getExpiringSoonCountAsync();
            lblExpiringSoonCount.Text = expiringSoonCount.ToString() ?? "0";
            string withInDays = _appSettingRepository.GetSetting("ExpiryThreshold");
            lblExpiringSoonInfo.Text = $"within {withInDays} days";

            int APlusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.APositive);
            lblAPlusCount.Text = APlusCount.ToString() ?? "0";
            int AMiusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.ANegative);
            lblAMinusCount.Text = AMiusCount.ToString() ?? "0";
            int BPlusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.BPositive);
            lblBPlusCount.Text = BPlusCount.ToString() ?? "0";
            int BMinusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.BNegative);
            lblBMinusCount.Text = BMinusCount.ToString() ?? "0";
            int OPlusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.OPositive);
            lblOPlusCount.Text = OPlusCount.ToString() ?? "0";
            int OMinusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.ONegative);
            lblOMinusCount.Text = OMinusCount.ToString() ?? "0";
            int ABPlusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.ABPositive);
            lblABPlusCount.Text = ABPlusCount.ToString() ?? "0";
            int ABMinusCount = await bloodUnitService.getBloodGroupCountAsync(BloodGroup.ABNegative);
            lblABMinusCount.Text = ABMinusCount.ToString() ?? "0";

            dgvExpiringUnits.Rows.Clear();
            Dictionary<string, int> expiringUnits = await bloodUnitService.getExpiringUnitsAsync();
            foreach (var expiryUnit in expiringUnits)
            {
                dgvExpiringUnits.Rows.Add(expiryUnit.Key, $"{expiryUnit.Value} days");
            }

            dgvPatientRequests.Rows.Clear();
            var patientRequests = await patientRequestService.GetRecentPatientRequestsAsync();
            foreach (var request in patientRequests)
            {
                int rowIndex = dgvPatientRequests.Rows.Add(
                    request.patientName,
                    request.group.ToString(),
                    request.unitsRequired.ToString(),
                    string.IsNullOrWhiteSpace(request.doctorName) ? "N/A" : request.doctorName,
                    request.status.ToString()
                );
                dgvPatientRequests.Rows[rowIndex].Tag = request;  
            }

            dgvPatientRequests.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var row = dgvPatientRequests.Rows[e.RowIndex];
                string status = row.Cells["colStatus"].Value?.ToString();
                bool isOldPending = status == "Pending" &&
                                    row.Tag is PatientModel m &&
                                    m.CreatedAt.Date < DateTime.Today;

                if (isOldPending)
                {
                    e.CellStyle.BackColor = AppTheme.OldPatientRecords;
                }
            };

            dgvExpiringUnits.CurrentCell = null;
            dgvExpiringUnits.ClearSelection();

            dgvPatientRequests.CurrentCell = null;
            dgvPatientRequests.ClearSelection();
        }

        private void AdminDashboardPage_HandleCreated(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                dgvExpiringUnits.ClearSelection();
                dgvExpiringUnits.CurrentCell = null;

                dgvPatientRequests.ClearSelection();
                dgvPatientRequests.CurrentCell = null;

                _allowSelection = true;
            }));
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

            int w = lbl.Width + 5;
            int h = lbl.Height + 5;
            int badgeSize = Math.Min(28, Math.Min(w - 8, h - 8));
            int bx = (w - badgeSize) / 2;
            int by = 6;
            Rectangle badgeRect = new Rectangle(bx, by, badgeSize, badgeSize);
            using GraphicsPath badgePath = new GraphicsPath();
            badgePath.AddEllipse(badgeRect);

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

        private void lblTotalDonor_Click(object sender, EventArgs e) { }
        private void lblPatientTodayCount_Click(object sender, EventArgs e) { }
        private void lblPatientTodayInfo_Click(object sender, EventArgs e) { }

        private void pnlBloodBreakdown_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPatientRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPatientRequests.Columns["colStatus"]?.Index && e.Value != null)
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
    }
}