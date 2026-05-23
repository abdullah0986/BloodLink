using BloodLink.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Interfaces
{
    public interface IPatientRequestRepository
    {
        public int AddRequest(PatientRequest patientRequest);
        public int UpdateRequest(PatientRequest patientRequest);
        public int DeleteRequest(string id);
        public List<PatientRequest> GetAllRequests();
        public List<PatientRequest> SearchPatientRequests(string searchItem, BloodGroup? bg, RequestStatus? rs);
        public int GetAllPatientInDay();
        public List<PatientModel> getRecentPatientRequests();
    }
}
