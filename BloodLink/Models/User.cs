using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace BloodLink.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsAdmin { get; set; } = false; // only admins can manage donors and view history
        public DateTime CreatedAt { get; set; }
    }
}
