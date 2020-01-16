using System.Threading.Tasks;
using Application.UserProfileArtists.Commands.CreateUserProfileFollowArtists;
using Application.UserProfileArtists.Commands.DeleteUserProfileFollowArtists;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/users/{userId}/artists")]
    public class UserProfileFollowArtistsController : BaseController
    {
        [HttpPost("{artistId}")]
        public async Task<IActionResult> CreateUserProfileFollowArtistAsync(int userId, int artistId)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();

            await Mediator.Send(
                new CreateUserFollowArtistCommand { ArtistId = artistId, UserProfileId = userId }
            );

            return Ok();
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteUserProfileMovieAsync(int userId, int artistId)
        {
            if(userId != int.Parse(User.FindFirst("UserProfileId").Value))
                return Unauthorized();

            await Mediator.Send(
                new DeleteUserProfileFollowArtistCommand { ArtistId = artistId, UserProfileId = userId }
            );

            return Ok();
        }
    }
}