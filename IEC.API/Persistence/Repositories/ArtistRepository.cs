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
    }
}