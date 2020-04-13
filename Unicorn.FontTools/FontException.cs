using System;

namespace Unicorn.FontTools
{
    public class FontException : Exception
    {
        public FontException()
        {
        }

        public FontException(string message) : base(message)
        {
        }

        public FontException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
