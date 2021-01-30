using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Circles.Commands;
using Application.Circles.DataTransfers;
using Domain.Models.Circles;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleGetListInteractor : IRequestHandler<CircleGetListCommand, CircleGetListOutputData>
    {
        private readonly ICircleRepository _circleRepository;

        public CircleGetListInteractor(ICircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        public Task<CircleGetListOutputData> Handle(CircleGetListCommand command, CancellationToken cancellationToken)
        {
            var circles = _circleRepository
                .FindAll()
                .Select(x => new CircleData(x.Id.Value, x.Name.Value, x.Owner.Value, x.Members.Select(y => y.Value).ToList()))
                .ToList();
            return Task.FromResult(new CircleGetListOutputData(circles));
        }
    }
}