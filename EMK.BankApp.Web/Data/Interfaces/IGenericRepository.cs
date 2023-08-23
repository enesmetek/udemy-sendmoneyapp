using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Create(T entity);

        void Update(T entity);

        void Remove(T entity);

        T GetByID(object id);

        List<T> GetAll();

        IQueryable<T> GetQueryable();
    }
}
