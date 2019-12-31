using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Artist>
    {
        private readonly IIECDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateArtistCommandHandler(IIECDbContext context, IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<Artist> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = _mapper.Map<Artist>(request);

            _context.Artists.Add(artist);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ArtistCreated { Id = artist.Id }, cancellationToken);

            return artist;
        }
    }
}