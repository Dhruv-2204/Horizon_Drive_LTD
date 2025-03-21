using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Horizon_Drive_LTD.models;

namespace Horizon_Drive_LTD.models
{
    public class Car
    {
        public string CarID { get; set; }
        public string CarBrand {  get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Registration { get; set; }
        public int Mileage { get; set; }
        public string FuelType { get; set; }
        public string EngineSize { get; set; }
        public string Transmission { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public string BodyType { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string CarImage { get; set; }



        public Car(string carID, string brand, string model, string color, int seatCapacity, string engineCapacity, string fuelType, string status, string transmissionType)
        {
            CarID = carID;
            CarBrand = brand;
            Model = model;
            Color = color;
            Seats = seatCapacity;
            EngineSize = engineCapacity;
            FuelType = fuelType;
            Condition = status;
            Transmission = transmissionType;
        }


       
    }

}
//CarID, UserID, CarBrand, CarImagePath, RegistrationNo, Model, Color, Features, SeatCapacity, EngineCapacity, FuelType, Status, TransmissionType