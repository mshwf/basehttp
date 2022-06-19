using System;
using System.Collections.Generic;

namespace GET.PKI.Common
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IList<T> GetAll();
        void Add(T item);
        bool Delete(Guid id);
        bool Update(T item);
    }
}