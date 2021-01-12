using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NG_Core_Auth.Email;
using NG_Core_Auth.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NG_Core_Auth.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly AppSettings _appSettings;

        public SendGridEmailSender(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public async Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message) 
        {
            var apiKey = _appSettings.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("dhiman.mona2010@gmail.com", "Monika");
            var subject = emailSubject;
            var to = new EmailAddress(userEmail, "Test");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return new SendEmailResponse();
        }
    }
}
