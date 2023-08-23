using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EMK.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
