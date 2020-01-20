using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand>
    {
        private readonly IIECDbContext _context;

        public DeleteArtistCommandHandler(IIECDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _context.Artists.FindAsync(request.Id) 
                ?? throw new NotFoundException(nameof(Artist), request.Id);

            var hasConnections = _context.MovieArtists.Any(a => a.ArtistId == artist.Id);
            if (hasConnections)
                throw new DeleteFailureException(nameof(Artist), request.Id, "There are existing movies associated with this artist.");

            _context.Artists.Remove(artist);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}