using Learning_Management_System.Application.Iservices;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace Learning_Management_System.Application.Services
{
    public class SendGridEmailService:IEmailService
    {
        IConfiguration _config;

        public SendGridEmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var client = new SendGridClient(_config["SendGrid:ApiKey"]);
            var from = new EmailAddress(
                _config["SendGrid:FromEmail"],
                _config["SendGrid:FromName"]
                );

            var toEmail = new EmailAddress(to);
            var message = MailHelper.CreateSingleEmail(
                from,
                toEmail,
                subject,
                body,
                body
                );
            await client.SendEmailAsync(message);        
        }
    }
}
