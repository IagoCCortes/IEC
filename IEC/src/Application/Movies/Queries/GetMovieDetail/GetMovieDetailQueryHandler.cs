using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDetailVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MovieDetailVM> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _mapper.ProjectTo<MovieDetailVM>(_context.Movies)
                                     .FirstOrDefaultAsync(m => m.Id == request.Id);

            for (int i = 0; i < movie.Genres.Count; i++)
                movie.Genres[i] = Enum.GetName(typeof(MovieGenreEnum), Int32.Parse(movie.Genres[i])).Replace('_', ' ').Replace('1', '-');

            if (movie == null)
                throw new NotFoundException(nameof(Movie), request.Id);

            return movie;
        }
    }
}