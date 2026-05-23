using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace BloodLink.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsAdmin { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        public static string GenerateUserId()
        {
            string year = DateTime.UtcNow.Year.ToString();
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return $"USR-{year}-{uniquePart}";
        }
    }
}
