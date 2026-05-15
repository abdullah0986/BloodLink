using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public BloodGroup BloodGroup { get; set; }  // A+, A-, B+, B-, O+, O-, AB+, AB-
        public string Phone { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsEligible { get; set; } = true;
        public DateTime? LastDonationDate { get; set; }
        public DateTime? NextEligibleDate { get; set; }
        public double Weight { get; set; }
        public int? UserId { get; set; }  // linked to User if donor registered
        public DateTime CreatedAt { get; set; }
    }
}
