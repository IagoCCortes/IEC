using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Models;

namespace IEC.API.Data
{
    public interface IMovieRepository : IGenericRepository
    {
        void DeleteGenres(int movieId);
        Task<IEnumerable<Movie>> GetMoviesAsync(IEnumerable<int> genreIds = null);
        Task<Movie> GetMovieAsync(int id);
    }
}