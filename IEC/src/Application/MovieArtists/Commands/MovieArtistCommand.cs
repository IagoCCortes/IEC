using System.Collections.Generic;
using MediatR;

namespace Application.MovieArtists.Commands
{
    public class MovieArtistCommand : IRequest
    {
        public int MovieId { get; set; }
        public List<int> ArtistIds { get; set; }
        public List<int> RoleIds { get; set; }
    }
}