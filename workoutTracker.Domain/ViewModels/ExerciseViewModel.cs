using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.ViewModels
{
    public class ExerciseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Instructions { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedByName { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? VerifiedById { get; set; }
        public string? VerifiedByName { get; set; }
        public DateTimeOffset? VerifiedOn { get; set; }
        public List<TagViewModel> Tags { get; set; } = new();
    }
}
