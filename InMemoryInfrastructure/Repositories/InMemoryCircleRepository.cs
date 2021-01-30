using System.Collections.Generic;
using System.Linq;
using Domain.Models.Circles;
using Domain.Models.Users;
using Domain.Shared;
using InMemoryInfrastructure.Models;

namespace InMemoryInfrastructure.Repositories
{
    public class InMemoryCircleRepository : ICircleRepository
    {
        private readonly InMemoryDataStore _inMemoryDataStore;

        public InMemoryCircleRepository(InMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }

        public Circle Find(CircleId id)
        {
            var data = _inMemoryDataStore.Circles.SingleOrDefault(x => x.Id == id.Value);
            if (data is null)
            {
                return null;
            }
            var owner = _inMemoryDataStore.Users.SingleOrDefault(x => x.Id == data.OwnerId);
            if (owner is null)
            {
                return null;
            }
            var members = _inMemoryDataStore.Users.Where(x => x.CircleIds.Contains(data.Id)).Select(x => new UserId(x.Id)).ToList();

            return new Circle(new CircleId(data.Id), new CircleName(data.Name), new UserId(data.OwnerId), members);
        }

        public Circle Find(CircleName name)
        {
            var data = _inMemoryDataStore.Circles.SingleOrDefault(x => x.Name == name.Value);
            if (data is null)
            {
                return null;
            }
            var owner = _inMemoryDataStore.Users.SingleOrDefault(x => x.Id == data.OwnerId);
            if (owner is null)
            {
                return null;
            }

            var members = _inMemoryDataStore.Users.Where(x => x.CircleIds.Contains(data.Id)).Select(x => new UserId(x.Id)).ToList();

            return new Circle(new CircleId(data.Id), new CircleName(data.Name), new UserId(data.OwnerId), members);
        }

        public IEnumerable<Circle> FindAll()
        {
            return _inMemoryDataStore.Circles.Select(x =>
                new Circle(
                    new CircleId(x.Id),
                    new CircleName(x.Name),
                    new UserId(x.OwnerId),
                    x.MemberIds.Select(mid => new UserId(mid)).ToList())
            ).ToList();
        }

        public IEnumerable<Circle> Find(IListSpecification<Circle> specification)
        {
            var data = _inMemoryDataStore.Circles.Select(x =>
                new Circle(
                    new CircleId(x.Id),
                    new CircleName(x.Name),
                    new UserId(x.OwnerId),
                    x.MemberIds.Select(mid => new UserId(mid)).ToList())
            );
            return data.Where(specification.Satisfy).ToList();
        }

        public void Save(Circle circle)
        {
            var found = _inMemoryDataStore.Circles.SingleOrDefault(x => x.Id == circle.Id.Value);
            if (found is null)
            {
                _inMemoryDataStore.Circles.Add(
                    new CircleData
                    {
                        Id = circle.Id.Value,
                        Name = circle.Name.Value,
                        OwnerId = circle.Owner.Value,
                        MemberIds = circle.Members.Select(x => x.Value).ToList()
                    });
                foreach (var user in _inMemoryDataStore.Users.Where(x => circle.Members.Select(x => x.Value).Contains(x.Id)))
                {
                    user.CircleIds.Add(circle.Id.Value);
                }
            }
            else
            {
                found.Name = circle.Name.Value;
                found.OwnerId = circle.Owner.Value;
                found.MemberIds = circle.Members.Select(x => x.Value).ToList();
                foreach (var user in _inMemoryDataStore.Users.Where(x => circle.Members.Select(x => x.Value).Contains(x.Id)))
                {
                    user.CircleIds.Add(circle.Id.Value);
                }
            }
        }

        public void Delete(Circle circle)
        {
            var data = _inMemoryDataStore.Circles.SingleOrDefault(x => x.Id == circle.Id.Value);
            if (data is null)
            {
                return;
            }

            var members = _inMemoryDataStore.Users.Where(x => circle.Members.Any(y => y.Value == x.Id));
            foreach (var member in members)
            {
                member.CircleIds.Remove(circle.Id.Value);
            }

            _inMemoryDataStore.Circles.Remove(data);
        }
    }
}