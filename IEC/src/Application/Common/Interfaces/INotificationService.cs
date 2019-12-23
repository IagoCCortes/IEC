using System.Threading.Tasks;
using Application.Notifications.Models;

namespace Application.Common.Interfaces
{
    public interface INotificationService
    {
         Task SendAsync(MessageDto message);
    }
}