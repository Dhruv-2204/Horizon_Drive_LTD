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
                string query = "INSERT INTO Payment (PaymentID, BookingID, UserID, PaymentAmount, PaymentDate, PaymentMethod) " +
                               "VALUES (@PaymentID, @BookingID, @UserID, @PaymentAmount, @PaymentDate, @PaymentMethod)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                    cmd.Parameters.AddWithValue("@BookingID", payment.BookingID);
                    cmd.Parameters.AddWithValue("@UserID", payment.UserID);

                    cmd.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Delete payment by BookingId
        public void DeletePaymentByBookingId(string bookingId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Payment WHERE BookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal GetTotalEarningsByBookingIds(List<string> bookingIds)
        {
            decimal total = 0;

            if (bookingIds == null || bookingIds.Count == 0)
                return total;

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                // Create a dynamic list of parameters
                string paramList = string.Join(",", bookingIds.Select((_, i) => $"@BookingId{i}"));
                string query = $"SELECT SUM(PaymentAmount) FROM Payment WHERE BookingID IN ({paramList})";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    for (int i = 0; i < bookingIds.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@BookingId{i}", bookingIds[i]);
                    }

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }

            return total;
        }


    }

}
