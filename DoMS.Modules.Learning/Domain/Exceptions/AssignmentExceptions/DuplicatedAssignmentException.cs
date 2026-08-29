using DoMS.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Exceptions.AssignmentExceptions
{
    internal class DuplicatedAssignmentException : CustomConflictException
    {
        public Guid LearnerID { get; }
        public Guid CourseID { get; }
        public DuplicatedAssignmentException(Guid learnerID, Guid courseID) : base($"the assignment with LearnerID: ({learnerID}) and CourseID: ({courseID}) is already exists")
        {
            LearnerID = learnerID;
            CourseID = courseID;
        }
    }
}
