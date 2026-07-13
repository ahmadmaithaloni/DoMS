using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DoMS.Shared;

public class InheritableEntity
{
    public DateTime CreatedAt { get; init; }
    public string CreadtedBy { get; init; } = string.Empty;
    public DateTime? UpdatedAt { get; init; }
    public string? UpdatedBy { get; init; }
}
