using MediatR;

namespace Application.UserProfileMovies.Queries
{
    public class UserProfileMovieQuery : IRequest<UserProfileMovieListVM>
    {
        public int UserProfileId { get; set; }
    }
}