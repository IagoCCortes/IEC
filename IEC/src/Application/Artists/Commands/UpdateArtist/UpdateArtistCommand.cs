using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommand : ArtistCommand, IRequest, IMapTo<Artist>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateArtistCommand, Artist>();
        }
    }
}