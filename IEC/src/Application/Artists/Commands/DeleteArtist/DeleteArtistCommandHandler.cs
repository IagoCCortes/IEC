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
            var artist = await _context.Artists.FindAsync(request.Id);

            if (artist == null)
            {
                throw new NotFoundException(nameof(Artist), request.Id);
            }

            // var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            // if (hasOrders)
            // {
            //     throw new DeleteFailureException(nameof(Artist), request.Id, "There are existing orders associated with this customer.");
            // }

            _context.Artists.Remove(artist);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}