using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Services.Implementation;

namespace workoutTracker.Domain.Services.Interface
{
    public interface IGoogleLoginService
    {
        Task<GoogleAccessTokenResponse> GetToken(string code);
    }
}
