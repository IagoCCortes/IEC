using System;
using System.Collections.Generic;

namespace IEC.API.Core.Domain
{
    public class Movie
    {
        public Movie()
        {
            MovieMovieGenres = new HashSet<MovieMovieGenre>();
            MovieArtists = new HashSet<MovieArtist>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<MovieMovieGenre> MovieMovieGenres { get; private set; }
        public ICollection<MovieArtist> MovieArtists { get; private set; }
    }
}