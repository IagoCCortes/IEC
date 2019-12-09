using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Models;

namespace IEC.API.Data
{
    public interface IArtistRepository : IGenericRepository
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetArtistAsync(int id);
    }
}