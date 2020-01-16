using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UserProfileArtists.Commands.CreateUserProfileFollowArtists
{
    public class CreateUserProfileFollowArtistCommandHandler : IRequestHandler<CreateUserFollowArtistCommand>
    {
        private readonly IIECDbContext _context;
        public CreateUserProfileFollowArtistCommandHandler(IIECDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateUserFollowArtistCommand request, CancellationToken cancellationToken)
        {
            if(await _context.Artists.FindAsync(request.ArtistId) == null)
                throw new NotFoundException(nameof(UserProfileFollowArtist), new { request.UserProfileId, request.ArtistId });

            var userProfile = _context.UserProfiles.Find(request.UserProfileId);

            var userProfileFollowArtist = new UserProfileFollowArtist { ArtistId = request.ArtistId, UserProfileId = userProfile.Id };

            _context.UserProfileFollowArtists.Add(userProfileFollowArtist);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}