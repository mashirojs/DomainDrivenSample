namespace Application.Circles.DataTransfers
{
    public class CircleGetOutputData
    {
        public CircleGetOutputData(CircleData cirlce)
        {
            Cirlce = cirlce;
        }

        public CircleData Cirlce { get; }
    }
}