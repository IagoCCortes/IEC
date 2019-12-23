using MediatR;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery : IRequest<MovieDetailVM>
    {
        public int Id { get; set; }
    }
}