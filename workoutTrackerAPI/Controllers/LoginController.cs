using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using workoutTracker.Domain.Models.Configuration;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Services.Interface;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.WebAPI.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LoginController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationSecrets _applicationSecrets;
    private readonly IGoogleLoginService _googleLoginService;

    public LoginController(IUnitOfWork unitOfWork,
        ApplicationSecrets applicationSecrets,
        IGoogleLoginService googleLoginService)
    {
        _unitOfWork = unitOfWork;
        _applicationSecrets = applicationSecrets;
        _googleLoginService = googleLoginService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        try
        {
            var googleAccessTokenResponse = await _googleLoginService.GetToken(model.Code);
            var token = await _unitOfWork.UserRepository.Login(googleAccessTokenResponse, _applicationSecrets.SecurityKey);
            await _unitOfWork.SaveAsync();

            return Ok(token);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [Route("/logout")]
    public IActionResult Logout()
    {
        // TODO: implement logout
        return Ok();
    }
}
