using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetArtistAsync(int id);
    }
}