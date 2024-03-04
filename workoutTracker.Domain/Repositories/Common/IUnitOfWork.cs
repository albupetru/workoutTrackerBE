using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Repositories.Interface;

namespace workoutTracker.Domain.Repositories.Common
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
        IUserRepository UserRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
    }   
}
