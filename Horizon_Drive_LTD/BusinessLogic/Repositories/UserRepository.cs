using System;
using System.Collections.Generic;
using System.Data.Common;
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
                string query = "SELECT UserId, Username, PasswordHash, Role, Email FROM Users"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                        reader.GetString(0), // userid
                        reader.GetString(1), // username
                        reader.GetString(2), // password
                        reader.GetString(3), // role
                        reader.GetString(4)  // email
                    );

                        userTable.Insert(user.Username, user);
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
                string query = @"INSERT INTO Users (UserId, FirstName, LastName, Username, Email, DOB, PhoneNumber, Address, PasswordHash)
                         VALUES (@UserId, @FirstName, @LastName, @Username, @Email, @DOB, @PhoneNumber, @Address, @PasswordHash)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DOB", user.DOB);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@PasswordHash", user.Password); 

                cmd.ExecuteNonQuery();
            }
        }

    }
}
