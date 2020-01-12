using System.Threading.Tasks;
using Application.Artists.Commands.CreateArtist;
using Application.Artists.Commands.DeleteArtist;
using Application.Artists.Commands.UpdateArtist;
using Application.Artists.Queries.GetArtistDetail;
using Application.Artists.Queries.GetArtistList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ArtistsController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ArtistListVM>> ListArtistsAsync()
        {
            var artists = await Mediator.Send(new GetArtistListQuery());
            
            return Ok(artists);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistDetailVM>> GetArtistAsync(int id)
        {
            var artist = await Mediator.Send(new GetArtistDetailQuery { Id = id });

            return Ok(artist);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddArtistAsync([FromBody]CreateArtistCommand command)
        {
            var artist = await Mediator.Send(command);

            return CreatedAtRoute("GetArtist", new {controller = "Artists", id = artist.Id}, artist);;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArtistAsync(int id, [FromBody]UpdateArtistCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArtistAsync(int id)
        {
            await Mediator.Send(new DeleteArtistCommand { Id = id});

            return NoContent();
        }
    }
}