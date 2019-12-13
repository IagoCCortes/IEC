using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEC.API.Core.Domain;
using Microsoft.EntityFrameworkCore;
using IEC.API.Core.Repositories;
using IEC.API.Helpers;

namespace IEC.API.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) :base(context) { }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(MovieParams movieParams)
        {
            if(movieParams.genreIds == null)
                return await Context.Movies.Include(m => m.MovieMovieGenres).ThenInclude(mg => mg.MovieGenre).ToListAsync();

            return await Context.Movies.Include(m => m.MovieMovieGenres)
                                        .ThenInclude(mg => mg.MovieGenre)
                                        .Where(m => m.MovieMovieGenres.Any(mg => movieParams.genreIds.Contains(mg.MovieGenreId)))
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