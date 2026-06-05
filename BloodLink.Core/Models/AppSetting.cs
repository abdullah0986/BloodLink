using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Models
{
    public class AppSetting
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public int ExpiryThreshold { get; set; }

        public string GenerateAppSettingId()
        {
            string year = DateTime.UtcNow.Year.ToString();
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return $"AS-{year}-{uniquePart}";
        }
    }
}
