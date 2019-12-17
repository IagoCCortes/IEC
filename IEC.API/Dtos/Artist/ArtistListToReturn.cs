using System;

namespace IEC.API.Dtos.Artist
{
    public class ArtistListToReturn
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public string PictureUrl { get; set; }
    }
}