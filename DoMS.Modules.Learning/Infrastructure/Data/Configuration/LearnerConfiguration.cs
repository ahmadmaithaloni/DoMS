using System.Data;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Shared.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoMS.Modules.Learning.Infrastructure.Data.Configuration;

public class LearnerConfiguration : BaseEntityConfiguration<Learner>
{
    public override void Configure(EntityTypeBuilder<Learner> builder)
    {
        base.Configure(builder);
        builder.HasKey(p => p.LearnerID);
        builder.Property(p => p.LearnerName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LearnerSSN).HasMaxLength(10).IsRequired().IsFixedLength();
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_LEARNER_SSN_Numeric", "\"LearnerSSN\" ~ '[0-9]{10}"
        ));
    }
}