using System;
using System.Collections.Generic;
using IEC.API.Core.Domain;

namespace IEC.API.Dtos
{
    public class MovieToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public string PosterUrl { get; set; }
        public List<string> Genres { get; set; }
    }
}