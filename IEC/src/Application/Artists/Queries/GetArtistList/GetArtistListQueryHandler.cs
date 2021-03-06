using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Pagination;
using AutoMapper;
using MediatR;

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
            var artistsQueryable = _mapper.ProjectTo<ArtistLookupDto>(_context.Artists, new { userId = request.UserId ?? 0});

            if(!string.IsNullOrEmpty(request.OrderBy))
            {
                switch(request.OrderBy)
                {
                    case "birthdate":
                        artistsQueryable = artistsQueryable.OrderByDescending(a => a.Birthdate);
                        break;
                    case "name":
                        artistsQueryable = artistsQueryable.OrderByDescending(a => a.ArtistName);
                        break;
                }
            }
            var artists = await PagedList<ArtistLookupDto>.CreateAsync(artistsQueryable, request.PageNumber, request.PageSize);
            
            return new ArtistListVM { 
                Artists = artists,
                CurrentPage = artists.CurrentPage,
                TotalCount = artists.TotalCount,
                PageSize = artists.PageSize,
                TotalPages = artists.TotalPages
            };
        }
    }
}