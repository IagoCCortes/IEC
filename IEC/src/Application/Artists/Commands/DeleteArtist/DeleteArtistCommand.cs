using MediatR;

namespace Application.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommand : IRequest
    {
        public int Id { get; set; }
    }
}