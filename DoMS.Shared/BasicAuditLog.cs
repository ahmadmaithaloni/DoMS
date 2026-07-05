using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DoMS.Shared;

public class BasicAuditLog
{
    public Guid AuditID { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserID { get; set; } = string.Empty;
    public string AuditDescription { get; set; } = string.Empty;
    public string? LogNotes { get; set; }
}
