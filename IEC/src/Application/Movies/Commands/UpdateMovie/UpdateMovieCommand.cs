using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : MovieCommand, IRequest, IMapTo<Movie>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMovieCommand, Movie>();
        }
    }
}