using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovieList
{
    public class UserProfileMovieListQueryHandler : IRequestHandler<UserProfileMovieListQuery, UserProfileMovieListVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public UserProfileMovieListQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserProfileMovieListVM> Handle(UserProfileMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _context.UserProfileMovies
                .Where(u => u.UserProfileId == request.UserProfileId)
                .Include(u => u.Movie)
                .ToListAsync()
                ?? throw new NotFoundException(nameof(UserProfileMovie), request.UserProfileId);

            var moviesToReturn = _mapper.Map<IList<UserProfileMovieLookupDto>>(movies);

            return new UserProfileMovieListVM { Movies = moviesToReturn };      
        }
    }
}