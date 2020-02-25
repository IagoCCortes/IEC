using System.Threading.Tasks;
using Application.UserProfileMovies.Commands.CreateUserProfileMovie;
using Application.UserProfileMovies.Commands.DeleteUserProfileMovie;
using Application.UserProfileMovies.Commands.FavoriteUserProfileMovie;
using Application.UserProfileMovies.Commands.UpdateUserProfileMovie;
using Application.UserProfileMovies.Queries.GetUserProfileMovie;
using Application.UserProfileMovies.Queries.GetUserProfileMovieList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/users/{userId}/movies")]
    public class UserMoviesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileMoviesAsync(int userId)
        {
            var movies = await Mediator.Send(new UserProfileMovieListQuery { UserProfileId = userId });
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetUserProfileMovieAsync(int userId, int movieId)
        {
            var data = await Mediator.Send(new UserProfileMovieQuery { UserProfileId = userId, MovieId = movieId });
            return Ok(data);
        }

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

        [HttpPut("{movieId}/favorite")]
        public async Task<IActionResult> FavoriteUserProfileMovieAsync(int userId, int movieId)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();
                
            await Mediator.Send(new FavoriteUserProfileMovieCommand { UserProfileId = userId, MovieId = movieId });

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