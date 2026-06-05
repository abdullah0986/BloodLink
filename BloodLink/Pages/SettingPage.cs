using BloodLink.Core.Database;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using BloodLink.Forms;
using BloodLink.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BloodLink.Pages
{
    public partial class SettingPage : UserControl
    {
        private readonly IAppSettingRepository _appSettingRepository = new AppSettingsRepository();
        private readonly PaintHelper _paintHelper = new PaintHelper();
        private MouseClickFilter _mouseFilter;
        private readonly DashboardShell _dashboard;

        public SettingPage(DashboardShell dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
            this.Load += LoadData_Handle;
        }

        private void LoadData_Handle(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadData();
            _mouseFilter = new MouseClickFilter(tbThresholdCount);
            Application.AddMessageFilter(_mouseFilter);

            string? savedThreshold = _appSettingRepository.GetSetting("ExpiryThreshold");
            tbThresholdCount.Text = savedThreshold ?? "7";

            tbThresholdCount.TextChanged += (s, e) => 
            {
                if (int.TryParse(tbThresholdCount.Text, out int days) && days > 0)
                {
                    _appSettingRepository.SaveSetting("ExpiryThreshold", days.ToString());
                }
            };
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.MainBackground;

            tlpSession.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(tlpSession);

            lblSessionHeading.ForeColor = AppTheme.PrimaryText;
            lblSessionHeading.Font = AppTheme.FontButton;

            lblSessoinFooter.ForeColor = AppTheme.BodyText;
            lblSessoinFooter.Font = AppTheme.FontSmall;

            styleComboBox(cbSessionValue);

            tlpExpiringThreshold.BackColor = AppTheme.ContentBackground;
            _paintHelper.AddRounding(tlpExpiringThreshold);

            lblThresholdHeading.ForeColor = AppTheme.PrimaryText;
            lblThresholdHeading.Font = AppTheme.FontButton;

            lblThresholdSubHeading.ForeColor = AppTheme.BodyText;
            lblThresholdSubHeading.Font = AppTheme.FontSmall;

            lblThresholdCountHeading.ForeColor = AppTheme.BodyText;
            lblThresholdCountHeading.Font = AppTheme.FontSmall;

            tbThresholdCount.BackColor = AppTheme.ContentBackground;
            tbThresholdCount.ForeColor = AppTheme.PrimaryText;
            tbThresholdCount.Leave += (s, e) => tbThresholdCount.SelectionLength = 0;

            tbThresholdCount.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };
        }

        private void styleComboBox(ComboBox cb)
        {
            cb.BackColor = AppTheme.ContentBackground;
            cb.ForeColor = AppTheme.PrimaryText;
            cb.Font = AppTheme.FontSmall;
            cb.TabStop = false;
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DrawItem += _paintHelper.cbStyling_DrawItem!;
        }

        private void LoadData()
        {
            var timeouts = Enum.GetValues(typeof(SessionTimeout))
                .Cast<SessionTimeout>()
                .Select(t => new
                {
                    Text = EnumHelper.GetDescription(t),
                    Value = t
                }).ToList();

            cbSessionValue.DataSource = timeouts;
            cbSessionValue.DisplayMember = "Text";
            cbSessionValue.ValueMember = "Value";

            // Load saved setting
            string? saved = _appSettingRepository.GetSetting("SessionTimeout");
            if (saved != null && Enum.TryParse<SessionTimeout>(saved, out var savedTimeout))
            {
                cbSessionValue.SelectedItem = timeouts.FirstOrDefault(t => t.Value == savedTimeout);
                _dashboard.ApplySessionTimeout(savedTimeout);
            }
            else
            {
                cbSessionValue.SelectedIndex = 0;
            }

            cbSessionValue.SelectedIndexChanged += (s, e) =>
            {
                SessionTimeout selected = (SessionTimeout)cbSessionValue.SelectedValue;
                _appSettingRepository.SaveSetting("SessionTimeout", selected.ToString());
                _dashboard.ApplySessionTimeout(selected);
            };
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_mouseFilter != null)
                Application.RemoveMessageFilter(_mouseFilter);
            base.OnHandleDestroyed(e);
        }
    }

    public class MouseClickFilter : IMessageFilter
    {
        private readonly Control _target;
        private const int WM_LBUTTONDOWN = 0x0201;

        public MouseClickFilter(Control target)
        {
            _target = target;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                Control clicked = Control.FromHandle(m.HWnd);
                if (clicked != null && clicked != _target)
                    _target.Parent?.Focus();
            }
            return false;
        }
    }
}