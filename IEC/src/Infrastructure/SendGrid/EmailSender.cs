using Application.Common.Interfaces;
using Application.Notifications.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
namespace Infrastructure.SendGrid

{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(MessageDto message)
        {
            return ExecuteAsync(Options.SendGridKey, message);
        }

        public Task ExecuteAsync(string apiKey, MessageDto message)
        {
            var sendGridClient = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage()
            {
                From = new EmailAddress(message.From, message.FromAlias),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };
            sendGridMessage.AddTo(new EmailAddress(message.To));
            // Disable click tracking.See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            sendGridMessage.SetClickTracking(false, false);
            return sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}