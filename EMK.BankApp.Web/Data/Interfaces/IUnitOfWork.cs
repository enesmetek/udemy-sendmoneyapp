namespace EMK.BankApp.Web.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();

        void SaveChanges();
    }
}
