using System;
using System.Collections.Generic;

namespace IEC.API.Dtos
{
    public class MovieForUpdateDto
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> GenreIds { get; set; }
    }
}