using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.Domain.Mappers;

public class TagMapper
{
    public TagViewModel ToViewModel(Tag tag) => new TagViewModel
    {
        Id = tag.Id,
        Name = tag.Name,
        TagType = tag.TagType.ToString(),
        ParentId = tag.TagParent?.ParentId
    };

    public IList<TagViewModel> ToViewModelList(IList<Tag> tags) =>
        tags.Select(ToViewModel).ToList();

    public IList<TagGroupViewModel> ToGroupedViewModels(IList<Tag> tags)
    {
        var byType = tags
            .GroupBy(t => t.TagType)
            .ToDictionary(g => g.Key, g => g.ToList());

        var result = new List<TagGroupViewModel>();

        // Hierarchical muscle section: BodyZone → MuscleFamily → MuscleGroup
        if (byType.TryGetValue(TagType.BodyZone, out var bodyZoneTags))
        {
            TagGroupViewModel? muscleGroupGroup = null;
            if (byType.TryGetValue(TagType.MuscleGroup, out var muscleGroupTags))
            {
                muscleGroupGroup = new TagGroupViewModel
                {
                    TagType = nameof(TagType.MuscleGroup),
                    Tags = muscleGroupTags.Select(ToViewModel).ToList(),
                    TagGroups = null
                };
            }

            TagGroupViewModel? muscleFamilyGroup = null;
            if (byType.TryGetValue(TagType.MuscleFamily, out var muscleFamilyTags))
            {
                muscleFamilyGroup = new TagGroupViewModel
                {
                    TagType = nameof(TagType.MuscleFamily),
                    Tags = muscleFamilyTags.Select(ToViewModel).ToList(),
                    TagGroups = muscleGroupGroup != null ? new List<TagGroupViewModel> { muscleGroupGroup } : null
                };
            }

            result.Add(new TagGroupViewModel
            {
                TagType = nameof(TagType.BodyZone),
                Tags = bodyZoneTags.Select(ToViewModel).ToList(),
                TagGroups = muscleFamilyGroup != null ? new List<TagGroupViewModel> { muscleFamilyGroup } : null
            });
        }

        // Flat types — order matches enum declaration
        var flatTypes = new[]
        {
            TagType.Equipment,
            TagType.MuscleActivationPattern,
            TagType.Laterality,
            TagType.Discipline,
            TagType.TrainingSplit,
            TagType.Comfort,
            TagType.ExerciseType,
            TagType.MovementPattern,
            TagType.Miscellaneous,
        };

        foreach (var flatType in flatTypes)
        {
            if (byType.TryGetValue(flatType, out var flatTags))
            {
                result.Add(new TagGroupViewModel
                {
                    TagType = flatType.ToString(),
                    Tags = flatTags.Select(ToViewModel).ToList(),
                    TagGroups = null
                });
            }
        }

        return result;
    }
}
