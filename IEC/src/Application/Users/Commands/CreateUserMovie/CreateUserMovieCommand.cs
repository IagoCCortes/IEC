using MediatR;

namespace Application.Users.Commands.CreateUserMovie
{
    public class CreateUserMovieCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int UserMovieStatusId { get; set; }
    }
}