using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MovieArtists.Commands.DeleteMovieArtist
{
    public class DeleteMovieArtistCommandHandler : IRequestHandler<MovieArtistCommand>
    {
        private readonly IIECDbContext _context;
        public DeleteMovieArtistCommandHandler(IIECDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(MovieArtistCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId)
                ?? throw new NotFoundException(nameof(Movie), request.MovieId);

            for (var i = 0; i < request.ArtistIds.Count; i++)
            {
                var movieArtist = _context.MovieArtists.FirstOrDefault(m => request.MovieId == m.MovieId 
                    && request.ArtistIds[i] == m.ArtistId 
                    && request.RoleIds[i] == m.RoleId)
                    ?? throw new NotFoundException(nameof(MovieArtist), request.ArtistIds[i]);

                _context.MovieArtists.Remove(movieArtist);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}