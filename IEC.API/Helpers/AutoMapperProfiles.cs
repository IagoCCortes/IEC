using System.Linq;
using AutoMapper;
using IEC.API.Dtos.Movie;
using IEC.API.Core.Domain;
using IEC.API.Core.Enums;
using System;
using IEC.API.Dtos.Artist;
using IEC.API.Dtos.User;

namespace IEC.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<ArtistForCreationDto, Artist>();
            CreateMap<Artist, ArtistListToReturn>();
            CreateMap<Artist, ArtistDetailToReturnDto>();

            CreateMap<MovieForCreationDto, Movie>();
            CreateMap<Movie, MovieListToReturnDto>();
            CreateMap<MovieForUpdateDto, Movie>();
            CreateMap<Movie, MovieDetailToReturnDto>()
            .ForMember(m => m.Genres, 
                       opt => opt.MapFrom(ps => ps.MovieMovieGenres.Select(mg => mg.MovieGenreId)
                                 .Select(mg => Enum.GetName(typeof(MovieGenreEnum), mg).Replace('_', ' ').Replace('1', '-'))))
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

            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserForDetailedDto>();
        }
    }
}