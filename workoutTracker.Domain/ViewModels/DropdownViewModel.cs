using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.ViewModels
{
    public class DropdownViewModel<T>
    {
        public Guid Value { get; set; }
        public T Name { get; set; }
    }
}
