using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieArtistConfiguration : IEntityTypeConfiguration<MovieArtist>
    {
        public void Configure(EntityTypeBuilder<MovieArtist> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.ArtistId, mg.RoleId });  

            builder.HasOne(mg => mg.Movie).WithMany(m => m.MovieArtists)
                .HasForeignKey(mg => mg.MovieId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mg => mg.Artist).WithMany(g => g.MoviesArtist)
                .HasForeignKey(bc => bc.ArtistId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mg => mg.Role).WithMany(g => g.MovieArtists)
                .HasForeignKey(bc => bc.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}