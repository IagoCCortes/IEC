using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Data
{
    public class ArtistRepository : GenericRepository, IArtistRepository
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