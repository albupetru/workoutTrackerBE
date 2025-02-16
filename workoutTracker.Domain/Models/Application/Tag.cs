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
    public class Tag : BaseEntity<Tag, Guid>
    {
        [Key]
        public override Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        // public TagType Type { get; set; }

        [JsonIgnore]
        public virtual ICollection<TagChild> TagChildren { get; set; } = new List<TagChild>();
        [NotMapped]
        public virtual ICollection<Tag> Children => TagChildren.Select(p => p.Child).ToList();

        [JsonIgnore]
        public virtual TagChild TagParent { get; set; }
        [NotMapped]
        public virtual Tag Parent => TagParent?.Parent;

        [JsonIgnore]
        public virtual ICollection<ExerciseTag> ExerciseTags { get; set; } = new List<ExerciseTag>();
        [NotMapped]
        public virtual ICollection<Exercise> Exercises => ExerciseTags.Select(p => p.Exercise).ToList();

        [NotMapped]
        public Lazy<List<Guid>> ChildrenIds { get; set; }
    }
}
