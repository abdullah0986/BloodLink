using BloodLink.Core.Database;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;

namespace BloodLink.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }
        public (bool success, string message, User? user) Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, "Email and password are required.", null);

            User? user = _userRepository.GetUserByEmail(email.Trim().ToLower());

            if (user == null)
                return (false, "No account found with this email.", null);

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!passwordMatch)
                return (false, "Incorrect password.", null);

            return (true, "Login successful.", user);
        }

        public (bool success, string message) CreateOperator(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password))
                return (false, "All fields are required.");

            if (!IsValidEmail(user.Email))
                return (false, "Please enter a valid email address.");

            if (user.Password.Length < 6)
                return (false, "Password must be at least 6 characters.");

            if (_userRepository.EmailExists(user.Email.Trim().ToLower()))
                return (false, "An account with this email already exists.");


            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            User newUser = new User
            {
                Id = User.GenerateUserId(),
                FullName = user.FullName.Trim(),
                Email = user.Email.Trim().ToLower(),
                Password = hashedPassword,
                Role = user.Role,
                CreatedAt = DateTime.Now
            };

            bool created = _userRepository.CreateUser(newUser);

            if (!created)
                return (false, "Something went wrong. Please try again.");

            return (true, "Operator account created successfully.");
        }

        public (bool Success, string Message) UpdateUser(User user, string plainTextPassword = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.FullName))
                {
                    return (false, "Full Name cannot be left empty.");
                }

                if (!IsValidEmail(user.Email))
                    return (false, "Please enter a valid email address.");

                if (user.Role == null)
                {
                    return (false, "Please select a valid role for the user.");
                }

                if (!string.IsNullOrWhiteSpace(plainTextPassword))
                {
                    if (plainTextPassword.Length < 6)
                    {
                        return (false, "Password must be at least 6 characters long.");
                    }
                    user.Password = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
                }
                else
                {
                    string existingHash = _userRepository.GetPasswordHashById(user.Id);
                    if (string.IsNullOrEmpty(existingHash))
                    {
                        return (false, "User record was not found in the database.");
                    }
                    user.Password = existingHash;
                }

                bool result = _userRepository.UpdateUser(user);

                if (result)
                    return (true, "User updated successfully.");
                else
                    return (false, "Failed to update the database record.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return (false, $"An unexpected error occurred: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public int DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return 0;

            return _userRepository.DeleteUser(id);
        }
    }
}