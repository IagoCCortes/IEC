using System;
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
            profile.CreateMap<Artist, ArtistLookupDto>();
        }
    }
}