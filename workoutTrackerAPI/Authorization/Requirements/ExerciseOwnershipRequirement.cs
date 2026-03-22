using Microsoft.AspNetCore.Authorization;

namespace workoutTracker.WebAPI.Authorization.Requirements
{
    public class ExerciseOwnershipRequirement : IAuthorizationRequirement
    {
        // Marker interface - no properties needed
    }
}
