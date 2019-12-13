using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Core.Domain;
using IEC.API.Helpers;

namespace IEC.API.Core.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(MovieParams movieParams = null);
        Task<Movie> GetMovieAsync(int id);
    }
}