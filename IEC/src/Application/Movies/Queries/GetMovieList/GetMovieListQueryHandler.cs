using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Pagination;
using AutoMapper;
using Domain.Entities;
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
            var moviesQueryable = _mapper.ProjectTo<MovieLookupDto>(_context.Movies);

            if(!string.IsNullOrEmpty(request.OrderBy))
            {
                switch(request.OrderBy)
                {
                    case "release":
                        moviesQueryable = moviesQueryable.OrderByDescending(m => m.ReleaseDate);
                        break;
                    case "runtime":
                        moviesQueryable = moviesQueryable.OrderByDescending(m => m.Runtime);
                        break;
                    default:
                        moviesQueryable = moviesQueryable.OrderByDescending(m => m.Title);
                        break;
                }
            }
            
            var movies = await PagedList<MovieLookupDto>.CreateAsync(moviesQueryable, request.PageNumber, request.PageSize);

            return new MovieListVM { 
                Movies = movies,
                CurrentPage = movies.CurrentPage,
                TotalCount = movies.TotalCount,
                PageSize = movies.PageSize,
                TotalPages = movies.TotalPages
            };
        }
    }
}