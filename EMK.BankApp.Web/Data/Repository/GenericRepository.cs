using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    { 
        private readonly BankContext _context;

        public GenericRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity); 
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T GetByID(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
