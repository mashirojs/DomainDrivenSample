using System.Collections.Generic;

namespace WebApi.Models.Circle.Common
{
    public class CircleResponseModel
    {
        public CircleResponseModel(string id, string name, string owner, IEnumerable<string> members)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }

        public string Id { get; }
        public string Name { get; }
        public string Owner { get; }
        public IEnumerable<string> Members { get; }

    }
}