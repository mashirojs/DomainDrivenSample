using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Circles.Commands;
using Application.Circles.Exceptions;
using Application.Users.Exceptions;
using Domain.Models.Circles;
using Domain.Models.Users;
using MediatR;

namespace Application.Circles.Interactors
{
    public class CircleJoinMemberInteractor : IRequestHandler<CircleJoinMemberCommand>
    {
        private readonly ICircleRepository _circleRepository;
        private readonly IUserRepository _userRepository;

        public CircleJoinMemberInteractor(ICircleRepository circleRepository, IUserRepository userRepository)
        {
            _circleRepository = circleRepository;
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(CircleJoinMemberCommand command, CancellationToken cancellationToken)
        {
            using var transaction = new TransactionScope();

            var circle = _circleRepository.Find(new CircleId(command.CircleId));
            if (circle is null)
            {
                throw new CircleNotFoundException("サークルが見つかりませんでした。");
            }

            var user = _userRepository.Find(new UserId(command.UserId));
            if (user is null)
            {
                throw new UserNotFoundException("追加対象のユーザーが見つかりませんでした。");
            }

            circle.Join(user);

            _circleRepository.Save(circle);

            transaction.Complete();

            return Task.FromResult(Unit.Value);
        }
    }
}