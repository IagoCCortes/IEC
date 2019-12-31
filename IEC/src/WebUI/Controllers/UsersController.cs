using System.Threading.Tasks;
using Application.Users.Queries.GetUserDetail;
using Application.Users.Queries.GetUserList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ListUsersAsync(int id)
        {
            var user = await Mediator.Send(new GetUserListQuery());

            return Ok(user);
        }        

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetUserDetails")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await Mediator.Send(new GetUserDetailQuery { Id = id});

            return Ok(user);
        }
    }
}