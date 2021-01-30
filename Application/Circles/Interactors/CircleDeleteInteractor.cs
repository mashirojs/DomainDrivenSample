using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Circles.Commands;
using Domain.Models.Circles;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleDeleteInteractor : IRequestHandler<CircleDeleteCommand>
    {
        private readonly ICircleRepository _circleRepository;

        public CircleDeleteInteractor(ICircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        public Task<Unit> Handle(CircleDeleteCommand request, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var circle = _circleRepository.Find(new CircleId(request.UserId));
            if (circle != null)
            {
                _circleRepository.Delete(circle);
            }

            transaction.Complete();

            return Task.FromResult(Unit.Value);
        }
    }
}