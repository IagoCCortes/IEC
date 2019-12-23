using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.CreateMovieGenre
{
    public class CreateMovieGenreCommandHandler : IRequestHandler<CreateMovieGenreCommand>
    {
        private readonly IMediator _mediator;
        private readonly IIECDbContext _context;

        public CreateMovieGenreCommandHandler(IIECDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }

        public async Task<Unit> Handle(CreateMovieGenreCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(Movie), request.MovieId);

            _context.MovieMovieGenres.RemoveRange(_context.MovieMovieGenres.Where(m => m.MovieId == request.MovieId));

            foreach(var genre in request.GenreIds)
                _context.MovieMovieGenres.Add(new MovieMovieGenre {MovieId = request.MovieId, MovieGenreId = genre });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}