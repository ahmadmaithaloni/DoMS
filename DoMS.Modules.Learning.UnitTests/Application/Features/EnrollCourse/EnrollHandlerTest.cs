using System;
using System.Collections.Generic;
using System.Text;
using DoMS.Modules.Learning.Application.Features.EnrollCourse;
using DoMS.Modules.Learning.Domain.Contracts.repositories.Course;
using DoMS.Modules.Learning.Domain.Contracts.repositories.Learner;
using DoMS.Modules.Learning.Domain.Contracts.UnitOfWork;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Domain.Exceptions.AssignmentExceptions;
using DoMS.Modules.Learning.Domain.Exceptions.CourseExceptions;
using DoMS.Modules.Learning.Domain.Exceptions.LearnerExceptions;
using NSubstitute;
namespace DoMS.Modules.Learning.UnitTests.Application.Features.EnrollCourse
{
    public class EnrollHandlerTest
    {
        // fetch all dependencies that need to be mocked:
        private readonly ILearnerRepository _learnerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EnrollHandler _handler;

        public EnrollHandlerTest()
        {
            _learnerRepository = Substitute.For<ILearnerRepository>();
            _courseRepository = Substitute.For<ICourseRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new EnrollHandler(_unitOfWork, _learnerRepository, _courseRepository); // create mocked handler
        }

        // 4 tests: happy path, one parameter not correct, and repeated input:

        // happy path:
        [Fact]
        public async Task Handle_LearnerAndCourseAvailable_ShouldReturnPositive()
        {
            // arrange:
            // create the mocked command values:
            var learnerID = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var courseID = Guid.Parse("22222222-2222-2222-2222-222222222222");
            // store the values into the mocked db context objects:
            var learnerDummy = new Learner();
            var courseDummy = new Course();
            _learnerRepository.GetByIDAsync(learnerID, Arg.Any<CancellationToken>()).Returns(learnerDummy);
            _courseRepository.GetByIDAsync(courseID, Arg.Any<CancellationToken>()).Returns(courseDummy);
            // mock the command:
            var enrollCommandMock = new EnrollCommand(learnerID, courseID);
            
            // act:
            var result = await _handler.Handle(enrollCommandMock, CancellationToken.None);

            // assert:
            // check if the result returned or not:
            Assert.NotNull(result);
            // check if the uow called the save changes method:
            await _unitOfWork.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        // learner not exist:
        [Fact]
        public async Task Handle_LearnerNotAvailable_ShouldReturnLearnerNotFoundException()
        {
            // arrange:
            // input inside the mocked repo without learner id:
            var learnerID = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var courseID = Guid.Parse("22222222-2222-2222-2222-222222222222");
            //store in the mocked repo:
            var course = new Course();
            _courseRepository.GetByIDAsync(courseID, Arg.Any<CancellationToken>()).Returns(course);
            // mockedCommand:
            var enrollCommandMock = new EnrollCommand(learnerID,courseID);

            // act + assert:
            //check if the handler returns the exception:
            await Assert.ThrowsAsync<LearnerNotFoundException>(() => _handler.Handle(enrollCommandMock, Arg.Any<CancellationToken>()));
            await _unitOfWork.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        // course not found:
        [Fact]
        public async Task Handle_CourseNotFound_ShouldReturnCourseNotFoundException()
        {
            // arrange:
            var learnerID = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var courseID = Guid.Parse("22222222-2222-2222-2222-222222222222");
            //store in the mocked repo:
            var learner = new Learner();
            _learnerRepository.GetByIDAsync(learnerID, Arg.Any<CancellationToken>()).Returns(learner);
            // mockedCommand:
            var enrollCommandMock = new EnrollCommand(learnerID, courseID);

            // act + assert:
            //check if the handler returns the exception:
            await Assert.ThrowsAsync<CourseNotFoundException>(() => _handler.Handle(enrollCommandMock, CancellationToken.None));
            await _unitOfWork.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        // duplicated assignment:
        [Fact]
        public async Task Handle_DuplicatedCourseAssignment_ShouldReturnDuplicatedAssignmentException()
        {
            // arrange:
            var learnerID = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var courseID = Guid.Parse("22222222-2222-2222-2222-222222222222");
            // store values:
            var learner = new Learner();
            var course = new Course();
            _learnerRepository.GetByIDAsync(learnerID, Arg.Any<CancellationToken>()).Returns(learner);
            _courseRepository.GetByIDAsync(courseID, Arg.Any<CancellationToken>()).Returns(course);
            learner.AddCourseAssignment(new CourseAssignment(learnerID, courseID, "New Note"));
            // create the command:
            var enrollCommandMock = new EnrollCommand(learnerID, courseID);

            // act + assert:
            await Assert.ThrowsAsync<DuplicatedAssignmentException>(() => _handler.Handle(enrollCommandMock, CancellationToken.None));
            await _unitOfWork.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}
