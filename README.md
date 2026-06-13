# 🩸 BloodLink — Blood Bank Management System

BloodLink is a desktop application built with **C# (.NET, WinForms)** designed to help blood banks and hospitals manage donors, blood units, patient requests, and staff efficiently. It provides a modern, themeable dashboard interface (dark/light mode) with real-time statistics, inventory tracking, and reporting tools.

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Project Structure](#project-structure)
- [Tech Stack](#tech-stack)
- [Database Schema](#database-schema)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Required NuGet Packages](#required-nuget-packages)
  - [Setup Instructions](#setup-instructions)
  - [Database Setup](#database-setup)
- [Default Login Credentials](#default-login-credentials)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

---

## 📖 About the Project

BloodLink streamlines the day-to-day operations of a blood bank by providing:

- A centralized **Donor Management** system
- **Blood Unit Inventory** tracking with automatic expiry handling
- **Patient Request** management for blood issuance
- An **Admin Dashboard** with live statistics (total donors, blood units, expiring units, blood group breakdown)
- **Reports** with charts (monthly donations, request status, stock levels)
- **Staff Management** for Admins to add/update/delete operator accounts
- Configurable **Settings** (session timeout, low-stock thresholds)
- A clean, modern **dark/light theme** toggle

The application uses **role-based access control** with two roles: `Admin` and `Operator`.

---

## ✨ Features

- 🔐 **Authentication** — Secure login with hashed passwords (BCrypt)
- 🩸 **Donor Management** — Add, update, view, delete, and search donors with eligibility tracking
- 🧪 **Blood Unit Inventory** — Track collection date, expiry date, status (Available, Reserved, Used, Expired), and linked donor
- 🏥 **Patient Requests** — Manage blood requests with status tracking (Pending, Fulfilled, Cancelled)
- 📊 **Admin Dashboard** — Real-time stats: total donors, blood units, patients today, expiring units, blood group breakdown
- 📈 **Reports Page** — Visual charts for blood stock levels, monthly donations, and request status (via LiveCharts)
- 👥 **Staff Management** — Admins can add/edit/delete operator accounts
- ⚙️ **Settings** — Configure session timeout and low-stock expiry threshold
- 🌓 **Dark/Light Theme Toggle** — Persistent theming across the application
- ⏱️ **Auto-Expiry** — Background timer automatically marks expired blood units

---

## 🗂️ Project Structure
BloodLink/
├── Core/
│   ├── Database/           # Repositories & DB connection
│   ├── Interfaces/         # Repository interfaces
│   ├── Models/             # Data models (Donor, BloodUnit, PatientRequest, User, etc.)
│   └── Helpers/            # EnumHelper and utility helpers
└── BloodLink.WindowsApp/
    ├── Program.cs          # Application entry point
    ├── App.config          # Database connection configuration
    ├── Forms/              # Dialog forms (Login, Donor, BloodUnit, Patient, User)
    ├── Pages/              # Dashboard pages (Donor, BloodUnit, Reports, etc.)
    ├── Services/           # Business logic layer (AuthService, DonorService, etc.)
    └── Helpers/            # UI helpers (AppTheme, PaintHelper, EnumHelper)

---

## 🛠️ Tech Stack

| Component        | Technology                              |
|-------------------|------------------------------------------|
| Language          | C# (.NET 8 / .NET Framework — WinForms)  |
| UI Framework      | Windows Forms (WinForms)                 |
| Database          | Microsoft SQL Server                     |
| ORM/Data Access   | ADO.NET (`Microsoft.Data.SqlClient`)     |
| Charts            | LiveChartsCore (SkiaSharp)               |
| Icons             | FontAwesome.Sharp                        |
| Password Hashing  | BCrypt.Net                               |

---

## 🗄️ Database Schema

BloodLink uses **Microsoft SQL Server**. You'll need to create a database named `bloodLinkDB` and the following tables:

### `Users`
| Column     | Type      | Notes                  |
|------------|-----------|------------------------|
| Id         | TEXT/VARCHAR | Primary Key         |
| FullName   | NVARCHAR  | Not null               |
| Email      | NVARCHAR  | Unique, not null       |
| Password   | NVARCHAR  | Hashed (BCrypt)        |
| Role       | NVARCHAR  | `Admin` / `Operator`   |
| CreatedAt  | DATETIME  | Not null               |

### `Donors`
| Column           | Type      | Notes                          |
|------------------|-----------|---------------------------------|
| Id               | VARCHAR   | Primary Key                    |
| FullName         | NVARCHAR  | Not null                       |
| BloodGroup       | NVARCHAR  | Not null                       |
| Phone            | NVARCHAR  | Not null                       |
| City             | NVARCHAR  | Not null                       |
| Area             | NVARCHAR  | Nullable                       |
| Age              | INT       | Nullable                       |
| Weight           | FLOAT     | Nullable                       |
| Gender           | NVARCHAR  | Nullable                       |
| IsEligible       | BIT       | Default `1`                    |
| LastDonationDate | DATETIME  | Nullable                       |
| NextEligibleDate | DATETIME  | Nullable                       |
| UserId           | VARCHAR   | FK → Users.Id                  |
| CreatedAt        | DATETIME  | Not null                       |

### `BloodUnits`
| Column        | Type      | Notes                              |
|---------------|-----------|-------------------------------------|
| Id            | VARCHAR   | Primary Key                        |
| BloodGroup    | NVARCHAR  | Not null                           |
| CollectedDate | DATETIME  | Not null                           |
| ExpiryDate    | DATETIME  | Not null                           |
| DonorId       | VARCHAR   | FK → Donors.Id, nullable           |
| Status        | NVARCHAR  | `Available`/`Reserved`/`Used`/`Expired` |
| Notes         | NVARCHAR  | Nullable                           |
| UserId        | VARCHAR   | FK → Users.Id                      |
| CreatedAt     | DATETIME  | Not null                           |

### `PatientRequests`
| Column         | Type      | Notes                                |
|----------------|-----------|---------------------------------------|
| Id             | VARCHAR   | Primary Key                          |
| PatientName    | NVARCHAR  | Not null                             |
| PatientAge     | INT       | Nullable                             |
| BloodGroup     | NVARCHAR  | Not null                             |
| UnitsRequired  | INT       | Default `1`                          |
| Ward           | NVARCHAR  | Nullable                             |
| DoctorName     | NVARCHAR  | Nullable                             |
| Status         | NVARCHAR  | `Pending`/`Fulfilled`/`Cancelled`    |
| Notes          | NVARCHAR  | Nullable                             |
| UserId         | VARCHAR   | FK → Users.Id                        |
| CreatedAt      | DATETIME  | Not null                             |

### `BloodIssuances`
| Column           | Type      | Notes                            |
|------------------|-----------|------------------------------------|
| Id               | VARCHAR   | Primary Key                       |
| PatientRequestId | VARCHAR   | FK → PatientRequests.Id           |
| BloodUnitId      | VARCHAR   | FK → BloodUnits.Id                |
| IssuedByUserId   | VARCHAR   | FK → Users.Id                      |
| IssuedDate       | DATETIME  | Not null                          |
| Notes            | NVARCHAR  | Nullable                          |

### `AppSettings`
| Column | Type     | Notes        |
|--------|----------|--------------|
| Key    | VARCHAR  | Primary Key  |
| Value  | NVARCHAR | Not null     |

> 💡 **Tip:** You can use the SQL script below to quickly create all tables.

<details>
<summary>📜 Click to expand full SQL setup script</summary>

```sql
CREATE DATABASE bloodLinkDB;
GO
USE bloodLinkDB;
GO

CREATE TABLE Users (
    Id VARCHAR(50) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Donors (
    Id VARCHAR(50) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    BloodGroup NVARCHAR(10) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    Area NVARCHAR(100),
    Age INT,
    Weight FLOAT,
    Gender NVARCHAR(20),
    IsEligible BIT NOT NULL DEFAULT 1,
    LastDonationDate DATETIME,
    NextEligibleDate DATETIME,
    UserId VARCHAR(50),
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE BloodUnits (
    Id VARCHAR(50) PRIMARY KEY,
    BloodGroup NVARCHAR(10) NOT NULL,
    CollectedDate DATETIME NOT NULL,
    ExpiryDate DATETIME NOT NULL,
    DonorId VARCHAR(50),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Available',
    Notes NVARCHAR(MAX),
    UserId VARCHAR(50),
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE PatientRequests (
    Id VARCHAR(50) PRIMARY KEY,
    PatientName NVARCHAR(150) NOT NULL,
    PatientAge INT,
    BloodGroup NVARCHAR(10) NOT NULL,
    UnitsRequired INT NOT NULL DEFAULT 1,
    Ward NVARCHAR(100),
    DoctorName NVARCHAR(150),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    Notes NVARCHAR(MAX),
    UserId VARCHAR(50),
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE BloodIssuances (
    Id VARCHAR(50) PRIMARY KEY,
    PatientRequestId VARCHAR(50) NOT NULL,
    BloodUnitId VARCHAR(50) NOT NULL,
    IssuedByUserId VARCHAR(50) NOT NULL,
    IssuedDate DATETIME NOT NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (PatientRequestId) REFERENCES PatientRequests(Id),
    FOREIGN KEY (BloodUnitId) REFERENCES BloodUnits(Id),
    FOREIGN KEY (IssuedByUserId) REFERENCES Users(Id)
);

CREATE TABLE AppSettings (
    [Key] VARCHAR(100) PRIMARY KEY,
    Value NVARCHAR(MAX) NOT NULL
);
```

</details>

---

## 🚀 Getting Started

### Prerequisites

Make sure you have the following installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with **.NET Desktop Development** workload)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express edition works fine)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional, for managing the DB)

### Required NuGet Packages

Install the following packages via **NuGet Package Manager** or the Package Manager Console:

```powershell
Install-Package Microsoft.Data.SqlClient
Install-Package BCrypt.Net-Next
Install-Package FontAwesome.Sharp
Install-Package LiveChartsCore.SkiaSharpView.WinForms
Install-Package Microsoft.Data.Sqlite
```

> ⚠️ Note: The project references both `Microsoft.Data.SqlClient` (for main data operations) and `Microsoft.Data.Sqlite` (used in a designer-generated component). Ensure both are installed to avoid build errors.

### Setup Instructions

1. **Clone the repository**

```bash
   git clone https://github.com/your-username/BloodLink.git
   cd BloodLink
```

2. **Open the project** in Visual Studio (`BloodLink.sln`)

3. **Restore NuGet packages**

   Visual Studio will usually do this automatically. If not, right-click the solution → **Restore NuGet Packages**.

4. **Configure the database connection**

   Open `App.config` and update the connection string to match your SQL Server instance:

```xml
   <connectionStrings>
       <add name="BloodLinkCon"
            connectionString="Server=YOUR_SERVER_NAME; Database=bloodLinkDB;
                Integrated Security=True; TrustServerCertificate=true;"
            providerName="Microsoft.Data.SqlClient"
       />
   </connectionStrings>
```

   Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `localhost`, `.\SQLEXPRESS`, etc.)

5. **Set up the database**

   Run the SQL script provided in the [Database Schema](#database-schema) section above using SSMS or the Azure Data Studio query editor.

6. **Build the solution**
7. **Run the application**

   Press `F5` or click **Start** in Visual Studio.

### Database Setup

After creating the tables, you'll need at least one **Admin** account to log in. You can insert one manually:

```sql
-- Password: Admin@123 (hashed with BCrypt)
INSERT INTO Users (Id, FullName, Email, Password, Role, CreatedAt)
VALUES (
    'USR-2026-ABC123',
    'Administrator',
    'admin@bloodlink.com',
    '$2a$11$your_bcrypt_hashed_password_here',
    'Admin',
    GETUTCDATE()
);
```

> 💡 **Tip:** You can generate a BCrypt hash using an online BCrypt generator tool, or temporarily add a few lines of C# code to print `BCrypt.Net.BCrypt.HashPassword("Admin@123")` to the console.

---

## 🔑 Default Login Credentials

If you're running in **DEBUG mode**, the login form auto-fills with:
> ⚠️ Make sure a corresponding user exists in your `Users` table with these credentials (hashed) for login to succeed.

---

## 📸 Screenshots

> _Add screenshots of the Login page, Dashboard, Donor Management, Blood Inventory, Patient Requests, and Reports here._

---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a new branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License** — feel free to use, modify, and distribute it.

---

<p align="center">Made with ❤️ for saving lives, one donation at a time.</p>
