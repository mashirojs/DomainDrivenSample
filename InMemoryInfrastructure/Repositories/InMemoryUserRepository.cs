using System.Collections.Generic;
using System.Linq;
using Domain.Models.Users;
using Domain.Shared;

namespace InMemoryInfrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly InMemoryDataStore _inMemoryDataStore;

        public InMemoryUserRepository(InMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }

        public User Find(UserId id)
        {
            var result = _inMemoryDataStore.Users.SingleOrDefault(x => x.Id == id.Value);
            return result is null ? null : ToModel(result);
        }

        public User Find(UserName name)
        {
            var result = _inMemoryDataStore.Users.SingleOrDefault(x => x.Name == name.Value);
            return result is null ? null : ToModel(result);
        }

        public IEnumerable<User> Find(IListSpecification<User> specification)
        {
            return FindAll().Where(specification.Satisfy);
        }

        public IEnumerable<User> FindAll()
        {
            return _inMemoryDataStore.Users.Select(ToModel);
        }

        public void Save(User user)
        {
            var target = _inMemoryDataStore.Users.SingleOrDefault(x => x.Id == user.Id.Value);
            if (target is null)
            {
                _inMemoryDataStore.Users.Add(new UserData{ Id = user.Id.Value, Name = user.Name.Value});
            }
            else
            {
                target.Name = user.Name.Value;
            }
        }

        public void Delete(User user)
        {
            var target = _inMemoryDataStore.Users.SingleOrDefault(x => x.Id == user.Id.Value);
            if (target is null)
            {
                return;
            }
            _inMemoryDataStore.Users.Remove(target);
        }

        private User ToModel(UserData user)
        {
            return new User(new UserId(user.Id), new UserName(user.Name));
        }
    }

    internal class UserData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}