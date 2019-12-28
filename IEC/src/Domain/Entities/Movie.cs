using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Movie : AuditableEntity
    {
        public Movie()
        {
            MovieMovieGenres = new HashSet<MovieMovieGenre>();
            MovieArtists = new HashSet<MovieArtist>();
            UsersMovie = new HashSet<UserMovie>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int? Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<MovieMovieGenre> MovieMovieGenres { get; private set; }
        public ICollection<MovieArtist> MovieArtists { get; private set; }
        public ICollection<UserMovie> UsersMovie { get; set; }
    }
}