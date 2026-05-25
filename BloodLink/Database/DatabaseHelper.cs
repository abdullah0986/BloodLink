using Microsoft.Data.Sqlite;
using BloodLink.Models;

namespace BloodLink.Database
{
    public static class DatabaseHelper
    {
        private static readonly string DbFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "BloodLink"
        );

        public static readonly string DbPath = Path.Combine(DbFolder, "bloodlink.db");

        public static readonly string ConnectionString = $"Data Source={DbPath}";

        public static void Initialize()
        {
            if (!Directory.Exists(DbFolder))
                Directory.CreateDirectory(DbFolder);

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            CreateTables(connection);
            SeedAdminUser(connection);
            SeedDonors(connection);
            SeedBloodUnits(connection);
            SeedPatientRequests(connection);
            SeedBloodIssuances(connection);
        }

        private static void CreateTables(SqliteConnection connection)
        {
            string sql = @"
CREATE TABLE IF NOT EXISTS Users (
    Id TEXT PRIMARY KEY,
    FullName TEXT NOT NULL,
    Email TEXT UNIQUE NOT NULL,
    Password TEXT NOT NULL,
    Role TEXT NOT NULL,
    IsAdmin INTEGER NOT NULL DEFAULT 0,
    CreatedAt TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Donors (
    Id TEXT PRIMARY KEY,
    FullName TEXT NOT NULL,
    BloodGroup TEXT NOT NULL,
    Phone TEXT NOT NULL,
    City TEXT NOT NULL,
    Area TEXT,
    Age INTEGER,
    Weight REAL,
    Gender TEXT,
    IsEligible INTEGER NOT NULL DEFAULT 1,
    LastDonationDate TEXT,
    NextEligibleDate TEXT,
    UserId TEXT,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS BloodUnits (
    Id TEXT PRIMARY KEY,
    BloodGroup TEXT NOT NULL,
    CollectedDate TEXT NOT NULL,
    ExpiryDate TEXT NOT NULL,
    DonorId TEXT,
    Status TEXT NOT NULL DEFAULT 'Available',
    Notes TEXT,
    UserId TEXT, 
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(Id)
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS PatientRequests (
    Id TEXT PRIMARY KEY,
    PatientName TEXT NOT NULL,
    PatientAge TEXT,
    BloodGroup TEXT NOT NULL,
    UnitsRequired INTEGER NOT NULL DEFAULT 1,
    Ward TEXT,
    DoctorName TEXT,
    Status TEXT NOT NULL DEFAULT 'Pending',
    Notes TEXT,
    UserId TEXT,
    CreatedAt TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS BloodIssuances (
    Id TEXT PRIMARY KEY,
    PatientRequestId TEXT NOT NULL,
    BloodUnitId TEXT NOT NULL,
    IssuedByUserId TEXT NOT NULL,
    IssuedDate TEXT NOT NULL,
    Notes TEXT,
    FOREIGN KEY (PatientRequestId) REFERENCES PatientRequests(Id),
    FOREIGN KEY (BloodUnitId) REFERENCES BloodUnits(Id),
    FOREIGN KEY (IssuedByUserId) REFERENCES Users(Id)
);
";
            using var cmd = new SqliteCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        private static void SeedAdminUser(SqliteConnection connection)
        {
            var check = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE IsAdmin = 1;", connection);
            if ((long)check.ExecuteScalar() > 0) return;

            var user = new User();

            string sql = @"INSERT INTO Users 
(Id, FullName, Email, Password, Role, IsAdmin, CreatedAt)
VALUES (@id, 'Administrator', 'admin@bloodlink.com', @pass, 'Admin', 1, @now);";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", User.GenerateUserId());
            cmd.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword("Admin@123"));
            cmd.Parameters.AddWithValue("@now", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.ExecuteNonQuery();
        }

        private static void SeedDonors(SqliteConnection connection)
        {
            var check = new SqliteCommand("SELECT COUNT(*) FROM Donors;", connection);
            if ((long)check.ExecuteScalar() > 0) return;

            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            var d1 = new Donor();
            var d2 = new Donor();
            var d3 = new Donor();

            string sql = @"
INSERT INTO Donors 
(Id, FullName, BloodGroup, Phone, City, Area, Age, Weight, Gender, CreatedAt)
VALUES
(@id1, 'Ali Khan', 'A+', '03001234567', 'Lahore', 'Model Town', 25, 70, 'Male', @now),
(@id2, 'Sara Ahmed', 'B+', '03111234567', 'Karachi', 'DHA', 28, 60, 'Female', @now),
(@id3, 'Usman Tariq', 'O+', '03221234567', 'Islamabad', 'F-10', 30, 75, 'Male', @now);
";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id1", d1.generateDonorId());
            cmd.Parameters.AddWithValue("@id2", d2.generateDonorId());
            cmd.Parameters.AddWithValue("@id3", d3.generateDonorId());
            cmd.Parameters.AddWithValue("@now", now);
            cmd.ExecuteNonQuery();
        }

        private static void SeedBloodUnits(SqliteConnection connection)
        {
            var check = new SqliteCommand("SELECT COUNT(*) FROM BloodUnits;", connection);
            if ((long)check.ExecuteScalar() > 0) return;

            string now = DateTime.UtcNow.ToString();
            string expiry = DateTime.UtcNow.AddDays(35).ToString("yyyy-MM-dd HH:mm:ss");

            string sql = @"
INSERT INTO BloodUnits 
(Id, BloodGroup, CollectedDate, ExpiryDate, Status, CreatedAt)
VALUES
(@id1, 'A+', @now, @exp, 'Available', @now),
(@id2, 'B+', @now, @exp, 'Available', @now),
(@id3, 'O+', @now, @exp, 'Available', @now);
";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id1", BloodUnit.GenerateBloodUnitId("A+"));
            cmd.Parameters.AddWithValue("@id2", BloodUnit.GenerateBloodUnitId("B+"));
            cmd.Parameters.AddWithValue("@id3", BloodUnit.GenerateBloodUnitId("O+"));
            cmd.Parameters.AddWithValue("@now", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@exp", expiry);
            cmd.ExecuteNonQuery();
        }

        private static void SeedPatientRequests(SqliteConnection connection)
        {
            var check = new SqliteCommand("SELECT COUNT(*) FROM PatientRequests;", connection);
            if ((long)check.ExecuteScalar() > 0) return;

            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            string id1 = $"PR-{Guid.NewGuid().ToString("N").Substring(0, 6)}";
            string id2 = $"PR-{Guid.NewGuid().ToString("N").Substring(0, 6)}";

            string sql = @"
INSERT INTO PatientRequests 
(Id, PatientName, PatientAge, BloodGroup, UnitsRequired, Ward, DoctorName, Status, CreatedAt)
VALUES
(@id1, 'Ahmed Raza', '45', 'A+', 2, 'Ward 1', 'Dr. Khan', 'Pending', @now),
(@id2, 'Fatima Noor', '30', 'B+', 1, 'Ward 2', 'Dr. Ali', 'Pending', @now);
";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Parameters.AddWithValue("@now", now);
            cmd.ExecuteNonQuery();
        }

        private static void SeedBloodIssuances(SqliteConnection connection)
        {
            var check = new SqliteCommand("SELECT COUNT(*) FROM BloodIssuances;", connection);
            if ((long)check.ExecuteScalar() > 0) return;

            // Skip for now (avoid FK issues)
            return;
        }

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}