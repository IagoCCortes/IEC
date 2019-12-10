using IEC.API.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IEC.API.Persistence.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(a => a.ArtistName).IsRequired();

            builder.Property(a => a.Bio).IsRequired();
        }
    }
}