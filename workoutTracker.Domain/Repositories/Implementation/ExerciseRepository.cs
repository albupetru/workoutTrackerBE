using Microsoft.EntityFrameworkCore;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Repositories.Interface;

namespace workoutTracker.Domain.Repositories.Implementation
{
    public class ExerciseRepository : BaseRepository<Exercise, Guid>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDbContext dbcontext)
           : base(dbcontext)
        {
            return;
        }

        public async Task<(IList<Exercise> Exercises, int TotalCount)> GetExercisesAsync(
            string? keyword = null,
            List<Guid>? tagIds = null,
            bool includeUnverified = false,
            Guid? currentUserId = null,
            bool isAdminOrModerator = false,
            int pageNumber = 1,
            int pageSize = 20,
            string sortBy = "Name",
            string sortOrder = "asc")
        {
            var query = _dbContext.Set<Exercise>()
                .AsNoTracking()
                .Include(e => e.ExerciseTags)
                    .ThenInclude(et => et.Tag)
                .Include(e => e.VerifiedBy)
                .AsQueryable();

            if (!isAdminOrModerator || !includeUnverified)
            {
                query = query.Where(e =>
                    e.VerifiedOn != null ||
                    (currentUserId.HasValue && EF.Property<Guid>(e, "CreatedById") == currentUserId.Value));
            }
            // If admin with includeUnverified=true, show all exercises (no filter needed)

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var keywordLower = keyword.ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(keywordLower));
            }

            if (tagIds != null && tagIds.Any())
            {
                query = query.Where(e => e.ExerciseTags.Any(et => tagIds.Contains(et.TagId)));
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            query = sortBy.ToLower() switch
            {
                "name" => sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(e => e.Name)
                    : query.OrderBy(e => e.Name),
                "createdon" => sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(e => EF.Property<DateTimeOffset>(e, "CreatedOn"))
                    : query.OrderBy(e => EF.Property<DateTimeOffset>(e, "CreatedOn")),
                "verifiedon" => sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(e => e.VerifiedOn)
                    : query.OrderBy(e => e.VerifiedOn),
                _ => query.OrderBy(e => e.Name)
            };

            var exercises = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (exercises, totalCount);
        }

        public async Task<Exercise?> GetByIdWithDetailsAsync(Guid id, bool tracking = false)
        {
            IQueryable<Exercise> query = _dbContext.Set<Exercise>();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .Include(e => e.ExerciseTags)
                    .ThenInclude(et => et.Tag)
                .Include(e => e.VerifiedBy)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

