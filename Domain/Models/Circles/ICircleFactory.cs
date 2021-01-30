using Domain.Models.Users;

namespace Domain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(string name, string ownerId);
    }
}