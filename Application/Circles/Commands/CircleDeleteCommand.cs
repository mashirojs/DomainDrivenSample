using MediatR;

namespace Application.Circles.Commands
{
    public class CircleDeleteCommand : IRequest
    {
        public CircleDeleteCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}