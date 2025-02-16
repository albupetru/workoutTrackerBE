using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workoutTracker.Domain.Models.Common;

namespace workoutTracker.Domain.Models.Application
{
    public class Exercise : BaseEntity<Exercise, Guid>, IAuditableEntity, ISoftDeletable
    {
        [Key]
        public override Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<ExerciseTag> ExerciseTags { get; set; } = new List<ExerciseTag>();
        [NotMapped]
        public virtual ICollection<Tag> Tags => ExerciseTags.Select(p => p.Tag).ToList();

        [NotMapped]
        public Lazy<List<Guid>> TagIds { get; set; }
    }
}
