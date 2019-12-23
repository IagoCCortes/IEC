using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Queries.GetArtistList
{
    public class GetArtistListQueryHandler : IRequestHandler<GetArtistListQuery, ArtistListVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetArtistListQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArtistListVM> Handle(GetArtistListQuery request, CancellationToken cancellationToken)
        {
            var artists = new ArtistListVM { Artists = await _mapper.ProjectTo<ArtistLookupDto>(_context.Artists)
                                       .ToListAsync(cancellationToken)};

            return artists;
        }
    }
}