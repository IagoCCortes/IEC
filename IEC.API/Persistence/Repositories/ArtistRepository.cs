using System.Collections.Generic;
using System.Threading.Tasks;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Persistence.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext context) : base(context) {}
        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            return await Context.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtistAsync(int id)
        {
            return await Context.Artists.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}