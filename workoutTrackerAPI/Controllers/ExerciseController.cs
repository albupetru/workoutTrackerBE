using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.ViewModels;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace workoutTracker.WebAPI.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class ExerciseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }    [HttpGet]
    // [Route]
    public async Task<ActionResult<PaginatedEntityViewModel<ExerciseViewModel>>> Get([FromQuery] string? keyword = null)/*int take, int skip, [FromQuery] string keyword*/
    {
        var mapper = new ExerciseMapper();
        var exercises = await _unitOfWork.ExerciseRepository
            .SelectAsync(x => string.IsNullOrEmpty(keyword) || x.Name.StartsWith(keyword),
            x => x.Name,
            query => query.Include(x => x.ExerciseTags).ThenInclude(x => x.Tag));

        var result = new PaginatedEntityViewModel<ExerciseViewModel>
        {
            Results = mapper.ToExerciseViewModelList(exercises),
            Total = exercises.Count
        };
        return result;
    }
}
