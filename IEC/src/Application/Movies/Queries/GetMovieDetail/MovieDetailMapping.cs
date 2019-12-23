using System;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class MovieDetailMapping : Profile
    {
        public MovieDetailMapping()
        {
            CreateMap<Movie, MovieDetailVM>()
            .ForMember(m => m.Genres, 
                       opt => opt.MapFrom(ps => ps.MovieMovieGenres.Select(mg => mg.MovieGenreId.ToString())))
                                 //.Select(mg => Enum.GetName(typeof(MovieGenreEnum), mg).Replace('_', ' ').Replace('1', '-'))))
                                 //Threw an exception(memory leak)
            .ForMember(m => m.Stars,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Star)
                                 .Select(ma => ma.Artist.ArtistName)))
            .ForMember(m => m.Directors,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Director)
                                 .Select(ma => ma.Artist.ArtistName)))
            .ForMember(m => m.Writers,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Writer)
                                 .Select(ma => ma.Artist.ArtistName)));     
        }
    }
}