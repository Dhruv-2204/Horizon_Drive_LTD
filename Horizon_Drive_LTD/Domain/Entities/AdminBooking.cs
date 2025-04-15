using System;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class AdminBooking
    {
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public string CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } // "Confirmed", "Canceled", "Completed"

        // Navigation properties for related entities (not stored in DB)
        public string UserName { get; set; }
        public string CarModel { get; set; }

        public AdminBooking(string bookingId, string userId, string carId,
                      DateTime startDate, DateTime endDate,
                      decimal totalCost, string status,
                      string userName = null, string carModel = null)
        {
            BookingId = bookingId;
            UserId = userId;
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            TotalCost = totalCost;
            Status = status;
            UserName = userName;
            CarModel = carModel;
        }

        // Calculate the duration of the booking in days
        public int GetDurationInDays()
        {
            return (int)(EndDate - StartDate).TotalDays;
        }

        // Check if the booking is active (current date is between start and end date)
        public bool IsActive()
        {
            DateTime now = DateTime.Now;
            return Status == "Confirmed" && now >= StartDate && now <= EndDate;
        }

        // Check if booking is upcoming (start date is in the future)
        public bool IsUpcoming()
        {
            return Status == "Confirmed" && DateTime.Now < StartDate;
        }

        // Check if booking is completed (end date is in the past)
        public bool IsCompleted()
        {
            return Status == "Completed" || (Status == "Confirmed" && DateTime.Now > EndDate);
        }
    }
}