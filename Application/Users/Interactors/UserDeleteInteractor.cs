using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Users.Commands;
using Application.Users.Exceptions;
using Domain.Models.Users;
using MediatR;

namespace Application.Users.Interactors
{
    public class UserDeleteInteractor : IRequestHandler<UserDeleteCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(UserDeleteCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var user = _userRepository.Find(new UserId(command.Id));
            if (user is null)
            {
                throw new UserNotFoundException($"IDが { command.Id } のユーザーが見つかりませんでした。");
            }

            _userRepository.Delete(user);

            transaction.Complete();

            return Task.FromResult(Unit.Value);
        }
    }
}