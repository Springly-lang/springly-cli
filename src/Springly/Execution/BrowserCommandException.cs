using System;
using System.Runtime.Serialization;

namespace Springly
{
    public class BrowserCommandException : Exception
    {
        public BrowserCommandException() : base()
        {
        }

        protected BrowserCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BrowserCommandException(string message) : base(message)
        {
        }

        public BrowserCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
