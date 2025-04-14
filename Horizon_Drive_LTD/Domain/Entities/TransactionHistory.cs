using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class TransactionHistory
    {
        string transactionID { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string RentalPrice { get; set; }
        string Status { get; set; }
        
        public TransactionHistory() { }

    }
}
