using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Movie : AuditableEntity, ISearchableEntity
    {
        public Movie()
        {
            MovieMovieGenres = new HashSet<MovieMovieGenre>();
            MovieArtists = new HashSet<MovieArtist>();
            UserProfilesMovie = new HashSet<UserProfileMovie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int? Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        // public string PosterPublicId { get; set; }
        public ICollection<MovieMovieGenre> MovieMovieGenres { get; private set; }
        public ICollection<MovieArtist> MovieArtists { get; private set; }
        public ICollection<UserProfileMovie> UserProfilesMovie { get; set; }
    }
}