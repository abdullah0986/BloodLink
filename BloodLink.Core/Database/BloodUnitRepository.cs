using BloodLink.Core.Helpers;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using Microsoft.Data.SqlClient;

namespace BloodLink.Core.Database
{
    public class BloodUnitRepository : IBloodUnitRepository
    {
        private readonly IAppSettingRepository _appSettingRepository = new AppSettingsRepository();

        int IBloodUnitRepository.AddBloodUnit(BloodUnit unit)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string bloodGroupDescription = EnumHelper.GetDescription(unit.BloodGroup);

                string sql = @"INSERT INTO BloodUnits (Id, BloodGroup, CollectedDate, ExpiryDate, DonorId, Status, UserId, Notes, CreatedAt)
                                VALUES (@Id, @BloodGroup, @CollectedDate, @ExpiryDate, @DonorId, @Status, @UserId, @Notes, @CreatedAt);";

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", BloodUnit.GenerateBloodUnitId(bloodGroupDescription));
                command.Parameters.AddWithValue("@BloodGroup", EnumHelper.GetDescription(unit.BloodGroup));
                command.Parameters.AddWithValue("@CollectedDate", unit.CollectedDate);
                command.Parameters.AddWithValue("@ExpiryDate", unit.ExpiryDate);
                command.Parameters.AddWithValue("@DonorId", unit.DonorId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Status", unit.Status.ToString());
                command.Parameters.AddWithValue("@UserId", unit.UserId.ToString());
                command.Parameters.AddWithValue("@Notes", unit.Notes ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CreatedAt", unit.CreatedAt);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BloodUnit not added error occured {ex.Message}");
                return 0;
            }
        }

        int IBloodUnitRepository.UpdateBloodUnit(BloodUnit bloodunit)
        {
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();
                string sql = @"UPDATE BloodUnits
                          SET BloodGroup = @bloodgroup,
                          CollectedDate = @collectedDate,
                          ExpiryDate = @expirydate,
                          DonorId = @donorId,
                          Status = @status,
                          UserId = @userId,
                          Notes = @notes
                          WHERE Id = @id;";
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", bloodunit.Id);
                command.Parameters.AddWithValue("@bloodgroup", EnumHelper.GetDescription(bloodunit.BloodGroup));
                command.Parameters.AddWithValue("@collectedDate", bloodunit.CollectedDate);
                command.Parameters.AddWithValue("@expirydate", bloodunit.ExpiryDate);
                command.Parameters.AddWithValue("@donorId", bloodunit.DonorId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@status", EnumHelper.GetDescription(bloodunit.Status));
                command.Parameters.AddWithValue("@userId", bloodunit.UserId.ToString());
                command.Parameters.AddWithValue("@notes", bloodunit.Notes ?? (object)DBNull.Value);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while Updating Bloodunit {ex}");
                throw;
            }
        }

        public int DeleteBloodUnit(string id)
        {
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();
                string sql = @"DELETE FROM BloodUnits WHERE Id = @id";
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while Deleting Bloodunit {ex}");
                throw;
            }
        }

        public List<BloodUnit> GetAllBloodUnits()
        {
            List<BloodUnit> bloodUnits = new List<BloodUnit>();
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();
                string sql = @"SELECT * FROM BloodUnits ORDER BY CreatedAt DESC";
                using SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bloodUnits.Add(MapBloodUnit(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching BloodUnits {ex}");
                throw;
            }
            return bloodUnits;
        }

        public List<BloodUnit> SearchBloodUnits(BloodGroup? bloodGroup, BloodUnitStatus? bloodUnitStatus)
        {
            List<BloodUnit> bloodUnits = new List<BloodUnit>();
            try
            {
                string sql = "WHERE 1 = 1";

                if (bloodGroup != null)
                    sql += " AND BloodGroup = @bloodGroup";

                if (bloodUnitStatus != null)
                    sql += " AND Status = @status";

                var fullQuery = $"SELECT * FROM BloodUnits {sql} ORDER BY CreatedAt DESC";
                using SqlConnection connection = DbConnection.GetConnection();
                using SqlCommand command = new SqlCommand(fullQuery, connection);

                if (bloodGroup != null)
                    command.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(bloodGroup));

                if (bloodUnitStatus != null)
                    command.Parameters.AddWithValue("@status", EnumHelper.GetDescription(bloodUnitStatus));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bloodUnits.Add(MapBloodUnit(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while searching BloodUnits {ex}");
                throw;
            }
            return bloodUnits;
        }

        async Task<int> IBloodUnitRepository.CollectionThisMonthAsync()
        {
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"SELECT COUNT(*) FROM BloodUnits 
                               WHERE YEAR(CollectedDate) = YEAR(GETUTCDATE()) 
                               AND MONTH(CollectedDate) = MONTH(GETUTCDATE());";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong while getting total collection of blood units.");
                throw;
            }
        }

        async Task<BloodUnitStats> IBloodUnitRepository.GetBloodUnitStatsAsync()
        {
            BloodUnitStats stats = new BloodUnitStats();
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM BloodUnits WHERE Status = 'Available' OR Status = 'Reserved'", connection))
                    stats.TotalUnits = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM BloodUnits WHERE Status = 'Available'", connection))
                    stats.AvailableUnits = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM BloodUnits WHERE Status = 'Reserved'", connection))
                    stats.ReservedUnits = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM BloodUnits WHERE Status = 'Used' 
                      AND YEAR(CollectedDate) = YEAR(GETUTCDATE()) 
                      AND MONTH(CollectedDate) = MONTH(GETUTCDATE())", connection))
                    stats.UsedUnits = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM BloodUnits WHERE Status = 'Expired' 
                      AND YEAR(CollectedDate) = YEAR(GETUTCDATE()) 
                      AND MONTH(CollectedDate) = MONTH(GETUTCDATE())", connection))
                    stats.ExpiredUnits = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching blood unit stats {ex.Message}");
            }
            return stats;
        }

        async Task<int> IBloodUnitRepository.getBloodGroupCountAsync(Enum BloodGroup)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                var bloodGroup = EnumHelper.GetDescription(BloodGroup);
                using var command = new SqlCommand(
                    "SELECT COUNT(*) FROM BloodUnits WHERE BloodGroup = @bloodGroup", connection);
                command.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Fetching BloodGroup Count : {ex.Message}");
                return -1;
            }
        }

        async Task<int> IBloodUnitRepository.getExpiringSoonCountAsync()
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT COUNT(*) FROM BloodUnits 
                               WHERE ExpiryDate <= @expiryThreshold 
                               AND (Status = 'Available' OR Status = 'Reserved');";
                using var command = new SqlCommand(sql, connection);

                string? saved = _appSettingRepository.GetSetting("ExpiryThreshold");
                int days = int.TryParse(saved, out int d) ? d : 7;

                command.Parameters.AddWithValue("@expiryThreshold", DateTime.UtcNow.AddDays(days));
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Fetching Expiring Soon Count : {ex.Message}");
                return -1;
            }
        }

        async Task<Dictionary<string, int>> IBloodUnitRepository.getExpiringUnitsAsync()
        {
            var expiringUnits = new Dictionary<string, int>();
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT Id, ExpiryDate FROM BloodUnits 
                               WHERE ExpiryDate <= @expiryThreshold 
                               AND (Status = 'Available' OR Status = 'Reserved')
                               ORDER BY ExpiryDate ASC";
                using var command = new SqlCommand(sql, connection);

                string? saved = _appSettingRepository.GetSetting("ExpiryThreshold");
                int days = int.TryParse(saved, out int d) ? d : 7;

                command.Parameters.AddWithValue("@expiryThreshold", DateTime.UtcNow.AddDays(days));

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string Id = reader["Id"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(Id)) continue;

                    DateTime expiryDate = reader.GetDateTime(reader.GetOrdinal("ExpiryDate"));
                    int daysLeft = (expiryDate.Date - DateTime.UtcNow.Date).Days;
                    if (daysLeft < 0) daysLeft = 0;

                    if (!expiringUnits.ContainsKey(Id))
                        expiringUnits.Add(Id, daysLeft);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Fetching Expiring Units : {ex.Message}");
            }
            return expiringUnits;
        }

        async Task<Dictionary<string, int>> IBloodUnitRepository.GetStockByBloodGroupAsync()
        {
            Dictionary<string, int> _result = new Dictionary<string, int>();
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"SELECT BloodGroup, COUNT(*) as Count FROM BloodUnits
                               WHERE Status = 'Available' GROUP BY BloodGroup;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string group = reader["BloodGroup"]?.ToString() ?? string.Empty;
                    int count = Convert.ToInt32(reader["Count"]);
                    if (!string.IsNullOrEmpty(group))
                        _result[group] = count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting blood group stocks. {ex.Message}");
                throw;
            }
            return _result;
        }

        async Task<Dictionary<string, int>> IBloodUnitRepository.GetMonthlyDonationsAsync(int monthsBack)
        {
            var result = new Dictionary<string, int>();
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT FORMAT(CollectedDate, 'yyyy-MM') AS Month, COUNT(*) AS Count
                               FROM BloodUnits
                               WHERE CollectedDate >= @startDate
                               GROUP BY FORMAT(CollectedDate, 'yyyy-MM')
                               ORDER BY Month ASC";
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@startDate", DateTime.UtcNow.AddMonths(-monthsBack));
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string month = reader["Month"]?.ToString() ?? string.Empty;
                    int count = Convert.ToInt32(reader["Count"]);
                    if (!string.IsNullOrEmpty(month))
                        result[month] = count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching monthly donations: {ex.Message}");
            }
            return result;
        }

        int IBloodUnitRepository.MarkExpiredUnits()
        {
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();
                string sql = @"UPDATE BloodUnits 
                               SET Status = 'Expired'
                               WHERE ExpiryDate < @today 
                               AND Status != 'Expired';";
                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@today", DateTime.UtcNow);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private BloodUnit MapBloodUnit(SqlDataReader reader)
        {
            return new BloodUnit
            {
                Id = reader["Id"].ToString()!,
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(reader["BloodGroup"]?.ToString() ?? string.Empty),
                CollectedDate = reader.GetDateTime(reader.GetOrdinal("CollectedDate")),
                ExpiryDate = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                DonorId = reader["DonorId"] == DBNull.Value ? null : reader["DonorId"].ToString(),
                Status = EnumHelper.GetValueFromDescription<BloodUnitStatus>(reader["Status"]?.ToString() ?? string.Empty),
                UserId = reader["UserId"] == DBNull.Value ? null : reader["UserId"].ToString(),
                Notes = reader["Notes"] == DBNull.Value ? null : reader["Notes"].ToString(),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }
    }
}