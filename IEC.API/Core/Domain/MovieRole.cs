using System.Collections.Generic;

namespace IEC.API.Core.Domain
{
    public class MovieRole
    {
        public MovieRole()
        {
            MovieArtists = new HashSet<MovieArtist>();
        }
        public int Id { get; set; }
        public string Role { get; set; }
        public ICollection<MovieArtist> MovieArtists { get; set; }
    }
}