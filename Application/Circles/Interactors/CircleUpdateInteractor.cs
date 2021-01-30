using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Circles.Commands;
using Application.Circles.Exceptions;
using Domain.Models.Circles;
using Domain.Services;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleUpdateInteractor : IRequestHandler<CircleUpdateCommand>
    {
        private readonly ICircleRepository _circleRepository;
        private readonly CircleService _circleService;

        public CircleUpdateInteractor(ICircleRepository circleRepository, CircleService circleService)
        {
            _circleRepository = circleRepository;
            _circleService = circleService;
        }

        public Task<Unit> Handle(CircleUpdateCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var circle = _circleRepository.Find(new CircleId(command.Id));

            if (command.Name != null)
            {
                circle.ChangeName(new CircleName(command.Name));
                if (_circleService.Exists(circle))
                {
                    throw new CanNotCircleRegisterException($"{ command.Name } は既に存在します。");
                }
            }

            _circleRepository.Save(circle);

            transaction.Complete();

            return Task.FromResult(Unit.Value);
        }
    }
}