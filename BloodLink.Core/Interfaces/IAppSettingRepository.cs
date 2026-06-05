using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Interfaces
{
    public interface IAppSettingRepository
    {
        public void SaveSetting(string key, string value);
        public string GetSetting(string key);
    }
}
