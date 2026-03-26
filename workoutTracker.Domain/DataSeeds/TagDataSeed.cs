using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    public static class TagDataSeed
    {
        public static IList<Tag> Data = new List<Tag>()
        {
            // Body Zone
            new Tag()
            {
                Id = Tags.BodyZone_LowerBody,
                Name = "Lower Body",
                TagType = TagType.BodyZone,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleFamily_Thighs,
                        Tags.MuscleFamily_Calves,
                    }
                ),
            },
            new Tag()
            {
                Id = Tags.BodyZone_UpperBody,
                Name = "Upper Body",
                TagType = TagType.BodyZone,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleFamily_Chest,
                        Tags.MuscleFamily_Shoulders,
                        Tags.MuscleFamily_UpperArms,
                        Tags.MuscleFamily_Forearms,
                    }
                ),
            },
            new Tag()
            {
                Id = Tags.BodyZone_Core,
                Name = "Core",
                TagType = TagType.BodyZone,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleFamily_LowerBack,
                        Tags.MuscleFamily_Abdominals,
                    }
                ),
            },
            // Muscle Family
            new Tag()
            {
                Id = Tags.MuscleFamily_Chest,
                Name = "Chest",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_Pecs,
                    }
                ),
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_Shoulders,
                Name = "Shoulders",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_FrontDelts,
                        Tags.MuscleGroup_SideDelts,
                        Tags.MuscleGroup_RearDelts,
                    }
                ),

            },
            new Tag()
            {
                Id = Tags.MuscleFamily_LowerBack,
                Name = "Lower Back",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_SpinalErectors,
                    }
                ),
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_UpperArms,
                Name = "Upper Arms",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_Biceps,
                        Tags.MuscleGroup_Triceps,
                    }
                )
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_Forearms,
                Name = "Forearms",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_ForearmExtensors,
                        Tags.MuscleGroup_ForearmFlexors,
                    }
                )
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_Thighs,
                Name = "Thighs",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_Quads,
                        Tags.MuscleGroup_Hamstrings,
                        Tags.MuscleGroup_Glutes,
                        Tags.MuscleGroup_Adductors,
                    }
                )
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_Abdominals,
                Name = "Abdominals",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_Abs,
                        Tags.MuscleGroup_Obliques,
                    }
                )
            },
            new Tag()
            {
                Id = Tags.MuscleFamily_Calves,
                Name = "Calves",
                TagType = TagType.MuscleFamily,
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_CalvesSoleus,
                        Tags.MuscleGroup_CalvesGastroc,
                    }
                )
            },
            // Muscle Group
            new Tag() { Id = Tags.MuscleGroup_Pecs, Name = "Pectorals", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_FrontDelts, Name = "Front Delts", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_SideDelts, Name = "Side Delts", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_RearDelts, Name = "Rear Delts", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_SpinalErectors, Name = "Spinal Erectors", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Biceps, Name = "Biceps", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Triceps, Name = "Triceps", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_ForearmExtensors, Name = "Forearm Extensors", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_ForearmFlexors, Name = "Forearm Flexors", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Quads, Name = "Quadriceps", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Hamstrings, Name = "Hamstrings", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Glutes, Name = "Glutes", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Adductors, Name = "Adductors", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Abs, Name = "Rectus Abdominis", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Obliques, Name = "Obliques", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_CalvesSoleus, Name = "Calves Soleus", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_CalvesGastroc, Name = "Calves Gastroc", TagType = TagType.MuscleGroup },
            new Tag() { Id = Tags.MuscleGroup_Lats, Name = "Lats", TagType = TagType.MuscleGroup },

            // Equipment
            new Tag() { Id = Tags.Equipment_Barbell, Name = "Barbell", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_Dumbbell, Name = "Dumbbell", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_Cable, Name = "Cable Machine", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_SmithMachine, Name = "Smith Machine", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_Machine, Name = "Machine", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_Bodyweight, Name = "Bodyweight", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_ResistanceBand, Name = "Resistance Band", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_Kettlebell, Name = "Kettlebell", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_EZBar, Name = "EZ Bar", TagType = TagType.Equipment },
            new Tag() { Id = Tags.Equipment_TrapBar, Name = "Trap Bar", TagType = TagType.Equipment },

            // Muscle Activation Pattern
            new Tag() { Id = Tags.MuscleActivationPattern_Compound, Name = "Compound", TagType = TagType.MuscleActivationPattern },
            new Tag() { Id = Tags.MuscleActivationPattern_Isolation, Name = "Isolation", TagType = TagType.MuscleActivationPattern },

            // Laterality
            new Tag() { Id = Tags.Laterality_Unilateral, Name = "Unilateral", TagType = TagType.Laterality },
            new Tag() { Id = Tags.Laterality_Bilateral, Name = "Bilateral", TagType = TagType.Laterality },

            // Discipline
            new Tag() { Id = Tags.Discipline_Powerlifting, Name = "Powerlifting", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Bodybuilding, Name = "Bodybuilding", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Crossfit, Name = "CrossFit", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Endurance, Name = "Endurance", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Strongman, Name = "Strongman", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Weightlifting, Name = "Olympic Weightlifting", TagType = TagType.Discipline },
            new Tag() { Id = Tags.Discipline_Calisthenics, Name = "Calisthenics", TagType = TagType.Discipline },

            // Training Split
            new Tag() { Id = Tags.TrainingSplit_Push, Name = "Push", TagType = TagType.TrainingSplit },
            new Tag() { Id = Tags.TrainingSplit_Pull, Name = "Pull", TagType = TagType.TrainingSplit },
            new Tag() { Id = Tags.TrainingSplit_Legs, Name = "Legs", TagType = TagType.TrainingSplit },
            new Tag() { Id = Tags.TrainingSplit_Upper, Name = "Upper", TagType = TagType.TrainingSplit },
            new Tag() { Id = Tags.TrainingSplit_Lower, Name = "Lower", TagType = TagType.TrainingSplit },
            new Tag() { Id = Tags.TrainingSplit_FullBody, Name = "Full Body", TagType = TagType.TrainingSplit },

            // Comfort
            new Tag() { Id = Tags.Comfort_LowBackFriendly, Name = "Low Back Friendly", TagType = TagType.Comfort },
            new Tag() { Id = Tags.Comfort_KneeFriendly, Name = "Knee Friendly", TagType = TagType.Comfort },
            new Tag() { Id = Tags.Comfort_ShoulderFriendly, Name = "Shoulder Friendly", TagType = TagType.Comfort },
            new Tag() { Id = Tags.Comfort_WristFriendly, Name = "Wrist Friendly", TagType = TagType.Comfort },

            // Exercise Type
            new Tag() { Id = Tags.ExerciseType_Strength, Name = "Strength", TagType = TagType.ExerciseType },
            new Tag() { Id = Tags.ExerciseType_Stretching, Name = "Stretching", TagType = TagType.ExerciseType },
            new Tag() { Id = Tags.ExerciseType_Cardio, Name = "Cardio", TagType = TagType.ExerciseType },
            new Tag() { Id = Tags.ExerciseType_Mobility, Name = "Mobility", TagType = TagType.ExerciseType },
            new Tag() { Id = Tags.ExerciseType_Warmup, Name = "Warmup", TagType = TagType.ExerciseType },
            new Tag() { Id = Tags.ExerciseType_Cooldown, Name = "Cooldown", TagType = TagType.ExerciseType },

            // Movement Pattern
            new Tag() { Id = Tags.MovementPattern_Pull_Vertical, Name = "Vertical Pull", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_Pull_Horizontal, Name = "Horizontal Pull", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_Push_Vertical, Name = "Vertical Push", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_Push_Horizontal, Name = "Horizontal Push", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_HipHingePattern, Name = "Hip Hinge", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_SquatPattern, Name = "Squat Pattern", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_LungePattern, Name = "Lunge Pattern", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_Carry, Name = "Carry", TagType = TagType.MovementPattern },
            new Tag() { Id = Tags.MovementPattern_Rotation, Name = "Rotation", TagType = TagType.MovementPattern },
        };

        public static Guid? GetTagParent(Guid id)
        {
            // Tags are expected to have a single parent.
            Tag parent;
            try
            {
                parent = Data.SingleOrDefault(x => x.ChildrenIds != null && x.ChildrenIds.Value.Contains(id));
            }
            catch (InvalidOperationException e)
            {
                throw new Exception($"Invalid tag data seed. Tag with id {id} has multiple parents.");
            }

            return parent?.Id;
        }

        public static List<Guid> GetChildlessTags()
        {
            return Data.Where(x => x.ChildrenIds == null || x.ChildrenIds.Value.Count == 0).Select(x => x.Id).ToList();
        }
    }
}
