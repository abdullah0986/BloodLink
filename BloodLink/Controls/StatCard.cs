using BloodLink.Helpers;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BloodLink.Controls
{
    public class StatCard : UserControl
    {
        private Label _iconLabel;
        private Label _titleLabel;
        private Label _valueLabel;
        private Label _subtitleLabel;

        public StatCard()
        {
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            // create child controls before setting size to avoid resize events
            BuildControls();
            Size = new Size(300, 110);
        }

        private void BuildControls()
        {
            _iconLabel = new Label
            {
                AutoSize = false,
                Size = new Size(40, 40),
                Location = new Point(16, 16),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppTheme.White,
                BackColor = Color.Transparent
            };

            _titleLabel = new Label
            {
                AutoSize = true,
                Location = new Point(72, 16),
                Font = AppTheme.FontLabel,
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent
            };

            _valueLabel = new Label
            {
                AutoSize = true,
                Location = new Point(72, 36),
                Font = AppTheme.FontH1,
                ForeColor = AppTheme.PrimaryText,
                BackColor = Color.Transparent
            };

            _subtitleLabel = new Label
            {
                AutoSize = true,
                Location = new Point(72, 72),
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.MutedText,
                BackColor = Color.Transparent
            };

            Controls.AddRange(new Control[] {
                _iconLabel, _titleLabel, _valueLabel, _subtitleLabel
            });
        }

        // Designer / runtime properties
        [Browsable(true)]
        [Category("Stat")]
        [Description("Icon text shown inside the accent circle.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string IconText
        {
            get => _iconLabel.Text;
            set
            {
                _iconLabel.Text = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Stat")]
        [Description("Title shown at the top of the card.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => _titleLabel.Text;
            set
            {
                _titleLabel.Text = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Stat")]
        [Description("Large value displayed in the card.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ValueText
        {
            get => _valueLabel.Text;
            set
            {
                _valueLabel.Text = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Stat")]
        [Description("Small subtitle / delta text under the value.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Subtitle
        {
            get => _subtitleLabel.Text;
            set
            {
                _subtitleLabel.Text = value;
                Invalidate();
            }
        }

        // Optional accent color for icon circle
        private Color _iconAccent = AppTheme.PrimaryRed;

        [Browsable(true)]
        [Category("Stat")]
        [Description("Accent color used for the icon circle.")]
        [TypeConverter(typeof(ColorConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconAccent
        {
            get => _iconAccent;
            set
            {
                _iconAccent = value;
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_valueLabel == null || _subtitleLabel == null) return;
            _valueLabel.Location = new Point(72, 36);
            _subtitleLabel.Location = new Point(72, Height - 28);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw rounded card background using AppTheme.Surface
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = RoundedRect(rect, 12);
            using var bg = new SolidBrush(AppTheme.Surface);
            e.Graphics.FillPath(bg, path);

            // Border
            using var pen = new Pen(AppTheme.BorderColor);
            e.Graphics.DrawPath(pen, path);

            // Draw icon circle
            var circleRect = new Rectangle(16, 16, 40, 40);
            using var circleBrush = new SolidBrush(_iconAccent);
            e.Graphics.FillEllipse(circleBrush, circleRect);

            // Ensure labels use current theme colors
            _iconLabel.ForeColor = AppTheme.White;
            _titleLabel.ForeColor = AppTheme.MutedText;
            _valueLabel.ForeColor = AppTheme.PrimaryText;
            _subtitleLabel.ForeColor = AppTheme.MutedText;
        }

        // utility: create rounded rectangle path
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Convenience method to set data quickly
        public void SetData(string iconText, string title, string value, string subtitle, Color? accent = null)
        {
            IconText = iconText;
            Title = title;
            ValueText = value;
            Subtitle = subtitle;
            if (accent.HasValue) IconAccent = accent.Value;
        }
    }
}