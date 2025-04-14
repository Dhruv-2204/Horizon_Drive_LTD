using Horizon_Drive_LTD.DataStructure;
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
                                reader["CarID"] != DBNull.Value ? reader["CarID"].ToString() : "UnknownCarID",
                                reader["UserID"] != DBNull.Value ? reader["UserID"].ToString() : "UnknownUserID",
                                reader["CarBrand"] != DBNull.Value ? reader["CarBrand"].ToString() : "UnknownBrand",
                                reader["Category"] != DBNull.Value ? reader["Category"].ToString() : "UnknownCategory",
                                "", 
                                reader["RegistrationNo"] != DBNull.Value ? reader["RegistrationNo"].ToString() : "UnknownRegNo",
                                reader["Model"] != DBNull.Value ? reader["Model"].ToString() : "UnknownModel",
                                reader["Years"] != DBNull.Value ? Convert.ToInt32(reader["Years"]) : 0, // Default integer value.
                                reader["Colour"] != DBNull.Value ? reader["Colour"].ToString() : "UnknownColour",
                                reader["Features"] != DBNull.Value ? reader["Features"].ToString() : "NoFeatures",
                                reader["VehicleDescription"] != DBNull.Value ? reader["VehicleDescription"].ToString() : "NoDescription",
                                reader["CarPrice"] != DBNull.Value ? Convert.ToDecimal(reader["CarPrice"]) : 0.0M, // Default decimal value.
                                reader["SeatNo"] != DBNull.Value ? Convert.ToInt32(reader["SeatNo"]) : 0, // Default seat number.
                                reader["EngineCapacity"] != DBNull.Value ? reader["EngineCapacity"].ToString() : "UnknownCapacity",
                                reader["Ratings"] != DBNull.Value ? Convert.ToDecimal(reader["Ratings"]) : 0.0M, // Default rating value.
                                reader["Power"] != DBNull.Value ? reader["Power"].ToString() : "UnknownPower",
                                reader["DriveTrain"] != DBNull.Value ? reader["DriveTrain"].ToString() : "UnknownDriveTrain",
                                reader["FuelType"] != DBNull.Value ? reader["FuelType"].ToString() : "UnknownFuel",
                                reader["TransmissionType"] != DBNull.Value ? reader["TransmissionType"].ToString() : "UnknownTransmission",
                                reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "UnknownStatus",
                                reader["AvailabilityStart"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityStart"]) : DateTime.MinValue, // Default DateTime value.
                                reader["AvailabilityEnd"] != DBNull.Value ? Convert.ToDateTime(reader["AvailabilityEnd"]) : DateTime.MinValue // Default DateTime value.
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
                            Convert.ToDateTime(reader["AvailabilityStart"]),
                            Convert.ToDateTime(reader["AvailabilityEnd"])


                        );

                        carHashTable.Insert(car.CarID, car);
                    }
                }
            }

            return carHashTable;
        }

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
                            Convert.ToDateTime(reader["AvailabilityStart"]),
                            Convert.ToDateTime(reader["AvailabilityEnd"])
                        );

                        carHashTable.Insert(car.CarID, car);
                    }
                }
            }

            return carHashTable;
        }

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
                            carIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return carIds;

        }
    }

}