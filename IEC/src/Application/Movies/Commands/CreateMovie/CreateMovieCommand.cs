using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : MovieCommand, IRequest<CreateMovieReturnDto>, IMapTo<Movie>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMovieCommand,Movie>();
        }
    }
}