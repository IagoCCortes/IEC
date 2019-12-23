using System.Collections.Generic;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieListVM
    {
        public IList<MovieLookupDto> Movies { get; set; }
    }
}