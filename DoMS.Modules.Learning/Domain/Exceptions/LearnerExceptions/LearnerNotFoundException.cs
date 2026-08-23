using DoMS.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Exceptions.LearnerExceptions
{
    public class LearnerNotFoundException : CustomException
    {
        public LearnerNotFoundException(Guid learnerID) : base ($"Learner with ID ({learnerID}) not found.", statusCode : 404)
        {
            
        }
    }
}
