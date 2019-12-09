using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEC.API.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string ArtistName { get; set; }
        
        public string RealName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Birthplace { get; set; }

        public int? Height { get; set; }

        [Required]
        public string Bio { get; set; }

        public ICollection<MovieArtist> MoviesArtist { get; set; }
    }
}