using System;
using System.Collections.Generic;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class ArtistDetailVM
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int? Height { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public ArtistMovieRole Movies { get; set; }
    }

    public class ArtistMovieRole
    {
        public IEnumerable<int> MovieIds { get; set; }
        public IEnumerable<string> MovieTitles { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
    } 
}