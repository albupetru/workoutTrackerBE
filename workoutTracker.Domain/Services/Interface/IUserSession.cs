using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Services.Interface
{
    public interface IUserSession
    {
        Guid UserId { get; set; }
        string Name { get; set; }
        List<string> Roles { get; set; }
        public string Email { get; set; }
        bool IsAdmin();
    }
}
