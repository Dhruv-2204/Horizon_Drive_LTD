using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadUsers();
        }

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

       

        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void Editbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
