using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IMovieMovieGenreRepository : IGenericRepository<MovieMovieGenre>
    {
         void DeleteMovieGenres(int movieId);
    }
}