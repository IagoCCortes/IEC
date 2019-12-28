using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using Infrastructure.SendGrid;

namespace Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailSender _emailSender;
        public NotificationService(IEmailSender emailSender)
        {
            _emailSender = emailSender;

        }

        public Task SendAsync(MessageDto message)
        {
            _emailSender.SendEmailAsync(message);

            return Task.CompletedTask;
        }
    }
}