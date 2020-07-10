using System;
using System.Runtime.Serialization;

namespace Springly
{
    public class AssertionFailedException : Exception
    {
        public AssertionFailedException() : base()
        {
        }

        public AssertionFailedException(string message) : base(message)
        {
        }

        public AssertionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
