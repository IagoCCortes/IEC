using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Core.Repositories;
using IEC.API.Dtos;
using IEC.API.Helpers;
using IEC.API.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using IEC.API.Core;

namespace IEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync([FromQuery]MovieParams movieParams)
        {
            var movies = await _unitOfWork.Movies.GetMoviesAsync(movieParams.genre);

            var moviesToReturn = _mapper.Map<IEnumerable<MovieToReturnDto>>(movies);

            return Ok(moviesToReturn);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetMovieAsync(id);

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

            _unitOfWork.Movies.Add(movie);            

            if(await _unitOfWork.CompleteAsync()) 
            {
                var movieToReturn = _mapper.Map<MovieToReturnDto>(movie);

                foreach(var genre in movieForCreationDto.GenreIds)
                    _unitOfWork.MovieMovieGenres.Add(new MovieMovieGenre {MovieGenreId = genre, MovieId = movie.Id});

                if(await _unitOfWork.CompleteAsync()) 
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
            var movie = await _unitOfWork.Movies.GetMovieAsync(id);

            _mapper.Map(movieForUpdateDto, movie);

            _unitOfWork.MovieMovieGenres.DeleteGenres(id);

            foreach(var genre in movieForUpdateDto.GenreIds)
                _unitOfWork.MovieMovieGenres.Add(new MovieMovieGenre {MovieId = id, MovieGenreId = genre });

            if(await _unitOfWork.CompleteAsync())
                return NoContent();

            throw new Exception($"Updating movie with {id} failed on save");
        }
    }
}