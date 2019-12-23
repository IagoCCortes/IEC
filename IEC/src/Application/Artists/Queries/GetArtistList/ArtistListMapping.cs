using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Queries.GetArtistList
{
    public class ArtistListMapping : Profile
    {
        public ArtistListMapping()
        {
            // CreateMap<Artist, ArtistListVM>()
            // .ForMember(a => a.Artists, conf => conf
            // .MapFrom(a => new ArtistLookupDto{ 
            //     Id = a.Id,
            //     ArtistName = a.ArtistName,
            //     Birthdate = a.Birthdate,
            //     Birthplace = a.Birthplace,
            //     PictureUrl = a.PictureUrl
            // }));
            CreateMap<Artist, ArtistLookupDto>();
        }
    }
}