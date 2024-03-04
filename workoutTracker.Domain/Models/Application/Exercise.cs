using System.ComponentModel.DataAnnotations;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Models.Application
{
    public class Exercise : BaseEntity<Exercise, Guid>, IAuditableEntity, ISoftDeletable
    {
        [Key]
        public override Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
