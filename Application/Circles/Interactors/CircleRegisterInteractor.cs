using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Circles.Commands;
using Application.Circles.DataTransfers;
using Application.Circles.Exceptions;
using Application.Users.Exceptions;
using Domain.Models.Circles;
using Domain.Models.Users;
using Domain.Services;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleRegisterInteractor : IRequestHandler<CircleRegisterCommand, CircleRegisterOutputData>
    {
        private readonly ICircleRepository _circleRepository;
        private readonly ICircleFactory _circleFactory;
        private readonly CircleService _circleService;
        private readonly IUserRepository _userRepository;

        public CircleRegisterInteractor(ICircleRepository circleRepository, ICircleFactory circleFactory, CircleService circleService, IUserRepository userRepository)
        {
            _circleRepository = circleRepository;
            _circleFactory = circleFactory;
            _circleService = circleService;
            _userRepository = userRepository;
        }

        public Task<CircleRegisterOutputData> Handle(CircleRegisterCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var circle = _circleFactory.Create(command.Name, command.OwnerId);
            if (_circleService.Exists(circle))
            {
                throw new CanNotCircleRegisterException($"{command.Name} は既に存在します。");
            }

            var owner = _userRepository.Find(circle.Owner);
            if (owner is null)
            {
                throw new UserNotFoundException($"IDが {command.OwnerId} のユーザーは存在しません。");
            }

            _circleRepository.Save(circle);

            transaction.Complete();

            return Task.FromResult(new CircleRegisterOutputData(circle.Id.Value));
        }
    }
}