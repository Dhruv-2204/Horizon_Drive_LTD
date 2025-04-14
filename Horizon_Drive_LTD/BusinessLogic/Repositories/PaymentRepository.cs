using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class PaymentRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public PaymentRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        // This method stores all payments to the database 
        public void LoadPaymentIntoDatabase(Payment payment)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Payment (PaymentID, BookingID, PaymentAmount, PaymentDate, PaymentMethod) " +
                               "VALUES (@PaymentID, @BookingID, @Amount, @PaymentDate, @PaymentMethod)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                    cmd.Parameters.AddWithValue("@BookingID", payment.BookingID);
                    cmd.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
