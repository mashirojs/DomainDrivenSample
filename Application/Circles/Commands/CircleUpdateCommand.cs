using MediatR;

namespace Application.Circles.Commands
{
    public class CircleUpdateCommand : IRequest
    {
        public CircleUpdateCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}