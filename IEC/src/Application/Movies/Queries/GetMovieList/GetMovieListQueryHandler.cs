using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Movies.Queries.GetMovieList
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, MovieListVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieListQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MovieListVM> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = new MovieListVM { Movies = await _mapper.ProjectTo<MovieLookupDto>(_context.Movies)
                                       .ToListAsync(cancellationToken)};

            return movies;
        }
    }
}