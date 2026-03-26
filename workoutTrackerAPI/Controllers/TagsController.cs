using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.WebAPI.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class TagsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TagMapper _mapper;

    public TagsController(IUnitOfWork unitOfWork, TagMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all tags ordered by name, optionally filtered by TagType.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IList<TagViewModel>>> GetTags([FromQuery] string? type = null)
    {
        if (type != null)
        {
            if (!Enum.TryParse<TagType>(type, ignoreCase: true, out var tagType))
                return BadRequest($"Invalid tag type: '{type}'. Valid values: {string.Join(", ", Enum.GetNames<TagType>())}");

            var filtered = await _unitOfWork.TagRepository.GetByTypeAsync(tagType);
            return Ok(_mapper.ToViewModelList(filtered));
        }

        var tags = await _unitOfWork.TagRepository.GetAllOrderedByNameAsync();
        return Ok(_mapper.ToViewModelList(tags));
    }

    /// <summary>
    /// Get all tags grouped by TagType. The muscle hierarchy (BodyZone → MuscleFamily → MuscleGroup)
    /// is returned as nested TagGroups. Flat types have TagGroups = null.
    /// </summary>
    [HttpGet("grouped")]
    public async Task<ActionResult<IList<TagGroupViewModel>>> GetTagsGrouped()
    {
        var tags = await _unitOfWork.TagRepository.GetAllWithParentsAsync();
        return Ok(_mapper.ToGroupedViewModels(tags));
    }
}

