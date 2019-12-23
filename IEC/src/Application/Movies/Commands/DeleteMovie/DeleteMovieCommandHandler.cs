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
            var movie = await _context.Movies.FindAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(nameof(Movie), request.Id);

            // var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            // if (hasOrders)
            // {
            //     throw new DeleteFailureException(nameof(Artist), request.Id, "There are existing orders associated with this customer.");
            // }

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}