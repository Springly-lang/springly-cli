using System;

namespace TestScriptRunner.Driver
{
    public class ExpectationNotSatisfiedException : Exception
    {
        public ExpectationNotSatisfiedException() : base()
        {
        }

        public ExpectationNotSatisfiedException(string message) : base(message)
        {
        }

        public ExpectationNotSatisfiedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
