using System.Collections.Generic;

namespace IEC.API.Dtos.Movie
{
    public class MovieArtistForCreateDto
    {
        public List<int> ActorIds { get; set; }
        public List<int> DirectorIds { get; set; }
        public List<int> WriterIds { get; set; }
        public List<int> ProducerIds { get; set; }
    }
}