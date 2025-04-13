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

        public void LoadBookingsIntoDatabase(Booking booking)
        {

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO Bookings (
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

    }



}
