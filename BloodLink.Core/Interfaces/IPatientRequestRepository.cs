using BloodLink.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Interfaces
{
    public interface IPatientRequestRepository
    {
        public int AddRequest(PatientRequest patientRequest);
        public int UpdateRequest(PatientRequest patientRequest);
        public int DeleteRequest(string id);
        public List<PatientRequest> GetAllRequests();
        public List<PatientRequest> SearchPatientRequests(string searchItem, BloodGroup? bg, RequestStatus? rs);
        public Task<int> GetAllPatientInDayAsync();
        public Task<List<PatientModel>> getRecentPatientRequestsAsync();
        public Task<int> GetPatientsPendingTodayAsync();
        public Task<Dictionary<string, int>> GetRequestStatusStatsAsync();
    }
}
