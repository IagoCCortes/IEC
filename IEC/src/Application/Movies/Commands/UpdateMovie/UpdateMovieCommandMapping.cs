using AutoMapper;
using Domain.Entities;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandMapping : Profile
    {
        public UpdateMovieCommandMapping()
        {
            CreateMap<UpdateMovieCommand, Movie>();
        }
    }
}