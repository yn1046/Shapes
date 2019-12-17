using System;

namespace Shapes.Exceptions
{
    public class InvalidSideException : Exception
    {
        public InvalidSideException(string message = "Side must be greater than 0") : base(message)
        {
            
        }
    }
}