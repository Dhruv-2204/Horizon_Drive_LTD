using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace Horizon_Drive_LTD.models
{

    // met ban id dan bn seperate table dan place met dan user table
    public class Customer : User
    {
        public string CustomerID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        
    }
}
