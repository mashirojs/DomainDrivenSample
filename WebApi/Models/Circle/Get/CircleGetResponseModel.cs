using Application.Circles.DataTransfers;

namespace WebApi.Models.Circle.Get
{
    public class CircleGetResponseModel
    {
        public CircleGetResponseModel(CircleData circle)
        {
            Circle = circle;
        }

        public CircleData Circle { get; }
    }
}