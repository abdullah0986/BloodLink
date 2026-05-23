using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace BloodLink.Helpers
{
    public class PaintHelper
    {

        //give linne gdv after 
        public static void DgvHeaderLine_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                int y = dgv.ColumnHeadersHeight + 1;
                using var pen = new Pen(Color.FromArgb(160, AppTheme.BorderColor), 2f);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.DrawLine(pen, new Point(0, y), new Point(dgv.ClientSize.Width, y));
            }
        }


        // for making pnl rounded
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

            int radius = 6;

            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            using GraphicsPath path = GetRoundedPath(rect, radius);

            pnl.Region = new Region(path);

            using SolidBrush bg = new SolidBrush(pnl.BackColor);
            g.FillPath(bg, path);

            Rectangle borderRect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using GraphicsPath borderPath = GetRoundedPath(borderRect, radius);
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

        // for making buttons round
        public void AddRounding(Button btn, int radius = 6)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            PaintEventHandler paintHandler = (sender, e) => BtnRounding_Paint(sender, e, radius);
            btn.Paint += paintHandler;

            btn.Resize += (sender, e) => ApplyRoundedRegion((Button)sender, radius);
            ApplyRoundedRegion(btn, radius);
        }

        private void ApplyRoundedRegion(Button btn, int radius)
        {
            if (btn.Width <= 0 || btn.Height <= 0) return;
            using GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, btn.Width, btn.Height), radius);
            btn.Region = new Region(path);
        }

        private void BtnRounding_Paint(object sender, PaintEventArgs e, int radius)
        {
            Button btn = (Button)sender;
            if (btn.Width <= 0 || btn.Height <= 0) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            using GraphicsPath path = GetRoundedPath(rect, radius);
            using SolidBrush bg = new SolidBrush(btn.BackColor);
            e.Graphics.FillPath(bg, path);
            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, rect, btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // for styling combobox dropdown values 
        public void cbStyling_DrawItem(object sender, DrawItemEventArgs e)
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

        public void AddClickEventToAllControls(Control parent, DataGridView dgv)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl != dgv)
                {
                    ctrl.Click += (s, e) =>
                    {
                        dgv.ClearSelection();
                    };
                }

                if (ctrl.HasChildren)
                {
                    AddClickEventToAllControls(ctrl, dgv);
                }
            }
        }
    }
}
