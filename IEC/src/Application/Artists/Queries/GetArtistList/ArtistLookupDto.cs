using System;
using System.Linq;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Queries.GetArtistList
{
    public class ArtistLookupDto :IMapFrom<Artist>
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthplace { get; set; }
        public string PictureUrl { get; set; }
        public bool IsInUserList { get; set; }

        public void Mapping(Profile profile)
        {
            int userId = 0;
            profile.CreateMap<Artist, ArtistLookupDto>()
                .ForMember(a => a.ArtistName, opt => opt.MapFrom(a => a.Name))
                .ForMember(a => a.PictureUrl, opt => opt.MapFrom(a => a.ImageUrl))
                .ForMember(a => a.IsInUserList, opt => opt.MapFrom(a => 
                    a.UserProfilesFollowArtist
                        .Any(up => up.UserProfileId == userId && up.ArtistId == a.Id)
                ));
        }
    }
}