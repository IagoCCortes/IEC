using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommand : IRequest<Artist>, IMapTo<Artist>
    {
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int? Height { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArtistCommand, Artist>();
        }
    }
}