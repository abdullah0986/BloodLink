using BloodLink.Core.Helpers;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
using Microsoft.Data.SqlClient;

namespace BloodLink.Core.Database
{
    public class UserRepository : IUserRepository
    {
        bool IUserRepository.CreateUser(User user)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = @"INSERT INTO Users (Id, FullName, Email, Password, Role, CreatedAt)
                              VALUES (@Id, @fullName, @email, @password, @role, @createdAt);";

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@fullName", user.FullName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", user.Role.ToString());
                command.Parameters.AddWithValue("@createdAt", user.CreatedAt);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                return false;
            }
        }

        User? IUserRepository.GetUserByEmail(string email)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = "SELECT * FROM Users WHERE Email = @email;";

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@email", email);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                    return MapUser(reader);

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user: {ex.Message}");
                return null;
            }
        }

        bool IUserRepository.EmailExists(string email)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = "SELECT COUNT(*) FROM Users WHERE Email = @email;";

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@email", email);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking email existence: {ex.Message}");
                return false;
            }
        }

        List<User> IUserRepository.GetAllUsers()
        {
            var users = new List<User>();
            try
            {
                using var connection = DbConnection.GetConnection();
                string sql = "SELECT * FROM Users ORDER BY CreatedAt DESC;";

                using var command = new SqlCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    users.Add(MapUser(reader));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
            }
            return users;
        }

        int IUserRepository.DeleteUser(string userId)
        {
            try
            {
                using var conn = DbConnection.GetConnection();
                var cmd = new SqlCommand(
                    "DELETE FROM Users WHERE Id = @id AND Role != 'Admin';", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting Operator. {ex.Message}");
                throw;
            }
        }

        bool IUserRepository.UpdateUser(User user)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string query = @"UPDATE Users 
                                 SET FullName = @FullName, 
                                     Email = @Email, 
                                     Role = @Role, 
                                     Password = @Password 
                                 WHERE Id = @Id;";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Role", user.Role.ToString());
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Id", user.Id);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        string IUserRepository.GetPasswordHashById(string userId)
        {
            try
            {
                using var connection = DbConnection.GetConnection();
                string query = "SELECT Password FROM Users WHERE Id = @Id;";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", userId);

                object result = command.ExecuteScalar();
                return result?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching password hash: {ex.Message}");
                return string.Empty;
            }
        }

        private User MapUser(SqlDataReader reader)
        {
            return new User
            {
                Id = reader["Id"].ToString()!,
                FullName = reader["FullName"].ToString()!,
                Email = reader["Email"].ToString()!,
                Password = reader["Password"].ToString()!,
                Role = Enum.Parse<Role>(reader["Role"].ToString()!),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }
    }
}