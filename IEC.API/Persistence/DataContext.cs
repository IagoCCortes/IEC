using IEC.API.Core.Domain;
using IEC.API.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieMovieGenre> MovieMovieGenres { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<MovieArtist> MovieArtists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());

            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());

            modelBuilder.ApplyConfiguration(new MovieMovieGenreConfiguration());

            modelBuilder.ApplyConfiguration(new MovieArtistConfiguration());

            modelBuilder.ApplyConfiguration(new MovieRoleConfiguration());
        }
    }
}