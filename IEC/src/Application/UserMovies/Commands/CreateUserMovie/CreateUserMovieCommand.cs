using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserMovies.Commands.CreateUserMovie
{
    public class CreateUserMovieCommand : UserMovieCommand, IRequest, IMapTo<UserMovie>
    {
        public int UserMovieStatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserMovieCommand, UserMovie>();
        }
    }
}