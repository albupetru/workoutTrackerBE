using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.DataSeeds;
using workoutTracker.Domain.Models.Application;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class ExerciseEntityTypeConfiguration : BaseEntityTypeConfiguration<Exercise, Guid>
    {
        public override void Configure(EntityTypeBuilder<Exercise> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .HasMany(p => p.ExerciseTags)
                .WithOne(b => b.Exercise);

            if (!ExeciseDataSeed.ValidateDataSeed())
            {
                throw new Exception("Invalid data seed for exercises.");
            }

            var exercises = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            foreach (var exercise in ExeciseDataSeed.Data)
            {
                exercises.Add(new
                {
                    exercise.Id,
                    exercise.Name,
                    exercise.Description,
                    exercise.Instructions,
                    CreatedById = Users.AutomaticProcess,
                    CreatedOn = dateTimeOffset,
                    ModifiedById = Users.AutomaticProcess,
                    ModifiedOn = dateTimeOffset,
                });
            }

            entityTypeBuilder.HasData(exercises);
        }

    }
}
