using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Horizon_Drive_LTD;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseConnection db = new DatabaseConnection();
            string result = db.TestConnection();
            MessageBox.Show(result, "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);


            HashTable<string, Car> carHashTable = new HashTable<string, Car>(50);


            db.FetchAndStoreCars(carHashTable);


            string searchCarId = "C004";
            Car foundCar = carHashTable.Search(searchCarId);

            if (foundCar != null)
            {
                MessageBox.Show($"Car Found: {foundCar.Make} {foundCar.Model} ",
                                "Car Search Result",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Car not found.",
                                "Car Search Result",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            // ReadUsers();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void Editbtn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /*
        private void ReadUsers()

        {
            DataTable dt = new DataTable();

            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Password");


            var repo = new UserRepository();
            var users = repo.GetUsers();

            foreach (var user in users)
            {
                var row = dt.NewRow();

                row["FirstName"] = user.FirstName;
                row["LastName"] = user.LastName;
                row["Password"] = user.Password;

                dt.Rows.Add(row);

            }

            UsersTable.DataSource = dt;

        }

       */


    }
}
