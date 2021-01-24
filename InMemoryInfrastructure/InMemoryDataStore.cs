using System.Collections.Generic;
using InMemoryInfrastructure.Repositories;

namespace InMemoryInfrastructure
{
    public class InMemoryDataStore
    {
        internal readonly IList<UserData> Users = new List<UserData>
        {
            new UserData {Id = "25d7cea7-7913-45df-9cf8-8743bc593c1d", Name = "大谷翔平"},
            new UserData {Id = "a84be288-a7f3-47c8-8f09-b9b34f3f0727", Name = "ダルビッシュ有"},
            new UserData {Id = "5c3a8b20-1514-4f0b-aaae-b65b5a1a8ced", Name = "田中将大"},
        };
    }
}