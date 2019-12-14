using System;

namespace IEC.API.Dtos.Artist
{
    public class ArtistForCreationDto
    {
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int? Height { get; set; }
        public string Bio { get; set; }
    }
}