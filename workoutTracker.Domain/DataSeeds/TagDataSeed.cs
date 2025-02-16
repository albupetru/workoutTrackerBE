using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    public static class TagDataSeed
    {
        public static IList<Tag> Data = new List<Tag>()
        {
            // Upper/Lower
            new Tag()
            {
                Id = Tags.BodyZone_LowerBody,
                Name = "Lower Body",
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
                ChildrenIds = new Lazy<List<Guid>>(() =>
                    new List<Guid>()
                    {
                        Tags.MuscleGroup_CalvesSoleus,
                        Tags.MuscleGroup_CalvesGastroc,
                    }
                )
            },
            // Muscle Group
            new Tag()
            {
                Id = Tags.MuscleGroup_Pecs,
                Name = "Pectorals",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_FrontDelts,
                Name = "Front Delts",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_SideDelts,
                Name = "Side Delts",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_RearDelts,
                Name = "Rear Delts",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_SpinalErectors,
                Name = "Spinal Erectors",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Biceps,
                Name = "Biceps",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Triceps,
                Name = "Triceps",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_ForearmExtensors,
                Name = "Forearm Extensors",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_ForearmFlexors,
                Name = "Forearm Flexors",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Quads,
                Name = "Quadriceps",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Hamstrings,
                Name = "Hamstrings",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Glutes,
                Name = "Glutes",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Adductors,
                Name = "Adductors",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Abs,
                Name = "Rectus Abdominis",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Obliques,
                Name = "Obliques",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_CalvesSoleus,
                Name = "Calves Soleus",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_CalvesGastroc,
                Name = "Calves Gastroc",
            },
            new Tag()
            {
                Id = Tags.MuscleGroup_Lats,
                Name = "Lats",
            }
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
