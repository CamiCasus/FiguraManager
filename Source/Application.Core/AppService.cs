using System;
using Application.Core.Interfaces;
using Infrastructure.Data.Core.UoW;

namespace Application.Core
{
    public class AppService : BaseAppService, ITransactionAppService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public AppService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentException("UnitOfWork");
            
            UnitOfWork = unitOfWork;
        }

        public virtual void BeginTransaction()
        {
            UnitOfWork.BeginTransaction();
        }

        public virtual void Commit()
        {
            UnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
