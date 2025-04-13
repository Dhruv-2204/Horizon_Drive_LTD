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
                            reader.IsDBNull(9) ? null : reader.GetString(9), // Password
                            reader.GetString(7),    // Address
                            DateOnly.FromDateTime(reader.GetDateTime(4)),
                            reader.IsDBNull(8) ? null : reader.GetString(8) // ProfilePicture (nullable)
                        );

                        userTable.Insert(user.UserId, user);
                    }
                }
            }

            return userTable;
        }

        public void InsertUser(User user)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO [User] 
                             (UserId, UserName, FirstName, LastName, DOB, Email, TelephoneNo, Password, Address)
                             VALUES 
                             (@UserId, @UserName, @FirstName, @LastName, @DOB, @Email, @TelephoneNo, @Password, @Address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DOB", user.DOB);
                cmd.Parameters.AddWithValue("@TelephoneNo", user.TelephoneNo);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();
            }


        }

    }
}
