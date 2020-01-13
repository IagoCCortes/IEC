using System.Collections.Generic;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieListVM
    {
        public IList<MovieLookupDto> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}