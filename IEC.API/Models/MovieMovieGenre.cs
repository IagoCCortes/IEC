namespace IEC.API.Models
{
    public class MovieMovieGenre
    {
        public int MovieId { get; set; }
        public int MovieGenreId { get; set; }
        public Movie Movie { get; set; }
        public MovieGenre MovieGenre { get; set; }
    }
}