using MediatR;

namespace Application.Users.Commands
{
    public class UserUpdateCommand : IRequest
    {
        public UserUpdateCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}