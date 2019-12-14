using IEC.API.Core.Domain;

namespace IEC.API.Core.Repositories
{
    public interface IMovieArtistRepository : IGenericRepository<MovieArtist>
    {
        void DeleteMovieArtists(int movieId);
    }
}