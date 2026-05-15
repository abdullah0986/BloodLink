using BloodLink.Helpers;
using BloodLink.Helpers;
using BloodLink.Models;
using BloodLink.Services;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BloodLink.Pages
{
    public partial class DonorPage : UserControl
    {

        private DonorService _DonorService;
        public DonorPage()
        {
            InitializeComponent();
            applyTheme();
            _DonorService = new DonorService();
            this.HandleCreated += DonorPage_HandleCreated;
            dgvDonors.SelectionChanged += dgvDonors_SelectionChanged;
        }

        private void applyTheme()
        {
            pnlTextBoxDonorSearch.BackColor = AppTheme.ContentBackground;
            AddRounding(pnlTextBoxDonorSearch);

            tbSearchDonor.BackColor = AppTheme.ContentBackground;
            tbSearchDonor.Font = AppTheme.FontSmall;
            tbSearchDonor.ForeColor = AppTheme.MutedText;

            cbBloodGroups.BackColor = AppTheme.ContentBackground;
            cbBloodGroups.ForeColor = AppTheme.PrimaryText;
            cbBloodGroups.Font = AppTheme.FontSmall;
            cbBloodGroups.TabStop = false;
            cbBloodGroups.DrawItem += cbStyling_DrawItem;

            cbStatus.BackColor = AppTheme.ContentBackground;
            cbStatus.ForeColor = AppTheme.PrimaryText;
            cbStatus.Font = AppTheme.FontSmall;
            cbStatus.TabStop = false;
            cbStatus.DrawItem += cbStyling_DrawItem;

            btnAddDonor.BackColor = AppTheme.PrimaryRed;
            btnAddDonor.ForeColor = AppTheme.PrimaryText;
            btnAddDonor.FlatAppearance.BorderColor = AppTheme.PrimaryRed;
            btnAddDonor.Font = AppTheme.FontSmall;

            pnlDgvDonorsStyling.BackColor = AppTheme.ContentBackground;
            AddRounding(pnlDgvDonorsStyling);

            dgvDonors.BackgroundColor = AppTheme.ContentBackground;
            dgvDonors.GridColor = AppTheme.CardBackground;
            dgvDonors.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.MutedText;
            dgvDonors.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontSmall;
            dgvDonors.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.ContentBackground;
            dgvDonors.DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.DefaultCellStyle.ForeColor = AppTheme.BodyText;
            dgvDonors.DefaultCellStyle.Font = AppTheme.FontSmall;
            dgvDonors.DefaultCellStyle.SelectionBackColor = AppTheme.SurfaceHover;
            dgvDonors.DefaultCellStyle.SelectionForeColor = AppTheme.PrimaryText;
            dgvDonors.Paint -= DgvHeaderLine_Paint;
            dgvDonors.Paint += DgvHeaderLine_Paint;

        }

        private void CbBloodGroups_DrawItem(object? sender, DrawItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DonorPage_HandleCreated(object sender, EventArgs e)
        {
            loadData();

            dgvDonors.ClearSelection();
            dgvDonors.CurrentCell = null;

            this.BeginInvoke(new Action(() =>
            {
                _allowSelection = true;
            }));
        }

        private bool _allowSelection = false;

        private void dgvDonors_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowSelection)
            {
                dgvDonors.ClearSelection();
            }
        }


        private void loadData()
        {
            dgvDonors.Rows.Insert(0, "");
            dgvDonors.Rows[0].Height = 10;
            dgvDonors.Rows[0].DefaultCellStyle.BackColor = AppTheme.ContentBackground;
            dgvDonors.Rows[0].ReadOnly = true;
            List<Donor> donors = _DonorService.GetAllDonors();
            foreach (Donor donor in donors)
            {
                dgvDonors.Rows.Add(
                    donor.FullName,
                    EnumHelper.GetDescription(donor.BloodGroup),
                    donor.Phone,
                    donor.City,
                    donor.LastDonationDate.HasValue ? donor.LastDonationDate.Value.ToString("yyyy-MM-dd") : "N/A",
                    donor.IsEligible ? "Yes" : "No"
                );
            }
            dgvDonors.CellFormatting += dgvDonors_CellFormatting;

            UpdateGridHeight();
            dgvDonors.Paint -= DgvHeaderLine_Paint;
            dgvDonors.Paint += DgvHeaderLine_Paint;
            dgvDonors.RowsAdded += (s, e) => UpdateGridHeight();

            populateBloodGroups();
            populateStatus();
            AddClickEventToAllControls(this);
        }

        private void populateBloodGroups()
        {

            var groups = Enum.GetValues(typeof(BloodGroup))
                .Cast<BloodGroup>()
                .Select(bg => new
                {
                    Text = EnumHelper.GetDescription(bg),
                    Value = (BloodGroup?)bg
                }).ToList();

            groups.Insert(0, new { Text = "All Groups", Value = (BloodGroup?)null });

            cbBloodGroups.DataSource = groups;
            cbBloodGroups.DisplayMember = "Text";
            cbBloodGroups.ValueMember = "Value";

            cbBloodGroups.SelectedIndex = 0;
        }

        private void populateStatus()
        {
            var statuses = Enum.GetValues(typeof(DonorEligibility))
                .Cast<DonorEligibility>()
                .Select(ds => new
                {
                    Text = EnumHelper.GetDescription(ds),
                    Value = (DonorEligibility?)ds
                }).ToList();
            statuses.Insert(0, new { Text = "All Status", Value = (DonorEligibility?)null });
            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        private void dgvDonors_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                string value = e.Value.ToString();

                if (value == "Yes")
                    e.CellStyle.ForeColor = Color.Green;
                else if (value == "No")
                    e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void DgvHeaderLine_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                int y = dgv.ColumnHeadersHeight + 1;
                using var pen = new Pen(Color.FromArgb(160, AppTheme.BorderColor), 2f);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.DrawLine(pen, new Point(0, y), new Point(dgv.ClientSize.Width, y));
            }
        }

        public void AddRounding(Panel panel)
        {
            panel.Paint -= PnlRounding_Paint;
            panel.Paint += PnlRounding_Paint;
            panel.Resize -= PnlResize;
            panel.Resize += PnlResize;
        }

        private void PnlResize(object sender, EventArgs e)
        {
            ((Panel)sender).Invalidate();
        }


        private void PnlRounding_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            if (pnl.Width <= 0 || pnl.Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            using GraphicsPath path = GetRoundedPath(rect, 6);

            pnl.Region = new Region(path);

            using SolidBrush bg = new SolidBrush(pnl.BackColor);
            g.FillPath(bg, path);

            Rectangle borderRect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using GraphicsPath borderPath = GetRoundedPath(borderRect, 12);
            using Pen borderPen = new Pen(AppTheme.BorderColor, 1);
            g.DrawPath(borderPen, borderPath);
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

        private void UpdateGridHeight()
        {
            int totalHeight = dgvDonors.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dgvDonors.Rows)
            {
                if (row.Visible)
                    totalHeight += row.Height;
            }

            totalHeight += 2;
            dgvDonors.Height = totalHeight;
        }

        private void cbStyling_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = sender as ComboBox;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color bgColor = isSelected ? AppTheme.SurfaceHover : AppTheme.ContentBackground;
            Color textColor = isSelected ? AppTheme.PrimaryText : AppTheme.BodyText;

            using (SolidBrush sb = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(sb, e.Bounds);
            }

            string text = combo.GetItemText(combo.Items[e.Index]);
            TextRenderer.DrawText(e.Graphics, text, combo.Font, e.Bounds, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private void AddClickEventToAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl != dgvDonors)
                {
                    ctrl.Click += (s, e) =>
                    {
                        dgvDonors.ClearSelection();
                    };
                }

                // Recursive call for nested controls 
                if (ctrl.HasChildren)
                {
                    AddClickEventToAllControls(ctrl);
                }
            }
        }

        private void tbSearchDonor_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbBloodGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }


        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string search = tbSearchDonor.Text;

            BloodGroup? selectedGroup = cbBloodGroups.SelectedValue as BloodGroup?;
            DonorEligibility? selectedStatus = cbStatus.SelectedValue as DonorEligibility?;

            var donors = _DonorService.SerachDonors(search, selectedGroup, selectedStatus);

            dgvDonors.Rows.Clear();

            foreach (Donor donor in donors)
            {
                dgvDonors.Rows.Add(
                    donor.FullName,
                    EnumHelper.GetDescription(donor.BloodGroup),
                    donor.Phone,
                    donor.City,
                    donor.LastDonationDate.HasValue ? donor.LastDonationDate.Value.ToString("yyyy-MM-dd") : "N/A",
                    donor.IsEligible ? "Yes" : "No"
                );
            }
        }
    }
}
