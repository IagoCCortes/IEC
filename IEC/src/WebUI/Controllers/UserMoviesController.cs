using System.Security.Claims;
using System.Threading.Tasks;
using Application.UserMovies.Commands.CreateUserMovie;
using Application.UserMovies.Commands.DeleteUserMovie;
using Application.UserMovies.Commands.UpdateUserMovie;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/users/{userId}/movies")]
    public class UserMoviesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUserMovieAsync(int userId, [FromBody]CreateUserMovieCommand command)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            command.UserId = userId;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateUserMovieAsync(int userId, int movieId, [FromBody]UpdateUserMovieCommand command)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
 
            command.UserId = userId;
            command.MovieId = movieId;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteUserMovieAsync(int userId, int movieId)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await Mediator.Send(new DeleteUserMovieCommand { UserId = userId, MovieId = movieId });

            return Ok();
        }
    }
}