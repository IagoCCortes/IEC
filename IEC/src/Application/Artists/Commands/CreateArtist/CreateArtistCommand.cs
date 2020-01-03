using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommand : ArtistCommand, IRequest<Artist>, IMapTo<Artist>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArtistCommand, Artist>();
        }
    }
}