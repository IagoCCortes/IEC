using Application.Movies.Commands.CreateMovie;
using Microsoft.AspNetCore.Http;

namespace WebUI.Dtos
{
    public class CreateMovieDto
    {
        public CreateMovieCommand CreateMovieCommand { get; set; }
        public IFormFile File { get; set; }
    }
}