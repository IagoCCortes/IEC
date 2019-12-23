using MediatR;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class GetArtistDetailQuery : IRequest<ArtistDetailVM>
    {
        public int Id { get; set; }
    }
}