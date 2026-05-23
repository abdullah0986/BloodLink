using System;

namespace BloodLink.Models
{
    public class BloodIssuance
    {
        public string Id { get; set; }
        public string PatientRequestId { get; set; }
        public string BloodUnitId { get; set; }
        public string IssuedByUserId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Notes { get; set; }

        public string generateIssuanceId()
        {
            string year = DateTime.UtcNow.Year.ToString();
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return $"ISS-{year}-{uniquePart}";
        }
    }
}