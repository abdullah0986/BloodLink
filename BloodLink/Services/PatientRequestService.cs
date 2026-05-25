using BloodLink.Database;
using BloodLink.Interfaces;
using BloodLink.Models;
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

            if (request.PatientAge.HasValue && (request.PatientAge < 18 || request.PatientAge > 65))
                return (-1, "Patient Age must be between 18 to 65");

            if (!Enum.IsDefined(typeof(BloodGroup), request.BloodGroup))
                return (-1, "Please Select Valid Blood Group");

            if (request.UnitsRequired <= 0)
                return (-1, "Units Required must be greater than 0");

            if (!Enum.IsDefined(typeof(RequestStatus), request.Status))
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

            if (string.IsNullOrWhiteSpace(request.Id))
                return (-1, "Request ID is required for an update");

            if (string.IsNullOrWhiteSpace(request.userId))
                return (-1, "User ID is required");

            if (string.IsNullOrWhiteSpace(request.PatientName))
                return (-1, "Patient Name Field is required");

            if (request.PatientAge.HasValue && (request.PatientAge < 18 || request.PatientAge > 65))
                return (-1, "Patient Age must be between 18 to 65");

            if (!Enum.IsDefined(typeof(BloodGroup), request.BloodGroup))
                return (-1, "Please Select Valid Blood Group");

            if (request.UnitsRequired <= 0)
                return (-1, "Units Required must be greater than 0");

            if (!Enum.IsDefined(typeof(RequestStatus), request.Status))
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

        public int GetAllPatientInDay()
        {
            return _patientRequestRepository.GetAllPatientInDay();
        }

        public List<PatientModel> GetRecentPatientRequests()
        {
            return _patientRequestRepository.getRecentPatientRequests();
        }

        public Dictionary<string, int> GetRequestStatusStats()
        {
            return _patientRequestRepository.GetRequestStatusStats();
        }
    }
}
