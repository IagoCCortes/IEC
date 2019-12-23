using System;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieLookupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
    }
}