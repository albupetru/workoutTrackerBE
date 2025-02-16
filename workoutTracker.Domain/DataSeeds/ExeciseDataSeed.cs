using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    // Only childless tags should be present in the data seed for exercises.
    // Their parents will be populated in the Type Configuration file.
    public static class ExeciseDataSeed
    {
        public static IList<Exercise> Data = new List<Exercise>()
        {
            new Exercise()
            {
                Id = Exercises.Barbell_Paused_BenchPress,
                Name = "Bench Press (Paused)",
                TagIds = new Lazy<List<Guid>>(() => new List<Guid> 
                {
                    Tags.MuscleGroup_Pecs,
                    Tags.MuscleGroup_Triceps,
                    Tags.MuscleGroup_FrontDelts,
                })
            },
            new Exercise()
            {
                Id = Exercises.Barbell_LowBar_Squat,
                Name = "Low Bar Squat",
                TagIds = new Lazy<List<Guid>>(() => new List<Guid>
                {
                    Tags.MuscleGroup_Quads,
                    Tags.MuscleGroup_Glutes,
                    Tags.MuscleGroup_SpinalErectors,
                })
            },
            new Exercise()
            {
                Id = Exercises.Conventional_Deadlift,
                Name = "Conventional Deadlift",
                TagIds = new Lazy<List<Guid>>(() => new List<Guid>
                {
                    Tags.MuscleGroup_Hamstrings,
                    Tags.MuscleGroup_Glutes,
                    Tags.MuscleGroup_SpinalErectors,
                })
            }
        };

        public static bool ValidateDataSeed()
        {
            var childlessTags = TagDataSeed.GetChildlessTags();
            foreach (var exercise in Data)
            {
                if (exercise.TagIds.Value.Count == 0
                    || exercise.Tags.Any(tag => !childlessTags.Contains(tag.Id)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
