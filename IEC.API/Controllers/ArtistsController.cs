using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace IEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _repo;
        private readonly IMapper _mapper;
        public ArtistsController(IArtistRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var artists = await _repo.GetArtistsAsync();

            return Ok(artists);
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public async Task<IActionResult> GetArtistAsync(int id)
        {
            var artist = await _repo.GetArtistAsync(id);

            if(artist == null)
                return NotFound();

            return Ok(artist);
        }
    }
}