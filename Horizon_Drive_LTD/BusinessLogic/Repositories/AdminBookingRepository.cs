using System;
using System.Collections.Generic;
using System.Linq;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class AdminBookingRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public AdminBookingRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Retrieves all bookings from the database
        /// </summary>
        public List<AdminBooking> GetAllBookings()
        {
            List<AdminBooking> bookings = new List<AdminBooking>();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                // Join with User and Car tables to get UserName and CarModel
                string query = @"
                    SELECT b.BookingId, b.UserId, b.CarId, b.StartDate, b.EndDate, 
                           b.TotalCost, b.Status, u.UserName, c.Model
                    FROM Booking b
                    JOIN [User] u ON b.UserId = u.UserId
                    JOIN Car c ON b.CarId = c.CarId
                    ORDER BY b.StartDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AdminBooking booking = new AdminBooking(
                            reader.GetString(0),     // BookingId
                            reader.GetString(1),     // UserId
                            reader.GetString(2),     // CarId
                            reader.GetDateTime(3),   // StartDate
                            reader.GetDateTime(4),   // EndDate
                            reader.GetDecimal(5),    // TotalCost
                            reader.GetString(6),     // Status
                            reader.GetString(7),     // UserName
                            reader.GetString(8)      // CarModel
                        );

                        bookings.Add(booking);
                    }
                }
            }

            return bookings;
        }

        /// <summary>
        /// Get a booking by its ID
        /// </summary>
        public AdminBooking GetBookingById(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.BookingId, b.UserId, b.CarId, b.StartDate, b.EndDate, 
                           b.TotalCost, b.Status, u.UserName, c.Model
                    FROM Booking b
                    JOIN [User] u ON b.UserId = u.UserId
                    JOIN Car c ON b.CarId = c.CarId
                    WHERE b.BookingId = @BookingId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AdminBooking(
                                reader.GetString(0),     // BookingId
                                reader.GetString(1),     // UserId
                                reader.GetString(2),     // CarId
                                reader.GetDateTime(3),   // StartDate
                                reader.GetDateTime(4),   // EndDate
                                reader.GetDecimal(5),    // TotalCost
                                reader.GetString(6),     // Status
                                reader.GetString(7),     // UserName
                                reader.GetString(8)      // CarModel
                            );
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Get all bookings for a specific user
        /// </summary>
        public List<AdminBooking> GetBookingsByUserId(string userId)
        {
            List<AdminBooking> bookings = new List<AdminBooking>();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.BookingId, b.UserId, b.CarId, b.StartDate, b.EndDate, 
                           b.TotalCost, b.Status, u.UserName, c.Model
                    FROM Booking b
                    JOIN [User] u ON b.UserId = u.UserId
                    JOIN Car c ON b.CarId = c.CarId
                    WHERE b.UserId = @UserId
                    ORDER BY b.StartDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdminBooking booking = new AdminBooking(
                                reader.GetString(0),     // BookingId
                                reader.GetString(1),     // UserId
                                reader.GetString(2),     // CarId
                                reader.GetDateTime(3),   // StartDate
                                reader.GetDateTime(4),   // EndDate
                                reader.GetDecimal(5),    // TotalCost
                                reader.GetString(6),     // Status
                                reader.GetString(7),     // UserName
                                reader.GetString(8)      // CarModel
                            );

                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }

        /// <summary>
        /// Change a booking's status to "Canceled"
        /// </summary>
        public bool CancelBooking(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Booking SET Status = 'Canceled' WHERE BookingId = @BookingId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Completely remove a booking from the database
        /// </summary>
        public bool DeleteBooking(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Booking WHERE BookingId = @BookingId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Change a booking's status to "Completed"
        /// </summary>
        public bool CompleteBooking(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Booking SET Status = 'Completed' WHERE BookingId = @BookingId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Get all bookings for a specific car
        /// </summary>
        public List<AdminBooking> GetBookingsByCarId(string carId)
        {
            List<AdminBooking> bookings = new List<AdminBooking>();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.BookingId, b.UserId, b.CarId, b.StartDate, b.EndDate, 
                           b.TotalCost, b.Status, u.UserName, c.Model
                    FROM Booking b
                    JOIN [User] u ON b.UserId = u.UserId
                    JOIN Car c ON b.CarId = c.CarId
                    WHERE b.CarId = @CarId
                    ORDER BY b.StartDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdminBooking booking = new AdminBooking(
                                reader.GetString(0),     // BookingId
                                reader.GetString(1),     // UserId
                                reader.GetString(2),     // CarId
                                reader.GetDateTime(3),   // StartDate
                                reader.GetDateTime(4),   // EndDate
                                reader.GetDecimal(5),    // TotalCost
                                reader.GetString(6),     // Status
                                reader.GetString(7),     // UserName
                                reader.GetString(8)      // CarModel
                            );

                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }

        /// <summary>
        /// Check if a car is available for a given date range
        /// </summary>
        public bool IsCarAvailable(string carId, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM Booking
                    WHERE CarId = @CarId
                    AND Status = 'Confirmed'
                    AND (
                        (@StartDate BETWEEN StartDate AND EndDate)
                        OR (@EndDate BETWEEN StartDate AND EndDate)
                        OR (StartDate BETWEEN @StartDate AND @EndDate)
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    int conflictCount = (int)cmd.ExecuteScalar();
                    return conflictCount == 0;
                }
            }
        }

        /// <summary>
        /// Create a new booking
        /// </summary>
        public bool CreateBooking(AdminBooking booking)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Booking (BookingId, UserId, CarId, StartDate, EndDate, TotalCost, Status)
                    VALUES (@BookingId, @UserId, @CarId, @StartDate, @EndDate, @TotalCost, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", booking.BookingId);
                    cmd.Parameters.AddWithValue("@UserId", booking.UserId);
                    cmd.Parameters.AddWithValue("@CarId", booking.CarId);
                    cmd.Parameters.AddWithValue("@StartDate", booking.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", booking.EndDate);
                    cmd.Parameters.AddWithValue("@TotalCost", booking.TotalCost);
                    cmd.Parameters.AddWithValue("@Status", booking.Status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}