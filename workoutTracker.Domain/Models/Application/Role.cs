using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Models.Application
{
    public class Role : BaseEntity<Role, Guid>
    {
        [Key]
        public override Guid Id { get; set; }
        public string Name { get; set; }
        public RoleType RoleType { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [NotMapped]
        public virtual ICollection<User> Users => UserRoles.Select(p => p.User).ToList();
    }
}
