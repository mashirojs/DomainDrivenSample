using System.Collections.Generic;

namespace Application.Circles.DataTransfers
{
    public class CircleGetListOutputData
    {
        public IEnumerable<CircleData> Circles { get; }

        public CircleGetListOutputData(IEnumerable<CircleData> circles)
        {
            Circles = circles;
        }
    }
}