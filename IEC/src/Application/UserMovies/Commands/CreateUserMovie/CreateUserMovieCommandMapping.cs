using AutoMapper;
using Domain.Entities;

namespace Application.UserMovies.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandMapping : Profile
    {
        public CreateUserMovieCommandMapping()
        {
            CreateMap<CreateUserMovieCommand, UserMovie>();
        }
    }
}