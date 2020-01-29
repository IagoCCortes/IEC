using System.Collections.Generic;

namespace Application.UserProfileMovies.Queries
{
    public class UserProfileMovieListVM
    {
        public IList<UserProfileMovieLookupDto> Movies { get; set; }
    }
}