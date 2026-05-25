using BloodLink.Helpers;
using BloodLink.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Data;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using BloodLink.Models;

namespace BloodLink.Pages
{
    public partial class ReportsPage : UserControl
    {
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private BloodUnitService _bloodUnitService = new BloodUnitService();
        private PatientRequestService _patientRequestService = new PatientRequestService();
        private int _maxUnits = 1;
        private (string Group, int Units, string Level)[] _stockData = Array.Empty<(string, int, string)>();

        public ReportsPage()
        {
            InitializeComponent();

            ApplyTheme();
            loadData();
            LoadStockData();
            SetupBloodStockBars();
            SetupMonthlyDonationsChart();
            SetupRequestStatusChart();
        }
        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;

            StyledStatCard(tlpUnitsCollection, lblUnitsCollectedHeader, lblUnitsColledtedCount, lblUnitsCollectedFooter, AppTheme.PrimaryText);
            StyledStatCard(tlpUnitsAvailable, lblUntisIssuedHeader, lblUnitsIssuedCount, lblUnitsIssuedFooter, Color.ForestGreen);
            StyledStatCard(tlpUnitsExpired, lblUnitsExpiredHeader, lblUnitsExpiredCount, lblUnitsExpiredFooter, Color.Red);

            tlpBloodStock.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(tlpBloodStock);

            lblBloodStock.ForeColor = AppTheme.PrimaryText;
            lblBloodStock.Font = AppTheme.FontButton;
            lblCurrentAvailableUnits.ForeColor = AppTheme.MutedText;
            lblCurrentAvailableUnits.Font = AppTheme.FontSmall;

            tlpMonthlyDonations.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(tlpMonthlyDonations);

            lblMonthlyDonations.ForeColor = AppTheme.PrimaryText;
            lblMonthlyDonations.Font = AppTheme.FontButton;
            lblMonthlyDonationsTime.ForeColor = AppTheme.MutedText;
            lblMonthlyDonationsTime.Font = AppTheme.FontSmall;

            tlpRequestsStaus.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(tlpRequestsStaus);

            lblRequestStatus.ForeColor = AppTheme.PrimaryText;
            lblRequestStatus.Font = AppTheme.FontButton;
            lblRequestStatusTime.ForeColor = AppTheme.MutedText;
            lblRequestStatusTime.Font = AppTheme.FontSmall;

            styledRequestSatusLabels(lblFulfilled);
            styledRequestSatusLabels(lblFulfilledCount);
            styledRequestSatusLabels(lblPending);
            styledRequestSatusLabels(lblPendingCount);
            styledRequestSatusLabels(lblRejected);
            styledRequestSatusLabels(lblRejectedCount);
        }

        private void styledRequestSatusLabels(Label lbl)
        {
            lbl.ForeColor = AppTheme.PrimaryText;
            lbl.Font = AppTheme.FontHeader;
        }

        private void loadData()
        {
            BloodUnitStats issuedUnits = _bloodUnitService.GetBloodUnitStats();

            int unitsIssued = issuedUnits.UsedUnits;
            lblUnitsIssuedCount.Text = unitsIssued.ToString();

            int unitsExpired = issuedUnits.ExpiredUnits;
            lblUnitsExpiredCount.Text = unitsIssued.ToString();
        }

        private void LoadStockData()
        {
            var _stockDict = _bloodUnitService.GetStockByBloodGroup();

            var groups = new[] { "O+", "A+", "B+", "O-", "A-", "AB+", "B-", "AB-" };

            _stockData = groups.Select
            (g =>
            {
                var units = _stockDict.ContainsKey(g) ? _stockDict[g] : 0;
                var level = units <= 10 ? "critical" :
                        units <= 20 ? "low" :
                        "normal";
                return (g, units, level);
            }).ToArray();

            _maxUnits = _stockData.Length > 0 ?
                         Math.Max(1, _stockData.Max(u => u.Units)) :
                         1;
        }

        private void SetupBloodStockBars()
        {
            for (int i = tlpBloodStock.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = tlpBloodStock.Controls[i];
                if (tlpBloodStock.GetRow(ctrl) == 1)
                    tlpBloodStock.Controls.RemoveAt(i);
            }

            var barsPanel = new BufferedPanel
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.ContentBackground,
            };

            tlpBloodStock.Controls.Add(barsPanel, 0, 1);
            barsPanel.Paint += (s, e) => DrawBloodStockBars(e.Graphics, barsPanel.ClientRectangle);
        }

        private void DrawBloodStockBars(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int rowHeight = bounds.Height / _stockData.Length;
            int labelWidth = 40;
            int valueWidth = 40;
            int barPadLeft = 8;
            int barPadRight = 4;
            int barHeight = 7;

            for (int i = 0; i < _stockData.Length; i++)
            {
                var (group, units, level) = _stockData[i];
                int midY = i * rowHeight + rowHeight / 2;

                // Label
                using var labelBrush = new SolidBrush(Color.FromArgb(201, 184, 182));
                using var labelFont = new Font("Segoe UI", 10f);
                g.DrawString(group, labelFont, labelBrush,
                    new RectangleF(0, midY - 8, labelWidth, 16));

                // Bar background
                int barX = labelWidth + barPadLeft;
                int barW = bounds.Width - labelWidth - valueWidth - barPadLeft - barPadRight;
                int barY = midY - barHeight / 2;

                using var bgBrush = new SolidBrush(Color.FromArgb(26, 10, 8));
                g.FillRectangle(bgBrush, new RectangleF(barX, barY, barW, barHeight));

                // Bar fill
                float pct = (float)units / _maxUnits;
                Color fillColor = level switch
                {
                    "critical" => Color.FromArgb(192, 57, 43),
                    "low" => Color.FromArgb(184, 134, 11),
                    _ => Color.FromArgb(116, 10, 3),
                };
                using var fillBrush = new SolidBrush(fillColor);
                g.FillRectangle(fillBrush, new RectangleF(barX, barY, barW * pct, barHeight));

                // Value — right-aligned inside valueWidth area
                using var valFont = new Font("Segoe UI", 10f, FontStyle.Bold);
                using var valBrush = new SolidBrush(
                    level == "critical" ? Color.FromArgb(192, 57, 43)
                                        : Color.FromArgb(245, 240, 239));

                var valRect = new RectangleF(barX + barW, midY - 8, valueWidth, 16);
                var valFormat = new StringFormat { Alignment = StringAlignment.Far }; // right-align
                g.DrawString(units.ToString(), valFont, valBrush, valRect, valFormat);
            }
        }

        private void SetupMonthlyDonationsChart()
        {
            var months = Enumerable.Range(0, 6)
                         .Select(i => DateTime.UtcNow.AddMonths(-5 + i))
                         .ToList();

            var donationDate = _bloodUnitService.GetMonthlyDonations();

            var values = months.Select(m =>
                                {
                                    string key = m.ToString("yyyy-MM");
                                    return donationDate.ContainsKey(key) ? donationDate[key] : 0;
                                }
                             );

            var labels = months.Select(m => m.ToString("MMM")).ToArray();

            string currentKey = DateTime.UtcNow.ToString("yyyy-MM");
            var barColors = months.Select(m =>
                m.ToString("yyyy-MM") == currentKey
                    ? SKColor.Parse("#ffffff")
                    : SKColor.Parse("#740A03")
            ).ToArray();

            // chart is building form here
            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.ContentBackground,
            };

            chart.Series = new ISeries[]
            {
        new ColumnSeries<int?>
        {
            Values = values.Cast<int?>().ToArray(),
            Fill = new SolidColorPaint(SKColor.Parse("#740A03")),
            Stroke = null,
            MaxBarWidth = 28,
            DataLabelsSize = 13,
            IgnoresBarPosition = true,
            DataLabelsPaint = new SolidColorPaint(SKColor.Parse("#C9B8B6")),
            DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
            DataLabelsFormatter = point => point.Coordinate.PrimaryValue.ToString("0"),
        }
            };

            chart.XAxes = new[]
            {
        new Axis
        {
            Labels = labels,
            LabelsPaint = new SolidColorPaint(SKColor.Parse("#eeeeee")),
            TicksPaint = null,
            SeparatorsPaint = null,
            TextSize = 13,
        }
    };

            chart.YAxes = new[]
            {
        new Axis
        {
            IsVisible = false, // hide Y axis for clean look
            SeparatorsPaint = null,
        }
    };

            // 7. Add into row 1 of tlpMonthlyDonations
            // Clear first
            for (int i = tlpMonthlyDonations.Controls.Count - 1; i >= 0; i--)
            {
                if (tlpMonthlyDonations.GetRow(tlpMonthlyDonations.Controls[i]) == 1)
                    tlpMonthlyDonations.Controls.RemoveAt(i);
            }

            tlpMonthlyDonations.Controls.Add(chart, 0, 1);
        }
        private void StyledStatCard(TableLayoutPanel tlp, Label heading, Label count, Label footer, Color color)
        {
            tlp.BackColor = AppTheme.ContentBackground;
            heading.ForeColor = AppTheme.MutedText;
            heading.Font = AppTheme.FontLabel;
            count.ForeColor = color;
            count.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            footer.ForeColor = AppTheme.MutedText;
            footer.Font = AppTheme.FontSmall;
            _paintHelper.AddRounding(tlp);
        }

        private void SetupRequestStatusChart()
        {
            var stats = _patientRequestService.GetRequestStatusStats();

            int fulfilled = stats.ContainsKey("Fulfilled") ? stats["Fulfilled"] : 0;
            int pending = stats.ContainsKey("Pending") ? stats["Pending"] : 0;
            int cancelled = stats.ContainsKey("Cancelled") ? stats["Cancelled"] : 0;
            int total = fulfilled + pending + cancelled;

            lblUnitsColledtedCount.Text = total.ToString();

            lblFulfilledCount.Text = fulfilled.ToString();
            lblPendingCount.Text = pending.ToString();
            lblRejectedCount.Text = cancelled.ToString();

            var chart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.ContentBackground,
                InitialRotation = -90,
            };

            chart.Series = new ISeries[]
            {
        new PieSeries<double>
        {
            Values          = new double[] { fulfilled },
            Fill            = new SolidColorPaint(SKColor.Parse("#27AE60")),
            Stroke          = null,
            InnerRadius     = 58,
            DataLabelsSize  = 0,
            DataLabelsPaint = null,
        },
        new PieSeries<double>
        {
            Values          = new double[] { pending },
            Fill            = new SolidColorPaint(SKColor.Parse("#F39C12")),
            Stroke          = null,
            InnerRadius     = 58,
            DataLabelsSize  = 0,
            DataLabelsPaint = null,
        },
        new PieSeries<double>
        {
            Values          = new double[] { cancelled },
            Fill            = new SolidColorPaint(SKColor.Parse("#C0392B")),
            Stroke          = null,
            InnerRadius     = 58,
            DataLabelsSize  = 0,
            DataLabelsPaint = null,
        },
            };

            pnlPiChart.Controls.Clear();
            pnlPiChart.Controls.Add(chart);

            var totalLabel = new Label
            {
                Text = total.ToString(),
                ForeColor = AppTheme.PrimaryText,
                Font = AppTheme.FontHeader,
                BackColor = Color.Transparent,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            pnlPiChart.Controls.Add(totalLabel);

            pnlPiChart.SizeChanged += (s, e) =>
            {
                totalLabel.Left = (pnlPiChart.Width - totalLabel.Width) / 2;
                totalLabel.Top = (pnlPiChart.Height - totalLabel.Height) / 2;
                totalLabel.BringToFront();
            };

            totalLabel.Left = (pnlPiChart.Width - totalLabel.Width) / 2;
            totalLabel.Top = (pnlPiChart.Height - totalLabel.Height) / 2;
            totalLabel.BringToFront();
        }

        internal class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                this.DoubleBuffered = true;
                this.ResizeRedraw = true; // redraws cleanly on every resize
            }
        }

        private void lblFulfilled_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 2. Define the green brush
            using (SolidBrush greenBrush = new SolidBrush(Color.LimeGreen))
            {
                // 3. Position the circle exactly relative to your label
                // This places it 15 pixels to the left, centered vertically with the label
                int circleSize = 12;
                int x = lblFulfilled.Left - circleSize - 5;
                int y = lblFulfilled.Top + (lblFulfilled.Height - circleSize) / 2;

                // 4. Draw the filled circle
                e.Graphics.FillEllipse(greenBrush, x, y, circleSize, circleSize);
            }
        }
    }
}