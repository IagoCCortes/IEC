using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.CreateMovieArtist;
using Application.Movies.Commands.CreateMovieGenre;
using Application.Movies.Commands.DeleteMovieArtist;
using Application.Movies.Commands.UpdateMovie;
using Application.Movies.Queries.GetMovieDetail;
using Application.Movies.Queries.GetMovieList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{

    // [Authorize]
    public class MoviesController : BaseController
    {
        // [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<MovieListVM>> GetMoviesAsync()
        {
            var movies = await Mediator.Send(new GetMovieListQuery());

            return Ok(movies);
        }

        // [AllowAnonymous]
        [HttpGet("{id}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDetailVM>> GetMovieAsync(int id)
        {
            var movie = await Mediator.Send(new GetMovieDetailQuery { Id = id });

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieAsync([FromBody]CreateMovieCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovieAsync([FromBody]UpdateMovieCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SetMovieGenresAsync([FromBody]CreateMovieGenreCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMovieArtistsAsync([FromBody]CreateMovieArtistCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieArtistsAsync([FromBody]DeleteMovieArtistCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}