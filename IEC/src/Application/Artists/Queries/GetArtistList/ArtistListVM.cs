using System.Collections.Generic;

namespace Application.Artists.Queries.GetArtistList
{
    public class ArtistListVM
    {
        public IList<ArtistLookupDto> Artists { get; set; }
    }
}