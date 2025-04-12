using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class Booking
    {
        public string BookingID { get;set;}
        public string CustomerID { get;set;}
        public string CarID { get; set;}
        public DateOnly BookingDate { get; set;}
        public DateOnly PickupDate { get; set;}
        public DateOnly DropoffDate { get; set;}
        public string PickupLocation { get; set;}
        public string DropoffLocation { get; set;}
        public bool IncludeDriver { get; set;}
        public bool BabyCarSeat { get; set;}
        public bool FullInsuranceCoverage { get; set;}
        public bool RoofRack { get;  set; }
        public bool AirportPickupDropoff { get; set;}


        public Booking(string bookingID, string customerID, string carID, DateOnly bookingDate, DateOnly pickupDate, DateOnly dropoffDate, string pickupLocation,
            string dropoffLocation, bool includeDriver, bool babyCarSeat, bool fullInsuranceCoverage, bool roofRack, bool airportPickupDropoff) {

            BookingID = bookingID;
            CustomerID = customerID;
            CarID = carID;
            BookingDate = bookingDate;
            PickupDate = pickupDate;
            DropoffDate = dropoffDate;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            IncludeDriver = includeDriver;
            BabyCarSeat = babyCarSeat;
            FullInsuranceCoverage = fullInsuranceCoverage;
            RoofRack = roofRack;
            AirportPickupDropoff = airportPickupDropoff;

        }

    }
}
