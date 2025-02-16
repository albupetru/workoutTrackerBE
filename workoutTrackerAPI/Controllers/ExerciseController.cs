using Microsoft.AspNetCore.Mvc;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.WebAPI.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ExerciseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    // [Route]
    public async Task<ActionResult<PaginatedEntityViewModel<ExerciseViewModel>>> Get()/*int take, int skip, [FromQuery] string keyword*/
    {
        var mapper = new ExerciseMapper();
        var exercises = await _unitOfWork.ExerciseRepository.SelectAsync(x => true);
        var result = new PaginatedEntityViewModel<ExerciseViewModel>
        {
            Results = mapper.ToExerciseViewModelList(exercises),
            Total = exercises.Count
        };
        return result;
    }
}
