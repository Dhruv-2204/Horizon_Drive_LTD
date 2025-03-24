using Microsoft.Win32;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD
{
    //public partial class Form1 : Form
    //{
    //    public Form1()
    //    {
    //        InitializeComponent();
    //    }

    //    private void Form1_Load(object sender, EventArgs e)
    //    {

    //    }

    //    private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
    //    {

    //    }

    //    private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
    //    {

    //    }

    //    private void button1_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void pictureBox1_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
    //    {

    //    }

    //    private void label1_Click(object sender, EventArgs e)
    //    {

    //    }
    //}

    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-VKDU1VH3\\SQLEXPRESS;Initial Catalog=DummyCars;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public Form1()

        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                RegistrationNumber = CarRegistor.Text,
                Make = Make.Text,
                Model = Model.Text,
                Year = int.Parse(Year.Text),
                //IsAvailable = checkBox1.Checked
            };

            InsertCarIntoDatabase(car);
            MessageBox.Show("Car added successfully!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carTable = RetrieveCarsFromDatabase();
            dataGridView1.DataSource = carTable.GetAllItems().Select(kvp => kvp.Value).ToList();

        }

        private void InsertCarIntoDatabase(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cars (RegistrationNumber, Make, Model, Year, IsAvailable) VALUES (@RegistrationNumber, @Make, @Model, @Year, @IsAvailable)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RegistrationNumber", car.RegistrationNumber);
                    command.Parameters.AddWithValue("@Make", car.Make);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@Year", car.Year);
                    command.Parameters.AddWithValue("@IsAvailable", car.IsAvailable);

                    command.ExecuteNonQuery();
                }
            }
        }

        private HashTable<string, Car> RetrieveCarsFromDatabase()
        {
            var carTable = new HashTable<string, Car>(7);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var car = new Car
                            {
                                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                                Make = reader["Make"].ToString(),
                                Model = reader["Model"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };

                            carTable.Insert(car.RegistrationNumber, car);
                        }
                    }
                }
            }

            return carTable;
        }

        private void buuton1_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                RegistrationNumber = CarRegistor.Text,
                Make = Make.Text,
                Model = Model.Text,
                Year = int.Parse(Year.Text),
                //IsAvailable = checkBox1.Checked
            };

            InsertCarIntoDatabase(car);
            MessageBox.Show("Car added successfully!");
        }

        private void RetriveButton_Click(object sender, EventArgs e)
        {
            var carTable = RetrieveCarsFromDatabase();
            dataGridView1.DataSource = carTable.GetAllItems().Select(kvp => kvp.Value).ToList();
        }
    }

    public class Car
{
    public string RegistrationNumber { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    public override string ToString()
    {
        return $"{RegistrationNumber} - {Make} {Model} ({Year}) - Available: {IsAvailable}";
    }
}


}
