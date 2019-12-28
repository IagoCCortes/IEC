using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            builder.HasKey(um => new { um.UserId, um.MovieId });

            builder.HasOne(um => um.Movie).WithMany(m => m.UsersMovie)
                   .HasForeignKey(um => um.MovieId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(um => um.User).WithMany(u => u.UserMovies)
                .HasForeignKey(um => um.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(um => um.UserMovieStatus)
                .WithMany(us => us.UserMovies).HasForeignKey(um => um.UserMovieStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}