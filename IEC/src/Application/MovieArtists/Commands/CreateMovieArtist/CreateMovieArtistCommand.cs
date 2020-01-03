using System.Collections.Generic;
using MediatR;

namespace Application.MovieArtists.Commands.CreateMovieArtist
{
    public class CreateMovieArtistCommand : IRequest
    {
        public int MovieId { get; set; }
        public List<int> ArtistIds { get; set; }
        public List<int> RoleIds { get; set; }
    }
}