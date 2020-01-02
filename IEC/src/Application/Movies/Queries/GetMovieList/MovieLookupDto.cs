using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieLookupDto : IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movie, MovieLookupDto>();
        }
    }
}