using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    public static class ExeciseDataSeed
    {
        public static IList<Exercise> Data = new List<Exercise>()
        {
            new Exercise()
            {
                Id = Exercises.BenchPress,
                Name = "Bench Press"
            },
            new Exercise()
            {
                Id = Exercises.Squat,
                Name = "Squat"
            },
            new Exercise()
            {
                Id = Exercises.Deadlift,
                Name = "Deadlift"
            }
        };
    }
}
