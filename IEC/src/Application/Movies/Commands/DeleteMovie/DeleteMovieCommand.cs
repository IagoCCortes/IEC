using MediatR;

namespace Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; }
    }
}