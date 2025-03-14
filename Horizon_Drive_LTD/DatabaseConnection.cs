using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD
{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarHireDB"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found in app.config.");
            }
        }

     

        public string TestConnection()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return "Connection successful!"; 
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}"; 
                }
            }
        }



    }
}
