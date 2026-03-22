using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;

namespace workoutTracker.Domain.Repositories.Interface
{
    public interface IExerciseRepository : IBaseRepository<Exercise, Guid>
    {
        Task<(IList<Exercise> Exercises, int TotalCount)> GetExercisesAsync(
            string? keyword = null,
            List<Guid>? tagIds = null,
            bool includeUnverified = false,
            Guid? currentUserId = null,
            bool isAdminOrModerator = false,
            int pageNumber = 1,
            int pageSize = 20,
            string sortBy = "Name",
            string sortOrder = "asc");

        Task<Exercise?> GetByIdWithDetailsAsync(Guid id);
    }
}

