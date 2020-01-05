using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileMovies.Commands.DeleteUserProfileMovie
{
    public class DeleteUserProfileMovieCommandHandler : IRequestHandler<DeleteUserProfileMovieCommand>
    {
        private readonly IIECDbContext _context;
        public DeleteUserProfileMovieCommandHandler(IIECDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserProfileMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfileMovies.FirstOrDefaultAsync(us => us.MovieId == request.MovieId && us.UserProfileId == request.UserProfileId);

            if(entity == null)
                throw new NotFoundException(nameof(UserProfileMovie), new { request.UserProfileId, request.MovieId });

            _context.UserProfileMovies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}