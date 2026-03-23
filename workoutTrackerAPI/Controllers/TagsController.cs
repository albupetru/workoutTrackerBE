using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    public TagsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get all tags ordered by name
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IList<TagViewModel>>> GetTags()
    {
        var tags = await _unitOfWork.TagRepository.GetAllOrderedByNameAsync();

        var viewModels = tags.Select(t => new TagViewModel
        {
            Id = t.Id,
            Name = t.Name
        }).ToList();

        return Ok(viewModels);
    }
}
