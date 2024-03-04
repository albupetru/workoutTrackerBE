using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.DataSeeds
{
    public static class UserDataSeed
    {
        public static IList<User> Data = new List<User>()
        {
            new User()
            {
                Id = Users.AutomaticProcess,
                Name = "Automatic Process",
                Email = string.Empty,
                GoogleId = string.Empty,
            }
        };
    }
}
