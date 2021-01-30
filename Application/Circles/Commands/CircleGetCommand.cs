using Application.Circles.DataTransfers;
using MediatR;

namespace Application.Circles.Commands
{
    public class CircleGetCommand : IRequest<CircleGetOutputData>
    {
        public CircleGetCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}