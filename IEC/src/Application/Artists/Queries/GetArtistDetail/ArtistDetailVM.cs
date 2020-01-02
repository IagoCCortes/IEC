using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class ArtistDetailVM : IMapFrom<Artist>
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int? Height { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public ArtistMovieRole Movies { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Artist, ArtistDetailVM>()
            .ForMember(a => a.Movies, conf => conf
            .MapFrom(a => new ArtistMovieRole{ 
                MovieIds = a.MoviesArtist.Select(ma => ma.MovieId),
                MovieTitles = a.MoviesArtist.Select(ma => ma.Movie.Title),
                RoleIds = a.MoviesArtist.Select(ma => ma.RoleId)
            }));
        }
    }

    public class ArtistMovieRole
    {
        public IEnumerable<int> MovieIds { get; set; }
        public IEnumerable<string> MovieTitles { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
    } 
}