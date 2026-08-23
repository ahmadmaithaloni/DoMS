using DoMS.Shared.Data.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DoMS.Modules.Learning.Domain.Entities;

namespace DoMS.Modules.Learning.Infrastructure.Data.Configuration;

public class CourseAssignmentConfiguration : BaseEntityConfiguration<CourseAssignment>
{
    public override void Configure(EntityTypeBuilder<CourseAssignment> builder)
    {
        base.Configure(builder);
        builder.HasKey(p => new { p.LearnerID, p.CourseID });
        builder.Property(p => p.Notes).HasMaxLength(1000).IsRequired(false);

        // navigation properties
        builder.HasOne(p => p.Learner).WithMany(l => l.CourseAssignments).HasForeignKey(p => p.LearnerID);
        builder.HasOne(p => p.Course).WithMany(c => c.CourseAssignments).HasForeignKey(p => p.CourseID);
    }
}
