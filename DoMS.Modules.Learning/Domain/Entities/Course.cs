using System.Collections;
namespace DoMS.Modules.Learning.Domain.Entities;

public class Course : DoMS.Shared.InheritableEntity
{
    public Guid CourseID { get; init; }
    public string CourseName { get; init; } = string.Empty;
    public string CourseDescription { get; init; } = string.Empty;
    public string? CourseNotes { get; init; }

    // navigation properties 
    private readonly List<CourseAssignment> _courseAssignments = new(); //basic assignments readonly list declaration
    public IReadOnlyCollection<CourseAssignment> CourseAssignments => _courseAssignments; // the readonly catalog for assignments
    public void AddAssignment(CourseAssignment assignment) // official way to fill the collection
    {
        ArgumentNullException.ThrowIfNull(assignment);
        _courseAssignments.Add(assignment);
    }
}
