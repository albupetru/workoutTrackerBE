using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Models.Common
{
    public abstract class BaseEntity<T, TId> : IBaseEntity<T, TId>
        where T : BaseEntity<T, TId>
    {
        private int? mCachedHashCode;

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            if (this.IsTransient() && other.IsTransient())
                return ReferenceEquals(this, other);

            return EqualityComparer<TId>.Default.Equals(this.Id, other.Id);
        }

        public override int GetHashCode()
        {
            if (mCachedHashCode.HasValue)
                return mCachedHashCode.Value;

            if (IsTransient())
                mCachedHashCode = base.GetHashCode();
            else
                mCachedHashCode = Id.GetHashCode();

            return mCachedHashCode.Value;
        }

        public virtual bool IsTransient()
        {
            return EqualityComparer<TId>.Default.Equals(Id, default(TId));
        }

        public virtual TId Id
        {
            get;
            set;
        }
    }
}
