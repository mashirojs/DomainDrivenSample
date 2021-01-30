using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Users;

namespace Domain.Models.Circles
{
    public class Circle
    {
        public CircleId Id { get; }

        public CircleName Name { get; private set; }

        public UserId Owner { get; }

        public IList<UserId> Members { get; }

        public Circle(CircleId id, CircleName name, UserId owner, IList<UserId> members)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }

        public void ChangeName(CircleName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Join(User member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (_GetMembers().Any(x => x.Equals(member.Id)))
            {
                throw new CircleAlreadyMemberJoinException($"{member.Id.Value} は既に {Name.Value} に参加しています。");
            }

            if (_CountMember() > 20)
            {
                throw new CircleFullException("サークルのメンバーが上限に達しています。");
            }

            Members.Add(member.Id);
        }

        private IList<UserId> _GetMembers()
        {
            var users = new List<UserId> {Owner};
            users.AddRange(Members);
            return users;
        }

        private int _CountMember()
        {
            return _GetMembers().Count;
        }
    }
}