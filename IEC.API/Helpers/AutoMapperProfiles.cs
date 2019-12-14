using System.Linq;
using AutoMapper;
using IEC.API.Dtos.Movie;
using IEC.API.Core.Domain;
using IEC.API.Core.Enums;
using System;
using IEC.API.Dtos.Artist;

namespace IEC.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<MovieForCreationDto, Movie>();

            CreateMap<Movie, MovieListToReturnDto>()
            .ForMember(m => m.Genres, 
                       opt => opt.MapFrom(ps => ps.MovieMovieGenres.Select(mg => mg.MovieGenreId)
                                 .Select(mg => Enum.GetName(typeof(MovieGenreEnum), mg).Replace('_', ' ').Replace('1', '-'))));

            CreateMap<Movie, MovieDetailToReturnDto>()
            .ForMember(m => m.Genres, 
                       opt => opt.MapFrom(ps => ps.MovieMovieGenres.Select(mg => mg.MovieGenreId)
                                 .Select(mg => Enum.GetName(typeof(MovieGenreEnum), mg).Replace('_', ' ').Replace('1', '-'))))
            .ForMember(m => m.Actors,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Actor)
                                 .Select(ma => ma.Artist.ArtistName)))
            .ForMember(m => m.Directors,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Director)
                                 .Select(ma => ma.Artist.ArtistName)))
            .ForMember(m => m.Writers,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Writer)
                                 .Select(ma => ma.Artist.ArtistName)))
            .ForMember(m => m.Producers,
                       opt => opt.MapFrom(ps => ps.MovieArtists
                                 .Where(ma => ma.RoleId == (int) MovieRoleEnum.Producer)
                                 .Select(ma => ma.Artist.ArtistName)));
                                 
            CreateMap<MovieForUpdateDto, Movie>();

            CreateMap<ArtistForCreationDto, Artist>();

            CreateMap<Artist, ArtistToReturnDto>();
        }
    }
}