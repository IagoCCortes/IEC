using MediatR;

namespace Application.UserMovies.Commands.DeleteUserMovie
{
    public class DeleteUserMovieCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}