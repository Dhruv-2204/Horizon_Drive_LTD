﻿using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    // This class handles the database operations related to cars.
    public class CarRepository
    {
        // Database connection object to interact with the database.
        private readonly DatabaseConnection _dbConnection;

        public CarRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        // This method loads all cars from the database and returns them in a hash table.
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
                                    reader["CarID"]?.ToString() ?? string.Empty,
                                    reader["UserID"]?.ToString() ?? string.Empty,

                                    reader["CarBrand"]?.ToString() ?? string.Empty,
                                    reader["Category"]?.ToString() ?? string.Empty,
                                    string.Empty, // Explicitly empty for this field.
                                    reader["RegistrationNo"]?.ToString() ?? string.Empty,
                                    reader["Model"]?.ToString() ?? string.Empty,
                                    reader["Years"] != DBNull.Value ? Convert.ToInt32(reader["Years"]) : 0, // Defaulting to 0.
                                    reader["Colour"]?.ToString() ?? string.Empty,
                                    reader["Features"]?.ToString() ?? string.Empty,
                                    reader["VehicleDescription"]?.ToString() ?? string.Empty,
                                    reader["CarPrice"] != DBNull.Value ? Convert.ToDecimal(reader["CarPrice"]) : 0m, // Defaulting to 0.0.
                                    reader["SeatNo"] != DBNull.Value ? Convert.ToInt32(reader["SeatNo"]) : 0, // Defaulting to 0.
                                    reader["EngineCapacity"]?.ToString() ?? string.Empty,
                                    reader["Ratings"] != DBNull.Value ? Convert.ToDecimal(reader["Ratings"]) : 0m, // Defaulting to 0.0.
                                    reader["Power"]?.ToString() ?? string.Empty,
                                    reader["DriveTrain"]?.ToString() ?? string.Empty,
                                    reader["FuelType"]?.ToString() ?? string.Empty,
                                    reader["TransmissionType"]?.ToString() ?? string.Empty,
                                    reader["Status"]?.ToString() ?? string.Empty,
                                    reader["AvailabilityStart"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityStart"]) : DateTime.MinValue, // Default DateTime value.
                                    reader["AvailabilityEnd"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityEnd"]) : DateTime.MinValue  // Default DateTime value.
                                );
                        // Insert the car into the hash table using its CarID as the key.
                        carHashTable.Insert(car.CarID, car);

                    }
                }
            }
            // Return the hash table containing all cars.
            return carHashTable;
        }

        // This method loads unbooked cars from the database and returns them in a hash table.
        public HashTable<string, Cars> LoadUnBookedCarsFromDatabase()
        {
            var carHashTable = new HashTable<string, Cars>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Car WHERE Status = 'unbooked'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Cars car = new Cars(
                            reader["CarID"].ToString(),
                             reader["UserID"].ToString(),
                            reader["CarBrand"].ToString(),
                            reader["Category"].ToString(),
                            "",
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
                            reader["Status"].ToString(),
                            reader["AvailabilityStart"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityStart"]) : DateTime.MinValue, // Default DateTime value.
                            reader["AvailabilityEnd"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityEnd"]) : DateTime.MinValue // Default DateTime value.



                        );

                        carHashTable.Insert(car.CarID, car);
                    }
                }
            }

            return carHashTable;
        }

        // This method loads booking transactions from the database and returns them in a hash table.
        public HashTable<string, Cars> LoadBookingTransactionFromDatabase()
        {
            var carHashTable = new HashTable<string, Cars>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Booking WHERE Status = 'unbooked'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Cars car = new Cars(
                            reader["CarID"].ToString(),
                            reader["UserID"].ToString(),
                            reader["CarBrand"].ToString(),
                            reader["Category"].ToString(),
                            reader["CarImagePath"].ToString(),
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
                            reader["Status"].ToString(),
                            reader["AvailabilityStart"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityStart"]) : DateTime.MinValue, // Default DateTime value.
                            reader["AvailabilityEnd"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityEnd"]) : DateTime.MinValue // Default DateTime value.

                        );
                        carHashTable.Insert(car.CarID, car);
                    }
                }
            }

            return carHashTable;
        }

        // This method adds a new car to the database.
        public void DeleteCarById(string carId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Car WHERE CarID = @CarID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarID", carId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // This method checks the status of a car in the database.
        public void CheckCarStatus(string carId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string updateQuery = @"
          ";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {


                    cmd.ExecuteNonQuery();
                }
            }
        }
        // This method updates the status of a car to "booked" in the database.
        public void ChangeCarStatus(string carId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string updateQuery = @"
            UPDATE Car 
            SET Status = @Status 
            WHERE CarID = @CarID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", "booked");
                    cmd.Parameters.AddWithValue("@CarID", carId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // This method retrieves the car IDs associated with a specific user ID from the database.
        public List<int> GetCarIdsByUserId(string userId)
        {
            List<int> carIds = new List<int>();

            string query = "SELECT CarId FROM Car WHERE UserID = @UserID";
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (int.TryParse(reader["CarId"].ToString(), out int carId))
                            {
                                carIds.Add(carId);
                            }
                            else
                            {
                                // Handle the case where CarId is not a valid integer
                                // Log an error or take appropriate action
                            }
                        }
                    }
                }
            }

            return carIds;
        }
    }

}
