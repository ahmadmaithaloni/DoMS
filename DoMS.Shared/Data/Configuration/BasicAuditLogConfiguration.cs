using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace DoMS.Shared.Data.Configuration;

public abstract class BasicAuditLogConfiguration : IEntityTypeConfiguration<BasicAuditLog>
{
    public void Configure(EntityTypeBuilder<BasicAuditLog> builder)
    {
        builder.HasKey(p => p.AuditID);
        builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(p => p.UserID).IsRequired();
        builder.Property(p => p.AuditID).IsRequired();
        builder.Property(p => p.LogNotes).IsRequired(false);
    }
}
