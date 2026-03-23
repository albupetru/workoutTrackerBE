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
                Description = "A horizontal pressing movement performed with a deliberate pause at the chest. The pause eliminates the stretch-reflex, forcing the muscles to generate force from a dead stop and building strength at the most challenging point of the lift.",
                Instructions = "Set up on the bench with eyes under the bar, retract your shoulder blades and arch your lower back slightly.\nUnrack the bar and position it over your lower chest with locked-out elbows.\nDescend with control, flaring the elbows slightly outward, until the bar touches your chest.\nPause for 1-2 full seconds — the bar must be motionless with no downward bounce.\nDrive the bar back up explosively, pressing your feet into the floor for leg drive.\nRe-rack only after achieving full lockout at the top.",
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
                Description = "A powerlifting squat variation where the bar rests lower on the rear deltoids rather than the traps. The lower bar position shifts the torso angle forward, recruiting the posterior chain more aggressively and allowing heavier loads to be moved.",
                Instructions = "Position the bar across your rear deltoids, not your traps. Grip just outside shoulder width.\nStep back with two controlled steps, feet shoulder-width or slightly wider, toes turned out 15-30 degrees.\nTake a deep breath into your belly, brace your core hard, and push your knees out in the direction of your toes.\nDescend by hinging at the hips simultaneously with bending the knees, maintaining a forward torso lean.\nSquat until hip crease is at or below the top of the knee.\nDrive through the entire foot explosively, keeping the chest up and knees out on the ascent.",
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
                Description = "The foundational hip-hinge movement for building total-body strength. The conventional stance targets the posterior chain — hamstrings, glutes, and spinal erectors — while also demanding significant upper back and grip strength to keep the bar controlled.",
                Instructions = "Stand with feet hip-width apart, bar over mid-foot. Grip the bar just outside your legs, double-overhand or mixed grip.\nHinge at the hips to reach the bar, then drop the hips until your shins touch the bar without letting it roll forward.\nRetract your shoulder blades, lift your chest, and create tension in your lats by 'bending the bar around your legs'.\nTake a big breath, brace hard, then drive your feet into the floor while simultaneously pulling the slack out of the bar.\nKeep the bar in contact with your legs throughout the pull. Lock out by squeezing glutes and driving hips through at the top.\nReturn the bar to the floor with control by hinging at the hips first, then bending the knees once the bar passes them.",
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
