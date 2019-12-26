using System;
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
    [AllowAnonymous]
    public class ArtistsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ArtistListVM>> GetArtistsAsync()
        {
            var artists = await Mediator.Send(new GetArtistListQuery());

            return Ok(artists);
        }

        [HttpGet("{id}", Name = "GetArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistDetailVM>> GetArtistAsync(int id)
        {
            var artist = await Mediator.Send(new GetArtistDetailQuery { Id = id });

            return Ok(artist);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddArtistAsync([FromBody]CreateArtistCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArtistAsync([FromBody]UpdateArtistCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArtistAsync(int id)
        {
            await Mediator.Send(new DeleteArtistCommand { Id = id});

            return NoContent();
        }
    }
}