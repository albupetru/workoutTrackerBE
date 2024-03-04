using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Repositories.Common
{
    public abstract class BaseRepository<T, TId> : IBaseRepository<T, TId>
        where T : BaseEntity<T, TId>
       where TId : IEquatable<TId>
    {
        protected ApplicationDbContext _dbContext { get; set; }

        public BaseRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public virtual async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByPredicate = null)
        {
            var query = _dbContext.Set<T>();
            if (orderByPredicate != null)
            {
                return await query
                   .Where(predicate)
                   .OrderBy(orderByPredicate)
                   .ToListAsync() ?? new List<T>();
            }

            return await query
               .Where(predicate)
               .ToListAsync() ?? new List<T>();
        }

        public virtual async Task<EntityEntry<T>> InsertAsync(T entity)
        {
            if (IsEntityDefaultValue(entity))
                throw new ArgumentNullException(nameof(entity));

            return await _dbContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);

            return entity;
        }

        public virtual async Task<T> SingleByIdAsync(TId id)
        {
            var entity = await _dbContext.Set<T>().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            return entity;
        }

        protected bool IsEntityDefaultValue(T entity)
        {
            return EqualityComparer<T>.Default.Equals(entity, default(T));
        }
    }
}
