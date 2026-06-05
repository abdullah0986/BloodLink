using BloodLink.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodLink.Core.Interfaces
{
    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public User? GetUserByEmail(string email);
        public bool EmailExists(string email);
        public List<User> GetAllUsers();
        public int DeleteUser(string userId);
        public bool UpdateUser(User user);
        public string GetPasswordHashById(string userId);
    }
}
