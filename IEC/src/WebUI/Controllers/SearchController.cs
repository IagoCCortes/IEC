using System.Threading.Tasks;
using Application.SearchAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SearchController : BaseController
    {
        // private readonly CloudinaryService _cloudinaryService;
        // public MoviesController(CloudinaryService cloudinaryService)
        // {
        //     _cloudinaryService = cloudinaryService;
        // }

        [AllowAnonymous]
        [HttpGet("{searchStr}")]
        public async Task<ActionResult<SearchAllVM>> SearchAll(string searchStr)
        {
            var results = await Mediator.Send(new GetSearchAllQuery{ValueToSearch = searchStr});

            return Ok(results);
        }
    }
}