using System;

namespace BloodLink.Models
{
    public class BloodUnit
    {
        public int Id { get; set; }
        public string BagId { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public DateTime CollectedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int DonorId { get; set; }
        public BloodUnitStatus Status { get; set; } = BloodUnitStatus.Available;
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public static string GenerateBagId(string bloodGroup)
        {
            string year = DateTime.UtcNow.Year.ToString();

            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            return $"{bloodGroup} -— BL-{year}-{uniquePart}";
        }
    }
}