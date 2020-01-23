using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Movies.Queries.GetMovieList
{
    public class MovieLookupDto : IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public bool IsInUserList { get; set; } = false;
        public IEnumerable<int> Genres { get; set; }

        public void Mapping(Profile profile)
        {
            int userId = 0;
            profile.CreateMap<Movie, MovieLookupDto>()
                .ForMember(m => m.Genres, opt => 
                    opt.MapFrom(m => m.MovieMovieGenres.Where(mg => mg.MovieId == m.Id).Select(mg => mg.MovieGenreId))
                )
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Name))
                .ForMember(m => m.PosterUrl, opt => opt.MapFrom(m => m.ImageUrl))
                .ForMember(m => m.IsInUserList, opt => opt.MapFrom(m => 
                    m.UserProfilesMovie
                        .Any(up => up.UserProfileId == userId && up.MovieId == m.Id)
                ));
        }
    }
}