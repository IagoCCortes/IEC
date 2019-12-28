using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserMovieStatus
    {
        public UserMovieStatus()
        {
            UserMovies = new HashSet<UserMovie>();
        }
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}