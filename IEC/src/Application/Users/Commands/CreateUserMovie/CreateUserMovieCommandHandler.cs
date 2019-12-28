using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUserMovie
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
            var userMovie = _mapper.Map<UserMovie>(request);

            _context.UserMovies.Add(userMovie);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}