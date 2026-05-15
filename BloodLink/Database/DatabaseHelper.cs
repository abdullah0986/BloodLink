using Microsoft.Data.Sqlite;

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
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName    TEXT NOT NULL,
                    Email       TEXT UNIQUE NOT NULL,
                    Password    TEXT NOT NULL,
                    Role        TEXT NOT NULL,
                    IsAdmin     INTEGER NOT NULL DEFAULT 0,
                    CreatedAt   TEXT NOT NULL
                );

CREATE TABLE IF NOT EXISTS Donors (
    Id                INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName          TEXT NOT NULL,
    BloodGroup        TEXT NOT NULL,
    Phone             TEXT NOT NULL,
    City              TEXT NOT NULL,
    Area              TEXT,
    Age               INTEGER,
    Weight            REAL,
    Gender            TEXT,
    IsEligible        INTEGER NOT NULL DEFAULT 1,
    LastDonationDate  TEXT,
    NextEligibleDate  TEXT,
    UserId            INTEGER,
    CreatedAt         TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS BloodUnits (
    Id            INTEGER PRIMARY KEY AUTOINCREMENT,
    BagId         TEXT NOT NULL UNIQUE,
    BloodGroup    TEXT NOT NULL,
    CollectedDate TEXT NOT NULL,
    ExpiryDate    TEXT NOT NULL,
    DonorId       INTEGER,
    Status        TEXT NOT NULL DEFAULT 'Available',
    Notes         TEXT,
    CreatedAt     TEXT NOT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(Id)
);

CREATE TABLE IF NOT EXISTS PatientRequests (
    Id             INTEGER PRIMARY KEY AUTOINCREMENT,
    PatientName    TEXT NOT NULL,
    PatientAge     TEXT,
    BloodGroup     TEXT NOT NULL,
    UnitsRequired  INTEGER NOT NULL DEFAULT 1,
    Ward           TEXT,
    DoctorName     TEXT,
    Status         TEXT NOT NULL DEFAULT 'Pending',
    Notes          TEXT,
    RequestDate    TEXT NOT NULL,
    CreatedAt      TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS BloodIssuances (
    Id                INTEGER PRIMARY KEY AUTOINCREMENT,
    PatientRequestId  INTEGER NOT NULL,
    BloodUnitId       INTEGER NOT NULL,
    IssuedByUserId    INTEGER NOT NULL,
    IssuedDate        TEXT NOT NULL,
    Notes             TEXT,
    FOREIGN KEY (PatientRequestId) REFERENCES PatientRequests(Id),
    FOREIGN KEY (BloodUnitId)      REFERENCES BloodUnits(Id),
    FOREIGN KEY (IssuedByUserId)   REFERENCES Users(Id)
);
            ";

            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static void SeedAdminUser(SqliteConnection connection)
        {
            string checkSql = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 1;";
            using var checkCmd = new SqliteCommand(checkSql, connection);
            long adminCount = (long)checkCmd.ExecuteScalar();

            if (adminCount > 0) return;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin@123");

            string insertSql = @"
                INSERT INTO Users (FullName, Email, Password, Role, IsAdmin, CreatedAt)
                VALUES ('Administrator', 'admin@bloodlink.com', @password, 'Admin', 1, @createdAt);
            ";

            using var insertCmd = new SqliteCommand(insertSql, connection);
            insertCmd.Parameters.AddWithValue("@password", hashedPassword);
            insertCmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertCmd.ExecuteNonQuery();
        }

        private static void SeedDonors(SqliteConnection connection)
        {
            string checkSql = "SELECT COUNT(*) FROM Donors;";
            using var checkCmd = new SqliteCommand(checkSql, connection);
            long count = (long)checkCmd.ExecuteScalar();

            if (count > 0) return;

            string sql = @"
        INSERT INTO Donors (FullName, BloodGroup, Phone, City, Area, Age, Weight, Gender, CreatedAt)
        VALUES
        ('Ali Khan', 'A+', '03001234567', 'Lahore', 'Model Town', 25, 70, 'Male', @now),
        ('Sara Ahmed', 'B+', '03111234567', 'Karachi', 'DHA', 28, 60, 'Female', @now),
        ('Usman Tariq', 'O+', '03221234567', 'Islamabad', 'F-10', 30, 75, 'Male', @now);
    ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@now", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.ExecuteNonQuery();
        }

        private static void SeedBloodUnits(SqliteConnection connection)
        {
            string checkSql = "SELECT COUNT(*) FROM BloodUnits;";
            using var checkCmd = new SqliteCommand(checkSql, connection);
            long count = (long)checkCmd.ExecuteScalar();

            if (count > 0) return;

            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            string expiry = DateTime.UtcNow.AddDays(35).ToString("yyyy-MM-dd HH:mm:ss");

            string sql = @"
        INSERT INTO BloodUnits (BagId, BloodGroup, CollectedDate, ExpiryDate, Status, CreatedAt)
        VALUES
        ('BAG001', 'A+', @now, @expiry, 'Available', @now),
        ('BAG002', 'B+', @now, @expiry, 'Available', @now),
        ('BAG003', 'O+', @now, @expiry, 'Available', @now);
    ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@now", now);
            cmd.Parameters.AddWithValue("@expiry", expiry);
            cmd.ExecuteNonQuery();
        }

        private static void SeedPatientRequests(SqliteConnection connection)
        {
            string checkSql = "SELECT COUNT(*) FROM PatientRequests;";
            using var checkCmd = new SqliteCommand(checkSql, connection);
            long count = (long)checkCmd.ExecuteScalar();

            if (count > 0) return;

            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            string sql = @"
        INSERT INTO PatientRequests (PatientName, PatientAge, BloodGroup, UnitsRequired, Ward, DoctorName, Status, RequestDate, CreatedAt)
        VALUES
        ('Ahmed Raza', '45', 'A+', 2, 'Ward 1', 'Dr. Khan', 'Pending', @now, @now),
        ('Fatima Noor', '30', 'B+', 1, 'Ward 2', 'Dr. Ali', 'Pending', @now, @now);
    ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@now", now);
            cmd.ExecuteNonQuery();
        }

        private static void SeedBloodIssuances(SqliteConnection connection)
        {
            string checkSql = "SELECT COUNT(*) FROM BloodIssuances;";
            using var checkCmd = new SqliteCommand(checkSql, connection);
            long count = (long)checkCmd.ExecuteScalar();

            if (count > 0) return;

            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            // ⚠️ Assumes IDs exist (since this is seed/demo data)
            string sql = @"
        INSERT INTO BloodIssuances (PatientRequestId, BloodUnitId, IssuedByUserId, IssuedDate)
        VALUES
        (1, 1, 1, @now),
        (2, 2, 1, @now);
    ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@now", now);
            cmd.ExecuteNonQuery();
        }

        public static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}