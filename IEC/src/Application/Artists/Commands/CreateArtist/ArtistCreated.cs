using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public class ArtistCreated : INotification
    {
        public int Id { get; set; }

        public class ArtistCreatedHandler : INotificationHandler<ArtistCreated>
        {
            private readonly INotificationService _notification;

            public ArtistCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ArtistCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}