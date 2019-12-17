using System;

namespace Shapes.Exceptions
{
    public class ImpossibleShapeException : Exception
    {
        public ImpossibleShapeException(string message = "Impossible shape") : base(message)
        {
            
        }
    }
}