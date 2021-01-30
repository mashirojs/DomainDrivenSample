using System.Collections.Generic;
using System.Linq;
using InMemoryInfrastructure.Models;

namespace InMemoryInfrastructure
{
    public class InMemoryDataStore
    {
        internal readonly IList<UserData> Users = new List<UserData>
        {
            // プロ野球サークルのメンバー
            new UserData {Id = "25d7cea7-7913-45df-9cf8-8743bc593c1d", CircleIds = new List<string>{ "b3b7b65f-1da9-4c16-9b4f-4ee40e7a7ab0" }, Name = "大谷翔平"},
            new UserData {Id = "a84be288-a7f3-47c8-8f09-b9b34f3f0727", CircleIds = new List<string>{ "b3b7b65f-1da9-4c16-9b4f-4ee40e7a7ab0" }, Name = "ダルビッシュ有"},
            new UserData {Id = "5c3a8b20-1514-4f0b-aaae-b65b5a1a8ced", CircleIds = new List<string>{ "b3b7b65f-1da9-4c16-9b4f-4ee40e7a7ab0" }, Name = "田中将大"},
            new UserData {Id = "97e4e536-4e7d-40c0-9c04-3d3e94aa9e91", CircleIds = new List<string>{ "cb799829-fc7c-42ed-99ea-ae6a5696062e" }, Name = "ゲスト"},
        };

        internal readonly IList<CircleData> Circles = new List<CircleData>
        {
            new CircleData
            {
                Id = "b3b7b65f-1da9-4c16-9b4f-4ee40e7a7ab0",
                OwnerId = "a84be288-a7f3-47c8-8f09-b9b34f3f0727",
                Name = "プロ野球サークル",
                MemberIds = new List<string>
                {
                    "25d7cea7-7913-45df-9cf8-8743bc593c1d",
                    "a84be288-a7f3-47c8-8f09-b9b34f3f0727",
                    "5c3a8b20-1514-4f0b-aaae-b65b5a1a8ced"
                }
            },
            new CircleData
            {
                Id = "cb799829-fc7c-42ed-99ea-ae6a5696062e",
                OwnerId = "97e4e536-4e7d-40c0-9c04-3d3e94aa9e91",
                Name = "デフォ空サークル",
                MemberIds = new List<string>
                {
                    "97e4e536-4e7d-40c0-9c04-3d3e94aa9e91"
                }
            }
        };
    }
}