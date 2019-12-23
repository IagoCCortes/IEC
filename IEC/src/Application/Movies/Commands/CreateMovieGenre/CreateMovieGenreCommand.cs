using System.Collections.Generic;
using MediatR;

namespace Application.Movies.Commands.CreateMovieGenre
{
    public class CreateMovieGenreCommand : IRequest
    {
        public int MovieId { get; set; }
        public List<int> GenreIds { get; set; }
    }
}