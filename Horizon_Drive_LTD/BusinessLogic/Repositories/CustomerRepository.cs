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
    public class CustomerRepository
    {

        private readonly DatabaseConnection _dbConnection;

        public CustomerRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        internal HashTable<string, Customer> LoadCustomersIntoHashTable()
        {
            var customerTable = new HashTable<string, Customer>(1000);

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT CustomerID, UserID, LicenseNo, LicenseExpiryDate, LicensePhoto FROM Customer";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer(
                            reader.GetString(0),  // CustomerID
                            reader.GetString(1),  // UserID
                            reader.GetString(2),  // LicenseNo
                            DateOnly.FromDateTime(reader.GetDateTime(3)),  // LicenseExpiryDate
                            reader.IsDBNull(4) ? null : reader.GetString(4) // LicensePhoto (nullable)
                        );

                        customerTable.Insert(customer.CustomerID, customer);
                    }
                }
            }

            return customerTable;
        }

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Customer
                             (CustomerID, UserID, LicenseNo, LicenseExpiryDate, LicensePhoto)
                             VALUES 
                             (@CustomerID, @UserID, @LicenseNo, @LicenseExpiryDate, @LicensePhoto)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@UserID", customer.UserID);
                cmd.Parameters.AddWithValue("@LicenseNo", customer.LicenseNo);
                cmd.Parameters.AddWithValue("@LicenseExpiryDate", customer.LicenseExpiryDate);
                cmd.Parameters.AddWithValue("@LicensePhoto", customer.LicensePhoto ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
