using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class LessorRepository
    {

        private readonly DatabaseConnection _dbConnection;

        public LessorRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public string GetLessorIdByUserId(string userId)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT LessorID FROM Lessor WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    object result = cmd.ExecuteScalar();

                    return result?.ToString(); // Returns null if not found
                }
            }
        }
    }
}
