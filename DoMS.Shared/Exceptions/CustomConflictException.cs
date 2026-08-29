using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Shared.Exceptions
{
    public class CustomConflictException : Exception
    {
        public CustomConflictException(string message) : base(message)
        {
            
        }
    }
}
