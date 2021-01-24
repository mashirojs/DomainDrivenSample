using MediatR;

namespace Application.Users.Commands
{
    public class UserDeleteCommand : IRequest
    {
        public UserDeleteCommand(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }
}