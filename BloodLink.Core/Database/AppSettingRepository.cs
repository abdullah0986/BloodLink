using BloodLink.Core.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace BloodLink.Core.Database
{
    public class AppSettingsRepository : IAppSettingRepository
    {
        void IAppSettingRepository.SaveSetting(string key, string value)
        {
            using var conn = DbConnection.GetConnection();
            string sql = @"IF EXISTS (SELECT 1 FROM AppSettings WHERE [Key] = @key)
                               UPDATE AppSettings SET Value = @value WHERE [Key] = @key;
                           ELSE
                               INSERT INTO AppSettings ([Key], Value) VALUES (@key, @value);";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@key", key);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.ExecuteNonQuery();
        }

        string? IAppSettingRepository.GetSetting(string key)
        {
            using var conn = DbConnection.GetConnection();
            string sql = "SELECT Value FROM AppSettings WHERE [Key] = @key;";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@key", key);
            var result = cmd.ExecuteScalar();
            return result?.ToString();
        }
    }
}