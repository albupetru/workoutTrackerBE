using Microsoft.EntityFrameworkCore;
using System.Reflection;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var tp in modelBuilder.Model.GetEntityTypes())
            {
                var t = tp.ClrType;

                // set auditing properties
                if (typeof(IAuditableEntity).IsAssignableFrom(t))
                {
                    var method = SetAuditingShadowPropertiesMethodInfo.MakeGenericMethod(t);
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }

                // set soft delete property
                if (typeof(ISoftDeletable).IsAssignableFrom(t))
                {
                    var method = SetIsDeletedShadowPropertyMethodInfo.MakeGenericMethod(t);
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }
            }
        }

        public static void SetAuditingShadowProperties<T>(ModelBuilder builder) where T : class, IAuditableEntity
        {
            // define shadow properties
            builder.Entity<T>().Property<DateTimeOffset>("CreatedOn").HasDefaultValueSql("SYSDATETIMEOFFSET()");
            builder.Entity<T>().Property<DateTimeOffset>("ModifiedOn").HasDefaultValueSql("SYSDATETIMEOFFSET()");
            builder.Entity<T>().Property<Guid>("CreatedById");
            builder.Entity<T>().Property<Guid>("ModifiedById");
        }

        public static void SetIsDeletedShadowProperty<T>(ModelBuilder builder) where T : class, ISoftDeletable
        {
            // define shadow property
            builder.Entity<T>().Property<DateTimeOffset?>("DeletedOn");
            builder.Entity<T>().Property<Guid?>("DeletedById");
        }

        public static void ExcludeSoftDeletedEntitiesGlobally(this ModelBuilder modelBuilder)
        {
            foreach (var tp in modelBuilder.Model.GetEntityTypes())
            {
                var type = tp.ClrType;

                if (typeof(ISoftDeletable).IsAssignableFrom(type))
                {
                    // softdeletable
                    var method = ExcludeSoftDeletedEntitiesInQueriesMethodInfo.MakeGenericMethod(type);
                    // todo: might fail
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }
            }
        }

        public static void ExcludeSoftDeletedEntitiesInQueries<T>(ModelBuilder builder) where T : class, ISoftDeletable
        {
            builder.Entity<T>().HasQueryFilter(item => EF.Property<Guid>(item, "DeletedById") == null);
        }

        private static readonly MethodInfo SetAuditingShadowPropertiesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetAuditingShadowProperties");

        private static readonly MethodInfo SetIsDeletedShadowPropertyMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetIsDeletedShadowProperty");

        private static readonly MethodInfo ExcludeSoftDeletedEntitiesInQueriesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "ExcludeSoftDeletedEntitiesInQueries");
    }
}
