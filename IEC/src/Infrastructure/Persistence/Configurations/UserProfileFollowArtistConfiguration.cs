using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserProfileFollowArtistConfiguration : IEntityTypeConfiguration<UserProfileFollowArtist>
    {
        public void Configure(EntityTypeBuilder<UserProfileFollowArtist> builder)
        {
            builder.HasKey(ua => new { ua.UserProfileId, ua.ArtistId });

            builder.HasOne(ua => ua.Artist).WithMany(a => a.UserProfilesFollowArtist)
                   .HasForeignKey(ua => ua.ArtistId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua => ua.UserProfile).WithMany(u => u.UserProfileFollowArtists)
                .HasForeignKey(ua => ua.UserProfileId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}