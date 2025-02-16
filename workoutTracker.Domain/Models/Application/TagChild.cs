using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Models.Application
{
    public class TagChild 
    {
        public Guid ParentId { get; set; }
        public Guid ChildId { get; set; }

        public Tag Parent { get; set; }
        public Tag Child { get; set; }
    }
}
