using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class MaintenanceRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public MaintenanceRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            List<MaintenanceRecord> records = new List<MaintenanceRecord>();

            try
            {
                string query = "SELECT MaintenanceID, CarID, MaintenanceDate, MaintenanceStatus, MaintenanceDescription FROM Maintenance";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new MaintenanceRecord
                                {
                                    MaintenanceID = reader.GetString(0),
                                    CarID = reader.GetString(1),
                                    MaintenanceDate = reader.GetDateTime(2),
                                    MaintenanceStatus = reader.GetString(3),
                                    MaintenanceDescription = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving maintenance records: {ex.Message}");
            }

            return records;
        }

        public bool AddMaintenanceRecord(MaintenanceRecord record)
        {
            try
            {
                string query = @"INSERT INTO Maintenance (MaintenanceID, CarID, MaintenanceDate, MaintenanceStatus, MaintenanceDescription) 
                       VALUES (@MaintenanceID, @CarID, @MaintenanceDate, @MaintenanceStatus, @MaintenanceDescription)";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", record.MaintenanceID);
                        command.Parameters.AddWithValue("@CarID", record.CarID);
                        command.Parameters.AddWithValue("@MaintenanceDate", record.MaintenanceDate);
                        command.Parameters.AddWithValue("@MaintenanceStatus", record.MaintenanceStatus);
                        command.Parameters.AddWithValue("@MaintenanceDescription",
                            string.IsNullOrEmpty(record.MaintenanceDescription) ? (object)DBNull.Value : record.MaintenanceDescription);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log detailed SQL exception
                Console.WriteLine($"SQL Error adding maintenance record: {sqlEx.Message}");
                Console.WriteLine($"Error Number: {sqlEx.Number}");
                Console.WriteLine($"SQL State: {sqlEx.State}");
                Console.WriteLine($"Server: {sqlEx.Server}");
                MessageBox.Show($"Database Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Log general exception
                Console.WriteLine($"Error adding maintenance record: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateMaintenanceRecord(MaintenanceRecord record)
        {
            try
            {
                string query = @"UPDATE Maintenance 
                               SET CarID = @CarID, 
                                   MaintenanceDate = @MaintenanceDate, 
                                   MaintenanceStatus = @MaintenanceStatus, 
                                   MaintenanceDescription = @MaintenanceDescription 
                               WHERE MaintenanceID = @MaintenanceID";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", record.MaintenanceID);
                        command.Parameters.AddWithValue("@CarID", record.CarID);
                        command.Parameters.AddWithValue("@MaintenanceDate", record.MaintenanceDate);
                        command.Parameters.AddWithValue("@MaintenanceStatus", record.MaintenanceStatus);
                        command.Parameters.AddWithValue("@MaintenanceDescription", record.MaintenanceDescription ?? (object)DBNull.Value);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating maintenance record: {ex.Message}");
                return false;
            }
        }

        public bool DeleteMaintenanceRecord(string maintenanceID)
        {
            try
            {
                string query = "DELETE FROM Maintenance WHERE MaintenanceID = @MaintenanceID";

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", maintenanceID);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting maintenance record: {ex.Message}");
                return false;
            }
        }
    }
}