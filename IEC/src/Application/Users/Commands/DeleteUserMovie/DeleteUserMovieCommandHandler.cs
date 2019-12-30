using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.DeleteUserMovie
{
    public class DeleteUserMovieCommandHandler : IRequestHandler<DeleteUserMovieCommand>
    {
        private readonly IIECDbContext _context;
        public DeleteUserMovieCommandHandler(IIECDbContext context)
        {
            _context = context;

        }
        public async Task<Unit> Handle(DeleteUserMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.UserMovies.FirstOrDefault(us => us.MovieId == request.MovieId && us.UserId == request.UserId);

            if(entity == null)
                throw new NotFoundException(nameof(UserMovie), new { request.UserId, request.MovieId });

            _context.UserMovies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}