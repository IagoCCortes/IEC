using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfileMovies.Commands.FavoriteUserProfileMovie
{
    public class FavoriteUserProfileMovieCommandHandler : IRequestHandler<FavoriteUserProfileMovieCommand>
    {
        private readonly IIECDbContext _context;
        public FavoriteUserProfileMovieCommandHandler(IIECDbContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(FavoriteUserProfileMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfileMovies
                .FirstOrDefaultAsync(u => u.UserProfileId == request.UserProfileId && u.MovieId == request.MovieId);

            if (entity == null)
            {
                entity = new UserProfileMovie
                {
                    UserProfileId = request.UserProfileId,
                    MovieId = request.MovieId,
                    UserProfileMovieStatusId = 3,
                    Favorited = true
                };
                _context.UserProfileMovies.Add(entity);
            }
            else
                entity.Favorited = entity.Favorited ? false : true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}