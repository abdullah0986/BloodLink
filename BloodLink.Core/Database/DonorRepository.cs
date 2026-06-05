using BloodLink.Core.Helpers;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using Microsoft.Data.SqlClient;

namespace BloodLink.Core.Database
{
    public class DonorRepository : IDonorRepository
    {
        int IDonorRepository.AddDonor(Donor donor)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"
                    INSERT INTO Donors (Id, FullName, BloodGroup, Phone, City, Area, Age, Gender,
                                        IsEligible, LastDonationDate, NextEligibleDate, Weight, UserId, CreatedAt)
                                        VALUES (@Id, @fullName, @bloodGroup, @phone, @city, @area, @age, @gender,
                                        @isEligible, @lastDonationDate, @nextEligibleDate, @weight, @userId, @createdAt)";

                using var command = new SqlCommand(sql, connection);
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
                    ? donor.NextEligibleDate.Value
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@weight", donor.Weight.HasValue
                    ? donor.Weight.Value
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@lastDonationDate", donor.LastDonationDate.HasValue
                    ? donor.LastDonationDate.Value
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@userId", donor.UserId.ToString());
                command.Parameters.AddWithValue("@createdAt", donor.CreatedAt);

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding donor: {ex.Message}");
                return -1;
            }
        }

        List<Donor> IDonorRepository.GetAllDonors()
        {
            var donors = new List<Donor>();
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = "SELECT * FROM Donors ORDER BY CreatedAt ASC;";

                using var command = new SqlCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    donors.Add(MapDonor(reader));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching donors: {ex.Message}");
            }
            return donors;
        }

        int IDonorRepository.DonorsThisMonth()
        {
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"SELECT COUNT(*) FROM Donors 
                               WHERE YEAR(CreatedAt) = YEAR(GETUTCDATE()) 
                               AND MONTH(CreatedAt) = MONTH(GETUTCDATE());";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while getting donors joined this month");
                throw;
            }
        }

        List<Donor> IDonorRepository.SearchDonors(string searchTerm, List<string>? bloodGroups, DonorEligibility? eligibility)
        {
            var donors = new List<Donor>();
            try
            {
                var conditions = new List<string>();
                var parameters = new Dictionary<string, object>();

                conditions.Add("(Id LIKE @search OR FullName LIKE @search OR City LIKE @search OR Phone LIKE @search)");
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
                    conditions.Add("IsEligible = @eligibility");
                    parameters["@eligibility"] = (int)eligibility;
                }

                var whereClause = "WHERE " + string.Join(" AND ", conditions);
                var sql = $"SELECT * FROM Donors {whereClause} ORDER BY CreatedAt DESC";

                using var connection = DbConnection.GetConnection();
                using var command = new SqlCommand(sql, connection);

                foreach (var param in parameters)
                    command.Parameters.AddWithValue(param.Key, param.Value);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                    donors.Add(MapDonor(reader));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching donors: {ex.Message}");
            }
            return donors;
        }

        bool IDonorRepository.UpdateDonor(Donor donor)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
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
                    WHERE Id = @id;";

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fullName", donor.FullName);
                command.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(donor.BloodGroup));
                command.Parameters.AddWithValue("@phone", donor.Phone);
                command.Parameters.AddWithValue("@city", donor.City);
                command.Parameters.AddWithValue("@area", donor.Area ?? "");
                command.Parameters.AddWithValue("@age", donor.Age);
                command.Parameters.AddWithValue("@gender", donor.Gender.ToString());
                command.Parameters.AddWithValue("@isEligible", donor.IsEligible ? 1 : 0);
                command.Parameters.AddWithValue("@weight", donor.Weight.HasValue
                    ? donor.Weight.Value
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@lastDonationDate", donor.LastDonationDate.HasValue
                    ? donor.LastDonationDate.Value
                    : (object)DBNull.Value);
                command.Parameters.AddWithValue("@userId", donor.UserId.ToString());
                command.Parameters.AddWithValue("@id", donor.Id);

                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating donor: {ex.Message}");
                return false;
            }
        }

        async Task<DonorStats> IDonorRepository.GetDonorStatsAsync()
        {
            var stats = new DonorStats();
            try
            {
                using var connection = DbConnection.GetConnection();

                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Donors;", connection))
                    stats.TotalDonors = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Donors WHERE IsEligible = 1;", connection))
                    stats.AvailableDonors = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                using (var cmd = new SqlCommand("SELECT COUNT(DISTINCT City) FROM Donors;", connection))
                    stats.CitiesCovered = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                string bgSql = "SELECT BloodGroup, COUNT(*) as Count FROM Donors GROUP BY BloodGroup;";
                using var bgCmd = new SqlCommand(bgSql, connection);
                using var reader = await bgCmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string bg = reader["BloodGroup"].ToString()!;
                    int count = Convert.ToInt32(reader["Count"]);
                    stats.ByBloodGroup[bg] = count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching stats: {ex.Message}");
            }
            return stats;
        }

        bool IDonorRepository.DeleteDonor(string donorId)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = "DELETE FROM Donors WHERE Id = @id;";
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", donorId);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting donor: {ex.Message}");
                return false;
            }
        }

        private Donor MapDonor(SqlDataReader reader)
        {
            return new Donor
            {
                Id = reader["Id"].ToString()!,
                FullName = reader["FullName"].ToString()!,
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(reader["BloodGroup"].ToString()!),
                Phone = reader["Phone"].ToString()!,
                City = reader["City"].ToString()!,
                Area = reader["Area"] == DBNull.Value ? null : reader["Area"].ToString(),
                Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                Gender = Enum.Parse<Gender>(reader["Gender"].ToString()!),
                IsEligible = Convert.ToInt32(reader["IsEligible"]) == 1,
                Weight = reader["Weight"] != DBNull.Value ? Convert.ToDouble(reader["Weight"]) : null,
                NextEligibleDate = reader["NextEligibleDate"] != DBNull.Value
                    ? reader.GetDateTime(reader.GetOrdinal("NextEligibleDate"))
                    : null,
                LastDonationDate = reader["LastDonationDate"] != DBNull.Value
                    ? reader.GetDateTime(reader.GetOrdinal("LastDonationDate"))
                    : null,
                UserId = reader["UserId"] == DBNull.Value ? null : reader["UserId"].ToString(),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
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