using System;

namespace Application.Circles.Exceptions
{
    public class CanNotCircleRegisterException : Exception
    {
        public CanNotCircleRegisterException(string message): base(message) {}
    }
}