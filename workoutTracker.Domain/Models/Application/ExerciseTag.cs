using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Models.Application
{
    public class ExerciseTag
    {
        public Guid ExerciseId { get; set; }

        public Guid TagId { get; set; }

        public Exercise Exercise { get; set; }
        public Tag Tag { get; set; }
    }
}
