using System.Collections.Generic;
using System.Linq;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;

namespace IEC.API.Persistence.Repositories
{
    public class MovieArtistRepository : GenericRepository<MovieArtist>, IMovieArtistRepository
    {
        public MovieArtistRepository(DataContext context) :base(context) {}

        public void DeleteMovieArtists(int movieId, List<int> artistIds, List<int> roleIds)
        {
            // Context.RemoveRange(Context.MovieArtists.Where(m => movieId == m.MovieId));
            for(var i = 0; i < artistIds.Count; i++) 
                Context.RemoveRange(Context.MovieArtists.Where(m => movieId == m.MovieId && artistIds[i] == m.ArtistId && roleIds[i] == m.RoleId));
        }
    }
}