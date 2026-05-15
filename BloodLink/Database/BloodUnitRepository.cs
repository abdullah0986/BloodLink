using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using BloodLink.Models;
using BloodLink.Helpers;
using BloodLink.Database;
using System.Web;

namespace BloodLink.Database
{
    public class BloodUnitRepository
    {
        public int AddBloodUnit(BloodUnit unit)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"
                INSERT INTO BloodUnits (BagId, BloodGroup, CollectedDate, ExpiryDate, DonorId, Status, Notes, CreatedAt)
                VALUES (@BagId, @BloodGroup, @CollectedDate, @ExpiryDate, @DonorId, @Status, @Notes, @CreatedAt);
            ";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@BagId", unit.BagId);
                command.Parameters.AddWithValue("@BloodGroup", EnumHelper.GetDescription(unit.BloodGroup));
                command.Parameters.AddWithValue("@CollectedDate", unit.CollectedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@ExpiryDate", unit.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@DonorId", unit.DonorId);
                command.Parameters.AddWithValue("@Status", unit.Status.ToString());
                command.Parameters.AddWithValue("@Notes", unit.Notes ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CreatedAt", unit.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"BloodUnit not added error occured {ex.Message}");
                return 0;
            }
        }
        
        public int getTotalBloodUnits()
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT COUNT(*) FROM BloodUnits";
                using var command = new SqliteCommand(sql, connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error while getting total bloodunits {ex.Message}");
                return -1;
            }
        }

        public int getBloodGroupCount(Enum BloodGroup)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                var bloodGroup = EnumHelper.GetDescription(BloodGroup);
                using var command = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits WHERE BloodGroup == @bloodGroup", connection);
                command.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error Fetching BloodGroup Count : {ex.Message}");
                return -1;
            }
        }


        public int getExpiringSoonCount()
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT COUNT(*) FROM BloodUnits WHERE ExpiryDate <= @expiryThreshold AND Status == 'Available'";
                using var command = new SqliteCommand(sql, connection);
                var expiryThreshold = DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@expiryThreshold", expiryThreshold);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Fetching Expiring Soon Count : {ex.Message}");
                return -1;
            }
        } 

        public Dictionary<string, int> getExpiringUnits()
        {
            var expiringUnits = new Dictionary<string, int>();
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT BagId, ExpiryDate FROM BloodUnits WHERE ExpiryDate <= @expiryThreshold ORDER BY ExpiryDate ASC";
                using var command = new SqliteCommand(sql, connection);
                var expiryThreshold = DateTime.UtcNow.AddDays(40).ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@expiryThreshold", expiryThreshold);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string bagId = reader["BagId"]?.ToString() ?? string.Empty;
                    string expiryStr = reader["ExpiryDate"]?.ToString() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(bagId) || string.IsNullOrWhiteSpace(expiryStr))
                        continue;

                    if (!DateTime.TryParseExact(expiryStr, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTime expiryDate))
                    {
                        if (!DateTime.TryParse(expiryStr, out expiryDate))
                            continue;
                    }

                    int daysLeft = (expiryDate.Date - DateTime.UtcNow.Date).Days;
                    if (daysLeft < 0) daysLeft = 0;

                    if (!expiringUnits.ContainsKey(bagId))
                        expiringUnits.Add(bagId, daysLeft);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Fetching Expiring Units : {ex.Message}");
            }
            return expiringUnits;
        }
    }
}
