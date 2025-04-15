
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic
{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarManagementDB"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found in app.config.");
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
