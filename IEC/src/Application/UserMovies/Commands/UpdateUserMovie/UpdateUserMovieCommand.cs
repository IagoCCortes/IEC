using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UserMovies.Commands.UpdateUserMovie
{
    public class UpdateUserMovieCommand : UserMovieCommand, IRequest, IMapTo<UserMovie>
    {
        public string Review { get; set; }  
        public int? Rating { get; set; }
        public bool Favorited { get; set; }
        public int UserMovieStatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserMovieCommand, UserMovie>();
        }
    }
}