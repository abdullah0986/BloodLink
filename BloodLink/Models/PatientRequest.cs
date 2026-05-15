using System;

namespace BloodLink.Models
{
    public class PatientRequest
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int UnitsRequired { get; set; }
        public string Ward { get; set; }
        public string DoctorName { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public string Notes { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}