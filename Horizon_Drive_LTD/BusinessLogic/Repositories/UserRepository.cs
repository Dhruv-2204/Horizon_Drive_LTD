﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public UserRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        internal HashTable<string, User> LoadUsersIntoHashTable()
        {
            var userTable = new HashTable<string, User>(1000);
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserId, UserName, FirstName, LastName, DOB, Email, TelephoneNo, Password, ProfilePicture, Address FROM [User]";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                            reader.GetString(0),    // UserId
                            reader.GetString(1),    // UserName
                            reader.GetString(2),    // FirstName
                            reader.GetString(3),    // LastName
                            reader.GetString(5),    // Email
                            reader.GetInt32(6),     // TelephoneNo
                            reader.IsDBNull(9) ? null : reader.GetString(9), // Address
                            reader.GetString(7),    // Password
                            DateOnly.FromDateTime(reader.GetDateTime(4)),    // DOB
                            reader.IsDBNull(8) ? null : reader.GetString(8)  // ProfilePicture (nullable)
                        );
                        userTable.Insert(user.UserId, user);
                    }
                }
            }
            return userTable;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            var userTable = LoadUsersIntoHashTable();

            foreach (var kvp in userTable.GetAllItems())
            {
                users.Add(kvp.Value);
            }

            return users;
        }

        public User GetUserById(string userId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserId, UserName, FirstName, LastName, DOB, Email, TelephoneNo, Password, ProfilePicture, Address FROM [User] WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                reader.GetString(0),    // UserId
                                reader.GetString(1),    // UserName
                                reader.GetString(2),    // FirstName
                                reader.GetString(3),    // LastName
                                reader.GetString(5),    // Email
                                reader.GetInt32(6),     // TelephoneNo
                                reader.IsDBNull(9) ? null : reader.GetString(9), // Address
                                reader.GetString(7),    // Password
                                DateOnly.FromDateTime(reader.GetDateTime(4)),    // DOB
                                reader.IsDBNull(8) ? null : reader.GetString(8)  // ProfilePicture (nullable)
                            );
                        }
                    }
                }
            }
            return null;
        }

        public string GetUserIdByUsername(string username)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserId FROM [User] WHERE UserName = @UserName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString(); // returns null if not found
                }
            }
        }

        public List<User> SearchUsers(string searchTerm)
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserId, UserName, FirstName, LastName, DOB, Email, TelephoneNo, Password, ProfilePicture, Address 
                                FROM [User]
                                WHERE UserId LIKE @SearchTerm 
                                OR UserName LIKE @SearchTerm 
                                OR FirstName LIKE @SearchTerm 
                                OR LastName LIKE @SearchTerm 
                                OR Email LIKE @SearchTerm";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(
                                reader.GetString(0),    // UserId
                                reader.GetString(1),    // UserName
                                reader.GetString(2),    // FirstName
                                reader.GetString(3),    // LastName
                                reader.GetString(5),    // Email
                                reader.GetInt32(6),     // TelephoneNo
                                reader.IsDBNull(9) ? null : reader.GetString(9), // Address
                                reader.GetString(7),    // Password
                                DateOnly.FromDateTime(reader.GetDateTime(4)),    // DOB
                                reader.IsDBNull(8) ? null : reader.GetString(8)  // ProfilePicture (nullable)
                            ));
                        }
                    }
                }
            }
            return users;
        }

        public void InsertUser(User user)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO [User] 
                (UserId, UserName, FirstName, LastName, DOB, Email, TelephoneNo, Password, Address, ProfilePicture)
                VALUES 
                (@UserId, @UserName, @FirstName, @LastName, @DOB, @Email, @TelephoneNo, @Password, @Address, @ProfilePicture)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DOB", new DateTime(user.DOB.Year, user.DOB.Month, user.DOB.Day));
                cmd.Parameters.AddWithValue("@TelephoneNo", user.TelephoneNo);
                cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicture ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE [User] 
                              SET UserName = @UserName,
                                  FirstName = @FirstName,
                                  LastName = @LastName, 
                                  DOB = @DOB,
                                  Email = @Email, 
                                  TelephoneNo = @TelephoneNo,
                                  Address = @Address,
                                  ProfilePicture = @ProfilePicture
                              WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@DOB", new DateTime(user.DOB.Year, user.DOB.Month, user.DOB.Day));
                    cmd.Parameters.AddWithValue("@TelephoneNo", user.TelephoneNo);
                    cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicture ?? (object)DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(string userId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM [User] WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public void StoreActiveUser(string username, string userId, string customerid, string lessorid)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                // Ensure the table exists
                string createTableQuery = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ActiveUser' AND xtype='U')
            CREATE TABLE ActiveUser (
                UserName VARCHAR(100) NOT NULL,
                UserId VARCHAR(10) NOT NULL,
                CustomerID VARCHAR(10) NOT NULL,
                LessorID VARCHAR(10) NOT NULL
            );";

                using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string deleteQuery = "DELETE FROM ActiveUser";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.ExecuteNonQuery();
                }

                // Insert the new active user
                string insertQuery = "INSERT INTO ActiveUser (UserName, UserId, CustomerID, LessorID) VALUES (@UserName, @UserId, @CustomerID, @LessorID)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@LessorID", lessorid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GetActiveUser(out string userName, out string customerid)
        {
            userName = null;
            customerid = null;

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 UserName, CustomerID FROM ActiveUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userName = reader["UserName"].ToString();
                        customerid = reader["CustomerID"].ToString();
                    }
                }
            }
        }

        public string GetEmailByCustomerId(string customerId)
        {
            using (SqlConnection connection = _dbConnection.GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT u.Email 
            FROM [User] u
            INNER JOIN Customer c ON u.UserId = c.UserId
            WHERE c.CustomerId = @CustomerId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Email"].ToString();
                    }
                    else
                    {
                        return null; // No email found
                    }
                }
            }
        }
    }
}