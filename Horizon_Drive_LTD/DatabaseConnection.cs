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

        public void FetchAndStoreCars(HashTable<string, Car> carHashTable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CarID, CarBrand, Model FROM Car"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Car car = new Car(
                            reader.GetString(0),  // CarId
                            reader.GetString(1), // Make
                            reader.GetString(2) // Model
                          
                        );

                        // Insert the car directly into the hash table
                        carHashTable.Insert(car.CarId, car);
                    }
                }
            }
        }

    }
}
