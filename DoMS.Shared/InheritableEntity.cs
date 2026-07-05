using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DoMS.Shared;

public class InheritableEntity
{
    public DateTime CreatedAt { get; set; }
    public string CreadtedBy { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
