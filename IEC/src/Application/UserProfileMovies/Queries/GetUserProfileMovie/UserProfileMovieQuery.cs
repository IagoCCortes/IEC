using MediatR;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovie
{
    public class UserProfileMovieQuery : IRequest<UserProfileMovieVM>
    {
        public int UserProfileId { get; set; }
        public int MovieId { get; set; }
    }
}