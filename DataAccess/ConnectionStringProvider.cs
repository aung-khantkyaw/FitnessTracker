using System;
using System.Data.SqlClient;
using System.IO;

namespace Fitness_Tracker.DataAccess
{
    internal static class ConnectionStringProvider
    {
        private static readonly Lazy<string> _connectionString = new Lazy<string>(BuildConnectionString);

        internal static string ConnectionString => _connectionString.Value;

        private static string BuildConnectionString()
        {
            string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString()
                                   ?? AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(dataDirectory, "FitnessTracker.mdf");

            // Use the user-supplied LocalDB instance and attach the MDF at the project root.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                AttachDBFilename = Path.Combine(dataDirectory, "FitnessTracker.mdf")
            };

            builder.AttachDBFilename = dbPath;

            return builder.ToString();
        }
    }
}
