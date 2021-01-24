using System.Collections.Generic;

namespace Domain.Shared
{
    public interface IListSpecification<T>
    {
        bool Satisfy(T item);
    }
}