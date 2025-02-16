using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.ViewModels
{
    public class PaginatedEntityViewModel<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int Total{ get; set; }
    }
}
