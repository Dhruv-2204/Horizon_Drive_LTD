using System;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class MaintenanceRecord
    {
        public string MaintenanceID { get; set; }
        public string CarID { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string MaintenanceStatus { get; set; } // Enum values: Pending, In Progress, Completed
        public string MaintenanceDescription { get; set; }
    }
}