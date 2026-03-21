using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Common.Enums
{
    public enum RoleType : int
    {
        Trial = 0,
        User = 1,
        ContentModerator = 2,
        Admin = 3,
    }
}
