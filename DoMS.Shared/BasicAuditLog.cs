using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DoMS.Shared;

public class BasicAuditLog
{
    public Guid AuditID { get; init; }
    public DateTime CreatedAt { get; init; }
    public string UserID { get; init; } = string.Empty;
    public string AuditDescription { get; init; } = string.Empty;
    public string? LogNotes { get; init; }
}
