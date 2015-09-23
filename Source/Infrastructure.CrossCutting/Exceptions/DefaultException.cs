using System;

namespace Infrastructure.CrossCutting.Exceptions
{
    [Serializable]
    public class DefaultException : Exception
    {
        public DefaultException()
            : base()
        {
        }

        public DefaultException(string message)
            : base(message)
        {
        }

        public DefaultException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
