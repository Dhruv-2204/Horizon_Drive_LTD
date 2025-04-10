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

        public HashTable<string, User> LoadUsersIntoHashTable()
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
    }
}
