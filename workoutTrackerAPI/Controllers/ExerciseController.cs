using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Services.Interface;
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
    private readonly IUserSession _userSession;
    private readonly ExerciseMapper _mapper;

    public ExerciseController(
        IUnitOfWork unitOfWork,
        IAuthorizationService authorizationService,
        IUserSession userSession,
        ExerciseMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authorizationService = authorizationService;
        _userSession = userSession;
        _mapper = mapper;
    }

    /// <summary>
    /// List exercises with filtering, pagination, and sorting
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<object>> GetExercises(
        [FromQuery] string? keyword = null,
        [FromQuery] List<Guid>? tagIds = null,
        [FromQuery] bool includeUnverified = false,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] string sortBy = "Name",
        [FromQuery] string sortOrder = "asc")
    {
        var isAdminOrModerator = _userSession.IsAdmin() || _userSession.IsModerator();
        
        var (exercises, totalCount) = await _unitOfWork.ExerciseRepository.GetExercisesAsync(
            keyword,
            tagIds,
            includeUnverified,
            _userSession.UserId,
            isAdminOrModerator,
            pageNumber,
            pageSize,
            sortBy,
            sortOrder);

        var exerciseViewModels = _mapper.ToExerciseViewModelList(exercises);

        return Ok(new
        {
            exercises = exerciseViewModels,
            totalCount,
            pageNumber,
            pageSize
        });
    }

    /// <summary>
    /// Get single exercise by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ExerciseViewModel>> GetExercise(Guid id)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);

        if (exercise == null)
        {
            return NotFound();
        }

        var canView = exercise.VerifiedOn != null ||
                      exercise.CreatedById == _userSession.UserId ||
                      _userSession.IsAdmin() || _userSession.IsModerator();

        if (!canView)
        {
            return Forbid();
        }

        var exerciseViewModel = _mapper.ToExerciseViewModel(exercise);

        return Ok(exerciseViewModel);
    }

    /// <summary>
    /// Create a new exercise
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ExerciseViewModel>> CreateExercise([FromBody] CreateExerciseViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exercise = _mapper.ToExerciseEntity(model);

        var isAdminOrModerator = _userSession.IsAdmin() || _userSession.IsModerator();
        if (isAdminOrModerator)
        {
            exercise.VerifiedById = _userSession.UserId;
            exercise.VerifiedOn = DateTimeOffset.UtcNow;
        }

        await _unitOfWork.ExerciseRepository.InsertAsync(exercise);
        await _unitOfWork.SaveAsync();

        var createdExercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(exercise.Id);
        var exerciseViewModel = _mapper.ToExerciseViewModel(createdExercise!);

        return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exerciseViewModel);
    }

    /// <summary>
    /// Update an existing exercise
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ExerciseViewModel>> UpdateExercise(Guid id, [FromBody] UpdateExerciseViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);

        if (exercise == null)
        {
            return NotFound();
        }

        var isAdminOrModerator = _userSession.IsAdmin() || _userSession.IsModerator();
        var isSubmitter = exercise.CreatedById == _userSession.UserId;
        var isUnverified = exercise.VerifiedOn == null;

        var canEdit = (isSubmitter && isUnverified) || isAdminOrModerator;

        if (!canEdit)
        {
            return Forbid();
        }

        _mapper.UpdateExerciseFromViewModel(model, exercise);

        // Note: We keep verification status as is (don't reset on edit)
        await _unitOfWork.SaveAsync();

        var updatedExercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);
        var exerciseViewModel = _mapper.ToExerciseViewModel(updatedExercise!);

        return Ok(exerciseViewModel);
    }

    /// <summary>
    /// Delete an exercise (soft delete)
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExercise(Guid id)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);

        if (exercise == null)
        {
            return NotFound();
        }

        var isAdminOrModerator = _userSession.IsAdmin() || _userSession.IsModerator();
        var isSubmitter = exercise.CreatedById == _userSession.UserId;
        var isUnverified = exercise.VerifiedOn == null;

        var canDelete = (isSubmitter && isUnverified) || isAdminOrModerator;

        if (!canDelete)
        {
            return Forbid();
        }

        _unitOfWork.ExerciseRepository.Remove(exercise);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    /// <summary>
    /// Verify an exercise (Admin/Moderator only)
    /// </summary>
    [HttpPatch("{id}/verify")]
    [Authorize(Roles = "Admin,ContentModerator")]
    public async Task<ActionResult<ExerciseViewModel>> VerifyExercise(Guid id)
    {
        var exercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);

        if (exercise == null)
        {
            return NotFound();
        }

        exercise.VerifiedById = _userSession.UserId;
        exercise.VerifiedOn = DateTimeOffset.UtcNow;

        await _unitOfWork.SaveAsync();

        var verifiedExercise = await _unitOfWork.ExerciseRepository.GetByIdWithDetailsAsync(id);
        var exerciseViewModel = _mapper.ToExerciseViewModel(verifiedExercise!);

        return Ok(exerciseViewModel);
    }
}

