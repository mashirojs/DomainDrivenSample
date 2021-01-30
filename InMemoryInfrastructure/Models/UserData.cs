using System.Collections.Generic;

namespace InMemoryInfrastructure.Models
{
    internal class UserData
    {
        public string Id { get; set; }
        public IList<string> CircleIds { get; set; }
        public string Name { get; set; }
    }
}