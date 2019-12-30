using AutoMapper;
using Domain.Entities;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommandMapping : Profile
    {
        public UpdateUserMovieCommandMapping()
        {
            CreateMap<UpdateUserMovieCommand, UserMovie>();
        }
    }
}