using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Interfaces;
using EMK.BankApp.Web.Data.Repository;

namespace EMK.BankApp.Web.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _context;

        public UnitOfWork(BankContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
