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
            var users = _userRepository.FindAll()
                .Select(x => new UserData(x.Id.Value, x.Name.Value))
                .ToList();
            return Task.FromResult(new UserGetListOutputData(users));
        }
    }
}