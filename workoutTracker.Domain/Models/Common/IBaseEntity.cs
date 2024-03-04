using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Models.Common
{
    public interface IBaseEntity<T, TId> : IEquatable<T>
        where T : IBaseEntity<T, TId>
    {
        TId Id
        {
            get;
            set;
        }
    }
}
