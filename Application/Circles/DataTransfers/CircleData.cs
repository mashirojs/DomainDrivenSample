using System.Collections.Generic;

namespace Application.Circles.DataTransfers
{
    public class CircleData
    {
        public string Id { get; }
        public string Name { get; }
        public string Owner { get; }
        public IList<string> Members { get; }

        public CircleData(string id, string name, string owner, IList<string> members)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }
    }
}