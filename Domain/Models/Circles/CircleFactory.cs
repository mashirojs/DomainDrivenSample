using System;
using System.Collections.Generic;
using Domain.Models.Users;

namespace Domain.Models.Circles
{
    public class CircleFactory : ICircleFactory
    {
        public Circle Create(string name, string owner)
        {
            return new Circle(
                new CircleId(Guid.NewGuid().ToString()),
                new CircleName(name),
                new UserId(owner),
                new List<UserId>()
            );
        }
    }
}