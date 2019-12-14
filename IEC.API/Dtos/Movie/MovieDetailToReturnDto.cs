using System;
using System.Collections.Generic;

namespace IEC.API.Dtos.Movie
{
    public class MovieDetailToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Producers { get; set; }
    }
}