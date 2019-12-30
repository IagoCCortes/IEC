using System.Threading.Tasks;
using Application.Users.Queries.GetUserDetail;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("{id}", Name = "GetUserDetails")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await Mediator.Send(new GetUserDetailQuery { Id = id});

            return Ok(user);
        }
    }
}