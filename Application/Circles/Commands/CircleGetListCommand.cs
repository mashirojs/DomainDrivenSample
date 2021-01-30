using Application.Circles.DataTransfers;
using MediatR;

namespace Application.Circles.Commands
{
    public class CircleGetListCommand : IRequest<CircleGetListOutputData>
    {
    }
}