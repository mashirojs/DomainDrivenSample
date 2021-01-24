using System.Collections.Generic;
using Domain.Shared;

namespace Domain.Models.Users
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        IEnumerable<User> Find(IListSpecification<User> specification);
        IEnumerable<User> FindAll();
        void Save(User user);
        void Delete(User user);
    }
}