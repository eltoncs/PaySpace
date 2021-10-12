using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpaceApplication.Exceptions
{
    public class CustomBadRequestException : Exception
    {
        public CustomBadRequestException()
        {
        }

        public CustomBadRequestException(string message)
            : base(message)
        {
        }

        public CustomBadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
