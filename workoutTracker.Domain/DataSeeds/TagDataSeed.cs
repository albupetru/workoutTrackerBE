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
            new Tag() { Id = Tags.MuscleGroup_Lats, Name = "Lats", TagType = TagType.MuscleGroup }
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
