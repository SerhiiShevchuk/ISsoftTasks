using System;

namespace Task_NET01_2.Exceptions
{
    public class InvalidIndexException : Exception
    {
        public InvalidIndexException(string message)
            : base(message)
        { }
    }
}
