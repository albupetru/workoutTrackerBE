using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Services.Interface;

namespace workoutTracker.Domain.Services.Implementation
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string objectidentifierClaim = "http://schemas.microsoft.com/identity/claims/objectidentifier";

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
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == objectidentifierClaim) &&
                Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(objectidentifierClaim).Value, out userId))
            {
                UserId = userId;
            }
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                Name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            }
            if (_httpContextAccessor.HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Email))
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
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
                Guid.TryParse(httpContext.User.FindFirst(objectidentifierClaim).Value, out userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

        public bool IsAdmin()
        {
            return Roles.Contains("Admin");
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
