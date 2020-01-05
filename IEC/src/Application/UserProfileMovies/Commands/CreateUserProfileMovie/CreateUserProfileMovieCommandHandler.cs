using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserProfileMovies.Commands.CreateUserProfileMovie
{
    public class CreateUserProfileMovieCommandHandler : IRequestHandler<CreateUserProfileMovieCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserProfileMovieCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Unit> Handle(CreateUserProfileMovieCommand request, CancellationToken cancellationToken)
        {
            if(await _context.Movies.FindAsync(request.MovieId) == null)
                throw new NotFoundException(nameof(UserProfileMovie), new { request.UserProfileId, request.MovieId });

            var UserProfile = _context.UserProfiles.Find(request.UserProfileId);

            var userProfileMovie = _mapper.Map<UserProfileMovie>(request);

            _context.UserProfileMovies.Add(userProfileMovie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}