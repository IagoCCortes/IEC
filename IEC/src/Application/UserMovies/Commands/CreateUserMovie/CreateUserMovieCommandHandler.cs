using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserMovies.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandHandler : IRequestHandler<CreateUserMovieCommand>
    {
        private readonly IIECDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserMovieCommandHandler(IIECDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Unit> Handle(CreateUserMovieCommand request, CancellationToken cancellationToken)
        {
            if(await _context.Movies.FindAsync(request.MovieId) == null)
                throw new NotFoundException(nameof(UserMovie), new { request.UserId, request.MovieId });

            var user = _context.Users.Find(request.UserId);

            var userMovie = _mapper.Map<UserMovie>(request);

            _context.UserMovies.Add(userMovie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}