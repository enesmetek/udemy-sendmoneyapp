using EMK.BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace EMK.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();

        ApplicationUser GetByID(int id);
    }
}
