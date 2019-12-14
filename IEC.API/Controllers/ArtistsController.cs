using System;
using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Core;
using IEC.API.Core.Domain;
using IEC.API.Dtos.Artist;
using Microsoft.AspNetCore.Mvc;

namespace IEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArtistsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var artists = await _unitOfWork.Artists.GetAllAsync();

            return Ok(artists);
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public async Task<IActionResult> GetArtistAsync(int id)
        {
            var artist = await _unitOfWork.Artists.GetAsync(id);

            if(artist == null)
                return NotFound();

            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> AddArtistAsync(ArtistForCreationDto artistForCreationDto)
        {
            var artist = _mapper.Map<Artist>(artistForCreationDto);

            _unitOfWork.Artists.Add(artist);            

            if(await _unitOfWork.CompleteAsync()) 
            {
                var artistToReturn = _mapper.Map<ArtistToReturnDto>(artist);

                return CreatedAtRoute("GetArtist", new {id = artist.Id}, artistToReturn);
            }

            throw new Exception("Adding the artist failed on save");
        }
    }
}