using AutoMapper;
using Domain.Entities;

namespace Application.Users.Commands.CreateUserMovie
{
    public class CreateUserMovieCommandMapping : Profile
    {
        public CreateUserMovieCommandMapping()
        {
            CreateMap<CreateUserMovieCommand, UserMovie>();
        }
    }
}