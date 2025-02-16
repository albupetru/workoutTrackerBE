using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.EntityTypeConfigurations;
using workoutTracker.Domain.Extensions;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Services.Interface;

namespace workoutTracker.Domain.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IUserSession _userSession;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _userSession = this.GetService<IUserSession>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureShadowProperties();
            modelBuilder.ExcludeSoftDeletedEntitiesGlobally();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
        }

        public override int SaveChanges()
        {
            ChangeTracker.ApplyAuditInfoToChanges(_userSession);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.ApplyAuditInfoToChanges(_userSession);
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }
    }
}
