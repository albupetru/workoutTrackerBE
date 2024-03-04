using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Services.Implementation;

namespace workoutTracker.Domain.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<string> Login(GoogleAccessTokenResponse googleAccessTokenResponse, string secret);
    }
}
