using MediatR;

namespace Application.Artists.Queries.GetArtistList
{
    public class GetArtistListQuery : IRequest<ArtistListVM>
    {
        public int? UserId { get; set; }
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 20;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string OrderBy { get; set; }
    }
}