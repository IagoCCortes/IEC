using System.Threading.Tasks;
using Application.SearchAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SearchController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("{searchIn}/{searchStr}")]
        public async Task<ActionResult<SearchAllVM>> SearchAll(string searchIn, string searchStr)
        {
            var results = await Mediator.Send(new GetSearchAllQuery{SearchIn = searchIn, ValueToSearch = searchStr});

            return Ok(results);
        }
    }
}