using System.Threading.Tasks;
using Application.UserProfiles.Queries.GetUserProfileDetail;
using Application.UserProfiles.Queries.GetUserProfileList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ListUserProfilesAsync(int id)
        {
            var user = await Mediator.Send(new GetUserProfileListQuery());

            return Ok(user);
        }        

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUserProfilesAsync(int id)
        {
            var user = await Mediator.Send(new GetUserProfileDetailQuery { Id = id});

            return Ok(user);
        }
    }
}