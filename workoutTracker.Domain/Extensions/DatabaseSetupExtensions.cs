using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using workoutTracker.Domain.DatabaseContext;

namespace workoutTracker.Domain.Extensions
{
    public static class DatabaseSetupExtensions
    {
        public static void RegisterSqliteDatabaseContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Empty database connection string!");
            }

            services
                .AddDbContext<ApplicationDbContext>((provider, options) =>
                {
                    options.UseSqlite(connectionString);
                });
        }
    }
}
