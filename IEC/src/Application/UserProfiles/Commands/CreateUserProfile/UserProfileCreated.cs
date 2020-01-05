using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;

namespace Application.UserProfiles.Commands.CreateUserProfile
{
    public class UserProfileCreated : INotification
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public class UserProfileCreatedHandler : INotificationHandler<UserProfileCreated>
        {
            private readonly INotificationService _notification;

            public UserProfileCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserProfileCreated notification, CancellationToken cancellationToken)
            {
                var MailBody = "<button href='google.com' target='_blank'>Welcome</button>";

                await _notification.SendAsync(new MessageDto { From = "no-reply@IEC.com", FromAlias = "The Internet Entertainment Center", 
                                                               To = notification.Email, Subject = "IEC - Please confirm your email", Body = MailBody});
            }
        }
    }
}