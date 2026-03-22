using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Services.Interface;

namespace workoutTracker.Domain.Services.Implementation
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private const string objectidentifierClaim = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
            {
                return;
            }
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor?.HttpContext?.User == null)
            {
                return;
            }

            Guid userId;
            // Try "oid" claim first (our JWT tokens), then fall back to objectidentifierClaim
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == "oid") &&
                Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst("oid")?.Value, out userId))
            {
                UserId = userId;
            }
            else if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == objectidentifierClaim) &&
                Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(objectidentifierClaim)?.Value, out userId))
            {
                UserId = userId;
            }
            
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                Name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
            }
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Email))
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
            }
            else if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == "email"))
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirst("email")?.Value ?? string.Empty;
            }

            Roles = _httpContextAccessor
                .HttpContext.User.FindAll(ClaimTypes.Role)
                .Select(x => x.Value)
                .ToList();
        }

        public static Guid GetUserGuid(HttpContext httpContext)
        {
            Guid userId;
            if (httpContext.User.HasClaim(x => x.Type == objectidentifierClaim) &&
                Guid.TryParse(httpContext.User.FindFirst(objectidentifierClaim)?.Value, out userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

        public bool IsAdmin()
        {
            return Roles?.Contains("Admin") == true || Roles?.Contains(RoleType.Admin.ToString()) == true;
        }

        public bool IsModerator()
        {
            return Roles?.Contains("ContentModerator") == true || Roles?.Contains(RoleType.ContentModerator.ToString()) == true;
        }

        public bool IsAtLeast(RoleType minimumRole)
        {
            var roleString = Roles?.FirstOrDefault();
            if (string.IsNullOrEmpty(roleString) || !Enum.TryParse<RoleType>(roleString, out var currentRole))
                return false;

            return currentRole switch
            {
                RoleType.Admin => true,
                RoleType.ContentModerator => minimumRole != RoleType.Admin,
                RoleType.User => minimumRole is RoleType.User or RoleType.Trial,
                RoleType.Trial => minimumRole == RoleType.Trial,
                _ => false
            };
        }
    }
}
