using System;

namespace BloodLink.Models
{
    public class PatientRequest
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public int? PatientAge { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int UnitsRequired { get; set; }
        public string? Ward { get; set; }
        public string? DoctorName { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public string? Notes { get; set; }
        public string userId { get; set; }
        public DateTime CreatedAt { get; set; }

        static public string generatePatientRequestId()
        {
            string year = DateTime.UtcNow.Year.ToString();
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return $"PR-{year}-{uniquePart}";
        }
    }
}