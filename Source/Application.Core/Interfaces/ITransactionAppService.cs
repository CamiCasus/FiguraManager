using System;

namespace Application.Core.Interfaces
{
    public interface ITransactionAppService : IDisposable
    {
        void BeginTransaction();
        void Commit();
    }
}
