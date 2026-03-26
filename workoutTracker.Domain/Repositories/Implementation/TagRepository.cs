using Microsoft.EntityFrameworkCore;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Repositories.Interface;

namespace workoutTracker.Domain.Repositories.Implementation
{
    public class TagRepository : BaseRepository<Tag, Guid>, ITagRepository
    {
        public TagRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IList<Tag>> GetAllOrderedByNameAsync()
        {
            return await _dbContext.Set<Tag>()
                .AsNoTracking()
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<IList<Tag>> GetByTypeAsync(TagType type)
        {
            return await _dbContext.Set<Tag>()
                .AsNoTracking()
                .Where(t => t.TagType == type)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<IList<Tag>> GetAllWithParentsAsync()
        {
            return await _dbContext.Set<Tag>()
                .AsNoTracking()
                .Include(t => t.TagParent)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }
    }
}
