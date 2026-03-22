using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.ViewModels
{
    public class CreateExerciseViewModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [MaxLength(5000)]
        public string? Instructions { get; set; }

        public List<Guid> TagIds { get; set; } = new();
    }
}
