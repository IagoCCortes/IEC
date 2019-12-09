using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Data
{
    public class MovieRepository : GenericRepository, IMovieRepository
    {
        public MovieRepository(DataContext context) :base(context) { }

        public void DeleteGenres(int movieId)
        {
            Context.RemoveRange(Context.MovieMovieGenres.Where(m => movieId == m.MovieId));
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(IEnumerable<int> genreIds = null)
        {
            if(genreIds == null)
                return await Context.Movies.Include(m => m.MovieMovieGenres).ThenInclude(mg => mg.MovieGenre).ToListAsync();

            return await Context.Movies.Include(m => m.MovieMovieGenres)
                                        .ThenInclude(mg => mg.MovieGenre)
                                        .Where(m => m.MovieMovieGenres.Any(mg => genreIds.Contains(mg.MovieGenreId)))
                                        .ToListAsync();
            
            // return await Context.Movies
            //     .FromSqlRaw($"SELECT M.* FROM MOVIES M LEFT JOIN MOVIEMOVIEGENRES MG ON M.ID = MG.MOVIEID LEFT JOIN MOVIEGENRES G on MG.MOVIEGENREID = G.ID WHERE G.ID IN ({string.Join(',', genreIds)})")
            //     .Include(m => m.MovieMovieGenres).ThenInclude(mg => mg.MovieGenre).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await Context.Movies.Include(m => m.MovieMovieGenres).ThenInclude(mg => mg.MovieGenre).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}