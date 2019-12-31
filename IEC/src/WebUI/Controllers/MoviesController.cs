using System.Threading.Tasks;
using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.CreateMovieArtist;
using Application.Movies.Commands.CreateMovieGenre;
using Application.Movies.Commands.DeleteMovie;
using Application.Movies.Commands.DeleteMovieArtist;
using Application.Movies.Commands.UpdateMovie;
using Application.Movies.Queries.GetMovieDetail;
using Application.Movies.Queries.GetMovieList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class MoviesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<MovieListVM>> ListMoviesAsync()
        {
            var movies = await Mediator.Send(new GetMovieListQuery());

            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDetailVM>> GetMovieAsync(int id)
        {
            var movie = await Mediator.Send(new GetMovieDetailQuery { Id = id });

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieAsync([FromBody]CreateMovieCommand command)
        {
            var movie = await Mediator.Send(command);

            return CreatedAtRoute("GetMovie", new {controller = "Movies", id = movie.Id}, movie);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody]UpdateMovieCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = id });

            return NoContent();
        }

        [HttpPost("{id}/genres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SetMovieGenresAsync(int id, [FromBody]CreateMovieGenreCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("{id}/artists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieArtistsAsync(int id, [FromBody]CreateMovieArtistCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}/artists")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieArtistsAsync(int id, [FromBody]DeleteMovieArtistCommand command)
        {
            command.MovieId = id;
            await Mediator.Send(command);

            return NoContent();
        }
    }
}