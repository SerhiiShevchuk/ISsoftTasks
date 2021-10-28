using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace Task_NET02_4
{
    public class EmailService
    {
        public async Task SendEmailAsync( string message)
        {
            MailAddress from = new MailAddress("mail@gmail.com", "Tom");
            MailAddress to = new MailAddress("mail@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Warning!";
            m.Body = message;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("mail@gmail.com", "password");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
