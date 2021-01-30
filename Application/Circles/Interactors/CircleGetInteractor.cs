using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Circles.Commands;
using Application.Circles.DataTransfers;
using Application.Circles.Exceptions;
using Domain.Models.Circles;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleGetInteractor : IRequestHandler<CircleGetCommand, CircleGetOutputData>
    {
        private readonly ICircleRepository _circleRepository;

        public CircleGetInteractor(ICircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        public Task<CircleGetOutputData> Handle(CircleGetCommand command, CancellationToken cancellationToken)
        {
            var data = _circleRepository.Find(new CircleId(command.Id));
            if (data is null)
            {
                throw new CircleNotFoundException($"IDが { command.Id } のサークルが見つかりませんでした");
            }

            var circle = new CircleData(data.Id.Value, data.Name.Value, data.Owner.Value, data.Members.Select(x => x.Value).ToList());
            return Task.FromResult(new CircleGetOutputData(circle));
        }
    }
}