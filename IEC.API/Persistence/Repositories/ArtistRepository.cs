using System;
using System.Collections.Generic;
using System.Linq;
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
            var artists = Context.Artists;

            return await artists.Select(a => new Artist {Id = a.Id, ArtistName = a.ArtistName, Birthdate = a.Birthdate, Birthplace = a.Birthplace, PictureUrl = a.PictureUrl})
                                .ToListAsync();

            // Func<DateTime?, DateTime> BirthDate = (birthDate => { return (birthDate ?? DateTime.Now);});
        }

        public async Task<object> GetArtistAsync(int id)
        {
            return await Context.Artists.Select(a => new{  Id = a.Id,  ArtistName = a.ArtistName,
                               RealName = a.RealName, Birthdate = a.Birthdate,
                               Birthplace = a.Birthplace, Height = a.Height,
                               Bio = a.Bio, 
                               Movies = new {MovieId = a.MoviesArtist.Select(ma => ma.MovieId), 
                                             MovieTitle = a.MoviesArtist.Select(ma => ma.Movie.Title),
                                             RoleId = a.MoviesArtist.Select(ma => ma.RoleId)}})
                    .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}