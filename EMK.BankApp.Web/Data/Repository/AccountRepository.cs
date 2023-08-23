using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Data.Interfaces;
using EMK.BankApp.Web.Models;

namespace EMK.BankApp.Web.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
