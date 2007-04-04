using System;

namespace Lyra2
{
    /// <summary>
    /// Default Lyra 2.0 Exception Wrapper
    /// </summary>
    public class LyraException : Exception
    {
        private ErrorLevel level = ErrorLevel.Info;

        public LyraException(string message) : base(message) { }

        public LyraException(string message, ErrorLevel level)
            : base(message)
        {
            this.level = level;
        }

        public LyraException(string message, Exception innerException) : base(message, innerException) { }

        public LyraException(string message, Exception innerException, ErrorLevel level)
            : base(message, innerException)
        {
            this.level = level;
        }

        public ErrorLevel Level
        {
            get { return this.level; }
        }
    }

    public enum ErrorLevel
    {
        Debug, Warning, Info, Error, Fatal, Always
    }
}
