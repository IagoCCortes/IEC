using System;

namespace Application.Movies.Commands
{
    public class MovieCommand
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
    }
}