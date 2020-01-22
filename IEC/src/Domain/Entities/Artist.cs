using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Artist : AuditableEntity, ISearchableEntity
    {
        public Artist()
        {
            MoviesArtist = new HashSet<MovieArtist>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Deathdate { get; set; }
        public string Birthplace { get; set; }
        public int? Height { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        // public string PicturePublicId { get; set; }
        public ICollection<MovieArtist> MoviesArtist { get; private set; }
        public ICollection<UserProfileFollowArtist> UserProfilesFollowArtist { get; set; }
        public string StringIdentifier { get {return ArtistName;} set { } }
    }
}