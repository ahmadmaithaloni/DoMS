using DoMS.Modules.Learning.Domain.Entities;

namespace DoMS.Modules.Learning.Domain.Models;

public class CourseAssignment : DoMS.Shared.InheritableEntity
{
    public Guid LearnerID { get; init; }
    public Guid CourseID { get; init; }
    public string? Notes { get; init; }

    // navigation properties
    public virtual Learner Learner { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
    private CourseAssignment()
    {
    }
    public CourseAssignment(Guid CourseID, Guid LearnerID, string Notes)
    {
        this.CourseID = CourseID;
        this.LearnerID = LearnerID;
        this.Notes = Notes;
    }
}
