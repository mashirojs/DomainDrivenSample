using Application.Users.DataTransfers;
using MediatR;

namespace Application.Users.Commands
{
    public class UserGetListCommand : IRequest<UserGetListOutputData>
    {
    }
}