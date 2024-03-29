﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Helpers
{
    public static class SecurityKeyHelper
    {
        public static SymmetricSecurityKey GetKey(string key)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return signingKey;
        }
    }
}
