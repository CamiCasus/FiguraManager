namespace Infrastructure.Data.Core.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
