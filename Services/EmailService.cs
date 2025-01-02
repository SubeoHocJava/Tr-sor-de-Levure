using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web_WineShop.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration) =>
            _configuration = configuration;

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var senderEmail = _configuration["EmailSettings:SenderEmail"];
            var senderPassword = _configuration["EmailSettings:SenderPassword"];

            using (var smtpClient = new SmtpClient(smtpServer) { Port = smtpPort, Credentials = new NetworkCredential(senderEmail, senderPassword), EnableSsl = true })
            {
                var mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body) { IsBodyHtml = true }; // IsBodyHtml cho phép gửi mail với định dạng phức tạp
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error sending email.", ex);
                }
            }
        }
    }
}
