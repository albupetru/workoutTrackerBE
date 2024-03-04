using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Models.Application
{
    public class User : BaseEntity<User, Guid>, IAuditableEntity, ISoftDeletable
    {
        [Key]
        public override Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        // named sub in the jwt provided by the Google Oauth2
        public string GoogleId { get; set; }

        public Guid? DeletedById { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<UserRole> UserRoles { get; set; }
        //[NotMapped]
        //public virtual ICollection<Role> Roles => UserRoles.Select(p => p.Role).ToList();
    }
}
