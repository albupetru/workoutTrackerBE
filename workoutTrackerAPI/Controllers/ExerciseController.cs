using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.ViewModels;
using workoutTracker.WebAPI.Authorization.Requirements;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace workoutTracker.WebAPI.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class ExerciseController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorizationService _authorizationService;

    public ExerciseController(IUnitOfWork unitOfWork, IAuthorizationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _authorizationService = authorizationService;
    }  

    [HttpGet]
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

    ///// <summary>
    ///// Example PUT endpoint demonstrating resource-based authorization with custom requirement.
    ///// This will be fully implemented when Exercise model includes IsVerified and SubmittedById properties.
    ///// </summary>
    //[HttpPut("{id}")]
    //[Authorize(Policy = "RequireUserOrAbove")] // Must be at least User role
    //public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] ExerciseViewModel model)
    //{
    //    var exercise = await _unitOfWork.ExerciseRepository.GetByIdAsync(id);
    //    if (exercise == null)
    //    {
    //        return NotFound();
    //    }

    //    // Check ownership with custom requirement
    //    var authResult = await _authorizationService.AuthorizeAsync(
    //        User,
    //        exercise,
    //        new ExerciseOwnershipRequirement()
    //    );

    //    if (!authResult.Succeeded)
    //    {
    //        return Forbid(); // 403 Forbidden
    //    }

    //    // TODO: Implement update logic when Exercise model is complete
    //    // exercise.Name = model.Name;
    //    // exercise.Description = model.Description;
    //    // await _unitOfWork.SaveAsync();

    //    return Ok(new { message = "Authorization successful. Update logic to be implemented." });
    //}
}
