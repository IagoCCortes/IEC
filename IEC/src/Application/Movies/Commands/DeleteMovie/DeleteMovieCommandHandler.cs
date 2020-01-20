using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IIECDbContext _context;

        public DeleteMovieCommandHandler(IIECDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.Id)
                ?? throw new NotFoundException(nameof(Movie), request.Id);

            var hasArtists = _context.MovieArtists.Any(m => m.MovieId == movie.Id);
            if (hasArtists)
                throw new DeleteFailureException(nameof(Artist), request.Id, "There are existing orders associated with this customer.");

            _context.MovieMovieGenres.RemoveRange(_context.MovieMovieGenres.Where(m => m.MovieId == request.Id));

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}