using System;

namespace workoutTracker.Domain.Common.Constants
{
    public static class Roles
    {
        public static readonly Guid Trial = new Guid("10000000-0000-0000-0000-000000000001");
        public static readonly Guid User = new Guid("10000000-0000-0000-0000-000000000002");
        public static readonly Guid ContentModerator = new Guid("10000000-0000-0000-0000-000000000003");
        public static readonly Guid Admin = new Guid("10000000-0000-0000-0000-000000000004");
    }
}
