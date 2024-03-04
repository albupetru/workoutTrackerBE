using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Repositories.Implementation;
using workoutTracker.Domain.Repositories.Interface;

namespace workoutTracker.Domain.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IUserRepository _userRepository;
        private IExerciseRepository _exerciseRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(_dbContext);
            }
        }

        public IExerciseRepository ExerciseRepository
        {
            get
            {
                return _exerciseRepository ??= new ExerciseRepository(_dbContext);
            }
        }
    }
}
