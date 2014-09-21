namespace LunchDictator.Web.Core
{
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class EmailSender
    {
        public static async Task SendEmail(string to, string subject, string body)
        {
            var message = new MailMessage("noreply@lunchdictator.co.uk", to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            var smtp = new SmtpClient();
            await smtp.SendMailAsync(message);
        }
    }
}