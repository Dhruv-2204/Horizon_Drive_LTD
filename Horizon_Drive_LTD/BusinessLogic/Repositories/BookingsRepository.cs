﻿using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    // This class is responsible for managing bookings in the database.
    public class BookingsRepository
    {
        // Database connection object to interact with the database.
        private readonly DatabaseConnection _dbConnection;

        // Constructor that initializes the database connection.
        public BookingsRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Load all bookings from the database into a hash table.
        public HashTable<string, Booking> LoadBookingsFromDatabase()
        {
            var bookingHashTable = new HashTable<string, Booking>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Booking";

                using (SqlCommand cmd = new SqlCommand(query, conn))

                // Execute the command and read the results.
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking(
                            reader["BookingID"].ToString(),
                            reader["CustomerID"].ToString(),
                            reader["CarID"].ToString(),
                            reader["BookingDate"].ToString(),
                            reader["PickupDate"].ToString(),
                            reader["DropoffDate"].ToString(),
                            reader["PickupLocation"].ToString(),
                            reader["DropoffLocation"].ToString(),
                            Convert.ToBoolean(reader["IncludeDriver"]),
                            Convert.ToBoolean(reader["BabyCarSeat"]),
                            Convert.ToBoolean(reader["FullInsuranceCoverage"]),
                            Convert.ToBoolean(reader["RoofRack"]),
                            Convert.ToBoolean(reader["AirportPickupDropoff"]),
                            reader["BookingStatus"].ToString()
                        );

                        bookingHashTable.Insert(booking.BookingID, booking);
                    }
                }
            }

            return bookingHashTable;
        }

        // Load a specific booking from the database using its ID.
        public void LoadBookingsIntoDatabase(Booking booking)
        {

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO Booking (
                        BookingID, CustomerID, CarID, BookingDate, PickupDate, DropoffDate,
                        PickupLocation, DropoffLocation, IncludeDriver, BabyCarSeat,
                        FullInsuranceCoverage, RoofRack, AirportPickupDropoff, BookingStatus
                    ) VALUES (
                        @BookingId, @CustomerID, @CarId, @BookingDate, @StartDate, @EndDate,
                        @PickupLocation, @DropoffLocation, @DriverIncluded, @BabyCarSeatIncluded,
                        @InsuranceIncluded, @RoofRackIncluded, @AirportPickupIncluded, @BookingStatus
                    )";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", booking.BookingID);
                    cmd.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
                    cmd.Parameters.AddWithValue("@CarId", booking.CarID);
                    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    cmd.Parameters.AddWithValue("@StartDate", booking.PickupDate);
                    cmd.Parameters.AddWithValue("@EndDate", booking.DropoffDate);
                    cmd.Parameters.AddWithValue("@PickupLocation", booking.PickupLocation);
                    cmd.Parameters.AddWithValue("@DropoffLocation", booking.DropoffLocation);
                    cmd.Parameters.AddWithValue("@DriverIncluded", booking.IncludeDriver);
                    cmd.Parameters.AddWithValue("@BabyCarSeatIncluded", booking.BabyCarSeat);
                    cmd.Parameters.AddWithValue("@InsuranceIncluded", booking.FullInsuranceCoverage);
                    cmd.Parameters.AddWithValue("@RoofRackIncluded", booking.RoofRack);
                    cmd.Parameters.AddWithValue("@AirportPickupIncluded", booking.AirportPickupDropoff);
                    cmd.Parameters.AddWithValue("@BookingStatus", booking.Status);


                    cmd.ExecuteNonQuery();

                }
            }
        }

        // Check the status of a booking and update it in the database.
        public void CheckBookingStatus(Booking booking)
        {

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO Booking (
                        BookingID, CustomerID, CarID, BookingDate, PickupDate, DropoffDate,
                        PickupLocation, DropoffLocation, IncludeDriver, BabyCarSeat,
                        FullInsuranceCoverage, RoofRack, AirportPickupDropoff, BookingStatus
                    ) VALUES (
                        @BookingId, @CustomerID, @CarId, @BookingDate, @StartDate, @EndDate,
                        @PickupLocation, @DropoffLocation, @DriverIncluded, @BabyCarSeatIncluded,
                        @InsuranceIncluded, @RoofRackIncluded, @AirportPickupIncluded, @BookingStatus
                    )";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", booking.BookingID);
                    cmd.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
                    cmd.Parameters.AddWithValue("@CarId", booking.CarID);
                    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    cmd.Parameters.AddWithValue("@StartDate", booking.PickupDate);
                    cmd.Parameters.AddWithValue("@EndDate", booking.DropoffDate);
                    cmd.Parameters.AddWithValue("@PickupLocation", booking.PickupLocation);
                    cmd.Parameters.AddWithValue("@DropoffLocation", booking.DropoffLocation);
                    cmd.Parameters.AddWithValue("@DriverIncluded", booking.IncludeDriver);
                    cmd.Parameters.AddWithValue("@BabyCarSeatIncluded", booking.BabyCarSeat);
                    cmd.Parameters.AddWithValue("@InsuranceIncluded", booking.FullInsuranceCoverage);
                    cmd.Parameters.AddWithValue("@RoofRackIncluded", booking.RoofRack);
                    cmd.Parameters.AddWithValue("@AirportPickupIncluded", booking.AirportPickupDropoff);
                    cmd.Parameters.AddWithValue("@BookingStatus", booking.Status);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        // Check if a car is available for booking based on the provided dates.
        public bool IsCarAvailable(string carId, DateTime userStartDate, DateTime userEndDate, HashTable<string, Booking> bookingHashTable)
        {
            foreach (var booking in bookingHashTable.Values())
            {
                if (booking.CarID == carId)
                {
                    // Convert string dates to DateTime
                    DateTime bookingPickupDate = DateTime.Parse(booking.PickupDate);
                    DateTime bookingDropoffDate = DateTime.Parse(booking.DropoffDate);

                    // Date conflict check
                    if (userStartDate <= bookingDropoffDate && userEndDate >= bookingPickupDate)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Get all bookings for a specific car
        public List<Booking> GetBookingsByCarId(string carId)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Booking WHERE CarId = @CarId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarID", carId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking(
                             reader["BookingID"].ToString(),
                             reader["CustomerID"].ToString(),
                             reader["CarID"].ToString(),
                             reader["BookingDate"].ToString(),
                             reader["PickupDate"].ToString(),
                             reader["DropoffDate"].ToString(),
                             reader["PickupLocation"].ToString(),
                             reader["DropoffLocation"].ToString(),
                             Convert.ToBoolean(reader["IncludeDriver"]),
                             Convert.ToBoolean(reader["BabyCarSeat"]),
                             Convert.ToBoolean(reader["FullInsuranceCoverage"]),
                             Convert.ToBoolean(reader["RoofRack"]),
                             Convert.ToBoolean(reader["AirportPickupDropoff"]),
                             reader["BookingStatus"].ToString()

                         );
                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }


        // Delete booking by BookingId
        public void DeleteBookingById(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Booking WHERE BookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Get all bookings for a specific user with car details
        public List<(Booking, string carBrand, string model, string carid, int year, decimal price, string status)> GetBookingsForUserWithCarDetails(string userId)
        {
            var result = new List<(Booking, string, string, string, int, decimal, string)>();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                                    SELECT 
                                         b.*, 
                                         c.CarBrand, 
                                         c.CarID,
                                         c.Model,
                                         YEAR(c.Years) AS Years,   
                                         c.CarPrice, 
                                         c.Status
                                     FROM Booking b
                                     INNER JOIN Car c ON b.CarID = c.CarID
                                     WHERE c.UserID = @userId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking(
                                reader["BookingID"].ToString(),
                                reader["CustomerID"].ToString(),
                                reader["CarID"].ToString(),
                                reader["BookingDate"].ToString(),
                                reader["PickupDate"].ToString(),
                                reader["DropoffDate"].ToString(),
                                reader["PickupLocation"].ToString(),
                                reader["DropoffLocation"].ToString(),
                                Convert.ToBoolean(reader["IncludeDriver"]),
                                Convert.ToBoolean(reader["BabyCarSeat"]),
                                Convert.ToBoolean(reader["FullInsuranceCoverage"]),
                                Convert.ToBoolean(reader["RoofRack"]),
                                Convert.ToBoolean(reader["AirportPickupDropoff"]),
                                reader["BookingStatus"].ToString()

                            );

                            string carBrand = reader["CarBrand"].ToString();
                            string carID = reader["CarID"].ToString();
                            int year = Convert.ToInt32(reader["Years"]);
                            decimal price = Convert.ToDecimal(reader["CarPrice"]);
                            string status = reader["Status"].ToString();
                            string model = reader["Model"].ToString();


                            result.Add((booking, carBrand, model, carID, year, price, status));
                        }
                    }
                }
            }

            return result;
        }

        // Get the count of active reservations for a specific user
        public int GetActiveReservationCountForUser(string userId)
        {
            int count = 0;

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                                SELECT COUNT(*) 
                                FROM Booking b
                                INNER JOIN Car c ON b.CarID = c.CarID
                                WHERE c.UserId = @UserId AND b.PickupDate >= @Now";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Now", DateTime.Now);

                    object result = cmd.ExecuteScalar();
                    count = result != null ? Convert.ToInt32(result) : 0;

                }
            }

            return count;
        }



    }

}