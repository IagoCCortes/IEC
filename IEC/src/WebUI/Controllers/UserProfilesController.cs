using System.Threading.Tasks;
using Application.UserProfiles.Queries.GetUserProfileDetail;
using Application.UserProfiles.Queries.GetUserProfileList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserProfilesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ListUserProfilesAsync()
        {
            var user = await Mediator.Send(new GetUserProfileListQuery());

            return Ok(user);
        }        

        [AllowAnonymous]
        [HttpGet("{userName}", Name = "GetUser")]
        public async Task<IActionResult> GetUserProfilesAsync(string userName)
        {
            var user = await Mediator.Send(new GetUserProfileDetailQuery { UserName = userName});

            return Ok(user);
        }
    }
}