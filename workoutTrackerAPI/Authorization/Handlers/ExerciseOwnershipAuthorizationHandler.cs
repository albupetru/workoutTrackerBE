using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.WebAPI.Authorization.Handlers
{
    public class ExerciseOwnershipAuthorizationHandler 
        : AuthorizationHandler<Requirements.ExerciseOwnershipRequirement, Exercise>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            Requirements.ExerciseOwnershipRequirement requirement,
            Exercise resource)
        {
            var roles = context.User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            
            if (roles.Contains("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            
            var userIdClaim = context.User.FindFirst("oid")?.Value;
            if (Guid.TryParse(userIdClaim, out var userId))
            {
                // TODO: Uncomment when IsVerified property is added to Exercise model
                /*
                // Moderator can edit unverified exercises
                if (roles.Contains("ContentModerator") && !resource.IsVerified)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                
                // Owner can edit their own unverified exercise
                if (resource.SubmittedById == userId && !resource.IsVerified)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                */
            }
            
            // Otherwise, fail
            return Task.CompletedTask;
        }
    }
}
