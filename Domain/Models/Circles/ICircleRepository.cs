using System.Collections.Generic;
using Domain.Shared;

namespace Domain.Models.Circles
{
    public interface ICircleRepository
    {
        Circle Find(CircleId id);
        Circle Find(CircleName name);
        IEnumerable<Circle> FindAll();
        IEnumerable<Circle> Find(IListSpecification<Circle> specification);
        void Save(Circle circle);
        void Delete(Circle circle);
    }
}