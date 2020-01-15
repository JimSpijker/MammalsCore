using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException()
        {

        }

        public ServerException(string message) : base(message)
        {

        }
    }
}
