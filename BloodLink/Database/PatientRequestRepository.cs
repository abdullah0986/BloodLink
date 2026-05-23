using BloodLink.Helpers;
using BloodLink.Interfaces;
using BloodLink.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Database
{
    public class PatientRequestRepository: IPatientRequestRepository
    {

        int IPatientRequestRepository.AddRequest(PatientRequest patientRequest)
        {
            try
            {
                using SqliteConnection connection = DatabaseHelper.GetConnection();
                string sql = @"INSERT INTO PatientRequests 
                            (Id, PatientName, PatientAge, BloodGroup, UnitsRequired, Ward, DoctorName, Status, Notes, userId, CreatedAt)
                            Values (@Id, @patientName, @patientAge, @bloodGroup, @unitsRequired, @ward, @doctorName, @status, @notes
                             , @userId, @createdAt);";
                SqliteCommand cmd = new SqliteCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", PatientRequest.generatePatientRequestId());
                cmd.Parameters.AddWithValue("@patientName", patientRequest.PatientName.ToString());
                cmd.Parameters.AddWithValue("@patientAge", patientRequest.PatientAge);
                cmd.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(patientRequest.BloodGroup));
                cmd.Parameters.AddWithValue("@unitsRequired", patientRequest.UnitsRequired <= 0 ? 0 : patientRequest.UnitsRequired);
                cmd.Parameters.AddWithValue("@ward", patientRequest.Ward.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@doctorName", patientRequest.DoctorName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", EnumHelper.GetDescription(patientRequest.Status));
                cmd.Parameters.AddWithValue("@notes", patientRequest.Notes);
                cmd.Parameters.AddWithValue("@userId", patientRequest.userId);
                cmd.Parameters.AddWithValue("@createdAt", patientRequest.CreatedAt);
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error adding patient request. {ex.Message}");
                throw;
            }
        }
        int IPatientRequestRepository.UpdateRequest(PatientRequest patientRequest)
        {
            try
            {
                using SqliteConnection conn = DatabaseHelper.GetConnection();
                string sql = @"UPDATE PatientRequests SET
                                PatientName = @patientName,
                                PatientAge = @patientAge, 
                                BloodGroup = @bloodGroup, 
                                UnitsRequired = @unitsRequired, 
                                Ward = @ward, 
                                DoctorName = @doctorName, 
                                Status = @status, 
                                Notes = @notes, 
                                userId = @userId
                               WHERE Id = @Id;";
                SqliteCommand cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", patientRequest.Id);
                cmd.Parameters.AddWithValue("@patientName", patientRequest.PatientName.ToString());
                cmd.Parameters.AddWithValue("@patientAge", patientRequest.PatientAge);
                cmd.Parameters.AddWithValue("@bloodGroup", EnumHelper.GetDescription(patientRequest.BloodGroup));
                cmd.Parameters.AddWithValue("@unitsRequired", patientRequest.UnitsRequired <= 0 ? 0 : patientRequest.UnitsRequired);
                cmd.Parameters.AddWithValue("@ward", patientRequest.Ward.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@doctorName", patientRequest.DoctorName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", EnumHelper.GetDescription(patientRequest.Status));
                cmd.Parameters.AddWithValue("@notes", patientRequest.Notes);
                cmd.Parameters.AddWithValue("@userId", patientRequest.userId);
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while updating patient Request. {ex.Message}");
                throw;
            }
        }
        int IPatientRequestRepository.DeleteRequest(string id)
        {
            try
            {
                using SqliteConnection conn = DatabaseHelper.GetConnection();
                string sql = @"DELETE FROM PatientRequests WHERE Id = @id";

                SqliteCommand cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
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
                using SqliteConnection conn = DatabaseHelper.GetConnection();
                string sql = @"SELECT * FROM PatientRequests ORDER BY CreatedAt ASC";

                SqliteCommand cmd = new SqliteCommand(sql, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _pr.Add(MapPatientRequest(reader));
                }
                return _pr;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting list of Pateient Requests. {ex.Message}");
                throw;
            }
        }
        List<PatientRequest> IPatientRequestRepository.SearchPatientRequests(string searchTerm, BloodGroup? bg, RequestStatus? rs)
        {
            List<PatientRequest> _pr = new List<PatientRequest>();
            try
            {
                using SqliteConnection conn = DatabaseHelper.GetConnection();
                string sql = @"PatientName LIKE @searchTerm";

                if (bg != null)
                    sql += " AND BloodGroup = @bloodGroup";

                if (rs != null)
                    sql += " AND Status = @status";

                string completeSql = $"SELECT * FROM PatientRequests WHERE {sql} ORDER BY CreatedBy ASC";
                SqliteCommand cmd = new SqliteCommand(completeSql, conn);
                cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm.Trim()}%");

                if (bg != null)
                    cmd.Parameters.AddWithValue("@bloodGroup", bg);
                if (rs != null)
                    cmd.Parameters.AddWithValue("@status", rs);

                SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _pr.Add(MapPatientRequest(reader));
                }

                return _pr;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while searching Patient Requests. {ex.Message}");
                throw;
            }
        }
        int IPatientRequestRepository.GetAllPatientInDay()
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"SELECT COUNT(*) FROM PatientRequests WHERE CreatedAt >= datetime('now', '-24 hours');";
                using var command = new SqliteCommand(sql, connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching patient requests: {ex.Message}");
                return 0;
            }
        }
        List<PatientModel> IPatientRequestRepository.getRecentPatientRequests()
        {
            var requests = new List<PatientModel>();
            try
            {
                using var connection = DatabaseHelper.GetConnection();

                const string sql = @"
                    SELECT PatientName, BloodGroup, UnitsRequired, DoctorName, Status
                    FROM PatientRequests
                    WHERE CreatedAt >= datetime('now','-48 hours')
                    ORDER BY CreatedAt DESC;";

                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return requests;

                int idxPatientName = reader.GetOrdinal("PatientName");
                int idxBloodGroup = reader.GetOrdinal("BloodGroup");
                int idxUnits = reader.GetOrdinal("UnitsRequired");
                int idxDoctor = reader.GetOrdinal("DoctorName");
                int idxStatus = reader.GetOrdinal("Status");

                while (reader.Read())
                {
                    var model = new PatientModel();

                    model.patientName = !reader.IsDBNull(idxPatientName)
                        ? reader.GetString(idxPatientName)
                        : string.Empty;

                    if (!reader.IsDBNull(idxBloodGroup))
                    {
                        var groupStr = reader.GetString(idxBloodGroup);
                        model.group = groupStr;
                    }
                    else
                    {
                        model.group = default;
                    }

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

                    requests.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching recent patient requests: {ex.Message}");
            }

            return requests;
        }


        private PatientRequest MapPatientRequest(SqliteDataReader reader)
        {
            return new PatientRequest
            {
                Id = reader["Id"].ToString()!,
                PatientName = reader["PatientName"].ToString()!,
                PatientAge = Convert.ToInt32(reader["PatientAge"]),
                BloodGroup = EnumHelper.GetValueFromDescription<BloodGroup>(reader["BloodGroup"]?.ToString() ?? string.Empty),
                UnitsRequired = Convert.ToInt32(reader["UnitsRequired"]),
                Ward = reader["Ward"].ToString() ?? "Outsider",
                DoctorName = reader["DoctorName"].ToString() ?? "N/A",
                Status = EnumHelper.GetValueFromDescription<RequestStatus>(reader["Status"]?.ToString() ?? string.Empty),
                Notes = reader["Notes"].ToString()!,
                userId = reader["userId"].ToString()!,
                CreatedAt = DateTime.Parse(reader["createdAt"].ToString() ?? string.Empty)
            };
        }
    }
}
