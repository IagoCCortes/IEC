using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class MovieDetailVM : IMapFrom<Movie>
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
        public bool IsInUserList { get; set; }
        public bool IsFavorited { get; set; }

        public void Mapping(Profile profile)
        {
            int userId = 0;
            profile.CreateMap<Movie, MovieDetailVM>()
            .ForMember(m => m.PosterUrl, opt => opt.MapFrom(m => m.ImageUrl))
            .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Name))
            .ForMember(m => m.Genres, 
                opt => opt.MapFrom(ps => ps.MovieMovieGenres
                    .Select(mg => mg.MovieGenreId.ToString())))
            .ForMember(m => m.Stars,
                opt => opt.MapFrom(ps => ps.MovieArtists
                    .Where(ma => ma.RoleId == (int) MovieRoleEnum.Star)
                    .Select(ma => ma.Artist.Name)))
            .ForMember(m => m.Directors,
                opt => opt.MapFrom(ps => ps.MovieArtists
                    .Where(ma => ma.RoleId == (int) MovieRoleEnum.Director)
                    .Select(ma => ma.Artist.Name)))
            .ForMember(m => m.IsInUserList, opt => opt.MapFrom(m => 
                    m.UserProfilesMovie
                        .Any(up => up.UserProfileId == userId && up.MovieId == m.Id)
                ))
            .ForMember(m => m.IsFavorited, opt => opt.MapFrom(m => 
                    m.UserProfilesMovie
                        .Any(up => up.UserProfileId == userId && up.MovieId == m.Id && up.Favorited)
                ));
        }
    } 
}