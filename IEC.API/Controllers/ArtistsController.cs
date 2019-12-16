using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Core;
using IEC.API.Core.Domain;
using IEC.API.Dtos.Artist;
using IEC.API.Helpers;
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
            var artists = await _unitOfWork.Artists.GetArtistsAsync();

            var artistListToReturn = _mapper.Map<IEnumerable<ArtistListToReturn>>(artists);

            return Ok(artistListToReturn);
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public async Task<IActionResult> GetArtistAsync(int id)
        {
            var artist = await _unitOfWork.Artists.GetArtistAsync(id);

            if(artist == null)
                return NotFound();

            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> AddArtistAsync(ArtistForCreationDto artistForCreationDto)
        {
            var artist = _mapper.Map<Artist>(artistForCreationDto);

            _unitOfWork.Artists.Add(artist);            

            if(await _unitOfWork.CompleteAsync() > 0) 
            {
                var artistToReturn = _mapper.Map<ArtistDetailToReturnDto>(artist);

                return CreatedAtRoute("GetArtist", new {id = artist.Id}, artistToReturn);
            }

            throw new Exception("Adding the artist failed on save");
        }
    }
}