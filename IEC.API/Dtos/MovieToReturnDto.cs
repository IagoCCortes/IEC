using System;
using System.Collections.Generic;
using IEC.API.Models;

namespace IEC.API.Dtos
{
    public class MovieToReturnDto
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public List<string> Genres { get; set; }
    }
}