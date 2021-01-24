using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Users.Commands;
using Application.Users.DataTransfers;
using Domain.Models.Users;
using MediatR;

namespace Application.Users.Interactors
{
    public class UserGetListInteractor : IRequestHandler<UserGetListCommand, UserGetListOutputData>
    {
        private readonly IUserRepository _userRepository;

        public UserGetListInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserGetListOutputData> Handle(UserGetListCommand command, CancellationToken cancellationToken)
        {
            var result = _userRepository.Find(new UserListSpecification(command.Search))
                .Skip((command.Page - 1) * command.DisplayCount)
                .Take(command.DisplayCount)
                .ToList();
            var users = result.Select(x => new UserData(x.Id.Value, x.Name.Value));
            return Task.FromResult(new UserGetListOutputData(users));
        }
    }
}