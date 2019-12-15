using System.Collections.Generic;

namespace IEC.API.Dtos.Movie
{
    public class MovieArtistForDeleteDto
    {
        public List<int> ArtistIds { get; set; }
        public List<int> RoleIds { get; set; }
    }
}