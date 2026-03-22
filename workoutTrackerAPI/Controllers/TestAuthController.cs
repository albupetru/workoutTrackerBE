using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Configuration;

namespace workoutTracker.WebAPI.Controllers;

/// <summary>
/// TEST-ONLY authentication endpoint for automated testing and UI development.
/// Generates JWT tokens without requiring Google OAuth flow.
/// 
/// SECURITY NOTES:
/// - Only available in Development environment
/// - Must be explicitly enabled via TestAuthSettings:Enabled in appsettings.Development.json
/// - Returns 404 in Production environments
/// - Should NEVER be deployed to production
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TestAuthController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;
    private readonly ApplicationSecrets _applicationSecrets;

    public TestAuthController(
        IWebHostEnvironment environment,
        IConfiguration configuration,
        ApplicationSecrets applicationSecrets)
    {
        _environment = environment;
        _configuration = configuration;
        _applicationSecrets = applicationSecrets;
    }

    /// <summary>
    /// Generates a test JWT token for the specified role and user.
    /// </summary>
    /// <param name="role">The role to assign (Trial, User, ContentModerator, Admin). Defaults to User.</param>
    /// <param name="userId">Optional custom user ID. Defaults to test-user-{role}</param>
    /// <param name="email">Optional email. Defaults to test-{role}@example.com</param>
    /// <param name="name">Optional name. Defaults to Test {Role}</param>
    /// <returns>JWT token with 12 hour expiration</returns>
    /// <response code="200">Returns the generated JWT token</response>
    /// <response code="404">Test auth is disabled or not in Development environment</response>
    /// <response code="400">Invalid role specified</response>
    [HttpPost("token")]
    [AllowAnonymous]
    public IActionResult GenerateTestToken(
        [FromQuery] string role = "User",
        [FromQuery] string? userId = null,
        [FromQuery] string? email = null,
        [FromQuery] string? name = null)
    {
        // Security check: Only allow in Development AND when explicitly enabled
        if (!_environment.IsDevelopment())
        {
            return NotFound();
        }

        var testAuthEnabled = _configuration.GetValue<bool>("TestAuthSettings:Enabled", false);
        if (!testAuthEnabled)
        {
            return NotFound("Test authentication is disabled. Enable it in appsettings.Development.json");
        }

        // Validate role
        if (!Enum.TryParse<RoleType>(role, ignoreCase: true, out var roleType))
        {
            return BadRequest($"Invalid role. Valid values: {string.Join(", ", Enum.GetNames<RoleType>())}");
        }

        // Set defaults if not provided
        userId ??= $"test-user-{roleType.ToString().ToLower()}";
        email ??= $"test-{roleType.ToString().ToLower()}@example.com";
        name ??= $"Test {roleType}";

        // Generate JWT token (same logic as real login)
        var claims = new List<Claim>
        {
            new("oid", userId),
            new(ClaimTypes.Name, name),
            new("email", email),
            new(ClaimTypes.Role, roleType.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSecrets.SecurityKey)),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new
        {
            token = tokenString,
            expiresIn = 43200, // 12 hours in seconds
            user = new
            {
                id = userId,
                name,
                email,
                role = roleType.ToString()
            }
        });
    }

    /// <summary>
    /// Quick endpoint to generate tokens via GET for easy browser testing.
    /// Format: /api/testauth/admin or /api/testauth/user
    /// </summary>
    [HttpGet("{role}")]
    [AllowAnonymous]
    public IActionResult GenerateTestTokenSimple(string role)
    {
        return GenerateTestToken(role);
    }
}
