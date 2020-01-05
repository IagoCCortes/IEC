using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserProfileMovie>
    {
        public void Configure(EntityTypeBuilder<UserProfileMovie> builder)
        {
            builder.HasKey(um => new { um.UserProfileId, um.MovieId });

            builder.HasOne(um => um.Movie).WithMany(m => m.UserProfilesMovie)
                   .HasForeignKey(um => um.MovieId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(um => um.UserProfile).WithMany(u => u.UserProfileMovies)
                .HasForeignKey(um => um.UserProfileId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(um => um.UserProfileMovieStatus)
                .WithMany(us => us.UserProfileMovies).HasForeignKey(um => um.UserProfileMovieStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}