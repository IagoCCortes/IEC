using AutoMapper;
using Domain.Entities;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandMappings: Profile
    {
        public CreateMovieCommandMappings()
        {
            CreateMap<CreateMovieCommand,Movie>();
            CreateMap<Movie, CreateMovieReturnDto>();
        }
    }
}