using Microsoft.Data.SqlClient;
using System.Configuration;

namespace BloodLink.Core.Database
{
    public static class DbConnection
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["BloodLinkCon"]?.ConnectionString
            ?? throw new InvalidOperationException("Connection string 'BloodLinkCon' not found in App.config.");

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}