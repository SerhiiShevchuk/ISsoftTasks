using System;

namespace Task_NET01_2.Exceptions
{
    class InvalidMatrixException : Exception
    {
        public InvalidMatrixException(string message)
            : base(message)
        { }
    }
}
