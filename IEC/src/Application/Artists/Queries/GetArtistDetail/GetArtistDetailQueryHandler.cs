using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class GetArtistDetailQueryHandler : IRequestHandler<GetArtistDetailQuery, ArtistDetailVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetArtistDetailQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArtistDetailVM> Handle(GetArtistDetailQuery request, CancellationToken cancellationToken)
        {
            var artist = await _mapper.ProjectTo<ArtistDetailVM>(_context.Artists)
                                      .FirstOrDefaultAsync(a => a.Id == request.Id);

            if (artist == null)
                throw new NotFoundException(nameof(Artist), request.Id);

            return artist;
        }
    }
}