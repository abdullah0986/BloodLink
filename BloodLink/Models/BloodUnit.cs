using System;

namespace BloodLink.Models
{
    public class BloodUnit
    {
        public string Id { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        public DateTime CollectedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DonorId { get; set; }
        public BloodUnitStatus? Status { get; set; } = BloodUnitStatus.Available;
        public string Notes { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public static string GenerateBloodUnitId(string bloodGroup)
        {
            string year = DateTime.UtcNow.Year.ToString();

            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            return $"{bloodGroup} -— BL-{year}-{uniquePart}";
        }
    }
}