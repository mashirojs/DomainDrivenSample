using System;

namespace Application.Users.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message): base(message) {}
    }
}