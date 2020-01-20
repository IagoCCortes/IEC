using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public UpdateArtistCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _context.Artists
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Artist), request.Id);

            _mapper.Map(request, artist);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}