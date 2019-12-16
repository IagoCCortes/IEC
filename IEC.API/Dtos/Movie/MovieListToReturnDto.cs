using System;
using System.Collections.Generic;

namespace IEC.API.Dtos.Movie
{
    public class MovieListToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
    }
}