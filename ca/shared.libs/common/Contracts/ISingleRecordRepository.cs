using System;

namespace GET.PKI.Common.Contracts
{
    public interface ISingleRecordRepository<T> : IDisposable
    {
        T Get();
        bool Create(T item);
        bool Delete();
        bool Update(T item);
    }
}