using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace DoMS.Modules.Learning.Application.Features.EnrollCourse
{
    internal class EnrollValidation : AbstractValidator<EnrollCommand>
    {
        public EnrollValidation()
        {
            RuleFor(p => p.CourseID).NotEmpty().WithMessage("The Course ID is empty!");
            RuleFor(p => p.LearnerID).NotEmpty().WithMessage("the Learner ID is empty!");
        }
    }
}
