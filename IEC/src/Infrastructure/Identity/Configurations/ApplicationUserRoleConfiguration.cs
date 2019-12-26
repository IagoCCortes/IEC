using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasKey(aur => new { aur.UserId, aur.RoleId });

            builder.HasOne(aur => aur.User).WithMany(u => u.UserRoles)
                   .HasForeignKey(aur => aur.UserId).IsRequired();

            builder.HasOne(aur => aur.Role).WithMany(r => r.UserRoles)
                   .HasForeignKey(aur => aur.RoleId).IsRequired();
        }
    }
}