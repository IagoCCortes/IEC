using System;
using System.Collections.Generic;

namespace IEC.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public ICollection<MovieMovieGenre> MovieMovieGenres { get; set; }
        public ICollection<MovieArtist> MovieArtists { get; set; }
    }
}