using BloodLink.Helpers;
using BloodLink.Interfaces;
using BloodLink.Models;
using Microsoft.Data.Sqlite;
namespace BloodLink.Database
{
    public class BloodUnitRepository: IBloodUnitRepository
    {
        int IBloodUnitRepository.AddBloodUnit(BloodUnit unit)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string bloodGroupDescription = EnumHelper.GetDescription(unit.BloodGroup);


                string sql = @"
                INSERT INTO BloodUnits (Id, BloodGroup, CollectedDate, ExpiryDate, DonorId, Status, UserId, Notes, CreatedAt)
                VALUES (@Id, @BloodGroup, @CollectedDate, @ExpiryDate, @DonorId, @Status, @UserId, @Notes, @CreatedAt);
            ";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", BloodUnit.GenerateBloodUnitId(bloodGroupDescription));
                command.Parameters.AddWithValue("@BloodGroup", EnumHelper.GetDescription(unit.BloodGroup));
                command.Parameters.AddWithValue("@CollectedDate", unit.CollectedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@ExpiryDate", unit.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@DonorId", unit.DonorId);
                command.Parameters.AddWithValue("@Status", unit.Status.ToString());
                command.Parameters.AddWithValue("@UserId", unit.UserId.ToString());
                command.Parameters.AddWithValue("@Notes", unit.Notes ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CreatedAt", unit.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"BloodUnit not added error occured {ex.Message}");
                return 0;
            }
        }

        int IBloodUnitRepository.UpdateBloodUnit(BloodUnit bloodunit)
        {
            try
            {
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                string sql = @"UPDATE Bloodunits
                          SET BloodGroup = @bloodgroup,
                          CollectedDate = @collectedDate,
                          ExpiryDate = @expirydate,
                          DonorId = @donorId,
                          Status = @status,
                          UserId = @userId,
                          Notes = @notes
                          WHERE Id = @id;";
                using SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", bloodunit.Id);
                command.Parameters.AddWithValue("@bloodgroup", EnumHelper.GetDescription(bloodunit.BloodGroup));
                command.Parameters.AddWithValue("@collectedDate", bloodunit.CollectedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@expirydate", bloodunit.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@donorId", bloodunit.DonorId);
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
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                string sql = @"DELETE FROM BloodUnits WHERE Id = @id";
                using SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
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
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT * FROM BloodUnits ORDER BY CreatedAt DESC";
                using SqliteCommand command = new SqliteCommand(sql, connection);
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bloodUnits.Add(MapBloodUnit(reader));
                }
            }
            catch(Exception ex)
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
                string sql = @"Where 1 = 1";

                if(bloodGroup != null)
                {
                    sql += " AND BloodGroup = @bloodGroup";
                }
                if(bloodUnitStatus != null)
                {
                    sql += " AND Status = @status";
                }

                var fullQuery = $"SELECT * FROM BloodUnits {sql} ORDER BY CreatedAt DESC";
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                using SqliteCommand command = new SqliteCommand(fullQuery, connection);
                if (bloodGroup != null)
                {
                    command.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(bloodGroup));
                }
                if(bloodUnitStatus != null)
                {
                    command.Parameters.AddWithValue("@status", EnumHelper.GetDescription(bloodUnitStatus));
                }
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bloodUnits.Add(MapBloodUnit(reader));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while searching BloodUnits {ex}");
                throw;
            }
            return bloodUnits;
        }

        BloodUnitStats IBloodUnitRepository.GetBloodUnitStats()
        {
            BloodUnitStats stats = new BloodUnitStats();
            try
            {
                using SqliteConnection connection = DatabaseHelper.GetConnection();

                using (SqliteCommand cmd = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits", connection))
                stats.TotalUnits = Convert.ToInt32(cmd.ExecuteScalar());

                using (SqliteCommand cmd = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits WHERE Status == 'Available'", connection))
                    stats.AvailableUnits = Convert.ToInt32(cmd.ExecuteScalar());

                using (SqliteCommand cmd = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits WHERE Status == 'Reserved'", connection))
                    stats.ReservedUnits = Convert.ToInt32(cmd.ExecuteScalar());

                using (SqliteCommand cmd = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits WHERE Status == 'Expired'", connection))
                    stats.ExpiredUnits = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error while fetching blood unit stats {ex.Message}");
            }
            return stats;
        }

        int IBloodUnitRepository.getBloodGroupCount(Enum BloodGroup)
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


        int IBloodUnitRepository.getExpiringSoonCount()
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

        Dictionary<string, int> IBloodUnitRepository.getExpiringUnits()
        {
            var expiringUnits = new Dictionary<string, int>();
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT Id, ExpiryDate FROM BloodUnits WHERE ExpiryDate <= @expiryThreshold ORDER BY ExpiryDate ASC";
                using var command = new SqliteCommand(sql, connection);
                var expiryThreshold = DateTime.UtcNow.AddDays(40).ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@expiryThreshold", expiryThreshold);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = reader["Id"]?.ToString() ?? string.Empty;
                    string expiryStr = reader["ExpiryDate"]?.ToString() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(expiryStr))
                        continue;

                    if (!DateTime.TryParseExact(expiryStr, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTime expiryDate))
                    {
                        if (!DateTime.TryParse(expiryStr, out expiryDate))
                            continue;
                    }

                    int daysLeft = (expiryDate.Date - DateTime.UtcNow.Date).Days;
                    if (daysLeft < 0) daysLeft = 0;

                    if (!expiringUnits.ContainsKey(Id))
                        expiringUnits.Add(Id, daysLeft);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Fetching Expiring Units : {ex.Message}");
            }
            return expiringUnits;
        }

        private BloodUnit MapBloodUnit(SqliteDataReader reader)
        {
            return new BloodUnit
            {
                Id = reader["Id"].ToString()!,
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(reader["BloodGroup"]?.ToString() ?? string.Empty),
                CollectedDate = DateTime.Parse(reader["CollectedDate"].ToString() ?? string.Empty),
                ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString() ?? string.Empty),
                DonorId = reader["DonorId"].ToString()!,
                Status = EnumHelper.GetValueFromDescription<BloodUnitStatus>(reader["Status"]?.ToString() ?? string.Empty),
                UserId = reader["UserId"].ToString()!,
                Notes = reader["Notes"]?.ToString()!,
                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString() ?? string.Empty)
            };
        }


        int IBloodUnitRepository.MarkExpiredUnits()
        {
            try
            {
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                string sql = @"UPDATE BloodUnits 
                   SET Status = 'Expired'
                   WHERE ExpiryDate < @today 
                   AND Status != 'Expired';";
                using SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
