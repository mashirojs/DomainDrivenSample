using System;

namespace Domain.Models.Users
{
    public class User
    {
        public User(UserId id, UserName name)
        {
            Id = id;
            Name = name;
        }
        public UserId Id { get; }
        public UserName Name { get; private set; }

        public void ChangeName(UserName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}