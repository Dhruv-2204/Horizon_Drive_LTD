using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD.BusinessLogic.Services
{
    public class EmailServices
    {
        public static void SendConfirmationEmail(string recipientEmail, string customerName, string bookingDetails)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email@gmail.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Booking Confirmation";
                mail.Body = $"Dear {customerName},\n\nYour booking has been confirmed!\n\n{bookingDetails}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("your_email@gmail.com", "your_app_password");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show("Confirmation email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }
    }




}
