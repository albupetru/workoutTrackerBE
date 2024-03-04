using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public abstract class BaseEntityTypeConfiguration<TBase, TId>
        : IEntityTypeConfiguration<TBase>
        where TBase : BaseEntity<TBase, TId>
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(c => c.Id);
        }
    }
}
