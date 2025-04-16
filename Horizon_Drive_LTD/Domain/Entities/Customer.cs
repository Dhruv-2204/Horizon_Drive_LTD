using System;

namespace Horizon_Drive_LTD.Domain.Entities
{
    // This class represents a customer in the car rental system.
    public class Customer
    {
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string LicenseNo { get; set; }
        public DateOnly LicenseExpiryDate { get; set; }
        public string LicensePhoto { get; set; }

        /// Constructor to initialize a customer object
        public Customer(string customerID, string userID, string licenseNo, DateOnly licenseExpiryDate, string licensePhoto)
        {
            CustomerID = customerID;
            UserID = userID;
            LicenseNo = licenseNo;
            LicenseExpiryDate = licenseExpiryDate;
            LicensePhoto = licensePhoto;
        }
    }
}