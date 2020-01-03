using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest, IMapTo<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMovieCommand, Movie>();
        }
    }
}