using System;
using System.Collections.Generic;
using System.Text;

namespace Lyra2
{
    /// <summary>
    /// Default Lyra 2.0 Exception Wrapper
    /// </summary>
    class LyraException : Exception
    {
        private ErrorHandler.ErrorLevel level = ErrorHandler.ErrorLevel.Info;

        public LyraException(string message) : base(message) { }

        public LyraException(string message, ErrorHandler.ErrorLevel level)
            : base(message)
        {
            this.level = level;
        }

        public LyraException(string message, Exception innerException) : base(message, innerException) { }

        public LyraException(string message, Exception innerException, ErrorHandler.ErrorLevel level)
            : base(message, innerException)
        {
            this.level = level;
        }

        public ErrorHandler.ErrorLevel Level
        {
            get { return this.level; }
        }
    }
}
