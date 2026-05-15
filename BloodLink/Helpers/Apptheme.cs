using System.Security.Policy;

namespace BloodLink.Helpers
{
    public static class AppTheme
    {
        // ── Theme State ───────────────────────────────
        public static bool IsDarkMode { get; private set; } = true;

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }   

        // ── Dynamic Colors (change based on theme) ────
        public static Color SidebarBackground => IsDarkMode ? Color.FromArgb(13, 3, 2) : Color.FromArgb(26, 8, 5);
        public static Color MainBackground => IsDarkMode ? Color.FromArgb(26, 10, 8) : Color.FromArgb(250, 250, 250);
        public static Color ContentBackground => IsDarkMode ? Color.FromArgb(40, 9, 5) : Color.FromArgb(237,235,235);
        public static Color Background => IsDarkMode ? Color.FromArgb(13, 13, 13) : Color.FromArgb(250, 250, 250);
        public static Color CardBackground => IsDarkMode ? Color.FromArgb(26, 10, 8) : Color.FromArgb(255, 255, 255);
        public static Color Surface => IsDarkMode ? Color.FromArgb(40, 9, 5) : Color.FromArgb(245, 240, 239);
        public static Color SurfaceHover => IsDarkMode ? Color.FromArgb(61, 12, 7) : Color.FromArgb(232, 213, 211);
        public static Color BorderColor => IsDarkMode ? Color.FromArgb(61, 26, 23) : Color.FromArgb(232, 213, 211);
        public static Color IconColor => IsDarkMode ? Color.WhiteSmoke : Color.FromArgb(40, 9, 5);
        public static Color TotalDonorIconColor => IsDarkMode ? Color.FromArgb(255, 82, 82) : Color.FromArgb(192, 57, 43);
        public static Color BloodUnitsIconColor => IsDarkMode ? Color.FromArgb(0, 210, 211) : Color.FromArgb(30, 124, 74);
        public static Color PatientsTodayIconColor => IsDarkMode ? Color.FromArgb(84, 160, 255) : Color.FromArgb(184, 134, 11);
        public static Color ExpiringSoonIconColor => IsDarkMode ? Color.FromArgb(255, 82, 82) : Color.FromArgb(184, 134, 11);

        public static Color PrimaryText => IsDarkMode ? Color.FromArgb(245, 240, 239) : Color.FromArgb(26, 8, 5);
        public static Color BodyText => IsDarkMode ? Color.FromArgb(201, 184, 182) : Color.FromArgb(74, 46, 43);
        public static Color MutedText => IsDarkMode ? Color.FromArgb(138, 110, 107) : Color.FromArgb(154, 122, 119);

        // ── Static Colors (same in both themes) ───────
        public static readonly Color PrimaryRed = Color.FromArgb(116, 10, 3);
        public static readonly Color BrightRed = Color.FromArgb(160, 16, 4);
        public static readonly Color BloodRed = Color.FromArgb(192, 57, 43);
        public static readonly Color LightRed = Color.FromArgb(250, 219, 216);
        public static readonly Color SuccessGreen = Color.FromArgb(30, 124, 74);
        public static readonly Color WarningAmber = Color.FromArgb(184, 134, 11);
        public static readonly Color ErrorRed = Color.FromArgb(192, 57, 43);
        public static readonly Color White = Color.White;

        // ── Gradient Colors ───────────────────────────
        public static Color GradientStart => IsDarkMode ? Color.FromArgb(40, 9, 5) : Color.FromArgb(116, 10, 3);
        public static Color GradientEnd => IsDarkMode ? Color.FromArgb(116, 10, 3) : Color.FromArgb(160, 16, 4);

        // ── Fonts ─────────────────────────────────────
        public static readonly Font FontLogo = new Font("Segoe UI", 24, FontStyle.Bold);
        public static readonly Font FontH1 = new Font("Segoe UI", 22, FontStyle.Bold);
        public static readonly Font FontH2 = new Font("Segoe UI", 16, FontStyle.Bold);
        public static readonly Font FontH3 = new Font("Segoe UI", 13, FontStyle.Bold);
        public static readonly Font FontLabel = new Font("Segoe UI", 9, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 11, FontStyle.Regular);
        public static readonly Font FontSmall = new Font("Segoe UI", 9, FontStyle.Regular);
        public static readonly Font FontButton = new Font("Segoe UI", 11, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 10, FontStyle.Regular);

        // ── Sizes ─────────────────────────────────────
        public static readonly Size InputSize = new Size(380, 40);
        public static readonly Size ButtonSize = new Size(380, 45);
        public static readonly int FormPadding = 60;
        public static readonly int SidebarWidth = 220;
        public static readonly int HeaderHeight = 56;

        // ── Helper — apply theme to any form ──────────
        public static void ApplyToForm(Form form)
        {
            form.BackColor = Background;
            ApplyToControls(form.Controls);
        }

        public static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Panel panel)
                {
                    ApplyToControls(panel.Controls);
                }
                else if (control is Label label)
                {
                    label.ForeColor = BodyText;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Surface;
                    textBox.ForeColor = PrimaryText;
                }
            }
        }
    }
}