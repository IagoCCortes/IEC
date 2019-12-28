using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;

namespace Application.Movies.Commands.CreateMovie
{
    public class MovieCreated : INotification
    {
        public int Id { get; set; }

        public class MovieCreatedHandler : INotificationHandler<MovieCreated>
        {
            private readonly INotificationService _notification;

            public MovieCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(MovieCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}