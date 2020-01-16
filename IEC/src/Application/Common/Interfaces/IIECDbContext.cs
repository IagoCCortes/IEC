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
        DbSet<UserProfile> UserProfiles { get; set; }
        DbSet<UserProfileFollowArtist> UserProfileFollowArtists { get; set; }
        DbSet<UserProfileMovie> UserProfileMovies { get; set; }
        DbSet<UserProfileMovieStatus> UserProfileMovieStatuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}