using System.Collections.Generic;

namespace Application.Artists.Queries.GetArtistList
{
    public class ArtistListVM
    {
        public IList<ArtistLookupDto> Artists { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}