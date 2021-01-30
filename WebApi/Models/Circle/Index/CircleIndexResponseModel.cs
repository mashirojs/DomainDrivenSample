using System.Collections.Generic;
using WebApi.Models.Circle.Common;

namespace WebApi.Models.Circle.Index
{
    public class CircleIndexResponseModel
    {
        public IEnumerable<CircleResponseModel> Circles { get; }

        public CircleIndexResponseModel(IEnumerable<CircleResponseModel> circles)
        {
            Circles = circles;
        }
    }
}