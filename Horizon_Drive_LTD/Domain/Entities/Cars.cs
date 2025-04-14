using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD.Domain.Entities
{
   public class Cars
    {

        public string CarID { get; set; }
        public string UserID { get; set; }
        public string CarBrand { get; set; }
        public string Category { get; set; }
        public string CarImagePath { get; set; }
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public int Year { get; set; } 
        public string Colour { get; set; }
        public string Features { get; set; }
        public string VehicleDescription { get; set; }
        public decimal CarPrice { get; set; }
        public int SeatNo { get; set; }
        public string EngineCapacity { get; set; } 
        public decimal Ratings { get; set; } 
        public string Power { get; set; }
        public string DriveTrain { get; set; }
        public string FuelType { get; set; } 
        public string TransmissionType { get; set; }
        public string Status { get; set; }

      



        public Cars(string carid , string userid, string carBrand, string category, string carImage, string registrationNo, string model, int year,
         string colour, string features, string desc, decimal price, int seat, string engine, decimal rating,
         string power, string drive, string fuel, string transmission, string status)
        {
            CarID = carid;
            UserID = userid;
            CarBrand = carBrand;
            Category = category;
            CarImagePath = carImage;

            RegistrationNo = registrationNo;
            Model = model;
            Features = features;
            VehicleDescription = desc;

            CarPrice = price;
            Ratings = rating;
            FuelType = fuel;
            TransmissionType = transmission;

            Year = year;
            Colour = colour;
            SeatNo = seat;
            EngineCapacity = engine;

            Power = power;
            DriveTrain = drive;
            Status = status;
        }

        
    }
}

