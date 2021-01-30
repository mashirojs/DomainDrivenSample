using System.Threading;
using System.Threading.Tasks;
using Application.Users.Commands;
using Application.Users.DataTransfers;
using Application.Users.Exceptions;
using Domain.Models.Users;
using MediatR;

namespace Application.Users.Interactors
{
    public class UserGetInteractor : IRequestHandler<UserGetCommand, UserGetOutputData>
    {
        private readonly IUserRepository _userRepository;

        public UserGetInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserGetOutputData> Handle(UserGetCommand command, CancellationToken cancellationToken)
        {
            var result = _userRepository.Find(new UserId(command.Id));
            if (result is null)
            {
                throw new UserNotFoundException($"IDが { command.Id } のユーザーが見つかりませんでした。");
            }

            var user = new UserData(result.Id.Value, result.Name.Value);
            return Task.FromResult(new UserGetOutputData(user));
        }
    }
}