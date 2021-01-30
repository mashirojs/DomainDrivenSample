using System;

namespace Domain.Models.Circles
{
    public class CircleFullException : Exception
    {
        public CircleFullException(string message): base(message) {}
    }
}