using Application.Users.DataTransfers;
using MediatR;

namespace Application.Users.Commands
{
    public class UserGetListCommand : IRequest<UserGetListOutputData>
    {
        public UserGetListCommand(int page, int displayCount, string search)
        {
            Page = page;
            DisplayCount = displayCount;
            Search = search ?? "";
        }

        public int Page { get; }
        public int DisplayCount { get; }
        public string Search { get; }
    }
}