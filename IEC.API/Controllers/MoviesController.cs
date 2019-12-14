using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Helpers;
using IEC.API.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using IEC.API.Core;
using IEC.API.Core.Repositories;
using IEC.API.Core.Enums;
using IEC.API.Dtos.Movie;

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
            var movies = await _unitOfWork.Movies.GetMoviesAsync(movieParams);

            var moviesToReturn = _mapper.Map<IEnumerable<MovieListToReturnDto>>(movies);

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

            var movieToReturn = _mapper.Map<MovieDetailToReturnDto>(movie);

            return Ok(movieToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync(MovieForCreationDto movieForCreationDto)
        {
            var movie = _mapper.Map<Movie>(movieForCreationDto);

            _unitOfWork.Movies.Add(movie);            

            if(await _unitOfWork.CompleteAsync()) 
            {
                var movieToReturn = _mapper.Map<MovieListToReturnDto>(movie);

                return CreatedAtRoute("GetMovie", new {id = movie.Id}, movieToReturn);
            }

            throw new Exception("Adding the movie failed on save");
        }

        [HttpPost("{id}/Genres")]
        public async Task<IActionResult> AddMovieGenres(int id, List<int> genres)
        {
            _unitOfWork.MovieMovieGenres.DeleteMovieGenres(id);

            foreach(var genre in genres)
                _unitOfWork.MovieMovieGenres.Add(new MovieMovieGenre {MovieId = id, MovieGenreId = genre });

            if(await _unitOfWork.CompleteAsync())
                return NoContent();

            throw new Exception($"Adding genres failed on save");
        }

        [HttpPost("{id}/Artists")]
        public async Task<IActionResult> AddMovieArtists(int id, MovieArtistForCreateDto movieArtistForCreateDto)
        {
            _unitOfWork.MovieArtists.DeleteMovieArtists(id);

            var artists = _unitOfWork.MovieArtists;

            Action<IMovieArtistRepository, List<int>, int> AddArtistsToContext =
                ((repository, artistIds, role) =>
                {
                    foreach (var aId in artistIds) repository.Add(new MovieArtist { MovieId = id, ArtistId = aId, RoleId = role });
                });

            AddArtistsToContext(artists, movieArtistForCreateDto.ActorIds, (int)MovieRoleEnum.Actor);
            AddArtistsToContext(artists, movieArtistForCreateDto.DirectorIds, (int)MovieRoleEnum.Director);
            AddArtistsToContext(artists, movieArtistForCreateDto.WriterIds, (int)MovieRoleEnum.Writer);
            AddArtistsToContext(artists, movieArtistForCreateDto.ProducerIds, (int)MovieRoleEnum.Producer);

            if(await _unitOfWork.CompleteAsync())
                return NoContent();

            throw new Exception($"Adding artists failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, MovieForUpdateDto movieForUpdateDto)
        {
            var movie = await _unitOfWork.Movies.GetMovieAsync(id);

            _mapper.Map(movieForUpdateDto, movie);

            if(await _unitOfWork.CompleteAsync())
                return NoContent();

            throw new Exception($"Updating movie with {id} failed on save");
        }
    }
}
