using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Helpers
{
    public static class ConfigurationHelper
    {
        public static T GetSection<T>(this IConfiguration configuration, in string section)
        {
            var configurationSection = configuration.GetSection(section).Get<T>() ??
                                       throw new SettingsPropertyNotFoundException(
                                           $"Configuration section '{section}' not found.");
            return configurationSection;
        }
    }
}
