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
    }
}
