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
    }
}
