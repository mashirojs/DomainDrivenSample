using Application.Circles.DataTransfers;
using MediatR;

namespace Application.Circles.Commands
{
    public class CircleRegisterCommand : IRequest<CircleRegisterOutputData>
    {
        public CircleRegisterCommand(string name, string ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }

        public string Name { get; }
        public string OwnerId { get; }

    }
}