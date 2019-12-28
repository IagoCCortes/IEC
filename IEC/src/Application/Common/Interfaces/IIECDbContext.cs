using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IIECDbContext
    {
        DbSet<Artist> Artists { get; set; }
        DbSet<MovieArtist> MovieArtists { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
        DbSet<MovieMovieGenre> MovieMovieGenres { get; set; }
        DbSet<MovieRole> MovieRoles { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}