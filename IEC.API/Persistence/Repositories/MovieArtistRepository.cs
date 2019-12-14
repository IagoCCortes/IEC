using System.Linq;
using IEC.API.Core.Domain;
using IEC.API.Core.Repositories;

namespace IEC.API.Persistence.Repositories
{
    public class MovieArtistRepository : GenericRepository<MovieArtist>, IMovieArtistRepository
    {
        public MovieArtistRepository(DataContext context) :base(context) {}

        public void DeleteMovieArtists(int movieId)
        {
            Context.RemoveRange(Context.MovieArtists.Where(m => movieId == m.MovieId));
        }
    }
}