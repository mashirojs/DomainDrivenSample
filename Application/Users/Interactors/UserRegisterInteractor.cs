using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Users.Commands;
using Application.Users.DataTransfers;
using Application.Users.Exceptions;
using Domain.Models.Users;
using Domain.Services;
using MediatR;

namespace Application.Users.Interactors
{
    public class UserRegisterInteractor : IRequestHandler<UserRegisterCommand, UserRegisterOutputData>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private readonly UserService _userService;

        public UserRegisterInteractor(IUserRepository userRepository, IUserFactory userFactory, UserService userService)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _userService = userService;
        }

        public Task<UserRegisterOutputData> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var user = _userFactory.Create(command.Name);

            if (_userService.Exists(user))
            {
                throw new CanNotUserRegisterException($"名前が { user.Name.Value } のユーザーは既に存在します。");
            }

            _userRepository.Save(user);

            transaction.Complete();

            return Task.FromResult(new UserRegisterOutputData(user.Id.Value));
        }
    }
}