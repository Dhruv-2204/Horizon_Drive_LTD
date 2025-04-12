using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class BookingsRepository
    {
        private readonly DatabaseConnection _dbConnection;

      

        public BookingsRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public HashTable<string, Cars> InsertIntoDatabase()
        {
            var carHashTable = new HashTable<string, Cars>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Car";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cars car = new Cars(
                            reader["CarID"].ToString(),
                            reader["CarBrand"].ToString(),
                            reader["Category"].ToString(),
                            "", // Image will come from API
                            reader["RegistrationNo"].ToString(),
                            reader["Model"].ToString(),
                            Convert.ToInt32(reader["Years"]),
                            reader["Colour"].ToString(),
                            reader["Features"].ToString(),
                            reader["VehicleDescription"].ToString(),
                            Convert.ToDecimal(reader["CarPrice"]),
                            Convert.ToInt32(reader["SeatNo"]),
                            reader["EngineCapacity"].ToString(),
                            Convert.ToDecimal(reader["Ratings"]),
                            reader["Power"].ToString(),
                            reader["DriveTrain"].ToString(),
                            reader["FuelType"].ToString(),
                            reader["TransmissionType"].ToString(),
                            reader["Status"].ToString()
                        );
                        carHashTable.Insert(car.CarID, car);

                    }
                }
            }

            return carHashTable;
        }


    }
    (DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public HashTable<string, Cars> LoadCarsFromDatabase()
        {
            var carHashTable = new HashTable<string, Cars>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Car";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cars car = new Cars(
                            reader["CarID"].ToString(),
                            reader["CarBrand"].ToString(),
                            reader["Category"].ToString(),
                            "", // Image will come from API
                            reader["RegistrationNo"].ToString(),
                            reader["Model"].ToString(),
                            Convert.ToInt32(reader["Years"]),
                            reader["Colour"].ToString(),
                            reader["Features"].ToString(),
                            reader["VehicleDescription"].ToString(),
                            Convert.ToDecimal(reader["CarPrice"]),
                            Convert.ToInt32(reader["SeatNo"]),
                            reader["EngineCapacity"].ToString(),
                            Convert.ToDecimal(reader["Ratings"]),
                            reader["Power"].ToString(),
                            reader["DriveTrain"].ToString(),
                            reader["FuelType"].ToString(),
                            reader["TransmissionType"].ToString(),
                            reader["Status"].ToString()
                        );
                        carHashTable.Insert(car.CarID, car);

                    }
                }
            }

            return carHashTable;
        }


    }



}
