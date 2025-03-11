using Microsoft.Data.SqlClient;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class UserRepository
    {
        private string connectionString = "Data Source=RUMAISA;Initial Catalog=User;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public List<User> GetUsers()
        {

            var users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                 
                    string sql = "SELECT * FROM Users";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.FirstName = reader["FirstName"].ToString();
                                user.LastName = reader["LastName"].ToString();
                                user.Password = reader["Password"].ToString();

                                users.Add(user);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.ToString());
            }
            return users;
        }


        public User GetUser(string FirstName)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Users WHERE FirstName = @FirstName";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User();
                               
                                user.FirstName = reader["FirstName"].ToString();
                                user.LastName = reader["LastName"].ToString();
                                user.Password = reader["Password"].ToString();


                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.ToString());
            }
            return null;
        }

        public void CreateUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Users (FirstName, LastName, Password)" +
                        " VALUES (@FirstName, @LastName, @Password)";

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                Console.WriteLine("error");
            }

        }
    }

}
