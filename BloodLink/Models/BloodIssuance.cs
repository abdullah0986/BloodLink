using System;

namespace BloodLink.Models
{
    public class BloodIssuance
    {
        public int Id { get; set; }
        public int PatientRequestId { get; set; }
        public int BloodUnitId { get; set; }
        public int IssuedByUserId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Notes { get; set; }
    }
}