using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;

namespace workoutTracker.Domain.Repositories.Interface
{
    public interface ITagRepository : IBaseRepository<Tag, Guid>
    {
        Task<IList<Tag>> GetAllOrderedByNameAsync();
        Task<IList<Tag>> GetByTypeAsync(TagType type);
        Task<IList<Tag>> GetAllWithParentsAsync();
    }
}
