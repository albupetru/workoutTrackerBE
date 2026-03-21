using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class RoleEntityTypeConfiguration : BaseEntityTypeConfiguration<Role, Guid>
    {
        public override void Configure(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .HasMany(p => p.UserRoles)
                .WithOne(b => b.Role);
        }
    }
}
