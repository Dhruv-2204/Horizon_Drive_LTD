using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public string BookingID { get; set; }
        public string UserID { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentAmount { get; set; }


        public Payment(string paymentID, string bookingID, string userID, string paymentDate, string paymentMethod, decimal paymentAmount)
        {
            PaymentID = paymentID;
            BookingID = bookingID;
            UserID = userID;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            PaymentAmount = paymentAmount;
        }
    }
}
