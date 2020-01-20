using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileArtists.Commands.DeleteUserProfileFollowArtists
{
    public class DeleteUserProfileFollowArtistCommandHandler : IRequestHandler<DeleteUserProfileFollowArtistCommand>
    {
        private readonly IIECDbContext _context;
        public DeleteUserProfileFollowArtistCommandHandler(IIECDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserProfileFollowArtistCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfileFollowArtists
                .FirstOrDefaultAsync(us => us.ArtistId == request.ArtistId && us.UserProfileId == request.UserProfileId)
                ?? throw new NotFoundException(nameof(UserProfileFollowArtist), new { request.UserProfileId, request.ArtistId });

            _context.UserProfileFollowArtists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}