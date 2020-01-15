using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Exceptions
{
    public class EmptyOrNullException : Exception
    {
        public EmptyOrNullException()
        {

        }
        public EmptyOrNullException(string message) : base(message)
        {

        }
    }
}
