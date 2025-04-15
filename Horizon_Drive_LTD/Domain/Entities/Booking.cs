using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Horizon_Drive_LTD.Domain.Entities
{
    // / This class represents a booking made by a customer.
    public class Booking
    {

        public string BookingID { get;set;}
        public string CustomerID { get;set;}
        public string CarID { get; set;}
        public string BookingDate { get; set;}
        public string PickupDate { get; set;}
        public string DropoffDate { get; set;}
        public string PickupLocation { get; set;}
        public string DropoffLocation { get; set;}
        public bool IncludeDriver { get; set;}
        public bool BabyCarSeat { get; set;}
        public bool FullInsuranceCoverage { get; set;}
        public bool RoofRack { get;  set; }
        public bool AirportPickupDropoff { get; set;}
        public string Status { get; set; }


        public Booking(string bookingID, string customerID, string carID, string bookingDate, string pickupDate, string dropoffDate, string pickupLocation,
            string dropoffLocation, bool includeDriver, bool babyCarSeat, bool fullInsuranceCoverage, bool roofRack, bool airportPickupDropoff, string status) {

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
            AirportPickupDropoff = airportPickupDropoff;
            Status = status;

        }


    }
}
