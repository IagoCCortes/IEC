using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovie
{
    public class UserProfileMovieQueryHandler : IRequestHandler<UserProfileMovieQuery, UserProfileMovieVM>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public UserProfileMovieQueryHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserProfileMovieVM> Handle(UserProfileMovieQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.UserProfileMovies
                .FirstOrDefaultAsync(u => u.UserProfileId == request.UserProfileId && u.MovieId == request.MovieId)
                ?? throw new NotFoundException(nameof(UserProfileMovie), request.UserProfileId);

            return _mapper.Map<UserProfileMovieVM>(data);      
        }
    }
}