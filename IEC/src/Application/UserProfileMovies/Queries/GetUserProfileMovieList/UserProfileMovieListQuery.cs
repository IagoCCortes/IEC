using MediatR;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovieList
{
    public class UserProfileMovieListQuery : IRequest<UserProfileMovieListVM>
    {
        public int UserProfileId { get; set; }
    }
}