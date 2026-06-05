using BloodLink.Core.Database;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Services
{
    public class PatientRequestService
    {
        public IPatientRequestRepository _patientRequestRepository;

        public PatientRequestService()
        {
            _patientRequestRepository = new PatientRequestRepository();
        }

        public (int, string) AddRequest(PatientRequest request)
        {
            if (request == null)
                return (-1, "Request is not received");

           if (string.IsNullOrWhiteSpace(request.userId))
                return (-1, "User ID is required");

            if (string.IsNullOrWhiteSpace(request.PatientName))
                return (-1, "Patient Name Field is required");

            if (request.PatientAge.HasValue && request.PatientAge > 100)
                return (-1, "Valid Patient Age is required.");

            if (request.BloodGroup == null)
                return (-1, "Please Select Valid Blood Group");

            if (request.UnitsRequired <= 0)
                return (-1, "Units Required must be greater than 0");

            if (request.Status == null)
                return (-1, "Please Select Valid Request Status");

            request.Id = PatientRequest.generatePatientRequestId();
            request.CreatedAt = DateTime.UtcNow;

            int result = _patientRequestRepository.AddRequest(request);
            if (result <= 0)
                return (-1, "Something Went Wrong in Db");
            return (1, "Patient Request Added Successfully");
        }

        public (int, string) UpdateRequest(PatientRequest request)
        {
            if (request == null)
                return (-1, "Request is not received");

            if (string.IsNullOrWhiteSpace(request.userId))
                return (-1, "User ID is required");

            if (string.IsNullOrWhiteSpace(request.PatientName))
                return (-1, "Patient Name Field is required");

            if (request.PatientAge.HasValue && request.PatientAge > 100)
                return (-1, "Valid Patient Age is required.");

            if (request.BloodGroup == null)
                return (-1, "Please Select Valid Blood Group");

            if (request.UnitsRequired <= 0)
                return (-1, "Units Required must be greater than 0");

            if (request.Status == null)
                return (-1, "Please Select Valid Request Status");
            try
            {
                int result = _patientRequestRepository.UpdateRequest(request);

                if (result <= 0)
                    return (0, "No changes made. Request record not found");

                return (1, "Patient Request Updated Successfully");
            }
            catch (Exception)
            {
                return (-1, "Something went wrong while processing the update in the database");
            }
        }

        public (int, string) DeleteRecord(string id)
        {
            if(id == null) 
                return (-1, "Did not find id");

             int result = _patientRequestRepository.DeleteRequest(id);
            if (result <= 0) return (-1, "Something Went Wrong while deleting record");
            return (1, "Record Deleted Successfully");
        }

        public List<PatientRequest> GetAllRequests()
        {
            return _patientRequestRepository.GetAllRequests();
        }

        public List<PatientRequest> SearchPatientRecords(string searchTerm, BloodGroup? bg, RequestStatus? rs)
        {
            return _patientRequestRepository.SearchPatientRequests(searchTerm, bg, rs);
        }

        public async Task<int> GetAllPatientInDayAsync()
        {
            return await _patientRequestRepository.GetAllPatientInDayAsync();
        }

        public async Task<int> GetPatientsPendingTodayAsync()
        {
            return await _patientRequestRepository.GetPatientsPendingTodayAsync();
        }

        public async Task<List<PatientModel>> GetRecentPatientRequestsAsync()
        {
            return await _patientRequestRepository.getRecentPatientRequestsAsync();
        }

        public async Task<Dictionary<string, int>> GetRequestStatusStatsAsync()
        {
            return await _patientRequestRepository.GetRequestStatusStatsAsync();
        }
    }
}
