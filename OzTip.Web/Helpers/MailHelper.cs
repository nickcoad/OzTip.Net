using System.Net.Mail;

namespace OzTip.Web.Helpers
{
    public class MailHelper
    {
        public static void SendEmail(string recipientAddress, string message)
        {
            var smtpClient = new SmtpClient("127.0.0.1", 25)
            {
                UseDefaultCredentials = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = false
            };

            var mail = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress("info@endtoend.tips", "End to End Footy Tipping"),
                Body = message
            };

            mail.To.Add(new MailAddress(recipientAddress));

            smtpClient.Send(mail);
        }
    }
}