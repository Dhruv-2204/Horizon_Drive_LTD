
using System.Net.Mail;
using System.Net;
using Horizon_Drive_LTD.Domain.Entities;
using System.Configuration;

namespace Horizon_Drive_LTD.BusinessLogic.Services
{
    //  This class handles the sending of booking confirmation emails to customers.
    public class EmailService
    {
        // This method sends a booking confirmation email to the customer.
        public static void SendBookingConfirmationEmail(string customerEmail, Booking booking)
        {
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
                string senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
                string senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

                string subject = "Booking Confirmation - Car Hire Service";

                string body = $@"
                                Dear Customer,

                                Thank you for booking with us! Here are your booking details:

                                🔹 Booking ID: {booking.BookingID}
                                🔹 Car ID: {booking.CarID}
                                🔹 Booking Date: {booking.BookingDate}
                                🔹 Pickup Location: {booking.PickupLocation}
                                🔹 Drop-off Location: {booking.DropoffLocation}
                                🔹 Pickup Date: {booking.PickupDate}
                                🔹 Drop-off Date: {booking.DropoffDate}

                                Extras:
                                - Driver Included: {booking.IncludeDriver}
                                - Baby Car Seat: {booking.BabyCarSeat}
                                - Full Insurance Coverage: {booking.FullInsuranceCoverage}
                                - Roof Rack: {booking.RoofRack}
                                - Airport Pickup/Dropoff: {booking.AirportPickupDropoff}

                                If you have any questions, feel free to contact our team.

                                Safe travels,
                                Car Hire Service Team

                                 /\_/\
                                ( o.o )
                                 > ^ <  
                                ";
                // Create the email message
                MailMessage mail = new MailMessage(senderEmail, customerEmail, subject, body);
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpHost"], int.Parse(ConfigurationManager.AppSettings["SmtpPort"]))
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(
                                        ConfigurationManager.AppSettings["SenderEmail"],
                                        ConfigurationManager.AppSettings["SenderPassword"]
                                    )
                };
                // Send the email to the user 
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send confirmation email: " + ex.Message);
            }
        }
    }


}
