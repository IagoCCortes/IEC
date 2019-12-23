namespace Domain.Entities
{
    public class MovieArtist
    {
        public int MovieId { get; set; }
        public int ArtistId { get; set; }
        public int RoleId { get; set; }
        public Movie Movie { get; set; }
        public Artist Artist { get; set; }
        public MovieRole Role { get; set; }
    }
}