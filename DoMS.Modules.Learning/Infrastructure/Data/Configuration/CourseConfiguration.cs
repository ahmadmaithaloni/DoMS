using DoMS.Shared.Data.Configuration;
using DoMS.Modules.Learning.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace DoMS.Modules.Learning.Infrastructure.Data.Configuration;

public class CourseConfiguration : BaseEntityConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);
        builder.HasKey(p => p.CourseID);
        builder.Property(p => p.CourseName).HasMaxLength(250).IsRequired();
        builder.Property(p => p.CourseDescription).HasMaxLength(5000).IsRequired();
        builder.Property(p => p.CourseNotes).HasMaxLength(700).IsRequired(false);
    }
    
}
