using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD
{
    public class Admin_managing_files_repo
    {
        private readonly DatabaseConnection _dbConnection;  
        public Admin_managing_files_repo(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

      
        public void SaveCarToDatabase(HashTable<string, Cars> data)
        {


            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    foreach (var kvp in data.GetAllItems())
                    {
                        var car = kvp.Value;

                        string query = @"INSERT INTO Car 
            (CarID, UserID, CarBrand, Category, RegistrationNo, Model, Years, Colour, Features, VehicleDescription, CarPrice, SeatNo, EngineCapacity, Ratings, Power, DriveTrain, FuelType, TransmissionType, Status, AvailabilityStart, AvailabilityEnd, CarImagePath) 
            VALUES 
            (@carid, @userid, @carBrand, @category, @registrationNo, @model, @years, @colour, @features, @desc, @price, @seat, @engine, @rating, @power, @drive, @fuel, @transmission, @status, @availabilityStart, @availabilityEnd, @carimagepath)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@carid", car.CarID);
                            cmd.Parameters.AddWithValue("@userid", car.UserID);
                            cmd.Parameters.AddWithValue("@carBrand", car.CarBrand);
                            cmd.Parameters.AddWithValue("@category", car.Category);
                            cmd.Parameters.AddWithValue("@registrationNo", car.RegistrationNo);
                            cmd.Parameters.AddWithValue("@model", car.Model);
                            cmd.Parameters.AddWithValue("@years", car.Year);
                            cmd.Parameters.AddWithValue("@colour", car.Colour);
                            cmd.Parameters.AddWithValue("@features", car.Features);
                            cmd.Parameters.AddWithValue("@desc", car.VehicleDescription);
                            cmd.Parameters.AddWithValue("@price", car.CarPrice);
                            cmd.Parameters.AddWithValue("@seat", car.SeatNo);
                            cmd.Parameters.AddWithValue("@engine", car.EngineCapacity);
                            cmd.Parameters.AddWithValue("@rating", car.Ratings);
                            cmd.Parameters.AddWithValue("@power", car.Power);
                            cmd.Parameters.AddWithValue("@drive", car.DriveTrain);
                            cmd.Parameters.AddWithValue("@fuel", car.FuelType);
                            cmd.Parameters.AddWithValue("@transmission", car.TransmissionType);
                            cmd.Parameters.AddWithValue("@status", car.Status);
                            cmd.Parameters.AddWithValue("@availabilityStart", car.AvailabilityStart);
                            cmd.Parameters.AddWithValue("@availabilityEnd", car.AvailabilityEnd);
                            cmd.Parameters.AddWithValue("@carimagepath", car.CarImagePath);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }

        

       


        public void SaveUsersToDatabase(HashTable<string, User> data)
        {


            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    foreach (var kvp in data.GetAllItems())
                    {
                        var user = kvp.Value;

                        string query = @"INSERT INTO [User] 
                    (UserID, UserName, FirstName, LastName, Email, TelephoneNo, Address, Password, DOB, ProfilePicture)
                VALUES 
                    (@userid, @username, @firstname, @lastname, @email, @phonenum, @address, @password, @dob, @profilepic)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userid", user.UserId);
                            cmd.Parameters.AddWithValue("@username", user.UserName);
                            cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                            cmd.Parameters.AddWithValue("@lastname", user.LastName);
                            cmd.Parameters.AddWithValue("@email", user.Email);
                            cmd.Parameters.AddWithValue("@phonenum", user.TelephoneNo);
                            cmd.Parameters.AddWithValue("@address", user.Address);
                            cmd.Parameters.AddWithValue("@password", user.Password);
                            cmd.Parameters.AddWithValue("@dob", user.DOB.ToDateTime(TimeOnly.MinValue));
                            cmd.Parameters.AddWithValue("@profilepic", user.ProfilePicture);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }



        public void SaveCustomerToDatabase(HashTable<string, Customer> data)
        {


            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    foreach (var kvp in data.GetAllItems())
                    {
                        var customer = kvp.Value;

                        string query = @"INSERT INTO Customer
                    (CustomerID, UserID, LicenseNo, LicenseExpiryDate, LicensePhoto)
                VALUES 
                    (@customerID, @userID, @LicenseNo, @licenseExpiryDate, @licensePhoto)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                            cmd.Parameters.AddWithValue("@UserID", customer.UserID);
                            cmd.Parameters.AddWithValue("@LicenseNo", customer.LicenseNo);
                            cmd.Parameters.AddWithValue("@LicenseExpiryDate", customer.LicenseExpiryDate);
                            cmd.Parameters.AddWithValue("@LicensePhoto", customer.LicensePhoto);


                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }
    }
}
