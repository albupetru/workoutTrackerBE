using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Common.Constants;
using workoutTracker.Domain.DataSeeds;
using workoutTracker.Domain.Models.Application;

namespace workoutTracker.Domain.EntityTypeConfigurations
{
    public class ExerciseEntityTypeConfiguration : BaseEntityTypeConfiguration<Exercise, Guid>
    {
        public override void Configure(EntityTypeBuilder<Exercise> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            var exercises = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            foreach (var exercise in ExeciseDataSeed.Data)
            {
                exercises.Add(new
                {
                    exercise.Id,
                    exercise.Name,

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
