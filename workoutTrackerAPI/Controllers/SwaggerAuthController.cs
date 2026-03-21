using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using workoutTracker.Domain.Mappers;
using workoutTracker.Domain.Models.Configuration;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Services.Interface;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.WebAPI.Controllers;

/// <summary>
/// Dev-only endpoint that acts as an OAuth2 token proxy for Swagger UI.
/// Receives the Google auth code from Swagger's OAuth2 flow, exchanges it
/// server-side (keeping client_secret secure), generates the app JWT,
/// and returns it in the standard OAuth2 token response format.
/// </summary>
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class SwaggerAuthController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationSecrets _applicationSecrets;
    private readonly IGoogleLoginService _googleLoginService;
    private readonly IWebHostEnvironment _environment;

    public SwaggerAuthController(
        IUnitOfWork unitOfWork,
        ApplicationSecrets applicationSecrets,
        IGoogleLoginService googleLoginService,
        IWebHostEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _applicationSecrets = applicationSecrets;
        _googleLoginService = googleLoginService;
        _environment = environment;
    }

    [HttpPost("swagger/token")]
    [AllowAnonymous]
    public async Task<IActionResult> Token(
        [FromForm(Name = "grant_type")] string grantType,
        [FromForm(Name = "code")] string code,
        [FromForm(Name = "redirect_uri")] string redirectUri,
        [FromForm(Name = "client_id")] string clientId,
        [FromForm(Name = "code_verifier")] string? codeVerifier = null)
    {
        if (!_environment.IsDevelopment())
            return NotFound();

        if (grantType != "authorization_code" || string.IsNullOrEmpty(code))
            return BadRequest(new { error = "invalid_request" });

        try
        {
            var googleResponse = await _googleLoginService.GetToken(code, redirectUri, codeVerifier);
            var (user, jwt) = await _unitOfWork.UserRepository.Login(googleResponse, _applicationSecrets.SecurityKey);
            await _unitOfWork.SaveAsync();

            // Return in OAuth2 format for Swagger compatibility
            return Ok(new
            {
                access_token = jwt,
                token_type = "Bearer",
                expires_in = 43200, // 12 hours
                user = UserMapper.ToViewModel(user)
            });
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(new { error = "access_denied" });
        }
    }
}
