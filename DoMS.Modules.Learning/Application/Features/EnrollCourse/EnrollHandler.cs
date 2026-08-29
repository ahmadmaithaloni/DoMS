using DoMS.Modules.Learning.Domain.Contracts.repositories.Course;
using DoMS.Modules.Learning.Domain.Contracts.repositories.Learner;
using DoMS.Modules.Learning.Domain.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Application.Features.EnrollCourse
{
    internal class EnrollHandler
    {
        // should add a specific repository for the Enrolment process
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILearnerRepository _learnerRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollHandler(IUnitOfWork unitOfWork, ILearnerRepository learnerRepository, ICourseRepository courseRepository)
        { 
            _unitOfWork = unitOfWork;
            _learnerRepository = learnerRepository;
            _courseRepository = courseRepository;
        }

        public async Task<EnrollmentResult> Handle(EnrollCommand request, CancellationToken cancellationToken)
        {
            // base: retrieve the repos:
            var learner = await _learnerRepository.GetByIDAsync(request.LearnerID, cancellationToken);
            var course = await _courseRepository.GetByIDAsync(request.CourseID, cancellationToken);
            if (learner is null)
            {
                throw new DoMS.Modules.Learning.Domain.Exceptions.LearnerExceptions.LearnerNotFoundException(request.LearnerID);
            }
            if (course is null)
            {
                throw new DoMS.Modules.Learning.Domain.Exceptions.CourseExceptions.CourseNotFoundException(request.CourseID);
            }
            // 1. Map the enrollment with the Assignment entity:
            var assignment = new DoMS.Modules.Learning.Domain.Entities.CourseAssignment
            {
                LearnerID = request.LearnerID,
                CourseID = request.CourseID,
                Notes = $"This course ({course.CourseName}) assigned to student ({learner.LearnerName}"
            };
            // 2. update the db:
            learner.AddCourseAssignment(assignment); 
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            // 3. return the result:
            
            return new EnrollmentResult(DateTime.UtcNow);
        }
    }
}
