using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.DataSeeds;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            //entityTypeBuilder
            //    .HasMany(p => p.UserRoles)
            //    .WithOne(b => b.User);

            var users = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            foreach (var user in UserDataSeed.Data)
            {
                users.Add(new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.GoogleId,

                    CreatedById = Users.AutomaticProcess,
                    CreatedOn = dateTimeOffset,
                    ModifiedById = Users.AutomaticProcess,
                    ModifiedOn = dateTimeOffset,
                });
            }

            entityTypeBuilder.HasData(users);
        }
    }
}
