using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Movies.Commands.DeleteMovieArtist
{
    public class DeleteMovieArtistCommandHandler : IRequestHandler<DeleteMovieArtistCommand>
    {
        private readonly IIECDbContext _context;
        public DeleteMovieArtistCommandHandler(IIECDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMovieArtistCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(Movie), request.MovieId);

            for (var i = 0; i < request.ArtistIds.Count; i++)
            {
                var movieArtist = _context.MovieArtists.FirstOrDefault(m => request.MovieId == m.MovieId 
                                                    && request.ArtistIds[i] == m.ArtistId 
                                                    && request.RoleIds[i] == m.RoleId);

                if(movieArtist == null)
                    throw new NotFoundException(nameof(MovieArtist), request.ArtistIds[i]);

                _context.MovieArtists.Remove(movieArtist);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}