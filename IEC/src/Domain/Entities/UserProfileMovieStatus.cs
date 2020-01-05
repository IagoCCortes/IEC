using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserProfileMovieStatus
    {
        public UserProfileMovieStatus()
        {
            UserProfileMovies = new HashSet<UserProfileMovie>();
        }
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<UserProfileMovie> UserProfileMovies { get; set; }
    }
}