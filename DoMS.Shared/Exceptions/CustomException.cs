using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Shared.Exceptions
{
    public abstract class CustomException : Exception
    {
        public int StatusCode { get;}

        protected CustomException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
