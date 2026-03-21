using System;
using System.Collections.Generic;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    public static class RoleDataSeed
    {
        public static IList<Role> Data = new List<Role>()
        {
            new Role()
            {
                Id = Roles.Trial,
                Name = "Trial User",
                RoleType = RoleType.Trial
            },
            new Role()
            {
                Id = Roles.User,
                Name = "User",
                RoleType = RoleType.User
            },
            new Role()
            {
                Id = Roles.ContentModerator,
                Name = "Content Moderator",
                RoleType = RoleType.ContentModerator
            },
            new Role()
            {
                Id = Roles.Admin,
                Name = "Administrator",
                RoleType = RoleType.Admin
            }
        };
    }
}
