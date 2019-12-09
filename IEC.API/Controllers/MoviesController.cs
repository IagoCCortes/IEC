using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Data;
using IEC.API.Dtos;
using IEC.API.Helpers;
using IEC.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;
        public MoviesController(IMovieRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync([FromQuery]MovieParams movieParams)
        {
            var movies = await _repo.GetMoviesAsync(movieParams.genre);

            var moviesToReturn = _mapper.Map<IEnumerable<MovieToReturnDto>>(movies);

            return Ok(moviesToReturn);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            var movie = await _repo.GetMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieToReturn = _mapper.Map<MovieToReturnDto>(movie);

            return Ok(movieToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync(MovieForCreationDto movieForCreationDto)
        {
            var movie = _mapper.Map<Movie>(movieForCreationDto);

            _repo.Add(movie);            

            if(await _repo.SaveAllAsync()) 
            {
                var movieToReturn = _mapper.Map<MovieToReturnDto>(movie);

                foreach(var genre in movieForCreationDto.GenreIds)
                    _repo.Add(new MovieMovieGenre {MovieGenreId = genre, MovieId = movie.Id});

                if(await _repo.SaveAllAsync()) 
                {
                    return CreatedAtRoute("GetMovie", new {id = movie.Id}, movieToReturn);
                }

                throw new Exception("Adding the movie genres failed on save");
            }

            throw new Exception("Adding the movie failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, MovieForUpdateDto movieForUpdateDto)
        {
            var movie = await _repo.GetMovieAsync(id);

            _mapper.Map(movieForUpdateDto, movie);

            _repo.DeleteGenres(id);

            foreach(var genre in movieForUpdateDto.GenreIds)
                _repo.Add(new MovieMovieGenre {MovieId = id, MovieGenreId = genre });

            if(await _repo.SaveAllAsync())
                return NoContent();

            throw new Exception($"Updating movie with {id} failed on save");
        }
    }
}