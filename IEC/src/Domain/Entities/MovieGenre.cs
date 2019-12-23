using System.Collections.Generic;

namespace Domain.Entities
{
    public class MovieGenre
    {
        public MovieGenre()
        {
            MovieMovieGenres = new HashSet<MovieMovieGenre>();
        }

        public int Id { get; set; }
        public string Genre { get; set; }
        public ICollection<MovieMovieGenre> MovieMovieGenres { get; private set; }
    }
}