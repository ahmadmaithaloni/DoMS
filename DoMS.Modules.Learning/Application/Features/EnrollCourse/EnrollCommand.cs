using DoMS.Modules.Learning.Domain.Entities;
using MediatR;

namespace DoMS.Modules.Learning.Application.Features.EnrollCourse;

public record EnrollCommand(Guid LearnerID, Guid CourseID) : IRequest<EnrollmentResult>;

public record EnrollmentResult(DateTime AssignmentDate);