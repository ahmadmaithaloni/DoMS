using DoMS.Modules.Learning.Domain.Exceptions.AssignmentExceptions;

namespace DoMS.Modules.Learning.Domain.Entities;

public class Learner : DoMS.Shared.InheritableEntity
{
    public Guid LearnerID { get; init; }
    public string LearnerName { get; init; } = string.Empty;
    public string LearnerSSN { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public string Email { get; init; } = string.Empty;
    public Guid TenantID { get; init; }

    // navigation properties
    private readonly List<CourseAssignment> _courseAssignments = new();
    public IReadOnlyCollection<CourseAssignment> CourseAssignments => _courseAssignments;
    public void AddCourseAssignment(CourseAssignment assignment)
    {
        ArgumentNullException.ThrowIfNull(assignment);
        if (_courseAssignments.Any(p => p.CourseID == assignment.CourseID))
        {
            throw new DuplicatedAssignmentException(assignment.LearnerID, assignment.CourseID);
        }
        _courseAssignments.Add(assignment);
    }
}
