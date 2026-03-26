using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.Domain.Mappers;

// At this point, a mapper isn't really needed, and there's the debate of
// whether it's productive to use a mapper or not. I'm adding it at this point
// since it gives me the opportunity to try Mapperly, which is faster than other
// alternatives (faster than Mapster and considerably faster than AutoMapper).
// Mapperly does support IQueryable projections.
public class ExerciseMapper
{
    public ExerciseViewModel ToExerciseViewModel(Exercise exercise)
    {
        return new ExerciseViewModel
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Description = exercise.Description,
            Instructions = exercise.Instructions,
            CreatedById = exercise.CreatedById,
            CreatedByName = exercise.CreatedBy?.Name,
            CreatedOn = exercise.CreatedOn,
            VerifiedById = exercise.VerifiedById,
            VerifiedByName = exercise.VerifiedBy?.Name,
            VerifiedOn = exercise.VerifiedOn,
            Tags = exercise.Tags.Select(t => new TagViewModel
            {
                Id = t.Id,
                Name = t.Name,
                TagType = t.TagType.ToString(),
                ParentId = t.TagParent?.ParentId
            }).ToList()
        };
    }
    
    public IList<ExerciseViewModel> ToExerciseViewModelList(IList<Exercise> exercises)
    {
        return exercises.Select(e => ToExerciseViewModel(e)).ToList();
    }

    public Exercise ToExerciseEntity(CreateExerciseViewModel viewModel)
    {
        return new Exercise
        {
            Name = viewModel.Name,
            Description = viewModel.Description ?? string.Empty,
            Instructions = viewModel.Instructions ?? string.Empty,
            ExerciseTags = viewModel.TagIds.Select(tagId => new ExerciseTag
            {
                TagId = tagId
            }).ToList()
        };
    }

    public void UpdateExerciseFromViewModel(UpdateExerciseViewModel viewModel, Exercise exercise)
    {
        exercise.Name = viewModel.Name;
        exercise.Description = viewModel.Description ?? string.Empty;
        exercise.Instructions = viewModel.Instructions ?? string.Empty;
        
        exercise.ExerciseTags.Clear();
        exercise.ExerciseTags = viewModel.TagIds.Select(tagId => new ExerciseTag
        {
            ExerciseId = exercise.Id,
            TagId = tagId
        }).ToList();
    }
}

