using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.DataSeeds;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class TagEntityTypeConfiguration : BaseEntityTypeConfiguration<Tag, Guid>
    {
        public override void Configure(EntityTypeBuilder<Tag> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .HasMany(p => p.ExerciseTags)
                .WithOne(b => b.Tag);

            entityTypeBuilder
                .HasMany(p => p.TagChildren)
                .WithOne(b => b.Parent);

            entityTypeBuilder
                .HasOne(p => p.TagParent)
                .WithOne(b => b.Child);

            var tags = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            foreach (var tag in TagDataSeed.Data)
            {
                tags.Add(new
                {
                    tag.Id,
                    tag.Name,

                    CreatedById = Users.AutomaticProcess,
                    CreatedOn = dateTimeOffset,
                    ModifiedById = Users.AutomaticProcess,
                    ModifiedOn = dateTimeOffset,
                });
            }

            entityTypeBuilder.HasData(tags);
        }
    }
}
