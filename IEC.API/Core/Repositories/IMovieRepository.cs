using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(IEnumerable<int> genreIds = null);
        Task<Movie> GetMovieAsync(int id);
    }
}