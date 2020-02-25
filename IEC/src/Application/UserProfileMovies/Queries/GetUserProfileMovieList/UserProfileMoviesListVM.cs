using System.Collections.Generic;

namespace Application.UserProfileMovies.Queries.GetUserProfileMovieList
{
    public class UserProfileMovieListVM
    {
        public IList<UserProfileMovieLookupDto> Movies { get; set; }
    }
}