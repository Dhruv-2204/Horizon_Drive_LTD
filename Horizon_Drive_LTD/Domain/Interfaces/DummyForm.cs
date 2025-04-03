using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon_Drive_LTD.Domain.Interfaces
{
    public partial class DummyWindow : Form
    {

        string connectionString = "Data Source=LAPTOP-VKDU1VH3\\SQLEXPRESS;Initial Catalog=DummyCars;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


        public DummyWindow()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                //openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //pictureBox1.ImageLocation = openFileDialog.FileName;
                    //label1.Text = "Image Selected";
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void InsertImage(string imagePath)
        {
            // Implement the logic to insert the image into the database
            // using the provided connection string and image path.
            // This is just a placeholder for demonstration purposes.
            //MessageBox.Show($"Image inserted: {imagePath}")
            //
            byte[] imageData = File.ReadAllBytes(imagePath);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Images (Name, Image) VALUES ('" + textBox2.Text + "', @ImageData)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ImageData", imageData);
                    //connection.Open();
                    command.ExecuteNonQuery();
                }
            }


        }

        private void Save_Click(object sender, EventArgs e)
        {
            InsertImage(textBox1.Text);
            loadData();
            MessageBox.Show("Image saved to database.");
        }

        private void DummyWindow_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            

            // SQL query to fetch data
            string query = "SELECT ImageID, Name FROM Images ORDER BY ImageID ASC"; // Fixed syntax error: By Asc -> ORDER BY

            // Create a DataSet to hold the data
            DataSet ds = new DataSet();

            // Create a SqlConnection and SqlDataAdapter using Microsoft.Data.SqlClient
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Fill the DataSet
                    dataAdapter.Fill(ds);

                    // Bind the data to the DataGridView
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }

            
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true; // Prevent editing
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int imageId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ImageID"].Value);
            loadImage(imageId);

        }

        public void loadImage(int imageId)
        {
            // Implement the logic to load the image from the database
            // using the provided connection string and image ID.
            // This is just a placeholder for demonstration purposes.
            //MessageBox.Show($"Image loaded: {imageId}");

            using (SqlConnection  conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Image FROM Images WHERE ImageID = @ImageID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImageID", imageId);
                    conn.Open();
                    byte[] imageData = (byte[])cmd.ExecuteScalar();
                    if (imageData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
