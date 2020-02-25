using MediatR;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery : IRequest<MovieDetailVM>
    {
        public int? UserId { get; set; }
        public int Id { get; set; }
    }
}