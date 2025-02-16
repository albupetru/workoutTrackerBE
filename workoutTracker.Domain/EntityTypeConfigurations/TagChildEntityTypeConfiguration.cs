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
    public class TagChildEntityTypeConfiguration : IEntityTypeConfiguration<TagChild>
    {
        public void Configure(EntityTypeBuilder<TagChild> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(c => new
                {
                    c.ParentId,
                    c.ChildId,
                });

            entityTypeBuilder
                .HasOne(p => p.Parent)
                .WithMany(b => b.TagChildren)
                .HasForeignKey(p => p.ParentId);

            entityTypeBuilder
                .HasOne(p => p.Child)
                .WithOne(b => b.TagParent)
                .HasForeignKey<TagChild>(p => p.ChildId);

            var tagsWithChildrenList = TagDataSeed.Data
                .Where(x => x.ChildrenIds != null && x.ChildrenIds.Value.Count > 0);
            var tagChildren = new List<object>();
            var dateTimeOffset = DateTimeOffset.Now;
            // var xtagChilren = new List<TagChild>();
            foreach (var tag in tagsWithChildrenList)
            {
                foreach (var childId in tag.ChildrenIds.Value)
                {
                    tagChildren.Add(new
                    {
                        ParentId = tag.Id,
                        ChildId = childId,
                        CreatedById = Users.AutomaticProcess,
                        CreatedOn = dateTimeOffset,
                        ModifiedById = Users.AutomaticProcess,
                        ModifiedOn = dateTimeOffset,
                    });
                    //xtagChilren.Add(new TagChild
                    //{
                    //    ParentId = tag.Id,
                    //    ChildId = childId,
                    //}); 
                }
            }
            //var uniqueTagChildren = xtagChilren.Distinct(new TagChildEqualityComparer());
            //var duplciateTagCHildren = xtagChilren.Except(uniqueTagChildren);
            entityTypeBuilder.HasData(tagChildren);
        }
    }

    //public class TagChildEqualityComparer : IEqualityComparer<TagChild>
    //{
    //    public bool Equals(TagChild x, TagChild y)
    //    {
    //        if (x == null || y == null)
    //            return false;

    //        return x.ParentId == y.ParentId && x.ChildId == y.ChildId;
    //    }

    //    public int GetHashCode(TagChild obj)
    //    {
    //        return HashCode.Combine(obj.ParentId, obj.ChildId);
    //    }
    //}
}
