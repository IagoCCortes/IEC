namespace IEC.API.Models
{
    public class MovieArtist
    {
        public int MovieId { get; set; }
        public int ArtistId { get; set; }
        public Movie Movie { get; set; }
        public Artist Artist { get; set; }
    }
}