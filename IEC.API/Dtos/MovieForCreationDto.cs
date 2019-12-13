using System;
using System.Collections.Generic;

namespace IEC.API.Dtos
{
    public class MovieForCreationDto
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public string PosterUrl { get; set; }
        public List<int> GenreIds { get; set; }

        public MovieForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}