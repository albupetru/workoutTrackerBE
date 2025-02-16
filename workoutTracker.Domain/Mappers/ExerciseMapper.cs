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
[Mapper]
public partial class ExerciseMapper
{
    public partial ExerciseViewModel ToExerciseViewModel(Exercise exercise);
    public partial IList<ExerciseViewModel> ToExerciseViewModelList(IList<Exercise> exercises);
}
