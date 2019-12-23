using AutoMapper;
using Domain.Entities;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieListMapping : Profile
    {
        public MovieListMapping()
        {
            CreateMap<Movie, MovieLookupDto>();
        }
    }
}