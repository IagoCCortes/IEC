using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserProfileMovies.Commands.UpdateUserProfileMovie
{
    public class UpdateUserProfileMovieCommand : UserProfileMovieCommand, IRequest, IMapTo<UserProfileMovie>
    {
        public string Review { get; set; }  
        public int? Rating { get; set; }
        public bool Favorited { get; set; }
        public int UserMovieStatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserProfileMovieCommand, UserProfileMovie>();
        }
    }
}