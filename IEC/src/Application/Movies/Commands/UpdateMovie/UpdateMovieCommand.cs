using System;
using MediatR;

namespace Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
    }
}