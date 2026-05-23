using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Models
{
    public class Donor
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public BloodGroup? BloodGroup { get; set; }  
        public string Phone { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }
        public bool IsEligible { get; set; } = true;
        public DateTime? LastDonationDate { get; set; }
        public DateTime? NextEligibleDate { get; set; }
        public double? Weight { get; set; }
        public string UserId { get; set; } 
        public DateTime CreatedAt { get; set; }

        public string generateDonorId()
        {
            string year = DateTime.UtcNow.Year.ToString();
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return $"DNR-{year}-{uniquePart}";

        }
    }
}
