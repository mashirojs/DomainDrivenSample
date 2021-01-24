using System;

namespace Application.Users.Exceptions
{
    public class CanNotUserRegisterException : Exception
    {
        public CanNotUserRegisterException(string message): base(message) { }
    }
}