using BloodLink.Helpers;
using BloodLink.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Database
{
    public class PatientRequestRepository
    {
        public int GetAllPatientInDay()
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

        public List<PatientModel> getRecentPatientRequests()
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

                // Get ordinals once for performance and safety.
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

        public class PatientModel
        {
            public string patientName { get; set; }
            public string group { get; set; }
            public int unitsRequired { get; set; }
            public string doctorName { get; set; }
            public RequestStatus status { get; set; }
        }
    }
}
