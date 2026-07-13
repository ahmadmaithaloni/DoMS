using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace DoMS.Shared.Data.Configuration;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : InheritableEntity// rewrite this code to be for the inhireted entity not for basic audit 
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(p => p.CreadtedBy).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired(false);
        builder.Property(p => p.UpdatedBy).IsRequired(false);
    }
}
