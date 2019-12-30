using MediatR;

namespace Application.Users.Commands.DeleteUserMovie
{
    public class DeleteUserMovieCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}