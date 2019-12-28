using System.Threading.Tasks;
using Application.Notifications.Models;

namespace Application.Common.Interfaces
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(MessageDto message);
        public Task ExecuteAsync(string apiKey, MessageDto message);
    }
}