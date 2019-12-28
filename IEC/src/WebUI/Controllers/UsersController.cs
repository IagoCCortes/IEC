using System.Threading.Tasks;
using Application.Users.Commands.CreateUserMovie;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : BaseController
    {
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUserAsync(int id)
        // {
        //     var user = await _unitOfWork.Users.GetAsync(id);

        //     return Ok(user);
        // }

        [HttpPost]
        public async Task<IActionResult> AddMovieToUserAsync(CreateUserMovieCommand command)
        {
            //var x = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Mediator.Send(command);

            return Ok();
        }
    }
}