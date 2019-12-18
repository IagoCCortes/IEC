using System.Threading.Tasks;
using IEC.API.Core;
using IEC.API.Core.Repositories;
using IEC.API.Persistence.Repositories;

namespace IEC.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Artists = new ArtistRepository(_context);
            MovieMovieGenres = new MovieMovieGenreRepository(_context);
            MovieArtists = new MovieArtistRepository(_context);
            Auth = new AuthRepository(_context);
            Users = new UserRepository(_context);
        }

        public IMovieRepository Movies { get; private set; }
        public IArtistRepository Artists { get; private set; }
        public IMovieMovieGenreRepository MovieMovieGenres { get; set; }
        public IMovieArtistRepository MovieArtists { get; set; }
        public IAuthRepository Auth { get; set; }
        public IUserRepository Users { get; set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}