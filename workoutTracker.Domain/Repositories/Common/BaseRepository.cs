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

        public virtual async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByPredicate, List<Expression<Func<T, object>>> include)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (include != null)
            {
                foreach (Expression<Func<T, object>> expr in include)
                {
                    query = query.Include(expr);
                }
            }
            query = query.Where(predicate);

            if (orderByPredicate != null)
            {
                query = query.OrderBy(orderByPredicate);
            }

            return await query
                .ToListAsync() ?? new List<T>();
        }

        public virtual async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByPredicate, Func<IQueryable<T>, IQueryable<T>> configureIncludes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (configureIncludes != null)
            {
                query = configureIncludes(query);
            }
            
            query = query.Where(predicate);

            if (orderByPredicate != null)
            {
                query = query.OrderBy(orderByPredicate);
            }

            return await query.ToListAsync() ?? new List<T>();
        }

        public virtual async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByPredicate, List<string> include)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (include != null)
            {
                foreach (string expr in include)
                {
                    query = query.Include(expr);
                }
            }
            query = query.Where(predicate);

            if (orderByPredicate != null)
            {
                query = query.OrderBy(orderByPredicate);
            }

            return await query
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

        public virtual void Remove(T entity)
        {
            if (IsEntityDefaultValue(entity))
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Remove(entity);
        }

        protected bool IsEntityDefaultValue(T entity)
        {
            return EqualityComparer<T>.Default.Equals(entity, default(T));
        }
    }
}
