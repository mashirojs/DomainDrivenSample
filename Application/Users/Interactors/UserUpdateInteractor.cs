using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Users.Commands;
using Application.Users.Exceptions;
using Domain.Models.Users;
using Domain.Services;
using MediatR;

namespace Application.Users.Interactors
{
    public class UserUpdateInteractor : IRequestHandler<UserUpdateCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserUpdateInteractor(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public Task<Unit> Handle(UserUpdateCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var user = _userRepository.Find(new UserId(command.Id));

            if (user is null)
            {
                throw new UserNotFoundException($"IDが { command.Id } のユーザーが見つかりませんでした。");
            }

            user.ChangeName(new UserName(command.Name));

            if (_userService.Exists(user))
            {
                throw new CanNotUserRegisterException($"名前が { user.Name.Value } のユーザーは既に存在します。");
            }

            _userRepository.Save(user);

            transaction.Complete();

            return Task.FromResult(Unit.Value);
        }
    }
}