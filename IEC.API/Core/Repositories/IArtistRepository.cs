using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Core.Domain;
using IEC.API.Helpers;

namespace IEC.API.Core.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<object> GetArtistAsync(int id);
    }
}