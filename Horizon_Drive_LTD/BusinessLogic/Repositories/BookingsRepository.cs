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
        public HashTable<string, Booking> LoadBookingsFromDatabase()
        {
            var bookingHashTable = new HashTable<string, Booking>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Booking";

                using (SqlCommand cmd = new SqlCommand(query, conn))
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
                            Convert.ToBoolean(reader["AirportPickupDropoff"])
                        );

                        bookingHashTable.Insert(booking.BookingID, booking);
                    }
                }
            }

            return bookingHashTable;
        }
        public void LoadBookingsIntoDatabase(Booking booking)
        {

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO Booking (
                        BookingID, CustomerID, CarID, BookingDate, PickupDate, DropoffDate,
                        PickupLocation, DropoffLocation, IncludeDriver, BabyCarSeat,
                        FullInsuranceCoverage, RoofRack, AirportPickupDropoff
                    ) VALUES (
                        @BookingId, @CustomerID, @CarId, @BookingDate, @StartDate, @EndDate,
                        @PickupLocation, @DropoffLocation, @DriverIncluded, @BabyCarSeatIncluded,
                        @InsuranceIncluded, @RoofRackIncluded, @AirportPickupIncluded
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

                    cmd.ExecuteNonQuery();



                }
            }
        }


        public void CheckBookingStatus(Booking booking)
        {

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO Booking (
                        BookingID, CustomerID, CarID, BookingDate, PickupDate, DropoffDate,
                        PickupLocation, DropoffLocation, IncludeDriver, BabyCarSeat,
                        FullInsuranceCoverage, RoofRack, AirportPickupDropoff
                    ) VALUES (
                        @BookingId, @CustomerID, @CarId, @BookingDate, @StartDate, @EndDate,
                        @PickupLocation, @DropoffLocation, @DriverIncluded, @BabyCarSeatIncluded,
                        @InsuranceIncluded, @RoofRackIncluded, @AirportPickupIncluded
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

                    cmd.ExecuteNonQuery();



                }
            }

        }

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



    }

}
