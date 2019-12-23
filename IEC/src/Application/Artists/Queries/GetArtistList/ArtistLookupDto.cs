using System;

namespace Application.Artists.Queries.GetArtistList
{
    public class ArtistLookupDto
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthplace { get; set; }
        public string PictureUrl { get; set; }
    }
}