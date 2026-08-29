using DoMS.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Exceptions.CourseExceptions
{
    public class CourseNotFoundException : CustomException
    {
        public CourseNotFoundException(Guid courseID) : base ($"Course with ID ({courseID}) is not found.", statusCode : 404)
        {
        }
    }
}
