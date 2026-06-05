using BloodLink.Core.Helpers;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using Microsoft.Data.SqlClient;

namespace BloodLink.Core.Database
{
    public class PatientRequestRepository : IPatientRequestRepository
    {
        int IPatientRequestRepository.AddRequest(PatientRequest patientRequest)
        {
            try
            {
                using SqlConnection connection = DbConnection.GetConnection();
                string sql = @"INSERT INTO PatientRequests 
                            (Id, PatientName, PatientAge, BloodGroup, UnitsRequired, Ward, DoctorName, Status, Notes, UserId, CreatedAt)
                            VALUES (@id, @patientName, @patientAge, @bloodGroup, @unitsRequired, @ward, @doctorName, @status, @notes, @userId, @createdAt);";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", patientRequest.Id);
                cmd.Parameters.AddWithValue("@patientName", patientRequest.PatientName.ToString());
                cmd.Parameters.AddWithValue("@patientAge", patientRequest.PatientAge ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(patientRequest.BloodGroup));
                cmd.Parameters.AddWithValue("@unitsRequired", patientRequest.UnitsRequired <= 0 ? 0 : patientRequest.UnitsRequired);
                cmd.Parameters.AddWithValue("@ward", (object?)patientRequest.Ward ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@doctorName", patientRequest.DoctorName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", EnumHelper.GetDescription(patientRequest.Status));
                cmd.Parameters.AddWithValue("@notes", (object?)patientRequest.Notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@userId", patientRequest.userId);
                cmd.Parameters.AddWithValue("@createdAt", patientRequest.CreatedAt);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding patient request. {ex.Message}");
                throw;
            }
        }

        int IPatientRequestRepository.UpdateRequest(PatientRequest patientRequest)
        {
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"UPDATE PatientRequests SET
                                PatientName = @patientName,
                                PatientAge = @patientAge, 
                                BloodGroup = @bloodGroup, 
                                UnitsRequired = @unitsRequired, 
                                Ward = @ward, 
                                DoctorName = @doctorName, 
                                Status = @status, 
                                Notes = @notes, 
                                UserId = @userId
                               WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", patientRequest.Id);
                cmd.Parameters.AddWithValue("@patientName", patientRequest.PatientName.ToString());
                cmd.Parameters.AddWithValue("@patientAge", patientRequest.PatientAge ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(patientRequest.BloodGroup));
                cmd.Parameters.AddWithValue("@unitsRequired", patientRequest.UnitsRequired <= 0 ? 0 : patientRequest.UnitsRequired);
                cmd.Parameters.AddWithValue("@ward", (object?)patientRequest.Ward ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@doctorName", patientRequest.DoctorName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", EnumHelper.GetDescription(patientRequest.Status));
                cmd.Parameters.AddWithValue("@notes", (object?)patientRequest.Notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@userId", patientRequest.userId);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating patient Request. {ex.Message}");
                throw;
            }
        }

        int IPatientRequestRepository.DeleteRequest(string id)
        {
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"DELETE FROM PatientRequests WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting patient Request. {ex.Message}");
                throw;
            }
        }

        List<PatientRequest> IPatientRequestRepository.GetAllRequests()
        {
            List<PatientRequest> _pr = new List<PatientRequest>();
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"SELECT * FROM PatientRequests ORDER BY CreatedAt DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    _pr.Add(MapPatientRequest(reader));
                return _pr;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting list of Patient Requests. {ex.Message}");
                throw;
            }
        }

        List<PatientRequest> IPatientRequestRepository.SearchPatientRequests(string searchTerm, BloodGroup? bg, RequestStatus? rs)
        {
            List<PatientRequest> _pr = new List<PatientRequest>();
            try
            {
                using SqlConnection conn = DbConnection.GetConnection();
                string sql = @"PatientName LIKE @searchTerm";

                if (bg != null)
                    sql += " AND BloodGroup = @bloodGroup";

                if (rs != null)
                    sql += " AND Status = @status";

                string completeSql = $"SELECT * FROM PatientRequests WHERE {sql} ORDER BY CreatedAt ASC";
                SqlCommand cmd = new SqlCommand(completeSql, conn);
                cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm.Trim()}%");

                if (bg != null)
                    cmd.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(bg));
                if (rs != null)
                    cmd.Parameters.AddWithValue("@status", EnumHelper.GetDescription(rs));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    _pr.Add(MapPatientRequest(reader));

                return _pr;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while searching Patient Requests. {ex.Message}");
                throw;
            }
        }

        async Task<int> IPatientRequestRepository.GetAllPatientInDayAsync()
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT COUNT(*) FROM PatientRequests 
                               WHERE CreatedAt >= DATEADD(HOUR, -24, GETUTCDATE());";
                using var command = new SqlCommand(sql, connection);
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching patient requests: {ex.Message}");
                return 0;
            }
        }

        async Task<int> IPatientRequestRepository.GetPatientsPendingTodayAsync()
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT COUNT(*) FROM PatientRequests 
                               WHERE CreatedAt >= DATEADD(HOUR, -24, GETUTCDATE()) 
                               AND Status = 'Pending';";
                using var command = new SqlCommand(sql, connection);
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching pending patient requests: {ex.Message}");
                return 0;
            }
        }

        async Task<List<PatientModel>> IPatientRequestRepository.getRecentPatientRequestsAsync()
        {
            var requests = new List<PatientModel>();
            try
            {
                using var connection = DbConnection.GetConnection(); 

                const string sql = @"
                    SELECT PatientName, BloodGroup, UnitsRequired, DoctorName, Status, CreatedAt
                    FROM PatientRequests
                    WHERE (CreatedAt >= DATEADD(HOUR, -24, GETUTCDATE()) OR Status = 'Pending')
                    ORDER BY CreatedAt DESC;";

                using var command = new SqlCommand(sql, connection);
                using var reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                    return requests;

                int idxPatientName = reader.GetOrdinal("PatientName");
                int idxBloodGroup = reader.GetOrdinal("BloodGroup");
                int idxUnits = reader.GetOrdinal("UnitsRequired");
                int idxDoctor = reader.GetOrdinal("DoctorName");
                int idxStatus = reader.GetOrdinal("Status");
                int idxCreatedAt = reader.GetOrdinal("CreatedAt");

                while (await reader.ReadAsync())
                {
                    var model = new PatientModel();

                    model.patientName = !reader.IsDBNull(idxPatientName)
                        ? reader.GetString(idxPatientName)
                        : string.Empty;

                    model.group = !reader.IsDBNull(idxBloodGroup)
                        ? reader.GetString(idxBloodGroup)
                        : default;

                    model.unitsRequired = !reader.IsDBNull(idxUnits)
                        ? reader.GetInt32(idxUnits)
                        : 0;

                    model.doctorName = !reader.IsDBNull(idxDoctor)
                        ? reader.GetString(idxDoctor)
                        : string.Empty;

                    if (!reader.IsDBNull(idxStatus))
                    {
                        var stStr = reader.GetString(idxStatus);
                        if (!Enum.TryParse<RequestStatus>(stStr, true, out var st))
                            st = default;
                        model.status = st;
                    }
                    else
                    {
                        model.status = default;
                    }

                    model.CreatedAt = !reader.IsDBNull(idxCreatedAt)
                        ? reader.GetDateTime(idxCreatedAt)
                        : DateTime.UtcNow;

                    requests.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching recent patient requests: {ex.Message}");
            }
            return requests;
        }

        async Task<Dictionary<string, int>> IPatientRequestRepository.GetRequestStatusStatsAsync()
        {
            var result = new Dictionary<string, int>();
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"SELECT Status, COUNT(*) as Count
                               FROM PatientRequests
                               WHERE YEAR(CreatedAt) = YEAR(GETUTCDATE())
                               AND MONTH(CreatedAt) = MONTH(GETUTCDATE())
                               GROUP BY Status";
                using var command = new SqlCommand(sql, connection);
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string status = reader["Status"]?.ToString() ?? string.Empty;
                    int count = Convert.ToInt32(reader["Count"]);
                    if (!string.IsNullOrEmpty(status))
                        result[status] = count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching request status stats: {ex.Message}");
            }
            return result;
        }

        private PatientRequest MapPatientRequest(SqlDataReader reader)
        {
            return new PatientRequest
            {
                Id = reader["Id"].ToString()!,
                PatientName = reader["PatientName"].ToString()!,
                PatientAge = reader["PatientAge"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(reader["PatientAge"]),
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(
                    reader["BloodGroup"]?.ToString() ?? string.Empty),
                UnitsRequired = Convert.ToInt32(reader["UnitsRequired"]),
                Ward = reader["Ward"] == DBNull.Value ? null : reader["Ward"].ToString(),
                DoctorName = reader["DoctorName"] == DBNull.Value ? null : reader["DoctorName"].ToString(),
                Status = Enum.Parse<RequestStatus>(reader["Status"]?.ToString() ?? "Pending"),
                Notes = reader["Notes"] == DBNull.Value ? null : reader["Notes"].ToString(),
                userId = reader["UserId"] == DBNull.Value ? null : reader["UserId"].ToString()!,
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }
    }
}