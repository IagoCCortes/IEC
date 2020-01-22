using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(a => a.ArtistName).IsRequired();
            builder.Property(a => a.StringIdentifier).HasColumnName("ArtistName");
            // builder.Ignore(a => a.StringIdentifier);
        }
    }
}