using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.ViewModels;

namespace workoutTracker.Domain.Mappers;

public static class UserMapper
{
    public static UserViewModel ToViewModel(User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.GetRoleType()?.ToString() ?? "Trial"
        };
    }
}
