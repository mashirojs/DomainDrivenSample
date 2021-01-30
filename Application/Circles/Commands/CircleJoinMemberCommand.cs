using MediatR;

namespace Application.Circles.Commands
{
    public class CircleJoinMemberCommand : IRequest
    {
        public CircleJoinMemberCommand(string circleId, string userId)
        {
            CircleId = circleId;
            UserId = userId;
        }

        public string CircleId { get; }
        public string UserId { get; }
    }
}