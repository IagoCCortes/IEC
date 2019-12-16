using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEC.API.Core.Domain;
using Microsoft.EntityFrameworkCore;
using IEC.API.Core.Repositories;
using IEC.API.Helpers;
using IEC.API.Core.Enums;

namespace IEC.API.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) :base(context) { }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieParams movieParams)
        {
            var movies = Context.Movies;

            if(movieParams.Genres == null)
                return await movies.ToListAsync();

            var genreIds = new List<int>();

            foreach(var genre in movieParams.Genres)
            {
                Enum.TryParse(genre, out MovieGenreEnum movieGenre);
                genreIds.Add((int) movieGenre);
            }
                
            return await movies.Where(m => m.MovieMovieGenres.Any(mg => genreIds.Contains(mg.MovieGenreId)))
                               .Select(m => new Movie {Id = m.Id, Title = m.Title, ReleaseDate = m.ReleaseDate, Runtime= m.Runtime, PosterUrl = m.PosterUrl})
                               .ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await Context.Movies.Include(m => m.MovieMovieGenres)
                                       .Include(m => m.MovieArtists).ThenInclude(ma => ma.Artist)
                                       .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}