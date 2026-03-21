using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            entityTypeBuilder
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entityTypeBuilder
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
