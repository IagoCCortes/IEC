using System;
using System.Collections.Generic;
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
            profile.CreateMap<Movie, MovieLookupDto>();
            // .ForMember(m => m.IsInMovieList, 
                    //    opt => {
                    //        opt.PreCondition(new Func<Movie, bool>(m => UserId != null));
                    //        opt.MapFrom(m => m.UserProfilesMovie.Any(up => up.UserProfileId == UserId && up.MovieId == m.Id));
                    //    });
        }
    }
}