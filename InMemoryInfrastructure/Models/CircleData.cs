using System.Collections.Generic;

namespace InMemoryInfrastructure.Models
{
    internal class CircleData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public IList<string> MemberIds { get; set; }
    }
}