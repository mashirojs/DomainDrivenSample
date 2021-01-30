using System;

namespace Domain.Models.Circles
{
    public class CircleAlreadyMemberJoinException : Exception
    {
        public CircleAlreadyMemberJoinException(string message): base(message) { }
    }
}