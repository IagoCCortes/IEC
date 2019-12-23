using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieMovieGenreConfiguration : IEntityTypeConfiguration<MovieMovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieMovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.MovieGenreId });

            builder.HasOne(mg => mg.Movie).WithMany(m => m.MovieMovieGenres)
                   .HasForeignKey(mg => mg.MovieId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mg => mg.MovieGenre).WithMany(g => g.MovieMovieGenres)
                .HasForeignKey(bc => bc.MovieGenreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}