using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieRoleConfiguration : IEntityTypeConfiguration<MovieRole>
    {
        public void Configure(EntityTypeBuilder<MovieRole> builder)
        {
            builder.Property(m => m.Role).IsRequired();
        }
    }
}