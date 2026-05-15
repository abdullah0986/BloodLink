using BloodLink.Database;
using BloodLink.Models;

namespace BloodLink.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        // ─────────────────────────────────────────
        // LOGIN
        // Called by: LoginForm
        // ─────────────────────────────────────────
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

        // ─────────────────────────────────────────
        // CREATE OPERATOR
        // Called by: StaffManagementPage (admin only)
        // ─────────────────────────────────────────
        public (bool success, string message) CreateOperator(string fullName, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
                return (false, "All fields are required.");

            if (!IsValidEmail(email))
                return (false, "Please enter a valid email address.");

            if (password != confirmPassword)
                return (false, "Passwords do not match.");

            if (password.Length < 6)
                return (false, "Password must be at least 6 characters.");

            if (_userRepository.EmailExists(email.Trim().ToLower()))
                return (false, "An account with this email already exists.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            User newUser = new User
            {
                FullName = fullName.Trim(),
                Email = email.Trim().ToLower(),
                Password = hashedPassword,
                Role = Role.Operator,
                IsAdmin = false,
                CreatedAt = DateTime.Now
            };

            bool created = _userRepository.CreateUser(newUser);

            if (!created)
                return (false, "Something went wrong. Please try again.");

            return (true, "Operator account created successfully.");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim().ToLower();
            }
            catch
            {
                return false;
            }
        }
    }
}