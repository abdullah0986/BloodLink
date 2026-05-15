using BloodLink.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Services
{
    public class PatientRequestService
    {
        public PatientRequestRepository _PatientRequestRepository;

        public PatientRequestService()
        {
            _PatientRequestRepository = new PatientRequestRepository();
        }

        public int GetAllPatientInDay()
        {
            return _PatientRequestRepository.GetAllPatientInDay();
        }

        public List<PatientRequestRepository.PatientModel> GetRecentPatientRequests()
        {
            return _PatientRequestRepository.getRecentPatientRequests();
        }
    }
}
