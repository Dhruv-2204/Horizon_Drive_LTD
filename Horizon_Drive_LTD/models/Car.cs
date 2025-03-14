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
        public string Make {  get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Registration { get; set; }
        public string Mileage { get; set; }
        public string FuelType { get; set; }
        public string EngineSize { get; set; }
        public string Transmission { get; set; }
        public string Doors { get; set; }
        public string Seats { get; set; }
        public string BodyType { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }



        public Car(string carID, string carMake, string model, string color, int seatCapacity, decimal engineCapacity, string fuelType, string status, string transmissionType)
        {
            CarID = carID;
            Make = carMake;
            Model = model;
            Color = color;
            carMake = seatCapacity;
            EngineCapacity = engineCapacity;
            FuelType = fuelType;
            Status = status;
            TransmissionType = transmissionType;
        }
    }

}
//CarID, UserID, CarBrand, CarImagePath, RegistrationNo, Model, Color, Features, SeatCapacity, EngineCapacity, FuelType, Status, TransmissionType