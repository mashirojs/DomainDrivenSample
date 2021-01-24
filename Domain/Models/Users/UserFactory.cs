using System;

namespace Domain.Models.Users
{
    public class UserFactory : IUserFactory
    {
        public User Create(string name)
        {
            var userId = new UserId(Guid.NewGuid().ToString());
            var userName = new UserName(name);
            return new User(userId, userName);
        }
    }
}