using BloodLink.Helpers;
using BloodLink.Models;
using Microsoft.Data.Sqlite;
using System.CodeDom;
using System.Reflection.Metadata;
using System.Windows.Media.Animation;

namespace BloodLink.Database
{
    public class DonorRepository
    {
        public int AddDonor(Donor donor)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"
                    INSERT INTO Donors (Id, FullName, BloodGroup, Phone, City, Area, Age, Gender,
                                        IsEligible, LastDonationDate, NextEligibleDate, Weight, UserId, CreatedAt)
VALUES (@Id, @fullName, @bloodGroup, @phone, @city, @area, @age, @gender,
        @isEligible, @lastDonationDate, @nextEligibleDate, @weight, @userId, @createdAt)
                ";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", donor.Id.ToString());
                command.Parameters.AddWithValue("@fullName", donor.FullName);
                command.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(donor.BloodGroup));
                command.Parameters.AddWithValue("@phone", donor.Phone);
                command.Parameters.AddWithValue("@city", donor.City);
                command.Parameters.AddWithValue("@area", donor.Area ?? "");
                command.Parameters.AddWithValue("@age", donor.Age);
                command.Parameters.AddWithValue("@gender", donor.Gender.ToString());
                command.Parameters.AddWithValue("@isEligible", donor.IsEligible ? 1 : 0);
                command.Parameters.AddWithValue("@nextEligibleDate", donor.NextEligibleDate.HasValue
                    ? donor.NextEligibleDate.Value.ToString("yyyy-MM-dd")
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@weight", donor.Weight);
                command.Parameters.AddWithValue("@lastDonationDate", donor.LastDonationDate.HasValue
                                                                        ? donor.LastDonationDate.Value.ToString("yyyy-MM-dd")
                                                                        : (object)DBNull.Value);
                command.Parameters.AddWithValue("@userId", donor.UserId.ToString());
                command.Parameters.AddWithValue("@createdAt", donor.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

                int result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding donor: {ex.Message}");
                return -1;
            }
        }
        public Donor? GetDonorByUserId(int userId)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "SELECT * FROM Donors WHERE UserId = @userId LIMIT 1;";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@userId", userId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                    return MapDonor(reader);

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching donor: {ex.Message}");
                return null;
            }
        }

        public Donor? GetDonorById(int donorId)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "SELECT * FROM Donors WHERE Id = @id LIMIT 1;";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", donorId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                    return MapDonor(reader);

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching donor: {ex.Message}");
                return null;
            }
        }

        public List<Donor> GetAllDonors()
        {
            var donors = new List<Donor>();
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "SELECT * FROM Donors ORDER BY CreatedAt ASC;";

                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    donors.Add(MapDonor(reader));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching donors: {ex.Message}");
            }
            return donors;
        }


        public List<Donor> SearchDonors(string searchTerm, List<string>? bloodGroups, DonorEligibility? eligibility)
        {
            var donors = new List<Donor>();
            try
            {
                var conditions = new List<string>();
                var parameters = new Dictionary<string, object>();

                conditions.Add("(FullName LIKE @search OR City LIKE @search OR Phone LIKE @search)");
                parameters["@search"] = $"%{searchTerm.Trim()}%";

                if (bloodGroups != null && bloodGroups.Count > 0)
                {
                    var placeholders = bloodGroups.Select((_, i) => $"@bg{i}").ToList();
                    conditions.Add($"BloodGroup IN ({string.Join(", ", placeholders)})");
                    for (int i = 0; i < bloodGroups.Count; i++)
                        parameters[$"@bg{i}"] = bloodGroups[i];
                }

                if (eligibility != null)
                {
                    conditions.Add("isEligible = @eligibility");
                    parameters["@eligibility"] = (int)eligibility;
                }
                var WhereClause = "WHERE " + string.Join(" AND ", conditions);
                var sql = $@"SELECT * FROM Donors {WhereClause} ORDER BY CreatedAt DESC";
                using var connection = DatabaseHelper.GetConnection();
                using var command = new SqliteCommand(sql, connection);

                foreach(var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    donors.Add(MapDonor(reader));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching donors: {ex.Message}");
            }
            return donors;
        }

        public bool UpdateDonor(Donor donor)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"
                    UPDATE Donors SET
                        FullName         = @fullName,
                        BloodGroup       = @bloodGroup,
                        Phone            = @phone,
                        City             = @city,
                        Area             = @area,
                        Age              = @age,
                        Gender           = @gender,
                        IsEligible       = @isEligible,
                        Weight           = @weight,
                        LastDonationDate = @lastDonationDate,
                        UserId           = @userId
                    WHERE Id = @id;
                ";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@fullName", donor.FullName);
                command.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(donor.BloodGroup));
                command.Parameters.AddWithValue("@phone", donor.Phone);
                command.Parameters.AddWithValue("@city", donor.City);
                command.Parameters.AddWithValue("@area", donor.Area ?? "");
                command.Parameters.AddWithValue("@age", donor.Age);
                command.Parameters.AddWithValue("@gender", donor.Gender.ToString());
                command.Parameters.AddWithValue("@isEligible", donor.IsEligible ? 1 : 0);
                command.Parameters.AddWithValue("@weight", donor.Weight);
                command.Parameters.AddWithValue("@lastDonationDate", donor.LastDonationDate.HasValue
                                                                        ? donor.LastDonationDate.Value.ToString("yyyy-MM-dd")
                                                                        : (object)DBNull.Value);
                command.Parameters.AddWithValue("@userId", donor.UserId.ToString());
                command.Parameters.AddWithValue("@id", donor.Id);

                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating donor: {ex.Message}");
                return false;
            }
        }
        public bool ToggleEligibility(int donorId, bool newStatus)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "UPDATE Donors SET IsEligible = @status WHERE Id = @id;";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@status", newStatus ? 1 : 0);
                command.Parameters.AddWithValue("@id", donorId);

                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error toggling availability: {ex.Message}");
                return false;
            }
        }

        public DonorStats GetDonorStats()
        {
            var stats = new DonorStats();
            try
            {
                using var connection = DatabaseHelper.GetConnection();

                // Total donors
                using (var cmd = new SqliteCommand("SELECT COUNT(*) FROM Donors;", connection))
                    stats.TotalDonors = Convert.ToInt32(cmd.ExecuteScalar());

                // Available donors
                using (var cmd = new SqliteCommand("SELECT COUNT(*) FROM Donors WHERE IsEligible  = 1;", connection))
                    stats.AvailableDonors = Convert.ToInt32(cmd.ExecuteScalar());

                // Distinct cities
                using (var cmd = new SqliteCommand("SELECT COUNT(DISTINCT City) FROM Donors;", connection))
                    stats.CitiesCovered = Convert.ToInt32(cmd.ExecuteScalar());

                // Count per blood group
                string bgSql = "SELECT BloodGroup, COUNT(*) as Count FROM Donors GROUP BY BloodGroup;";
                using var bgCmd = new SqliteCommand(bgSql, connection);
                using var reader = bgCmd.ExecuteReader();
                while (reader.Read())
                {
                    string bg = reader["BloodGroup"].ToString()!;
                    int count = Convert.ToInt32(reader["Count"]);
                    stats.ByBloodGroup[bg] = count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching stats: {ex.Message}");
            }
            return stats;
        }

        public bool DeleteDonor(string donorId)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "DELETE FROM Donors WHERE Id = @id;";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", donorId);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting donor: {ex.Message}");
                return false;
            }
        }

        private Donor MapDonor(SqliteDataReader reader)
        {
            return new Donor
            {
                Id = reader["Id"].ToString()!,
                FullName = reader["FullName"].ToString()!,
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(reader["BloodGroup"].ToString()!),
                Phone = reader["Phone"].ToString()!,
                City = reader["City"].ToString()!,
                Area = reader["Area"].ToString()!,
                Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                Gender = Enum.Parse<Gender>(reader["Gender"].ToString()!),
                IsEligible = Convert.ToInt32(reader["IsEligible"]) == 1,
                Weight = reader["Weight"] != DBNull.Value ? Convert.ToDouble(reader["Weight"]) : 0,
                NextEligibleDate = reader["NextEligibleDate"] != DBNull.Value
    ? DateTime.Parse(reader["NextEligibleDate"].ToString()!)
    : null,
                LastDonationDate = reader["LastDonationDate"] != DBNull.Value
                                    ? DateTime.Parse(reader["LastDonationDate"].ToString()!)
                                    : null,
                UserId = reader["UserId"].ToString(),
                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()!)
            };
        }
    }

    public class DonorStats
    {
        public int TotalDonors { get; set; }
        public int AvailableDonors { get; set; }
        public int CitiesCovered { get; set; }
        public Dictionary<string, int> ByBloodGroup { get; set; } = new();
    }
}