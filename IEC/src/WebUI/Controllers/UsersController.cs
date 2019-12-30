using System.Security.Claims;
using System.Threading.Tasks;
using Application.Users.Commands.CreateUserMovie;
using Application.Users.Commands.DeleteUserMovie;
using Application.Users.Queries.GetUserId;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUserAsync([FromBody]string userId)
        {
            var user = await Mediator.Send(new GetUserIdQuery { Id = userId});

            return Ok(user);
        }

        [HttpPost("{userId}/{movieId}/{userMovieStatusId}")]
        public async Task<IActionResult> AddMovieToUserAsync(int userId, int movieId, int userMovieStatusId)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await Mediator.Send(new CreateUserMovieCommand { UserId = userId, MovieId = movieId, UserMovieStatusId = userMovieStatusId});

            return Ok();
        }

        [HttpDelete("{userId}/{movieId}")]
        public async Task<IActionResult> DeleteMovieFromUserAsync(int userId, int movieId)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await Mediator.Send(new DeleteUserMovieCommand { UserId = userId, MovieId = movieId });

            return Ok();
        }
    }
}