using System;
using System.Collections.Generic;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class MovieDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Stars { get; set; }
        public List<string> Directors { get; set; }
    } 
}