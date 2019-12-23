using AutoMapper;
using Domain.Entities;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandMapping : Profile
    {
        public CreateArtistCommandMapping()
        {
            CreateMap<CreateArtistCommand, Artist>();
        }
    }
}