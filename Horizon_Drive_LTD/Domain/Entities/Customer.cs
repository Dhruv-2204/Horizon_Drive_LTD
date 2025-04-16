using System;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string LicenseNo { get; set; }
        public DateOnly LicenseExpiryDate { get; set; }
        public string LicensePhoto { get; set; }

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