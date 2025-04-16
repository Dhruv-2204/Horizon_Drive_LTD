using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class Admin_managing_files_repo
    {
        private readonly DatabaseConnection _dbConnection;

        public Admin_managing_files_repo(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Check if a user exists in the database
        /// </summary>
        private bool UserExists(string userId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT COUNT(*) FROM [User] WHERE UserID = @userId";
            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        /// <summary>
        /// Saves cars to database handling duplicates and foreign key constraints
        /// </summary>
        public void SaveCarToDatabase(HashTable<string, Cars> data)
        {
            int inserted = 0;
            int updated = 0;
            int skipped = 0;
            List<string> errorMessages = new List<string>();

            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var kvp in data.GetAllItems())
                            {
                                var car = kvp.Value;

                                // Check if the user exists before trying to insert the car
                                if (!UserExists(car.UserID, conn, transaction))
                                {
                                    skipped++;
                                    errorMessages.Add($"User ID {car.UserID} not found for Car ID {car.CarID}");
                                    continue;
                                }

                                // Check if car exists
                                string checkCarQuery = "SELECT COUNT(*) FROM Car WHERE CarID = @carId";
                                bool carExists = false;
                                using (SqlCommand checkCmd = new SqlCommand(checkCarQuery, conn, transaction))
                                {
                                    checkCmd.Parameters.AddWithValue("@carId", car.CarID);
                                    int count = (int)checkCmd.ExecuteScalar();
                                    carExists = count > 0;
                                }

                                // Choose between INSERT or UPDATE based on existence
                                if (carExists)
                                {
                                    // Update existing car
                                    string updateQuery = @"
                                        UPDATE Car SET 
                                            UserID = @userId,
                                            CarBrand = @carBrand,
                                            Category = @category,
                                            CarImagePath = @carImagePath,
                                            RegistrationNo = @registrationNo,                                           
                                            Model = @model,
                                            Years = @years,
                                            Colour = @colour,
                                            Features = @features,
                                            VehicleDescription = @desc,
                                            CarPrice = @price,
                                            SeatNo = @seat,
                                            EngineCapacity = @engine,
                                            Ratings = @rating,
                                            Power = @power,
                                            DriveTrain = @drive,
                                            FuelType = @fuel,
                                            TransmissionType = @transmission,
                                            Status = @status,
                                            AvailabilityStart = @availabilityStart,
                                            AvailabilityEnd = @availabilityEnd
                                        WHERE CarID = @carId";

                                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                                    {
                                        AddCarParameters(cmd, car);
                                        cmd.ExecuteNonQuery();
                                        updated++;
                                    }
                                }
                                else
                                {
                                    // Insert new car
                                    string insertQuery = @"
                                        INSERT INTO Car (
                                            CarID, UserID, CarBrand, Category, CarImagePath, RegistrationNo, Model, Years, Colour,
                                            Features, VehicleDescription, CarPrice, SeatNo, EngineCapacity, Ratings,
                                            Power, DriveTrain, FuelType, TransmissionType, Status, AvailabilityStart,
                                            AvailabilityEnd
                                        )
                                        VALUES (
                                            @carId, @userId, @carBrand, @category, @carImagePath, @registrationNo, @model, @years, @colour,
                                            @features, @desc, @price, @seat, @engine, @rating, @power, @drive, @fuel,
                                            @transmission, @status, @availabilityStart, @availabilityEnd
                                        )";

                                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                                    {
                                        AddCarParameters(cmd, car);
                                        cmd.ExecuteNonQuery();
                                        inserted++;
                                    }
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Transaction failed and was rolled back. " + ex.Message);
                        }
                    }
                }

                // Show summary
                StringBuilder message = new StringBuilder();
                message.AppendLine($"Cars processed successfully: {inserted} inserted, {updated} updated, {skipped} skipped.");

                if (errorMessages.Count > 0)
                {
                    message.AppendLine("\nSkipped records due to missing user references:");
                    foreach (var error in errorMessages.Take(5)) // Show first 5 errors only
                    {
                        message.AppendLine("- " + error);
                    }

                    if (errorMessages.Count > 5)
                        message.AppendLine($"...and {errorMessages.Count - 5} more errors.");
                }

                MessageBox.Show(message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cars to database: " + ex.Message);
            }
        }

        // Helper method to add parameters to command
        private void AddCarParameters(SqlCommand cmd, Cars car)
        {
            cmd.Parameters.AddWithValue("@carId", car.CarID);
            cmd.Parameters.AddWithValue("@userId", car.UserID);
            cmd.Parameters.AddWithValue("@carBrand", car.CarBrand);
            cmd.Parameters.AddWithValue("@category", car.Category);
            cmd.Parameters.AddWithValue("@carImagePath", car.CarImagePath);
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
            
        }

        /// <summary>
        /// Saves users to database handling duplicates
        /// </summary>
        public void SaveUsersToDatabase(HashTable<string, User> data)
        {
            int inserted = 0;
            int updated = 0;

            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var kvp in data.GetAllItems())
                            {
                                var user = kvp.Value;

                                // Check if user exists
                                string checkUserQuery = "SELECT COUNT(*) FROM [User] WHERE UserID = @userId";
                                bool userExists = false;
                                using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, conn, transaction))
                                {
                                    checkCmd.Parameters.AddWithValue("@userId", user.UserId);
                                    int count = (int)checkCmd.ExecuteScalar();
                                    userExists = count > 0;
                                }

                                if (userExists)
                                {
                                    // Update existing user
                                    string updateQuery = @"
                                        UPDATE [User] SET 
                                            UserName = @userName,
                                            FirstName = @firstName,
                                            LastName = @lastName,
                                            Email = @email,
                                            TelephoneNo = @telephoneNo,
                                            Address = @address,
                                            Password = @password,
                                            DOB = @dob,
                                            ProfilePicture = @profilePicture
                                        WHERE UserID = @userId";

                                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                                    {
                                        AddUserParameters(cmd, user);
                                        cmd.ExecuteNonQuery();
                                        updated++;
                                    }
                                }
                                else
                                {
                                    // Insert new user
                                    string insertQuery = @"
                                        INSERT INTO [User] (
                                            UserID, UserName, FirstName, LastName, Email, 
                                            TelephoneNo, Address, Password, DOB, ProfilePicture
                                        )
                                        VALUES (
                                            @userId, @userName, @firstName, @lastName, @email,
                                            @telephoneNo, @address, @password, @dob, @profilePicture
                                        )";

                                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                                    {
                                        AddUserParameters(cmd, user);
                                        cmd.ExecuteNonQuery();
                                        inserted++;
                                    }

                                    // Create lessor only for new users
                                    InsertLessor(user.UserId, conn, transaction);
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Transaction failed and was rolled back. " + ex.Message);
                        }
                    }
                }

                MessageBox.Show($"Users processed successfully: {inserted} inserted, {updated} updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving users to database: " + ex.Message);
            }
        }

        // Helper method to add parameters to command
        private void AddUserParameters(SqlCommand cmd, User user)
        {
            cmd.Parameters.AddWithValue("@userId", user.UserId);
            cmd.Parameters.AddWithValue("@userName", user.UserName);
            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@telephoneNo", user.TelephoneNo);
            cmd.Parameters.AddWithValue("@address", user.Address);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@dob", user.DOB.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@profilePicture", user.ProfilePicture);
        }

        /// <summary>
        /// Creates a new lessor record
        /// </summary>
        /// <summary>
        /// Creates a new lessor record
        /// </summary>
        private void InsertLessor(string userId, SqlConnection conn, SqlTransaction transaction)
        {
            // First check if a lessor record already exists for this user
            string checkQuery = "SELECT COUNT(*) FROM Lessor WHERE UserId = @UserId";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction))
            {
                checkCmd.Parameters.AddWithValue("@UserId", userId);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Lessor record already exists, no need to insert
                    return;
                }
            }

            // We need to generate a unique LessorId that doesn't collide
            string lessorId;
            bool idExists;

            do
            {
                // Generate a new potential ID
                lessorId = GenerateLessorId();

                // Check if this ID already exists
                string idCheckQuery = "SELECT COUNT(*) FROM Lessor WHERE LessorId = @LessorId";
                using (SqlCommand idCheckCmd = new SqlCommand(idCheckQuery, conn, transaction))
                {
                    idCheckCmd.Parameters.AddWithValue("@LessorId", lessorId);
                    idExists = ((int)idCheckCmd.ExecuteScalar() > 0);
                }
            } while (idExists); // Repeat until we find a unique ID

            // Now insert the new Lessor with the guaranteed unique ID
            string insertQuery = "INSERT INTO Lessor (LessorId, UserId, No_Of_Cars) VALUES (@LessorId, @UserId, @No_Of_Cars)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@LessorId", lessorId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@No_Of_Cars", 0); // Start with 0 cars
                cmd.ExecuteNonQuery();
            }
        }

        private string GenerateLessorId()
        {
            Guid guid = Guid.NewGuid();
            int numericPart = Math.Abs(guid.GetHashCode()) % 100000;
            return "L" + numericPart.ToString("D5");
        }

        /// <summary>
        /// Saves customers to database handling duplicates and foreign key constraints
        /// </summary>
        public void SaveCustomerToDatabase(HashTable<string, Customer> data)
        {
            int inserted = 0;
            int updated = 0;
            int skipped = 0;
            List<string> errorMessages = new List<string>();

            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var kvp in data.GetAllItems())
                            {
                                var customer = kvp.Value;

                                // Check if the user exists before trying to insert the customer
                                if (!UserExists(customer.UserID, conn, transaction))
                                {
                                    skipped++;
                                    errorMessages.Add($"User ID {customer.UserID} not found for Customer ID {customer.CustomerID}");
                                    continue;
                                }

                                // Check if customer exists
                                string checkCustomerQuery = "SELECT COUNT(*) FROM Customer WHERE CustomerID = @customerId";
                                bool customerExists = false;
                                using (SqlCommand checkCmd = new SqlCommand(checkCustomerQuery, conn, transaction))
                                {
                                    checkCmd.Parameters.AddWithValue("@customerId", customer.CustomerID);
                                    int count = (int)checkCmd.ExecuteScalar();
                                    customerExists = count > 0;
                                }

                                if (customerExists)
                                {
                                    // Update existing customer
                                    string updateQuery = @"
                                        UPDATE Customer SET 
                                            UserID = @userId,
                                            LicenseNo = @licenseNo,
                                            LicenseExpiryDate = @licenseExpiryDate,
                                            LicensePhoto = @licensePhoto
                                        WHERE CustomerID = @customerId";

                                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                                    {
                                        AddCustomerParameters(cmd, customer);
                                        cmd.ExecuteNonQuery();
                                        updated++;
                                    }
                                }
                                else
                                {
                                    // Insert new customer
                                    string insertQuery = @"
                                        INSERT INTO Customer (
                                            CustomerID, UserID, LicenseNo, LicenseExpiryDate, LicensePhoto
                                        )
                                        VALUES (
                                            @customerId, @userId, @licenseNo, @licenseExpiryDate, @licensePhoto
                                        )";

                                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                                    {
                                        AddCustomerParameters(cmd, customer);
                                        cmd.ExecuteNonQuery();
                                        inserted++;
                                    }
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Transaction failed and was rolled back. " + ex.Message);
                        }
                    }
                }

                // Show summary
                StringBuilder message = new StringBuilder();
                message.AppendLine($"Customers processed successfully: {inserted} inserted, {updated} updated, {skipped} skipped.");

                if (errorMessages.Count > 0)
                {
                    message.AppendLine("\nSkipped records due to missing user references:");
                    foreach (var error in errorMessages.Take(5)) // Show first 5 errors only
                    {
                        message.AppendLine("- " + error);
                    }

                    if (errorMessages.Count > 5)
                        message.AppendLine($"...and {errorMessages.Count - 5} more errors.");
                }

                MessageBox.Show(message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customers to database: " + ex.Message);
            }
        }

        // Helper method to add parameters to command
        private void AddCustomerParameters(SqlCommand cmd, Customer customer)
        {
            cmd.Parameters.AddWithValue("@customerId", customer.CustomerID);
            cmd.Parameters.AddWithValue("@userId", customer.UserID);
            cmd.Parameters.AddWithValue("@licenseNo", customer.LicenseNo);
            cmd.Parameters.AddWithValue("@licenseExpiryDate", customer.LicenseExpiryDate);
            cmd.Parameters.AddWithValue("@licensePhoto", customer.LicensePhoto);
        }
    }
}