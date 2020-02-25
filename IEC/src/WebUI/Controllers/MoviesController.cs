using System.Threading.Tasks;
using Application.MovieArtists.Commands;
using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.CreateMovieGenre;
using Application.Movies.Commands.DeleteMovie;
using Application.Movies.Commands.UpdateMovie;
using Application.Movies.Queries.GetMovieDetail;
using Application.Movies.Queries.GetMovieList;
using Application.SearchAll;
// using Infrastructure.CloudiNary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using WebUI.Dtos;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class MoviesController : BaseController
    {
        // private readonly CloudinaryService _cloudinaryService;
        // public MoviesController(CloudinaryService cloudinaryService)
        // {
        //     _cloudinaryService = cloudinaryService;
        // }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<MovieListVM>> ListMoviesAsync([FromQuery]GetMovieListQuery getMovieListQuery)
        {
            if (Request.Headers["Authorization"] != default(string))
                getMovieListQuery.UserId = int.Parse(User.FindFirst("UserProfileId").Value);

            var movies = await Mediator.Send(getMovieListQuery);

            Response.AddPagination(movies.CurrentPage, movies.PageSize, movies.TotalCount, movies.TotalPages);

            return Ok(movies.Movies);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDetailVM>> GetMovieAsync(int id)
        {
            var request = new GetMovieDetailQuery { Id = id };
            if (Request.Headers["Authorization"] != default(string))
                request.UserId = int.Parse(User.FindFirst("UserProfileId").Value);

            var movie = await Mediator.Send(request);

            return Ok(movie);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieAsync([FromBody]CreateMovieCommand command)
        {
            // var posterUrls = _cloudinaryService.UploadImage(createMovieDto.File);
            // if(posterUrls != null)
            // {
            //     createMovieDto.CreateMovieCommand.PosterUrl = posterUrls[0];
            //     createMovieDto.CreateMovieCommand.PosterPublicId = posterUrls[1];
            // }

            var movie = await Mediator.Send(command);

            return CreatedAtRoute("GetMovie", new { controller = "Movies", id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody]UpdateMovieCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = id });

            return NoContent();
        }

        [HttpPost("{id}/genres")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SetMovieGenresAsync(int id, [FromBody]CreateMovieGenreCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("{id}/artists")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieArtistsAsync(int id, [FromBody]MovieArtistCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}/artists")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieArtistsAsync(int id, [FromBody]MovieArtistCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return NoContent();
        }
    }
}