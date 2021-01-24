using Application.Users.DataTransfers;
using MediatR;

namespace Application.Users.Commands
{
    public class UserGetCommand : IRequest<UserGetOutputData>
    {
        public UserGetCommand(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }
}