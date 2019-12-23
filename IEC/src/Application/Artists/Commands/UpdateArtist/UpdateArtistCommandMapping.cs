using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandMapping : Profile
    {
        public UpdateArtistCommandMapping()
        {
            CreateMap<UpdateArtistCommand, Artist>();
        }
    }
}