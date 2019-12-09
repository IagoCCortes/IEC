using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEC.API.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }

        [Required]
        public string Genre { get; set; }

        public ICollection<MovieMovieGenre> MovieMovieGenres { get; set; }
    }
}