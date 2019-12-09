using IEC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IEC.API.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieMovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.MovieGenreId });  
            modelBuilder.Entity<MovieMovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieMovieGenres)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Restrict);  
            modelBuilder.Entity<MovieMovieGenre>()
                .HasOne(mg => mg.MovieGenre)
                .WithMany(g => g.MovieMovieGenres)
                .HasForeignKey(bc => bc.MovieGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovieArtist>()
                .HasKey(mg => new { mg.MovieId, mg.ArtistId });  
            modelBuilder.Entity<MovieArtist>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieArtists)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Restrict);  
            modelBuilder.Entity<MovieArtist>()
                .HasOne(mg => mg.Artist)
                .WithMany(g => g.MoviesArtist)
                .HasForeignKey(bc => bc.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}