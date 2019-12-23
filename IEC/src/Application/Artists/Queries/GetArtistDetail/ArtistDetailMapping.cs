using System.Linq;
using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class ArtistDetailMapping : Profile
    {
        public ArtistDetailMapping()
        {
            CreateMap<Artist, ArtistDetailVM>()
            .ForMember(a => a.Movies, conf => conf
            .MapFrom(a => new ArtistMovieRole{ 
                MovieIds = a.MoviesArtist.Select(ma => ma.MovieId),
                MovieTitles = a.MoviesArtist.Select(ma => ma.Movie.Title),
                RoleIds = a.MoviesArtist.Select(ma => ma.RoleId)
            }));
        }
    }
}