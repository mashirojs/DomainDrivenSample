using System;

namespace Application.Circles.Exceptions
{
    public class CircleNotFoundException : Exception
    {
        public CircleNotFoundException(string message): base(message) { }
    }
}