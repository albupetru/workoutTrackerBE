using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Repositories.Common
{
    public interface IBaseRepository<T, TId>
        where T : class, IBaseEntity<T, TId>
    {
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleByIdAsync(TId id);
        Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByPredicate = null);
        Task<EntityEntry<T>> InsertAsync(T entity);
    }
}
