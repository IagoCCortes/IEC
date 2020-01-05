using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserMovieStatusConfiguration : IEntityTypeConfiguration<UserProfileMovieStatus>
    {
        public void Configure(EntityTypeBuilder<UserProfileMovieStatus> builder)
        {
            builder.HasMany(us => us.UserProfileMovies)
            .WithOne(um => um.UserProfileMovieStatus).IsRequired();
        }
    }
}