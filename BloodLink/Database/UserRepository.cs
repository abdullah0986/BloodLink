using BloodLink.Helpers;
using BloodLink.Models;
using Microsoft.Data.Sqlite;

namespace BloodLink.Database
{
    public class UserRepository
    {
        // Creates a new user in the database
        // Used by: StaffManagementPage when admin creates operator
        public bool CreateUser(User user)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = @"
    INSERT INTO Users (FullName, Email, Password, Role, IsAdmin, CreatedAt)
    VALUES (@fullName, @email, @password, @role, @isAdmin, @createdAt);
";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@fullName", user.FullName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", user.Role.ToString());
                command.Parameters.AddWithValue("@isAdmin", user.IsAdmin ? 1 : 0);
                command.Parameters.AddWithValue("@createdAt", user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}");
                return false;
            }
        }

        // Fetches a user by email
        // Used by: AuthService during login
        public User? GetUserByEmail(string email)
        {
            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "SELECT * FROM Users WHERE Email = @email;";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@email", email);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                    return MapUser(reader);

                return null; // user not found
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user: {ex.Message}");
                return null;
            }
        }

        // Checks if email is already registered
        // Used by: RegisterForm to prevent duplicates
        public bool EmailExists(string email)
        {
            using var connection = DatabaseHelper.GetConnection();
            string sql = "SELECT COUNT(*) FROM Users WHERE Email = @email;";

            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);

            long count = (long)command.ExecuteScalar();
            return count > 0;
        }

        // Fetches all users — for admin panel
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                using var connection = DatabaseHelper.GetConnection();
                string sql = "SELECT * FROM Users WHERE IsAdmin = 0 ORDER BY CreatedAt DESC;";

                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    users.Add(MapUser(reader));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching users: {ex.Message}");
            }

            return users;
        }

        // Converts a database row into a User object
        // Private — only used inside this class
        private User MapUser(SqliteDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                FullName = reader["FullName"].ToString(),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                Role = Enum.Parse<Role>(reader["Role"].ToString()),
                IsAdmin = Convert.ToInt32(reader["IsAdmin"]) == 1,
                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString())
            };
        }
    }
}