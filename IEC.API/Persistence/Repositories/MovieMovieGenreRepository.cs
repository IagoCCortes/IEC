using System.Linq;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;


namespace IEC.API.Persistence.Repositories
{
    public class MovieMovieGenreRepository : GenericRepository<MovieMovieGenre>, IMovieMovieGenreRepository
    {
        public MovieMovieGenreRepository(DataContext context) :base(context) {}

        public void DeleteMovieGenres(int movieId)
        {
            Context.RemoveRange(Context.MovieMovieGenres.Where(m => movieId == m.MovieId));
        }
    }
}