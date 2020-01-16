using System.Threading.Tasks;
using Application.UserProfileMovies.Commands.CreateUserProfileMovie;
using Application.UserProfileMovies.Commands.DeleteUserProfileMovie;
using Application.UserProfileMovies.Commands.UpdateUserProfileMovie;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/users/{userId}/movies")]
    public class UserMoviesController : BaseController
    {
        [HttpPost("{movieId}")]
        public async Task<IActionResult> CreateUserProfileMovieAsync(int userId, int movieId, [FromBody]CreateUserProfileMovieCommand command)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();

            command.UserProfileId = userId;
            command.MovieId = movieId;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateUserProfileMovieAsync(int userId, int movieId, [FromBody]UpdateUserProfileMovieCommand command)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();
 
            command.UserProfileId = userId;
            command.MovieId = movieId;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteUserProfileMovieAsync(int userId, int movieId)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();

            await Mediator.Send(new DeleteUserProfileMovieCommand { UserProfileId = userId, MovieId = movieId });

            return Ok();
        }
    }
}