using IEC.API.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IEC.API.Persistence.EntityConfigurations
{
    public class MovieRoleConfiguration : IEntityTypeConfiguration<MovieRole>
    {
        public void Configure(EntityTypeBuilder<MovieRole> builder)
        {
            builder.Property(m => m.Role).IsRequired();
        }
    }
}