using Domain.Models.Circles;

namespace Domain.Services
{
    public class CircleService
    {
        private readonly ICircleRepository _circleRepository;

        public CircleService(ICircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        public bool Exists(Circle circle)
        {
            var duplicated = _circleRepository.Find(circle.Name);
            return duplicated != null;
        }
    }
}