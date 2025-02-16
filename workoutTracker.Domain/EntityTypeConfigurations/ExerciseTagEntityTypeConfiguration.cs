using Microsoft.EntityFrameworkCore;
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
    public class ExerciseTagEntityTypeConfiguration : IEntityTypeConfiguration<ExerciseTag>
    {
        public void Configure(EntityTypeBuilder<ExerciseTag> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(c => new
                {
                    c.ExerciseId,
                    c.TagId,
                });

            entityTypeBuilder
                .HasOne(p => p.Exercise)
                .WithMany(b => b.ExerciseTags)
                .HasForeignKey(p => p.ExerciseId);

            entityTypeBuilder
                .HasOne(p => p.Tag)
                .WithMany()
                .HasForeignKey(p => p.TagId);

            var exerciseList = GetCompleteExerciseList();
            var exerciseTags = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            foreach (var exercise in exerciseList)
            {
                foreach(var tagId in exercise.TagIds.Value)
                    exerciseTags.Add(new
                    {
                        ExerciseId = exercise.Id,
                        TagId = tagId,
                        CreatedById = Users.AutomaticProcess,
                        CreatedOn = dateTimeOffset,
                        ModifiedById = Users.AutomaticProcess,
                        ModifiedOn = dateTimeOffset,
                    });
            }

            entityTypeBuilder.HasData(exerciseTags);
        }

        // This simplifies the process of adding exercises to the data seed, since it allows for
        // only the children that have no children of their own to be added to the initial seed list.
        public static IList<Exercise> GetCompleteExerciseList()
        {
            var newData = new List<Exercise>();
            foreach (var exercise in ExeciseDataSeed.Data)
            {
                var newExercise = new Exercise()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                };
                var finalTagIds = new List<Guid>(exercise.TagIds.Value);
                foreach (var tagId in exercise.TagIds.Value)
                {
                    var parentId = TagDataSeed.GetTagParent(tagId);
                    if (parentId.HasValue)
                    {
                        finalTagIds.Add(parentId.Value);
                    }
                }
                newExercise.TagIds = new Lazy<List<Guid>>(finalTagIds.Distinct().ToList());
                newData.Add(newExercise);
            }

            return newData;
        }
    }
}
