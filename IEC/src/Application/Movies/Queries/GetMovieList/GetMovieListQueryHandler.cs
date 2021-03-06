using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Pagination;
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
            var moviesQueryable =  _mapper.ProjectTo<MovieLookupDto>(_context.Movies, new { userId = request.UserId ?? 0});

            if(request.GenreIds != null)
            {
                moviesQueryable = moviesQueryable.Where(m => 
                    m.Genres.Any(x => request.GenreIds.Any(y => y == x)));
            }

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
                    case "title":
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