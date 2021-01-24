using Application.Users.DataTransfers;
using MediatR;

namespace Application.Users.Commands
{
    public class UserRegisterCommand : IRequest<UserRegisterOutputData>
    {
        public UserRegisterCommand(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}