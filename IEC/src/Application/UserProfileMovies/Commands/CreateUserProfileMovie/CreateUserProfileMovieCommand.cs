using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserProfileMovies.Commands.CreateUserProfileMovie
{
    public class CreateUserProfileMovieCommand : UserProfileMovieCommand, IRequest, IMapTo<UserProfileMovie>
    {
        public int UserProfileMovieStatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserProfileMovieCommand, UserProfileMovie>();
        }
    }
}