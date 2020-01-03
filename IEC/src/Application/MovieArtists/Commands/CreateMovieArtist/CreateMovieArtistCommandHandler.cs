using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MovieArtists.Commands.CreateMovieArtist
{
    public class CreateMovieArtistCommandHandler : IRequestHandler<CreateMovieArtistCommand>
    {
        private readonly IIECDbContext _context;
        public CreateMovieArtistCommandHandler(IIECDbContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(CreateMovieArtistCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId);

            if(movie == null)
                throw new NotFoundException(nameof(Movie), request.MovieId);

            await _context.MovieArtists.AddRangeAsync(CreateMovieArtistList(request.MovieId, request.ArtistIds, request.RoleIds));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private IEnumerable<MovieArtist> CreateMovieArtistList(int movieId, List<int> artistIds, List<int> roleIds)
        {
            for (int i = 0; i < artistIds.Count; i++)
            {
                var artist = _context.Artists.Find(artistIds[i]);

                if(artist == null)
                    throw new NotFoundException(nameof(Artist), artistIds[i]);

                yield return new MovieArtist { MovieId = movieId, ArtistId = artistIds[i], RoleId = roleIds[i] };
            }
        }
    }
}