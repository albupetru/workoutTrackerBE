using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using workoutTracker.Domain.Models.Common;
using workoutTracker.Domain.Services.Interface;

namespace workoutTracker.Domain.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ApplyAuditInfoToChanges(this ChangeTracker changeTracker, IUserSession userSession)
        {
            changeTracker.DetectChanges();

            var timestamp = DateTimeOffset.Now;

            foreach (var entry in changeTracker.Entries())
            {
                if (entry.Entity is IAuditableEntity)
                {
                    if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                    {
                        entry.Property("ModifiedOn").CurrentValue = timestamp;
                        entry.Property("ModifiedById").CurrentValue = userSession.UserId;
                    }

                    if (entry.State == EntityState.Added)
                    {
                        if (entry.Property("ModifiedOn").CurrentValue?.ToString() == DateTimeOffset.MinValue.ToString() || entry.Property("ModifiedOn").CurrentValue == null)
                        {
                            entry.Property("ModifiedOn").CurrentValue = timestamp;
                        }
                        if (entry.Property("ModifiedById").CurrentValue?.ToString() == (Guid.Empty).ToString() || entry.Property("ModifiedById").CurrentValue == null)
                        {
                            entry.Property("ModifiedById").CurrentValue = userSession.UserId;
                        }


                        if (entry.Property("CreatedOn").CurrentValue?.ToString() == DateTimeOffset.MinValue.ToString() || entry.Property("CreatedOn").CurrentValue == null)
                        {
                            entry.Property("CreatedOn").CurrentValue = timestamp;
                        }
                        if (entry.Property("CreatedById").CurrentValue?.ToString() == (Guid.Empty).ToString() || entry.Property("CreatedById").CurrentValue == null)
                        {
                            entry.Property("CreatedById").CurrentValue = userSession.UserId;
                        }
                    }

                    if (entry.State == EntityState.Deleted && entry.Entity is ISoftDeletable)
                    {
                        entry.State = EntityState.Modified;
                        entry.Property("DeletedOn").CurrentValue = timestamp;
                        entry.Property("DeletedById").CurrentValue = userSession.UserId;
                        entry.Property("ModifiedOn").CurrentValue = timestamp;
                        entry.Property("ModifiedById").CurrentValue = userSession.UserId;
                    }
                }
            }
        }
    }
}
