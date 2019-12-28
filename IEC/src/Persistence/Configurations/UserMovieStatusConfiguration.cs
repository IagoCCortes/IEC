using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserMovieStatusConfiguration : IEntityTypeConfiguration<UserMovieStatus>
    {
        public void Configure(EntityTypeBuilder<UserMovieStatus> builder)
        {
            builder.HasMany(us => us.UserMovies)
            .WithOne(um => um.UserMovieStatus).IsRequired();
        }
    }
}